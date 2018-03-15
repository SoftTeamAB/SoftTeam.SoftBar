using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftTeam.SoftBar.Core.Settings;

namespace SoftTeam.SoftBar.Test
{
    [TestClass]
    public class SettingsTest
    {
        [TestMethod]
        public void CreateSettingsClass()
        {
            Settings settings = new Settings();
        }

        [TestMethod]
        public void AddSettings()
        {
            Settings settings = new Settings();
            settings.SetSetting("Test", "Test");
        }

        [TestMethod]
        public void AddMultipleSettings()
        {
            Settings settings = new Settings();
            settings.SetSetting("Test", "Test");
            settings.SetSetting("Test2", "Test");
        }

        [TestMethod]
        public void AddMultipleSettingsAndEnumerateThem()
        {
            Settings settings = new Settings();
            settings.SetSetting("Test", "Test");
            settings.SetSetting("Test2", "Test");

            foreach (var setting in settings.MySettings)
                Console.WriteLine(setting.Key + "=" + setting.Value);
        }

        [TestMethod]
        public void AddMultipleSettingsAndValidateThem()
        {
            Settings settings = new Settings();
            settings.SetSetting("Test", "Test");
            settings.SetSetting("Test2", "Test2");

            var setting = settings.GetSetting("Test");
            Assert.AreEqual("Test", setting.Value);

            setting = settings.GetSetting("Test2");
            Assert.AreEqual("Test2", setting.Value);
        }

        [TestMethod]
        public void NonExistingSettingShouldReturnNull()
        {
            Settings settings = new Settings();
            settings.SetSetting("Test", "Test");

            var setting = settings.GetSetting("x");
            Assert.AreEqual(null, setting);
        }
    }
}
