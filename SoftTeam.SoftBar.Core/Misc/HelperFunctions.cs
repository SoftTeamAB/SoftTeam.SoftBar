﻿using DevExpress.Utils;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Windows.Forms;
using static SoftTeam.SoftBar.Core.Hotkey.HotkeyManager;

namespace SoftTeam.SoftBar.Core.Misc
{
    public class HelperFunctions
    {
        public static Keys GetModifierKeys(ModifierKeys modifiers)
        {
            Keys modifierKeys = Keys.None;
            switch (modifiers)
            {
                case ModifierKeys.Control:
                    modifierKeys = Keys.Control;
                    break;
                case ModifierKeys.Alt:
                    modifierKeys = Keys.Alt;
                    break;
                case ModifierKeys.Shift | ModifierKeys.Control:
                    modifierKeys = Keys.Shift | Keys.Control;
                    break;
                case ModifierKeys.Control | ModifierKeys.Alt:
                    modifierKeys = Keys.Control | Keys.Alt;
                    break;
                case ModifierKeys.Alt | ModifierKeys.Shift:
                    modifierKeys = Keys.Alt | Keys.Shift;
                    break;
                case ModifierKeys.Shift | ModifierKeys.Control | ModifierKeys.Alt:
                    modifierKeys = Keys.Shift | Keys.Control | Keys.Alt;
                    break;
            }
            return modifierKeys;
        }

        public static ModifierKeys GetModifierKeys(int index)
        {
            ModifierKeys modifierKeys = ModifierKeys.None;
            switch (index)
            {
                case 0:
                    modifierKeys = ModifierKeys.Control;
                    break;
                case 1:
                    modifierKeys = ModifierKeys.Alt;
                    break;
                case 2:
                    modifierKeys = ModifierKeys.Shift | ModifierKeys.Control;
                    break;
                case 3:
                    modifierKeys = ModifierKeys.Control | ModifierKeys.Alt;
                    break;
                case 4:
                    modifierKeys = ModifierKeys.Alt | ModifierKeys.Shift;
                    break;
                case 5:
                    modifierKeys = ModifierKeys.Shift | ModifierKeys.Control | ModifierKeys.Alt;
                    break;
            }
            return modifierKeys;
        }

        public static string GetTimeStamp()
        {
            string timeStamp = DateTime.Now.ToShortDateString() + "_" + DateTime.Now.ToLongTimeString();
            timeStamp = timeStamp.Replace(":", "_").Replace("-", "_");

            return timeStamp;
        }

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public static string GetTypeName(MenuItemType type)
        {
            switch (type)
            {
                case MenuItemType.Menu:
                    return "Menu";
                case MenuItemType.SubMenu:
                    return "Sub menu";
                case MenuItemType.HeaderItem:
                    return "Header";
                case MenuItemType.MenuItem:
                    return "Menu item";
                case MenuItemType.None:
                    return "Error : None is not a valid type!";
                default:
                    return "Error : Invalid type!";
            }
        }
        public static Color GetTypeColor(object type)
        {
            switch (type)
            {
                case MenuItemType.Menu:
                    return Color.FromArgb(80, 80, 80);
                case MenuItemType.SubMenu:
                    return Color.FromArgb(80, 80, 80);
                case MenuItemType.HeaderItem:
                    return Color.Gray;
                case MenuItemType.MenuItem:
                    return Color.LightGray;
                case MenuItemType.None:
                    return Color.Red;
                default:
                    return Color.Red;
            }
        }

        //public static string GetSettingsPath()
        //{
        //    var path = Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
        //    path = System.IO.Path.Combine(path, "SoftTeam AB");
        //    path = System.IO.Path.Combine(path, "SoftBar");
        //    System.IO.Directory.CreateDirectory(path);
        //    path = System.IO.Path.Combine(path, "settings.xml");

        //    return path;
        //}

        public static Image GetFileImage(string path, ImageSize size = ImageSize.Medium_24x24)
        {
            if (string.IsNullOrEmpty(path))
                return null;
            else
            {
                try
                {
                    // Remove quotationmarks
                    path = path.Replace("\"", "");

                    // Expand environment variables
                    path = Environment.ExpandEnvironmentVariables(path);

                    Image image = null;
                    // Make sure that the file exists
                    if (System.IO.File.Exists(path))
                    {
                        FileInfo info = new FileInfo(path);
                        // Get file extension
                        var ext = info.Extension.ToUpper();

                        // Formats Image.FromFile can handle:
                        if (ext == ".BMP" || ext == ".GIF" || ext == ".JPG" || ext == ".JPEG" || ext == ".JPE" || ext == ".JIF" ||
                            ext == ".JFIF" || ext == ".JFI" || ext == ".PNG" || ext == ".TIFF" || ext == ".TIF")
                            image = Image.FromFile(path);
                        else
                            // TODO : Icon number
                            image = Icon.ExtractAssociatedIcon(path).ToBitmap();
                    }

                    if (image != null)
                    {
                        // Return image in correct size
                        if (size == ImageSize.Small_16x16)
                            return image.ResizeImage(16, 16);
                        else if (size == ImageSize.Medium_24x24)
                            return image.ResizeImage(24, 24);
                        else
                            return image.ResizeImage(32, 32);
                    }
                    else
                        // Return warning image in correct size
                        return ReturnWarninImage(size);
                }
                catch
                {
                    // Return warning image in correct size
                    return ReturnWarninImage(size);
                }
            }
        }

        private static Image ReturnWarninImage(ImageSize size)
        {
            // Return warning image in correct size
            if (size == ImageSize.Small_16x16)
                return new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_small);
            if (size == ImageSize.Medium_24x24)
                return new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning_medium);
            else
                return new Bitmap(SoftTeam.SoftBar.Core.Properties.Resources.Warning);
        }

        public static string GetXmlSchemaPath(bool debug = false)
        {
            if (debug)
            {
                var xsdPath = HelperFunctions.AssemblyDirectory;
                xsdPath = Path.GetFullPath(Path.Combine(xsdPath, @"..\..\..\"));
                xsdPath = Path.GetFullPath(Path.Combine(xsdPath, @"SoftTeam.SoftBar.Core\bin\Debug\Xml\SoftBar.xsd"));
                return xsdPath;
            }
            else
                return Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), @"Xml\SoftBar.xsd");

        }

        public static SuperToolTip CreateWarningToolTip(string errorMessage)
        {
            SuperToolTip tooltip = new SuperToolTip();

            ToolTipTitleItem title = new ToolTipTitleItem();
            title.AllowHtmlText = DefaultBoolean.True;
            title.Text = "<b>Warning!</b>";

            ToolTipItem item = new ToolTipItem();
            item.Image = SoftTeam.SoftBar.Core.Properties.Resources.Warning;
            item.AllowHtmlText = DefaultBoolean.True;
            item.Text += errorMessage;

            ToolTipSeparatorItem separator = new ToolTipSeparatorItem();

            tooltip.Items.Add(title);
            tooltip.Items.Add(separator);
            tooltip.Items.Add(item);

            return tooltip;
        }

        public static SuperToolTip CreateInformationToolTip(string message)
        {
            SuperToolTip tooltip = new SuperToolTip();

            ToolTipTitleItem title = new ToolTipTitleItem();
            title.AllowHtmlText = DefaultBoolean.True;
            title.Text = "<b>Information!</b>";

            ToolTipItem item = new ToolTipItem();
            item.Image = SoftTeam.SoftBar.Core.Properties.Resources.information;
            item.AllowHtmlText = DefaultBoolean.True;
            item.Text += message;

            ToolTipSeparatorItem separator = new ToolTipSeparatorItem();

            tooltip.Items.Add(title);
            tooltip.Items.Add(separator);
            tooltip.Items.Add(item);

            return tooltip;
        }

        public static string GetThemeName(int index)
        {
            switch (index)
            {
                case 0:
                    return "DevExpress Dark Style";
                case 1:
                    return "DevExpress Light Style";
                case 2:
                    return "Office 2007 Green";
                case 3:
                    return "Office 2007 Blue";
                case 4:
                    return "Office 2007 Pink";
                default:
                    return "DevExpress Dark Style";
            }
        }

        /// <summary>
        /// Creates color with corrected brightness.
        /// </summary>
        /// <param name="color">Color to correct.</param>
        /// <param name="correctionFactor">The brightness correction factor. Must be between -1 and 1. 
        /// Negative values produce darker colors.</param>
        /// <returns>
        /// Corrected <see cref="Color"/> structure.
        /// </returns>
        /// https://stackoverflow.com/questions/801406/c-create-a-lighter-darker-color-based-on-a-system-color
        public static Color ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = (float)color.R;
            float green = (float)color.G;
            float blue = (float)color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        public static string GetWorkingDirectory()
        {
            var path = "";

            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\SoftTeam\\SoftBar"))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("WorkingDirectory");
                        if (o != null)
                            path = o.ToString();
                    }
                }
            }
            catch
            {
            }

            return path;
        }

        public static string SetWorkingDirectory(string path)
        {
            try
            {
                // Make sure the keys exists
                CreateWorkingDirectoryRegistryKeys();

                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\SoftTeam\\SoftBar", true))
                {
                    if (key != null)
                        key.SetValue("WorkingDirectory", path);
                }
            }
            catch
            {
            }

            return path;
        }

        private static void CreateWorkingDirectoryRegistryKeys()
        {
            try
            {
                using (RegistryKey softTeamKey = Registry.CurrentUser.CreateSubKey("Software\\SoftTeam", true))
                {
                    using (RegistryKey softBarKey = Registry.CurrentUser.CreateSubKey("Software\\SoftTeam\\SoftBar", true))
                    {
                    }
                }
            }
            catch
            {
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
