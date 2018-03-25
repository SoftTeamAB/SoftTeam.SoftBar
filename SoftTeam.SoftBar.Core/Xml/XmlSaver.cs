using System;
using System.Text;
using System.Xml;

namespace SoftTeam.SoftBar.Core.Xml
{
    public class XmlSaver : IDisposable
    {
        #region Fields
        private XmlArea _area;
        private string _path;
        #endregion

        #region Constructors
        public XmlSaver(XmlArea area, string path)
        {
            _area = area;
            _path = path;
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            _area = null;
            _path = null;
        }
        #endregion

        #region Save
        public void Save()
        {
            XmlDocument doc = new XmlDocument();

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.GetEncoding("utf-8");
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(_path, settings);

            var softbar = doc.CreateElement("softbar");
            doc.AppendChild(softbar);

            foreach (var menu in _area.Menus)
            {
                var menuNode = doc.CreateElement("menu");
                menuNode.SetAttribute("name", menu.Name);
                menuNode.SetAttribute("iconPath", menu.IconPath);
                menuNode.SetAttribute("width", menu.Width.ToString());
                menuNode.SetAttribute("beginGroup", menu.BeginGroup.ToString().ToLower());
                softbar.AppendChild(menuNode);

                CreateMenuNodes(doc, menu, menuNode);
            }

            doc.Save(writer);

            writer.Close();
            writer.Dispose();
            writer = null;
        }

        private void CreateMenuNodes(XmlDocument doc, XmlMenuBase menu, XmlElement menuNode)
        {
            foreach (var menuItem in menu.MenuItems)
            {
                if (menuItem is XmlSubMenu)
                {
                    var subMenuItem = menuItem as XmlSubMenu;
                    var subMenuItemNode = doc.CreateElement("menu");

                    subMenuItemNode.SetAttribute("name", subMenuItem.Name);
                    subMenuItemNode.SetAttribute("iconPath", subMenuItem.IconPath);
                    subMenuItemNode.SetAttribute("beginGroup", subMenuItem.BeginGroup.ToString().ToLower());
                    menuNode.AppendChild(subMenuItemNode);

                    CreateMenuNodes(doc, subMenuItem, subMenuItemNode);
                }
                else if (menuItem is XmlHeaderItem)
                {
                    var headerItem = menuItem as XmlHeaderItem;
                    var headerItemNode = doc.CreateElement("headerItem");

                    headerItemNode.SetAttribute("name", headerItem.Name);
                    headerItemNode.SetAttribute("beginGroup", headerItem.BeginGroup.ToString().ToLower());

                    menuNode.AppendChild(headerItemNode);
                }
                else if (menuItem is XmlMenuItem)
                {
                    var item = menuItem as XmlMenuItem;
                    var itemNode = doc.CreateElement("menuItem");

                    itemNode.SetAttribute("name", item.Name);
                    itemNode.SetAttribute("beginGroup", item.BeginGroup.ToString().ToLower());
                    itemNode.SetAttribute("iconPath", item.IconPath);

                    if (!string.IsNullOrEmpty(item.ApplicationPath))
                    {
                        var applicationPathNode = doc.CreateElement("applicationPath");
                        applicationPathNode.InnerText = item.ApplicationPath;
                        itemNode.AppendChild(applicationPathNode);
                    }

                    if (!string.IsNullOrEmpty(item.DocumentPath))
                    {
                        var documentPathNode = doc.CreateElement("documentPath");
                        documentPathNode.InnerText = item.DocumentPath;
                        itemNode.AppendChild(documentPathNode);
                    }

                    if (!string.IsNullOrEmpty(item.Parameters))
                    {
                        var parametersNode = doc.CreateElement("parametersPath");
                        parametersNode.InnerText = item.Parameters;
                        itemNode.AppendChild(parametersNode);
                    }

                    menuNode.AppendChild(itemNode);
                }
            }
        }
        #endregion
    }
}
