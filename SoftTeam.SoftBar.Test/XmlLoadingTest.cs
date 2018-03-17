using System;
using System.Xml;
using System.Xml.Schema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftTeam.SoftBar.Core.NewXml;

namespace SoftTeam.SoftBar.Test
{
    [TestClass]
    public class XmlLoadingTest
    {
        [TestMethod]
        public void CreateXmlLoader()
        {
            var path = @"c:\temp\SoftBarTest\menu.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            Assert.AreNotEqual(null, loader);            
        }

        [TestMethod]
        public void CreateXmlLoaderAndLoadEmptyXml()
        {
            var path = @"c:\temp\SoftBarTest\emptymenu.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            NewXmlArea area = loader.Load();
            Assert.AreEqual(0, area.Menus.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(XmlException))]
        public void InvalidXmlTest()
        {
            var path = @"c:\temp\SoftBarTest\invalidmenu.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            NewXmlArea area = loader.Load();            
        }

        [TestMethod]
        [ExpectedException(typeof(XmlSchemaException))]
        public void InvalidXmlTest2()
        {
            var path = @"c:\temp\SoftBarTest\invalidmenu2.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            NewXmlArea area = loader.Load();
        }

        [TestMethod]
        public void CreateXmlLoaderAndLoadXml()
        {
            var path = @"c:\temp\SoftBarTest\complexmenu.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            NewXmlArea area = loader.Load();
            Assert.AreEqual(2, area.Menus.Count);
            Assert.AreEqual(4, area.Menus[0].MenuItems.Count);
            Assert.AreEqual(6, area.Menus[1].MenuItems.Count);
        }

        [TestMethod]
        public void TestSimpleHeaderItem()
        {
            var path = @"c:\temp\SoftBarTest\headeritem.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            NewXmlArea area = loader.Load();
            Assert.AreEqual(1, area.Menus.Count);
            Assert.AreEqual(1, area.Menus[0].MenuItems.Count);
            Assert.AreEqual("Development", area.Menus[0].MenuItems[0].Name);
            Assert.AreEqual(false, ((NewXmlHeaderItem)area.Menus[0].MenuItems[0]).BeginGroup);
        }

        [TestMethod]
        public void TestFullHeaderItem()
        {
            var path = @"c:\temp\SoftBarTest\headeritem2.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            NewXmlArea area = loader.Load();
            Assert.AreEqual(1, area.Menus.Count);
            Assert.AreEqual(1, area.Menus[0].MenuItems.Count);
            Assert.AreEqual("Development", area.Menus[0].MenuItems[0].Name);
            Assert.AreEqual(true, ((NewXmlHeaderItem)area.Menus[0].MenuItems[0]).BeginGroup);
        }

        [TestMethod]
        public void TestMenuItem()
        {
            var path = @"c:\temp\SoftBarTest\menuitem.xml";
            NewXmlLoader loader = new NewXmlLoader(path);
            NewXmlArea area = loader.Load();
            Assert.AreEqual(1, area.Menus.Count);
            Assert.AreEqual(6, area.Menus[0].MenuItems.Count);

            var applicationPath = @"c:\windows\notepad.exe";
            var iconPath = @"C:\Program Files (x86)\Microsoft Office\root\Office16\Excel.exe";
            var documentPath = @"c:\document.doc";
            var parameters = @"%f";
            var index = 0;

            // First menu item
            Assert.AreEqual("Item1", area.Menus[0].MenuItems[index].Name);
            Assert.AreEqual(false, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).BeginGroup);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).IconPath);
            Assert.AreEqual(applicationPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).ApplicationPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).DocumentPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).Parameters);

            // Second menu item
            index++;
            Assert.AreEqual("Item2", area.Menus[0].MenuItems[index].Name);
            Assert.AreEqual(true, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).BeginGroup);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).IconPath);
            Assert.AreEqual(applicationPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).ApplicationPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).DocumentPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).Parameters);

            // Third menu item
            index++;
            Assert.AreEqual("Item3", area.Menus[0].MenuItems[index].Name);
            Assert.AreEqual(false, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).BeginGroup);
            Assert.AreEqual(iconPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).IconPath);
            Assert.AreEqual(applicationPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).ApplicationPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).DocumentPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).Parameters);

            // Fourth menu item
            index++;
            Assert.AreEqual("Item4", area.Menus[0].MenuItems[index].Name);
            Assert.AreEqual(true, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).BeginGroup);
            Assert.AreEqual(iconPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).IconPath);
            Assert.AreEqual(applicationPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).ApplicationPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).DocumentPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).Parameters);

            // Fifth menu item
            index++;
            Assert.AreEqual("Item5", area.Menus[0].MenuItems[index].Name);
            Assert.AreEqual(true, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).BeginGroup);
            Assert.AreEqual(iconPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).IconPath);
            Assert.AreEqual(applicationPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).ApplicationPath);
            Assert.AreEqual(documentPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).DocumentPath);
            Assert.AreEqual(string.Empty, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).Parameters);

            // Sixth menu item
            index++;
            Assert.AreEqual("Item6", area.Menus[0].MenuItems[index].Name);
            Assert.AreEqual(true, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).BeginGroup);
            Assert.AreEqual(iconPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).IconPath);
            Assert.AreEqual(applicationPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).ApplicationPath);
            Assert.AreEqual(documentPath, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).DocumentPath);
            Assert.AreEqual(parameters, ((NewXmlMenuItem)area.Menus[0].MenuItems[index]).Parameters);
        }
    }
}
