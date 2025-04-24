
using MAUIAndroidUIAutomationUtility.Helper;
using MAUIAndroidUIAutomationUtility.AndroidTools;
using MAUIAndroidUIAutomationUtility.iOSTools;


namespace MAUIAndroidUIAutomationUtility;
class Program
{
    static void Main()
    {
        string documentFolder = "/Users/aravindkannanarayanarao/Documents";
        // Appium 1
        List<Dictionary<string, string>> projects = new List<Dictionary<string, string>>
        {
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "MAUISfSchedulerAgenda" }, { "ApplicationID", "com.companyname.mauisfscheduleragenda" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerAgendaView" }, { "ApplicationID", "com.companyname.sfscheduleragendaview" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerCalendarTypes" }, { "ApplicationID", "com.companyname.sfschedulercalendartypes" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "AppointmentTemplateSelector" }, { "ApplicationID", "com.companyname.appointmenttemplateselector" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerDayView" }, { "ApplicationID", "com.companyname.sfschedulerdayview" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerEvents" }, { "ApplicationID", "com.companyname.sfschedulerevents" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerHeaderView" }, { "ApplicationID", "com.companyname.sfschedulerheaderview" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfschedulerRecurrenceRule" }, { "ApplicationID", "com.companyname.sfschedulerrecurrencerule" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerShowAllowedViews" }, { "ApplicationID", "com.companyname.sfschedulershowallowedviews" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerSpecialTimeRegion" }, { "ApplicationID", "com.companyname.sfschedulerspecialtimeregion" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerTimelineView" }, { "ApplicationID", "com.companyname.sfschedulertimelineview" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfSchedulerTimeslot" }, { "ApplicationID", "com.companyname.sfschedulertimeslot" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
            new Dictionary<string, string> { { "ProjectName", "maui-scheduler-tests" }, { "SampleName", "SfShedulerMonthView" }, { "ApplicationID", "com.companyname.sfshedulermonthview" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_2_XL" } },
        };

        foreach (var project in projects)
        {
            Console.WriteLine($"Running UI tests for {project["ProjectName"]}...");
            RunUITests(project, documentFolder);
        }

    }
    public static void SimulatorDeviceBoot(Dictionary<string, string> project)
    {

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

            string platform = project["Platform"];

            if (platform.Contains("Android"))
            {
                AndroidTool.HandleAndroidLaunch(emulator);
            }
            else if (platform.Contains("iOS"))
            {
                iOSTool.HandleiOSLaunch(emulator);
            }
            Console.WriteLine($"Starting {project["SampleName"]} build and publish");
            CommondExcecute.ExecuteCommand($"cd {appPath} && {publishCommand}");

            Console.WriteLine($"Installing {project["SampleName"]} in to emulator");
            CommondExcecute.ExecuteCommand(installCommand);

            Console.WriteLine($"UITest started for project : {project["SampleName"]} Sample : {project["SampleName"]} Platform : {project["Platform"]} ");
            CommondExcecute.ExecuteCommand(TestRun);
            if (project["EmulatorCommand"] == "Pixel_5_API_33")
            {
                Console.WriteLine($"Closing emulator");
                AndroidTool.ShutdownDevice(project["EmulatorCommand"]);
            }
            else if (project["EmulatorCommand"] == "Pixel_2_XL_API_28")
            {
                Console.WriteLine($"Closing emulator");
                AndroidTool.ShutdownDevice(project["EmulatorCommand"]);
            }

        }

        else if (project["Platform"] == "UITests.iOS")
        {
            var iphone13promax = "815F3742-98E7-4405-9611-EC74A30DB5F2";
            string emulator = $"{project["EmulatorCommand"]}";
            string appPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["SampleName"]}";
            string testPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["Platform"]}";
            string TestRun = $"dotnet test {testPath}";

            string platform = project["Platform"];

            if (platform.Contains("Android"))
            {
                AndroidTool.HandleAndroidLaunch(emulator);
            }
            else if (platform.Contains("iOS"))
            {
                iOSTool.HandleiOSLaunch(iphone13promax);
            }
            Console.WriteLine($"Running commands for {project["ProjectName"]}...");

            Console.WriteLine($"Starting simulator : {project["EmulatorCommand"]}...");

            Console.WriteLine($"Installing {project["SampleName"]} in to Simulator ");
            iOSTool.InstallApp(project["EmulatorCommand"], appPath, project["SampleName"]);

            Console.WriteLine($"UITest started for project : {project["SampleName"]} Sample : {project["SampleName"]} Platform : {project["Platform"]} ");
            CommondExcecute.ExecuteCommand(TestRun);
        }
    }
}
