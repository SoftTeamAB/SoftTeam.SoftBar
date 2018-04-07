using DevExpress.XtraEditors;
using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using SoftTeam.SoftBar.Core.SoftBar;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.Hotkey
{
    public class HotkeyManager
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        #region Fields
        private SoftBarManager _manager = null;
        #endregion

        #region Hotkeys essentials
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        /// <summary>
        /// The enumeration of possible modifiers.
        /// </summary>
        [Flags]
        public enum ModifierKeys : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Win = 8
        }
        #endregion

        #region Constructor
        public HotkeyManager(SoftBarManager manager)
        {
            _manager = manager;
        }
        #endregion

        #region Register/unregister hot keys
        public void RegisterHotKeys()
        {
            //http://www.dreamincode.net/forums/topic/180436-global-hotkeys/
            var hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.Clipboard_Hotkey, "c").ToLower();
            Keys clipboardHotkey = (Keys)char.ToUpper(hotkey[0]);

            if (!RegisterHotKey(_manager.Form.Handle, 0, (int)(ModifierKeys.Shift | ModifierKeys.Control), (int)clipboardHotkey))
                XtraMessageBox.Show($"Failed to register hotkey CTRL + SHIFT + {hotkey}!");

            hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.General_Hotkey, "s").ToLower();
            Keys softBarHotkey = (Keys)char.ToUpper(hotkey[0]);

            if (!RegisterHotKey(_manager.Form.Handle, 0, (int)(ModifierKeys.Shift | ModifierKeys.Control), (int)softBarHotkey))
                XtraMessageBox.Show($"Failed to register hotkey CTRL + SHIFT + {hotkey}!");
        }

        public void UnregisterHotKeys()
        {
            UnregisterHotKey(_manager.Form.Handle, 0);
        }

        //public bool TryRegisterHotkey()
        //{
        //    try
        //    {
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        #endregion

        #region Process hot keys
        public void ProcessHotKeys(ref Message m, Point mousePosition)
        {
            // get the keys.
            Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
            ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);
            var hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.Clipboard_Hotkey, "c").ToLower();
            Keys clipboardHotkey = (Keys)char.ToUpper(hotkey[0]);
            hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.General_Hotkey, "s").ToLower();
            Keys softBarHotkey = (Keys)char.ToUpper(hotkey[0]);

            if (modifier == (ModifierKeys.Shift | ModifierKeys.Control) && key == clipboardHotkey)
                _manager.ClipboardManager.HotKeyClicked(mousePosition);
            else if (modifier == (ModifierKeys.Shift | ModifierKeys.Control) && key == softBarHotkey)
            {
                // Application bar on top
                _manager.ApplicationBarManager.AlwaysOnTop();
                // Set focus on system button does not work so we
                // have to use SetForegroundWindow here for some reason
                SetForegroundWindow(_manager.Form.Handle);
            }

        }
        #endregion
    }
}
