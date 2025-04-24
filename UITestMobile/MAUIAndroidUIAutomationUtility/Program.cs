
using MAUIAndroidUIAutomationUtility.Helper;
using MAUIAndroidUIAutomationUtility.AndroidTools;
using MAUIAndroidUIAutomationUtility.iOSTools;


namespace MAUIAndroidUIAutomationUtility;
class Program
{
    static void Main()
    {
        string documentFolder= "/Users/aravindkann/Documents";
        // Appium 1
        List<Dictionary<string, string>> projects = new List<Dictionary<string, string>>
        {

        //Android platform

         new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "BindingAndEvents" }, { "ApplicationID", "com.companyname.bindingandevents" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5_API_33" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "CRbugs" }, { "ApplicationID", "com.companyname.crbugs" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "m aui-listview-tests" }, { "SampleName", "EmptyView" }, { "ApplicationID", "com.companyname.emptyview" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "HeaderAndFooter" }, { "ApplicationID", "com.companyname.headerandfooter" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewHeaderAndFooter" }, { "ApplicationID", "com.companyname.MAUISfListViewHeaderAndFooter" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewHeaderFooter" }, { "ApplicationID", "com.companyname.MAUISfListViewHeaderFooter" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewItemSize" }, { "ApplicationID", "com.companyname.mauisflistviewitemsize" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewLayouts" }, { "ApplicationID", "com.companyname.mauisflistviewlayouts" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewQueryItemSize" }, { "ApplicationID", "com.companyname.mauisflistviewqueryitemsize" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "mauisflistviewsortgroupfilter" }, { "ApplicationID", "com.companyname.maui.sflistview.recorditems" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewRTL" }, { "ApplicationID", "com.companyname.mauisflistviewrtl" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewSelection" }, { "ApplicationID", "com.companyname.mauisflistviewselection" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewSortGroupFilter" }, { "ApplicationID", "com.companyname.mauisflistviewsortgroupfilter" }, { "Platform", "UITests.Android" }, { "EmulatorCommand", "Pixel_5" } },      

        //iOS platform

         //new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "BindingAndEvents" }, { "ApplicationID", "com.companyname.bindingandevents" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "CRbugs" }, { "ApplicationID", "com.companyname.crbugs" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "EmptyView" }, { "ApplicationID", "com.companyname.emptyview" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "HeaderAndFooter" }, { "ApplicationID", "com.companyname.headerandfooter" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewHeaderAndFooter" }, { "ApplicationID", "com.companyname.MAUISfListViewHeaderAndFooter" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewHeaderFooter" }, { "ApplicationID", "com.companyname.MAUISfListViewHeaderFooter" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewItemSize" }, { "ApplicationID", "com.companyname.mauisflistviewitemsize" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewLayouts" }, { "ApplicationID", "com.companyname.mauisflistviewlayouts" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewQueryItemSize" }, { "ApplicationID", "com.companyname.mauisflistviewqueryitemsize" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "mauisflistviewsortgroupfilter" }, { "ApplicationID", "com.companyname.maui.sflistview.recorditems" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewRTL" }, { "ApplicationID", "com.companyname.mauisflistviewrtl" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewSelection" }, { "ApplicationID", "com.companyname.mauisflistviewselection" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        // new Dictionary<string, string> { { "ProjectName", "maui-listview-tests" }, { "SampleName", "MAUISfListViewSortGroupFilter" }, { "ApplicationID", "com.companyname.mauisflistviewsortgroupfilter" }, { "Platform", "UITests.iOS" }, { "EmulatorCommand", "2EE8CBD0-4E77-4574-810A-C19A1D9E050D" } },
        
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
            if(project["EmulatorCommand"] == "Pixel_2_XL")
            {
                Console.WriteLine($"Starting emulator : {project["EmulatorCommand"]}...");
                AndroidTool.BootDevice(project["EmulatorCommand"]);
            }
            string appPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["SampleName"]}";
            string testPath = $"{documentFolder}/Appium/{project["ProjectName"]}/UITest/Appium/{project["SampleName"]}/{project["Platform"]}/{project["Platform"]}.csproj";
            string publishCommand = "dotnet publish -f net9.0-android -c Release -p:AndroidKeyStore=true -p:AndroidSigningKeyStore=key.keystore -p:AndroidSigningKeyAlias=MauiAlias -p:AndroidSigningKeyPass=kanna007 -p:AndroidSigningStorePass=kanna007";
            string installCommand = $"{AndroidTool.ANDROID_PLATFORMTOOL}/adb install {appPath}/bin/Release/net9.0-android/publish/{project["ApplicationID"]}-Signed.apk";
            string TestRun = $"dotnet test {testPath}";
            Console.WriteLine($"Running commands for {project["ProjectName"]}...");
            try{

            Console.WriteLine($"Starting {project["SampleName"]} build and publish");
            CommondExcecute.ExecuteCommand($"cd {appPath} && {publishCommand}");

            Console.WriteLine($"Installing {project["SampleName"]} in to emulator");
            CommondExcecute.ExecuteCommand(installCommand);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception sample not installed", ex.Message);
            }
            try
            {
            Console.WriteLine($"UITest started for project : {project["SampleName"]} Sample : {project["SampleName"]} Platform : {project["Platform"]} ");
            CommondExcecute.ExecuteCommand(TestRun);
            }
        catch (Exception ex)
        {
            Console.WriteLine("Test Not runned ", ex);
        }
            

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
