using System;
using System.IO;
using DriverService = AutomationFramework.WEB.Driver.DriverService;

namespace AutomationFramework.WEB.Helpers
{
    public static class AttachmentManager
    {
        private const string attachmentRootFolder = @"..\..\TestResults";
        private const string screenshotsRoot = @"Attachments\Screenshots";

        /// <summary>
        /// Add Screenshot with custom filename format
        /// </summary>
        /// <param name="filename"></param>
        public static void AddScreenshot(string filename)
        {
            DriverService.TakeScreenshot(Path.Combine(attachmentRootFolder, screenshotsRoot, filename));
            string rawString = string.Format("Screenshot={0}", Path.Combine(screenshotsRoot, filename));
            Console.WriteLine(rawString);
        }

        /// <summary>
        /// Add Screenshot with default filename format
        /// </summary>
        public static void AddScreenshot()
        {
            AddScreenshot("Screenshot" + DateTime.Now.ToString("yyyy-M-d-hh-mm-ss") + ".png");
        }
    }
}