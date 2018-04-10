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
        #region Foreground windows essentials
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        #endregion

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

            ModifierKeys modifierKeys = GetModifierKeys();

            RegisterClipboardHotkey(modifierKeys);
            RegisterSoftBarHotkey(modifierKeys);
        }

        public bool RegisterHotkey(ModifierKeys modifierKeys, Keys key)
        {
            return RegisterHotKey(_manager.Form.Handle, 0, (int)modifierKeys, (int)key);
        }

        public bool RegisterSoftBarHotkey(ModifierKeys modifierKeys)
        {
            Keys softBarHotkey = GetSoftBarHotkey();

            return RegisterHotkey(modifierKeys, softBarHotkey);                
        }

        public bool RegisterClipboardHotkey(ModifierKeys modifierKeys)
        {
            Keys clipboardHotkey = GetClipboardHotkey();

            return RegisterHotkey(modifierKeys, clipboardHotkey);                
        }

        private Keys GetClipboardHotkey()
        {
            var hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.Clipboard_Hotkey, "c").ToLower();
            return (Keys)char.ToUpper(hotkey[0]);
        }

        private Keys GetSoftBarHotkey()
        {
            var hotkey = _manager.SettingsManager.Settings.GetStringSetting(Constants.General_Hotkey, "s").ToLower();
            return (Keys)char.ToUpper(hotkey[0]);
        }

        private ModifierKeys GetModifierKeys()
        {
            var modifierSetting = _manager.SettingsManager.Settings.GetIntegerSetting(Constants.General_Modifiers, 3);
            return HelperFunctions.GetModifierKeys(modifierSetting);
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

            ModifierKeys modifierKeys = _manager.HotkeyManager.GetModifierKeys();
            Keys clipboardHotkey = _manager.HotkeyManager.GetClipboardHotkey();
            Keys softBarHotkey = _manager.HotkeyManager.GetSoftBarHotkey();

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
