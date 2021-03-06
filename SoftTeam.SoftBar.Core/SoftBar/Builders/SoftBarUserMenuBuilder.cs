﻿using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Xml;

namespace SoftTeam.SoftBar.Core.SoftBar.Builders
{
    /// <summary>
    /// Class that builds user menus from and XmlArea
    /// </summary>
    public class SoftBarUserMenuBuilder
    {
        #region Fields
        private XmlArea _area = null;
        private MainAppBarForm _form = null;
        private SoftBarArea _softBarArea = null;
        #endregion

        #region Constructor
        public SoftBarUserMenuBuilder(SoftBarManager manager)
        {
            _form = manager.Form;
            _area = manager.UserAreaXml;
            _softBarArea = manager.UserArea;
        }
        #endregion

        #region Builds
        public void Build()
        {
            foreach (var menu in _area.Menus)
            {
                // Create the menu item
                SoftBarMenu barMenu = new SoftBarMenu(_form, menu);

                // Position the menu
                barMenu.Left = _softBarArea.Width;

                // Set up the menu
                barMenu.Setup();

                // Add the menu to the menus collection
                _softBarArea.Menus.Add(barMenu);

                // Build the rest of the menu
                BuildMenu((XmlMenuBase)menu, barMenu);
            }
        }

        // Build a user menu
        private void BuildMenu(XmlMenuBase xmlMenu, SoftBarBaseMenu barMenu)
        {
            // For all menu items in the menu
            foreach (XmlMenuItemBase xmlMenuItemBase in xmlMenu.MenuItems)
            {
                if (xmlMenuItemBase is XmlSubMenu)
                {
                    // We have a sub menu
                    var xmlSubMenu = xmlMenuItemBase as XmlSubMenu;
                    SoftBarSubMenu softBarSubMenu = new SoftBarSubMenu(_form, xmlSubMenu);

                    // Create the sub menu 
                    var barSubItem = softBarSubMenu.Setup(softBarSubMenu);

                    // Add the sub menu
                    if (barMenu is SoftBarMenu)
                        ((SoftBarMenu)barMenu).Item.AddItem(barSubItem);
                    else
                        ((SoftBarSubMenu)barMenu).Item.AddItem(barSubItem);

                    // Create a new group if beginGroup is true
                    if (softBarSubMenu.BeginGroup) barSubItem.Links[0].BeginGroup = true;

                    // Call create menu recursivly
                    BuildMenu(xmlSubMenu, softBarSubMenu);
                }
                else if (xmlMenuItemBase is XmlHeaderItem)
                {
                    // We have a header item
                    var xmlHeaderItem = xmlMenuItemBase as XmlHeaderItem;
                    SoftBarHeaderItem softBarHeaderItem = new SoftBarHeaderItem(_form, xmlHeaderItem);

                    // Create the header item
                    var barHeaderItem = softBarHeaderItem.Setup();

                    // Add the header item to the menu
                    if (barMenu is SoftBarMenu)
                        ((SoftBarMenu)barMenu).Item.AddItem(barHeaderItem);
                    else
                        ((SoftBarSubMenu)barMenu).Item.AddItem(barHeaderItem);

                    // Create a new group if beginGroup is true
                    if (softBarHeaderItem.BeginGroup) barHeaderItem.Links[0].BeginGroup = true;
                }
                else
                {
                    // We have a menu item
                    var xmlMenuItem = xmlMenuItemBase as XmlMenuItem;
                    SoftBarMenuItem softBarMenuItem = new SoftBarMenuItem(_form, xmlMenuItem);

                    // Create the menu item
                    var barButtonItem = softBarMenuItem.Setup();

                    // Add the menu item to the menu
                    if (barMenu is SoftBarMenu)
                        ((SoftBarMenu)barMenu).Item.AddItem(barButtonItem);
                    else
                        ((SoftBarSubMenu)barMenu).Item.AddItem(barButtonItem);

                    // Create a new group if beginGroup is true
                    if (softBarMenuItem.BeginGroup) barButtonItem.Links[0].BeginGroup = true;
                }
            }
        }
        #endregion
    }
}
