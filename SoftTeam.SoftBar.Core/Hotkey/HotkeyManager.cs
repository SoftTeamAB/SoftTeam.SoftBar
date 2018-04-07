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
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        #region Fields
        private SoftBarManager _manager = null;
        private IntPtr _foregroundWindow;
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
            var modifierSetting = _manager.SettingsManager.Settings.GetIntegerSetting(Constants.General_Modifiers, 2);
            ModifierKeys modifierKeys = HelperFunctions.GetModifierKeys(modifierSetting);

            var hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.Clipboard_Hotkey, "c").ToLower();
            Keys clipboardHotkey = (Keys)char.ToUpper(hotkey[0]);

            if (!RegisterHotKey(_manager.Form.Handle, 0, (int)modifierKeys, (int)clipboardHotkey))
                XtraMessageBox.Show($"Failed to register hotkey {hotkey}!");

            hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.General_Hotkey, "s").ToLower();
            Keys softBarHotkey = (Keys)char.ToUpper(hotkey[0]);

            if (!RegisterHotKey(_manager.Form.Handle, 0, (int)modifierKeys, (int)softBarHotkey))
                XtraMessageBox.Show($"Failed to register hotkey {hotkey}!");
        }

        public void UnregisterHotKeys()
        {
            UnregisterHotKey(_manager.Form.Handle, 0);
        }
        #endregion

        #region Process hot keys
        public void ProcessHotKeys(ref Message m, Point mousePosition)
        {
            Keys keyPressed = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
            ModifierKeys modifiersPressed = (ModifierKeys)((int)m.LParam & 0xFFFF);

            var modifierSetting = _manager.SettingsManager.Settings.GetIntegerSetting(Constants.General_Modifiers, 2);
            ModifierKeys modifierKeys = HelperFunctions.GetModifierKeys(modifierSetting);

            var hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.Clipboard_Hotkey, "c").ToLower();
            Keys clipboardHotkey = (Keys)char.ToUpper(hotkey[0]);
            hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.General_Hotkey, "s").ToLower();
            Keys softBarHotkey = (Keys)char.ToUpper(hotkey[0]);

            if (modifiersPressed == modifierKeys && keyPressed == clipboardHotkey)
                _manager.ClipboardManager.HotKeyClicked(mousePosition);
            else if (modifiersPressed == modifierKeys && keyPressed == softBarHotkey)
            {
                // Application bar on top
                var onTop = _manager.ApplicationBarManager.AlwaysOnTop();
                // Set focus on system button does not work so we
                // have to use SetForegroundWindow here for some reason

                if (onTop)
                {
                    // Store the current foreground window, so that we can restore it later
                    _foregroundWindow = GetForegroundWindow();
                    // Set focus to our app bar
                    SetForegroundWindow(_manager.Form.Handle);
                }
                else
                {
                    // Try and restore focus to previous windows
                    try
                    {
                        SetForegroundWindow(_foregroundWindow);
                    }
                    catch 
                    {
                    }
                }
            }

        }
        #endregion
    }
}
