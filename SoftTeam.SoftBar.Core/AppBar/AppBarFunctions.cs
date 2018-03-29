using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core
{
    /// <summary>
    /// Enums for the app bar edge
    /// </summary>
    public enum AppBarEdge : int
    {
        Left = 0,
        Top,
        Right,
        Bottom,
        None
    }

    /// <summary>
    /// Class for setting up and maintaining an app bar
    /// See : https://github.com/PhilipRieck/WpfAppBar
    /// See : https://stackoverflow.com/questions/75785/how-do-you-do-appbar-docking-to-screen-edge-like-winamp-in-wpf
    /// </summary>
    public static class AppBarFunctions
    {
        public static AppBarEdge Edge { get; set; } = AppBarEdge.None;
        /// <summary>
        /// Internal class for registration of an app bar
        /// </summary>
        public class RegisterInfo
        {
            public int CallbackId { get; set; }
            public bool IsRegistered { get; set; }
            public Form Window { get; set; }
            public AppBarEdge Edge { get; set; }
            public FormBorderStyle OriginalStyle { get; set; }
            public Point OriginalPosition { get; set; }
            public Size OriginalSize { get; set; }
            public bool OriginalTopmost { get; set; }

            public Rectangle? DockedSize { get; set; }

            /// <summary>
            /// Call back proc for app bar events (like another app bar attached or full screen window started)
            /// </summary>
            public IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam,
                                    IntPtr lParam, ref bool handled)
            {
                Interop.ABState ustate;
                Interop.APPBARDATA abd = new Interop.APPBARDATA();
                abd.hWnd = hwnd;

                if (msg == CallbackId)
                {
                    // https://msdn.microsoft.com/en-us/library/bb776821.aspx

                    if (wParam.ToInt32() == (int)Interop.ABNotify.ABN_STATECHANGE)
                    {
                        ustate = (Interop.ABState)Interop.SHAppBarMessage((int)Interop.ABMsg.ABM_GETSTATE, ref abd);
                        Interop.SetWindowPos(hwnd,
                            ustate.HasFlag(Interop.ABState.ABS_ALWAYSONTOP) ? Interop.HWND_TOPMOST : Interop.HWND_BOTTOM,
                            0, 0, 0, 0, Interop.SetWindowPosFlags.IgnoreMove | Interop.SetWindowPosFlags.IgnoreResize | Interop.SetWindowPosFlags.DoNotActivate);

                        handled = true;
                    }
                    else if (wParam.ToInt32() == (int)Interop.ABNotify.ABN_FULLSCREENAPP)
                    {
                        if (lParam != null)
                        {
                            ustate = (Interop.ABState)Interop.SHAppBarMessage((int)Interop.ABMsg.ABM_GETSTATE, ref abd);
                            Interop.SetWindowPos(hwnd,
                                ustate.HasFlag(Interop.ABState.ABS_ALWAYSONTOP) ? Interop.HWND_TOPMOST : Interop.HWND_BOTTOM,
                                0, 0, 0, 0, Interop.SetWindowPosFlags.IgnoreMove | Interop.SetWindowPosFlags.IgnoreResize | Interop.SetWindowPosFlags.DoNotActivate);
                        }
                        else
                        {
                            ustate = (Interop.ABState)Interop.SHAppBarMessage((int)Interop.ABMsg.ABM_GETSTATE, ref abd);
                            if (ustate.HasFlag(Interop.ABState.ABS_ALWAYSONTOP))
                                Interop.SetWindowPos(hwnd, Interop.HWND_TOPMOST,
                                    0, 0, 0, 0, Interop.SetWindowPosFlags.IgnoreMove | Interop.SetWindowPosFlags.IgnoreResize | Interop.SetWindowPosFlags.DoNotActivate);
                        }
                    }
                    else if (wParam.ToInt32() == (int)Interop.ABNotify.ABN_POSCHANGED)
                    {
                        ABSetPos(this, Window);
                        handled = true;
                    }
                }
                return IntPtr.Zero;
            }

        }

        /// <summary>
        /// Register for all app bars
        /// </summary>
        private static readonly Dictionary<Form, RegisterInfo> RegisteredWindowInfo = new Dictionary<Form, RegisterInfo>();

        /// <summary>
        /// Get the current app bar
        /// </summary>
        /// <param name="appbarWindow"></param>
        /// <returns></returns>
        public static RegisterInfo GetRegisterInfo(Form appbarWindow)
        {
            RegisterInfo reg;
            if (RegisteredWindowInfo.ContainsKey(appbarWindow))
            {
                reg = RegisteredWindowInfo[appbarWindow];
            }
            else
            {
                // Create a new app bar registration
                reg = new RegisterInfo()
                {
                    CallbackId = 0,
                    Window = appbarWindow,
                    IsRegistered = false,
                    Edge = AppBarEdge.Top,
                    OriginalStyle = appbarWindow.FormBorderStyle,
                    OriginalPosition = new Point(appbarWindow.Left, appbarWindow.Top),
                    OriginalSize = appbarWindow.Size,
                    OriginalTopmost = appbarWindow.TopMost,
                    DockedSize = null
                };
                RegisteredWindowInfo.Add(appbarWindow, reg);
            }
            return reg;
        }

        private static void RestoreWindow(Form appbarWindow)
        {
            var info = GetRegisterInfo(appbarWindow);

            appbarWindow.FormBorderStyle = info.OriginalStyle;
            //appbarWindow.ResizeMode = info.OriginalResizeMode;
            appbarWindow.TopMost = info.OriginalTopmost;

            info.DockedSize = null;

            var rect = new Rectangle(info.OriginalPosition.X, info.OriginalPosition.Y,info.OriginalSize.Width, info.OriginalSize.Height);

            appbarWindow.BeginInvoke(new ResizeDelegate(DoResize), appbarWindow, rect);

        }

        public static void SetAppBar(Form appbarWindow, AppBarEdge edge, bool topMost = true)
        {
            // Get the app bar from the form that was passed in
            var info = GetRegisterInfo(appbarWindow);
            info.Edge = edge;
            Edge = edge;

            var appBarData = new Interop.APPBARDATA();
            appBarData.cbSize = Marshal.SizeOf(appBarData);
            appBarData.hWnd = appbarWindow.Handle;

            int renderPolicy;

            // AppBarEdge.None : Remove app bar
            if (edge == AppBarEdge.None)
            {
                if (info.IsRegistered)
                {
                    Interop.SHAppBarMessage((int)Interop.ABMsg.ABM_REMOVE, ref appBarData);
                    info.IsRegistered = false;
                }
                RestoreWindow(appbarWindow);

                // Restore normal desktop window manager attributes
                renderPolicy = (int)Interop.DWMNCRenderingPolicy.UseWindowStyle;

                Interop.DwmSetWindowAttribute(appBarData.hWnd, (int)Interop.DWMWINDOWATTRIBUTE.DWMA_EXCLUDED_FROM_PEEK, ref renderPolicy, sizeof(int));
                Interop.DwmSetWindowAttribute(appBarData.hWnd, (int)Interop.DWMWINDOWATTRIBUTE.DWMA_DISALLOW_PEEK, ref renderPolicy, sizeof(int));

                return;
            }

            if (!info.IsRegistered)
            {
                info.IsRegistered = true;
                info.CallbackId = Interop.RegisterWindowMessage("AppBarMessage");
                appBarData.uCallbackMessage = info.CallbackId;

                var ret = Interop.SHAppBarMessage((int)Interop.ABMsg.ABM_NEW, ref appBarData);

                // Problem : How to hook up a call back proc??
                //var source = HwndSource.FromHwnd(abd.hWnd);
                //source.AddHook(info.WndProc);
            }

            appbarWindow.FormBorderStyle = FormBorderStyle.None;
            appbarWindow.TopMost = topMost;

            // Set desktop window manager attributes to prevent window
            // from being hidden when peeking at the desktop or when
            // the 'show desktop' button is pressed
            renderPolicy = (int)Interop.DWMNCRenderingPolicy.Enabled;

            Interop.DwmSetWindowAttribute(appBarData.hWnd, (int)Interop.DWMWINDOWATTRIBUTE.DWMA_EXCLUDED_FROM_PEEK, ref renderPolicy, sizeof(int));
            Interop.DwmSetWindowAttribute(appBarData.hWnd, (int)Interop.DWMWINDOWATTRIBUTE.DWMA_DISALLOW_PEEK, ref renderPolicy, sizeof(int));

            ABSetPos(info, appbarWindow);
        }

        private delegate void ResizeDelegate(Form appbarWindow, Rectangle rect);
        private static void DoResize(Form appbarWindow, Rectangle rect)
        {
            appbarWindow.Width = rect.Width;
            appbarWindow.Height = rect.Height;
            appbarWindow.Top = rect.Top;
            appbarWindow.Left = rect.Left;

            Console.WriteLine("Top : " + rect.Top);
            Console.WriteLine("Left : " + rect.Left);
            Console.WriteLine("Width : " + rect.Width);
            Console.WriteLine("Height : " + rect.Height);
        }

        private static void ABSetPos(RegisterInfo info, Form appbarWindow)
        {
            var edge = info.Edge;
            var barData = new Interop.APPBARDATA();
            barData.cbSize = Marshal.SizeOf(barData);
            barData.hWnd = appbarWindow.Handle;
            barData.uEdge = (int)edge;

            // Transform window size from wpf units (1/96 ") to real pixels, for win32 usage
            var sizeInPixels = appbarWindow.Size;
            // Even if the documentation says SystemParameters.PrimaryScreen{Width, Height} return values in 
            // "pixels", they return wpf units instead.
            var actualWorkArea = GetActualWorkArea(info);
            var screenSizeInPixels = actualWorkArea.Size;
            var workTopLeftInPixels = actualWorkArea.Location;
            var workAreaInPixelsF = new Rectangle(workTopLeftInPixels, screenSizeInPixels);

            if (barData.uEdge == (int)AppBarEdge.Left || barData.uEdge == (int)AppBarEdge.Right)
            {
                barData.rc.top = (int)workAreaInPixelsF.Top;
                barData.rc.bottom = (int)workAreaInPixelsF.Bottom;
                if (barData.uEdge == (int)AppBarEdge.Left)
                {
                    barData.rc.left = (int)workAreaInPixelsF.Left;
                    barData.rc.right = (int)Math.Round(workAreaInPixelsF.Left + (double)sizeInPixels.Width);
                }
                else
                {
                    barData.rc.right = (int)workAreaInPixelsF.Right;
                    barData.rc.left = barData.rc.right - (int)Math.Round((double)sizeInPixels.Width);
                }
            }
            else
            {
                barData.rc.left = (int)workAreaInPixelsF.Left;
                barData.rc.right = (int)workAreaInPixelsF.Right;
                if (barData.uEdge == (int)AppBarEdge.Top)
                {
                    barData.rc.top = (int)workAreaInPixelsF.Top;
                    barData.rc.bottom = (int)Math.Round(workAreaInPixelsF.Top + (double)sizeInPixels.Height);
                }
                else
                {
                    barData.rc.bottom = (int)workAreaInPixelsF.Bottom;
                    barData.rc.top = barData.rc.bottom - (int)Math.Round((double)sizeInPixels.Height);
                }
            }

            Interop.SHAppBarMessage((int)Interop.ABMsg.ABM_QUERYPOS, ref barData);
            Interop.SHAppBarMessage((int)Interop.ABMsg.ABM_SETPOS, ref barData);

            // transform back to wpf units, for wpf window resizing in DoResize. 
            var location = new Point(barData.rc.left, barData.rc.top);
            var dimension = new Size(barData.rc.right - barData.rc.left,
                barData.rc.bottom - barData.rc.top);

            var rect = new Rectangle(location, dimension);
            info.DockedSize = rect;

            //This is done async, because WPF will send a resize after a new appbar is added.  
            //if we size right away, WPFs resize comes last and overrides us.
            appbarWindow.BeginInvoke(new ResizeDelegate(DoResize), appbarWindow, rect);
        }

        private static Rectangle GetActualWorkArea(RegisterInfo info)
        {
            var area = Screen.PrimaryScreen.WorkingArea;

            if (info.DockedSize != null)
            {
                return Rectangle.Union(area, info.DockedSize.Value);
            }
            else
                return area;
        }
    }
}

