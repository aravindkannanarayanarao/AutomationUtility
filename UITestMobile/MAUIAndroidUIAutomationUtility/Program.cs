
using MAUIAndroidUIAutomationUtility.Helper;
using MAUIAndroidUIAutomationUtility.AndroidTools;
using MAUIAndroidUIAutomationUtility.iOSTools;


namespace MAUIAndroidUIAutomationUtility;
class Program
{
    static void Main()
    {
        string documentFolder= "/Users/mauitesting/Documents";
        // Appium 1
        List<Dictionary<string, string>> projects = new List<Dictionary<string, string>>
        {

        //Android platform

			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerDayView" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerEvents" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerHeaderView" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfschedulerRecurrenceRule" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerShowAllowedViews" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerSpecialTimeRegion" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerTimelineView" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerTimeslot" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
			new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfShedulerMonthView" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
        //iOS platform

        
        //MacCatalyst platform

        //new Dictionary<string, string> { { "ProjectName", "maui-chat-tests" }, { "SampleName", "SfChatSample" }, { "ApplicationID", "com.companyname.sfchatsample" }, { "Platform", "UITests.macOS" }, { "EmulatorCommand", "A345178C-6D96-4B7E-83BD-266E3B81B0F7" } }
        //new Dictionary<string, string> { { "ProjectName", "BusyIndicator-MAUI-tests" }, { "SampleName", "SfBusyIndicatorSample" }, { "ApplicationID", "com.companyname.SfBusyIndicatorSample" }, { "Platform", "UITests.macOS" }, { "EmulatorCommand", "A345178C-6D96-4B7E-83BD-266E3B81B0F7" } },
        };

        foreach (var project in projects)
        {
            Console.WriteLine($"Running UI tests for {project["ProjectName"]}...");
            RunUITests(project, documentFolder);
        }

    }
    static void RunUITests(Dictionary<string, string> project, string documentFolder)
    {
        if (project["Platform"] == "UITests.Android")
        {

            string emulator = $"{project["EmulatorCommand"]}";
            string appPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["SampleName"]}";
            string testPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["Platform"]}";
            string publishCommand = "dotnet publish -f net9.0-android -c Release -p:AndroidKeyStore=true -p:AndroidSigningKeyStore=key.keystore -p:AndroidSigningKeyAlias=MauiAlias -p:AndroidSigningKeyPass=kanna007 -p:AndroidSigningStorePass=kanna007";
            string installCommand = $"adb install {appPath}/bin/Release/net9.0-android/publish/{project["ApplicationID"]}-Signed.apk";
            string TestRun = $"dotnet test {testPath}";
            Console.WriteLine($"Running commands for {project["ProjectName"]}...");
            // if(project["EmulatorCommand"] == "Pixel_2_XL")
            // {
            // Console.WriteLine($"Starting emulator : {project["EmulatorCommand"]}...");
            // AndroidTool.BootDevice(project["EmulatorCommand"]);
            // }
            // else if(project["EmulatorCommand"] == "Pixel_2_XL_API_28")
            // {
            //     AndroidTool.ShutdownDeviceCompletely("Pixel_5_API_33");
            //     Console.WriteLine($"Starting emulator : {project["EmulatorCommand"]}...");
            //     AndroidTool.BootDevice(project["EmulatorCommand"]);
            // }
            Console.WriteLine($"Starting {project["SampleName"]} build and publish");
            CommondExcecute.ExecuteCommand($"cd {appPath} && {publishCommand}");

            Console.WriteLine($"Installing {project["SampleName"]} in to emulator");
            CommondExcecute.ExecuteCommand(installCommand);

            // Console.WriteLine($"UITest started for project : {project["SampleName"]} Sample : {project["SampleName"]} Platform : {project["Platform"]} ");
            // CommondExcecute.ExecuteCommand(TestRun);
            

        }

        else if (project["Platform"] == "UITests.iOS")
        {
            var iphone13promax = "815F3742-98E7-4405-9611-EC74A30DB5F2";
            string emulator = $"{project["EmulatorCommand"]}";
            string appPath = $"{documentFolder}/AppiumiOS/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["SampleName"]}";
            string testPath = $"{documentFolder}/AppiumiOS/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["Platform"]}";
            string TestRun = $"dotnet test {testPath}";
            Console.WriteLine($"Running commands for {project["ProjectName"]}...");

            Console.WriteLine($"Starting simulator : {project["EmulatorCommand"]}...");

            Console.WriteLine($"Installing {project["SampleName"]} in to Simulator ");
            iOSTool.InstallApp(project["EmulatorCommand"], appPath, project["SampleName"]);

            Console.WriteLine($"UITest started for project : {project["SampleName"]} Sample : {project["SampleName"]} Platform : {project["Platform"]} ");
            CommondExcecute.ExecuteCommand(TestRun);
        }
        else if( project["Platform"] == "UITests.macOS")
        {
            string appPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["SampleName"]}";
            string testPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["Platform"]}";
            string publishCommand = "dotnet publish -f net9.0-maccatalyst -c Release";
            string TestRun = $"dotnet test {testPath}";
            string pkgInstaller = $"sudo -S installer -pkg {appPath}/bin/Release/net9.0-maccatalyst/publish/{project["SampleName"]}-1.0.pkg -target /";
            Console.WriteLine($"Running commands for {project["ProjectName"]}...");
            Console.WriteLine($"Starting {project["SampleName"]} build and publish");
            CommondExcecute.ExecuteCommand($"cd {appPath} && {publishCommand}");
            Console.WriteLine($"Installing {project["SampleName"]} in to simulator");
            CommondExcecute.ExecuteCommand($"echo 'Syncfusion#132' | {pkgInstaller}");
            Console.WriteLine($"UITest started for project : {project["SampleName"]} Sample : {project["SampleName"]} Platform : {project["Platform"]} ");
            CommondExcecute.ExecuteCommand($"cd {testPath} && {TestRun}");
        }
    }
}
