using MAUIAndroidUIAutomationUtility.Helper;
using System.Diagnostics;

namespace MAUIAndroidUIAutomationUtility.AndroidTools
{
    public static class AndroidTool
    {
        public static void InstallApp(string deviceSerial, string appPath)
        {
            try
            {
                if (!Adb.CheckAdbInstalled())
                {
                    throw new Exception("ADB is not installed or not in PATH. Please install ADB and ensure it is in your PATH.");
                }

                if (string.IsNullOrEmpty(deviceSerial))
                {
                    throw new ArgumentNullException(nameof(deviceSerial), "Error: Invalid or missing device serial number.");
                }

                if (string.IsNullOrEmpty(appPath))
                {
                    throw new ArgumentNullException(nameof(appPath), "Error: Invalid or missing application path.");
                }

                // Execute the adb install command
                CommondExcecute.ExecuteCommand($"adb -s {deviceSerial} install \"{appPath}\"");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error installing application: {ex.Message}", ex);
            }
        }
        public static string ListPackages(string deviceSerial)
        {
            try
            {
                if (!Adb.CheckAdbInstalled())
                {
                    throw new Exception("ADB is not installed or not in PATH. Please install ADB and ensure it is in your PATH.");
                }

                if (string.IsNullOrEmpty(deviceSerial))
                {
                    return $"Error: Invalid or missing device serial number.";
                }

                var packages = new List<string>();

                string result = $"adb -s {deviceSerial} shell pm list packages";
                CommondExcecute.ExecuteCommand(result);

                string[] lines = result.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

                foreach (var line in lines)
                {
                    if (line.StartsWith("package:"))
                    {
                        // Remove the "package:" prefix and add the package name to the list
                        string packageName = line.Replace("package:", "").Trim();
                        packages.Add(packageName);
                    }
                }

                if (packages is null || packages.Count == 0)
                {
                    return "No packages found on the device.";
                }

                // Format the result as a table
                var packagesStr = "# Installed Packages\n\n";
                packagesStr += "| Package Name |\n";
                packagesStr += "|--------------|\n";

                foreach (var app in packages)
                {
                    packagesStr += $"| `{app}` |\n";
                }

                return packagesStr;
            }
            catch (Exception ex)
            {
                return $"Error retrieving packages: {ex.Message}";
            }
        }

        public static string ListDevices()
        {
            try
            {
                if (!Adb.CheckAdbInstalled())
                {
                    throw new Exception("ADB is not installed or not in PATH. Please install ADB and ensure it is in your PATH.");
                }

                var devices = new List<AdbDevice>();
                string result = "adb devices -l";
                CommondExcecute.ExecuteCommand(result);

                string[] lines = result.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries);

                // Skip the first line (header)
                for (int i = 1; i < lines.Length; i++)
                {
                    string line = lines[i];

                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        // Parse each line to extract device details
                        string[] parts = line.Split([' '], StringSplitOptions.RemoveEmptyEntries);
                        var device = new AdbDevice
                        {
                            Product = GetPropertyFromParts(parts, "product:"),
                            Model = GetPropertyFromParts(parts, "model:"),
                            Device = GetPropertyFromParts(parts, "device:"),
                            SerialNumber = parts[0], // Assuming the serial number is the first part
                        };
                        devices.Add(device);
                    }
                }

                if (devices is null || devices.Count == 0)
                {
                    return "No devices found.";
                }

                // Format the result as a table
                var devicesStr = "# Devices\n\n";
                devicesStr += "| Serial          | Device           | Product          | Model            |\n";
                devicesStr += "|-----------------|------------------|------------------|------------------|\n";

                foreach (var device in devices)
                {
                    devicesStr += $"| `{device.SerialNumber}` | `{device.Device}` | `{device.Product}` | `{device.Model}` |\n";
                }

                return devicesStr;
            }
            catch (Exception ex)
            {
                return $"Error retrieving device list: {ex.Message}";
            }
        }
        public static void BootDevice(string avdName)
        {
            try
            {
                if (string.IsNullOrEmpty(avdName))
                {
                    throw new ArgumentNullException(nameof(avdName), "Error: Device name is missing or invalid.");
                }
                string emulatorCommand = $"emulator -avd {avdName}";
                Process process = new Process()

                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "/bin/bash",

                        Arguments = $"-c \"{emulatorCommand} &\"", // Run in background

                        RedirectStandardOutput = false,

                        RedirectStandardError = false,

                        UseShellExecute = false,

                        CreateNoWindow = true,
                    }
                };
                process.Start();
                WaitForEmulatorToBoot();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error booting the device: {ex.Message}");
            }
        }

        public static void ShutdownDevice(string avdName)
        {
            try
            {
                if (!Adb.CheckAdbInstalled())
                {
                    throw new Exception("ADB is not installed or not in PATH. Please install ADB and ensure it is in your PATH.");
                }

                if (string.IsNullOrEmpty(avdName))
                {
                    throw new ArgumentNullException(nameof(avdName), "Error: Device name is missing or invalid.");
                }

                // Kill all running emulator instances

                CommondExcecute.ExecuteCommand($"adb -s {avdName} emu kill");

                Console.WriteLine(avdName + " emulator instances have been shut down.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error shutting down the device:" + avdName + " {ex.Message}");
            }
        }

        public static void ShutdownDeviceCompletely(string avdName)
        {
            try
            {
                if (!Adb.CheckAdbInstalled())
                {
                    throw new Exception("ADB is not installed or not in PATH. Please install ADB and ensure it is in your PATH.");
                }

                if (string.IsNullOrEmpty(avdName))
                {
                    throw new ArgumentNullException(nameof(avdName), "Error: Device name is missing or invalid.");
                }

                // Kill all running emulator instances

                CommondExcecute.ExecuteCommand($"adb -s {avdName} emu kill");
                CommondExcecute.ExecuteCommand($"adb emu kill");
                CommondExcecute.ExecuteCommand("adb kill-server");


                Console.WriteLine("All emulator instances have been shut down.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error shutting down the device: {ex.Message}");
            }
        }

        private static string GetPropertyFromParts(string[] parts, string propertyKey)
        {
            foreach (var part in parts)
            {
                if (part.StartsWith(propertyKey, StringComparison.OrdinalIgnoreCase))
                {
                    return part.Substring(propertyKey.Length);
                }
            }

            return string.Empty;
        }
        static void WaitForEmulatorToBoot()
        {
            Console.WriteLine("Waiting for emulator to boot...");
            while (true)
            {
                Process process = new Process()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "/bin/bash",

                        Arguments = "-c \"adb shell getprop sys.boot_completed\"",

                        RedirectStandardOutput = true,

                        UseShellExecute = false,

                        CreateNoWindow = true,

                    }
                };
                process.Start();
                string output = process.StandardOutput.ReadToEnd().Trim();
                process.WaitForExit();
                if (output == "1") break;
                Thread.Sleep(5000); // Wait for 5 seconds before checking again
            }

            Console.WriteLine("Emulator booted successfully!");

        }
        public static void HandleAndroidLaunch(string avdName)
        {
            string deviceId = GetAndroidDeviceId(avdName);

            if (!string.IsNullOrEmpty(deviceId) && IsAndroidDeviceBooted(deviceId))
            {
                Console.WriteLine("✅ Android emulator already running and booted.");
            }
            else
            {
                Console.WriteLine("🚀 Launching Android emulator...");
                RunCommand($"emulator -avd {avdName}", true);
                Thread.Sleep(5000);
                WaitForAndroidBoot(avdName);
            }
        }

        public static void WaitForAndroidBoot(string deviceName)
        {
            Console.WriteLine("⏳ Checking Android boot status...");
            string deviceId = GetAndroidDeviceId(deviceName);

            if (IsAndroidDeviceBooted(deviceId))
            {
                Console.WriteLine("✅ Android emulator is already booted.");
                return;
            }

            Console.WriteLine("⌛ Waiting for Android emulator to fully boot...");
            while (!IsAndroidDeviceBooted(deviceId))
            {
                Thread.Sleep(5000);
            }

            Console.WriteLine("✅ Android emulator is ready!");
        }


        public static string GetAndroidDeviceId(string avdName)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb",
                    Arguments = "devices",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // Assumes only one emulator running, otherwise you'll need better mapping
            foreach (var line in output.Split('\n'))
            {
                if (line.Contains("emulator-"))
                {
                    return line.Split('\t')[0];
                }
            }
            return string.Empty;
        }

        static bool IsAndroidDeviceBooted(string deviceId)
        {
            if (string.IsNullOrEmpty(deviceId)) return false;

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "adb",
                    Arguments = $"-s {deviceId} shell getprop sys.boot_completed",
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            string output = process.StandardOutput.ReadToEnd().Trim();
            process.WaitForExit();

            return output == "1";
        }


    }
}


public class AdbDevice
{
    public string SerialNumber { get; set; }
    public string Product { get; set; }
    public string Model { get; set; }
    public string Device { get; set; }
}
