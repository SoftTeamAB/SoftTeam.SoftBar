using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftTeam.SoftBar.Core.Settings;

namespace SoftTeam.SoftBar.Test
{
    [TestClass]
    public class SettingsManagerTest
    {
        private const string _path = @"c:\temp\SoftBarTest\settings.xml";

        [TestMethod]
        public void SaveSettingsXml()
        {
            SettingsManager manager = new SettingsManager(_path);
            manager.Settings.SetSetting("Test", "Test");
            manager.Save();

            Assert.AreEqual(true, System.IO.File.Exists(_path));
        }

        [TestMethod]
        public void LoadSettingsXml()
        {
            SettingsManager manager = new SettingsManager(_path);
            manager.Load();

            Assert.AreEqual("Test", manager.Settings.GetSetting("Test").Value);
            Assert.AreEqual(null, manager.Settings.GetSetting("Test2"));
        }
    }
}
