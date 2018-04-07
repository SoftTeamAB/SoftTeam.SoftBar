using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core
{
    public class AppBarTool
    {

        /// <summary>
        /// Enums for app bar z order positions
        /// </summary>
        public static System.IntPtr HWND_TOP = (System.IntPtr)0;
        public static System.IntPtr HWND_BOTTOM = (System.IntPtr)1;
        public static System.IntPtr HWND_TOPMOST = (System.IntPtr)(-1);
        public static System.IntPtr HWND_NOTOPMOST = (System.IntPtr)(-2);

        /// <summary>
        /// Enums for app bar states
        /// </summary>
        [Flags()]
        internal enum ABState : uint
        {
            ABS_MANUAL = 0x0000,
            ABS_AUTOHIDE = 0x0001,
            ABS_ALWAYSONTOP = 0x0002,
            ABS_AUTOHIDEANDONTOP = 0x0003
        }

        [StructLayout(LayoutKind.Sequential)]
        struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct APPBARDATA
        {
            public int cbSize;
            public IntPtr hWnd;
            public int uCallbackMessage;
            public int uEdge;
            public RECT rc;
            public IntPtr lParam;
        }

        enum ABMsg : int
        {
            ABM_NEW = 0,
            ABM_REMOVE = 1,
            ABM_QUERYPOS = 2,
            ABM_SETPOS = 3,
            ABM_GETSTATE = 4,
            ABM_GETTASKBARPOS = 5,
            ABM_ACTIVATE = 6,
            ABM_GETAUTOHIDEBAR = 7,
            ABM_SETAUTOHIDEBAR = 8,
            ABM_WINDOWPOSCHANGED = 9,
            ABM_SETSTATE = 10
        }

        enum ABNotify : int
        {
            ABN_STATECHANGE = 0,
            ABN_POSCHANGED,
            ABN_FULLSCREENAPP,
            ABN_WINDOWARRANGE
        }

        enum ABEdge : int
        {
            ABE_LEFT = 0,
            ABE_TOP,
            ABE_RIGHT,
            ABE_BOTTOM
        }

        /// <summary>
        /// Enums for Windows positions
        /// </summary>
        [Flags()]
        internal enum SetWindowPosFlags : uint
        {
            /// <summary>If the calling thread and the thread that owns the window are attached to different input queues,
            /// the system posts the request to the thread that owns the window. This prevents the calling thread from
            /// blocking its execution while other threads process the request.</summary>
            /// <remarks>SWP_ASYNCWINDOWPOS</remarks>
            AsynchronousWindowPosition = 0x4000,
            /// <summary>Prevents generation of the WM_SYNCPAINT message.</summary>
            /// <remarks>SWP_DEFERERASE</remarks>
            DeferErase = 0x2000,
            /// <summary>Draws a frame (defined in the window's class description) around the window.</summary>
            /// <remarks>SWP_DRAWFRAME</remarks>
            DrawFrame = 0x0020,
            /// <summary>Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to
            /// the window, even if the window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE
            /// is sent only when the window's size is being changed.</summary>
            /// <remarks>SWP_FRAMECHANGED</remarks>
            FrameChanged = 0x0020,
            /// <summary>Hides the window.</summary>
            /// <remarks>SWP_HIDEWINDOW</remarks>
            HideWindow = 0x0080,
            /// <summary>Does not activate the window. If this flag is not set, the window is activated and moved to the
            /// top of either the topmost or non-topmost group (depending on the setting of the hWndInsertAfter
            /// parameter).</summary>
            /// <remarks>SWP_NOACTIVATE</remarks>
            DoNotActivate = 0x0010,
            /// <summary>Discards the entire contents of the client area. If this flag is not specified, the valid
            /// contents of the client area are saved and copied back into the client area after the window is sized or
            /// repositioned.</summary>
            /// <remarks>SWP_NOCOPYBITS</remarks>
            DoNotCopyBits = 0x0100,
            /// <summary>Retains the current position (ignores X and Y parameters).</summary>
            /// <remarks>SWP_NOMOVE</remarks>
            IgnoreMove = 0x0002,
            /// <summary>Does not change the owner window's position in the Z order.</summary>
            /// <remarks>SWP_NOOWNERZORDER</remarks>
            DoNotChangeOwnerZOrder = 0x0200,
            /// <summary>Does not redraw changes. If this flag is set, no repainting of any kind occurs. This applies to
            /// the client area, the nonclient area (including the title bar and scroll bars), and any part of the parent
            /// window uncovered as a result of the window being moved. When this flag is set, the application must
            /// explicitly invalidate or redraw any parts of the window and parent window that need redrawing.</summary>
            /// <remarks>SWP_NOREDRAW</remarks>
            DoNotRedraw = 0x0008,
            /// <summary>Same as the SWP_NOOWNERZORDER flag.</summary>
            /// <remarks>SWP_NOREPOSITION</remarks>
            DoNotReposition = 0x0200,
            /// <summary>Prevents the window from receiving the WM_WINDOWPOSCHANGING message.</summary>
            /// <remarks>SWP_NOSENDCHANGING</remarks>
            DoNotSendChangingEvent = 0x0400,
            /// <summary>Retains the current size (ignores the cx and cy parameters).</summary>
            /// <remarks>SWP_NOSIZE</remarks>
            IgnoreResize = 0x0001,
            /// <summary>Retains the current Z order (ignores the hWndInsertAfter parameter).</summary>
            /// <remarks>SWP_NOZORDER</remarks>
            IgnoreZOrder = 0x0004,
            /// <summary>Displays the window.</summary>
            /// <remarks>SWP_SHOWWINDOW</remarks>
            ShowWindow = 0x0040,
        }

        private bool fBarRegistered = false;

        [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
        static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);
        [DllImport("USER32")]
        static extern int GetSystemMetrics(int Index);
        [DllImport("User32.dll", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int cx, int cy, bool repaint);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern int RegisterWindowMessage(string msg);
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SetWindowPosFlags uFlags);

        private int uCallBack;

        public AppBarTool()
        {
        }

        public void RegisterBar(Form form)
        {
            form.FormBorderStyle = FormBorderStyle.None;
            APPBARDATA abd = new APPBARDATA();
            abd.cbSize = Marshal.SizeOf(abd);
            abd.hWnd = form.Handle;
            if (!fBarRegistered)
            {
                uCallBack = RegisterWindowMessage("AppBarMessage");
                abd.uCallbackMessage = uCallBack;

                uint ret = SHAppBarMessage((int)ABMsg.ABM_NEW, ref abd);
                fBarRegistered = true;

                ABSetPos(form);
            }
            else
            {
                SHAppBarMessage((int)ABMsg.ABM_REMOVE, ref abd);
                fBarRegistered = false;
            }
        }

        private void ABSetPos(Form form)
        {
            APPBARDATA abd = new APPBARDATA();
            abd.cbSize = Marshal.SizeOf(abd);
            abd.hWnd = form.Handle;
            abd.uEdge = (int)ABEdge.ABE_TOP;

            if (abd.uEdge == (int)ABEdge.ABE_LEFT || abd.uEdge == (int)ABEdge.ABE_RIGHT)
            {
                abd.rc.top = 0;
                abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height;
                if (abd.uEdge == (int)ABEdge.ABE_LEFT)
                {
                    abd.rc.left = 0;
                    abd.rc.right = form.Size.Width;
                }
                else
                {
                    abd.rc.right = SystemInformation.PrimaryMonitorSize.Width;
                    abd.rc.left = abd.rc.right - form.Size.Width;
                }

            }
            else
            {
                abd.rc.left = 0;
                abd.rc.right = SystemInformation.PrimaryMonitorSize.Width;
                if (abd.uEdge == (int)ABEdge.ABE_TOP)
                {
                    abd.rc.top = 0;
                    abd.rc.bottom = form.Size.Height;
                }
                else
                {
                    abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height;
                    abd.rc.top = abd.rc.bottom - form.Size.Height;
                }
            }

            // Query the system for an approved size and position. 
            SHAppBarMessage((int)ABMsg.ABM_QUERYPOS, ref abd);

            // Adjust the rectangle, depending on the edge to which the 
            // appbar is anchored. 
            switch (abd.uEdge)
            {
                case (int)ABEdge.ABE_LEFT:
                    abd.rc.right = abd.rc.left + form.Size.Width;
                    break;
                case (int)ABEdge.ABE_RIGHT:
                    abd.rc.left = abd.rc.right - form.Size.Width;
                    break;
                case (int)ABEdge.ABE_TOP:
                    abd.rc.bottom = abd.rc.top + form.Size.Height;
                    break;
                case (int)ABEdge.ABE_BOTTOM:
                    abd.rc.top = abd.rc.bottom - form.Size.Height;
                    break;
            }

            // Pass the final bounding rectangle to the system. 
            SHAppBarMessage((int)ABMsg.ABM_SETPOS, ref abd);

            // Move and size the appbar so that it conforms to the 
            // bounding rectangle passed to the system. 
            MoveWindow(abd.hWnd, abd.rc.left, abd.rc.top,
                abd.rc.right - abd.rc.left, abd.rc.bottom - abd.rc.top, true);
        }

        public void AlwaysOnTop(Form form, bool onTop)
        {
            APPBARDATA abd = new APPBARDATA();
            abd.cbSize = Marshal.SizeOf(abd);
            abd.hWnd = form.Handle;
            //abd.uEdge = (int)ABEdge.ABE_TOP;

            SetWindowPos(abd.hWnd, onTop ? HWND_TOPMOST : HWND_BOTTOM,
                0, 0, 0, 0, SetWindowPosFlags.IgnoreMove | SetWindowPosFlags.IgnoreResize | SetWindowPosFlags.DoNotActivate);
        }

        public void WndProc(Form form, ref System.Windows.Forms.Message m)
        {
            if (m.Msg == uCallBack)
            {
                APPBARDATA abd = new APPBARDATA();
                abd.cbSize = Marshal.SizeOf(abd);
                abd.hWnd = form.Handle;
                abd.uEdge = (int)ABEdge.ABE_TOP;

                switch (m.WParam.ToInt32())
                {
                    case (int)ABNotify.ABN_STATECHANGE:
                        // Check to see if the taskbar's always-on-top state has changed and, if it has, change the appbar's state 
                        // accordingly. 
                        ABState ustate = (ABState)SHAppBarMessage((int)ABMsg.ABM_GETSTATE, ref abd);

                        SetWindowPos(abd.hWnd, ustate.HasFlag(ABState.ABS_ALWAYSONTOP) ? HWND_TOPMOST : HWND_BOTTOM,
                            0, 0, 0, 0, SetWindowPosFlags.IgnoreMove | SetWindowPosFlags.IgnoreResize | SetWindowPosFlags.DoNotActivate);
                        break;
                    case (int)ABNotify.ABN_FULLSCREENAPP:
                        // A full-screen application has started, or the last full-screen application has closed. Set the appbar's 
                        // z-order appropriately. 
                        if (m.LParam != null)
                        {
                            ustate = (ABState)SHAppBarMessage((int)ABMsg.ABM_GETSTATE, ref abd);
                            SetWindowPos(abd.hWnd,
                                ustate.HasFlag(ABState.ABS_ALWAYSONTOP) ? HWND_TOPMOST : HWND_BOTTOM,
                                0, 0, 0, 0, SetWindowPosFlags.IgnoreMove | SetWindowPosFlags.IgnoreResize | SetWindowPosFlags.DoNotActivate);
                        }
                        else
                        {
                            ustate = (ABState)SHAppBarMessage((int)ABMsg.ABM_GETSTATE, ref abd);
                            if (ustate.HasFlag(ABState.ABS_ALWAYSONTOP))
                                SetWindowPos(abd.hWnd, HWND_TOPMOST,
                                    0, 0, 0, 0, SetWindowPosFlags.IgnoreMove | SetWindowPosFlags.IgnoreResize | SetWindowPosFlags.DoNotActivate);
                        }
                        break;
                    case (int)ABNotify.ABN_POSCHANGED:
                        // The taskbar or another appbar has changed its size or position. 
                        ABSetPos(form);
                        break;
                    case (int)ABNotify.ABN_WINDOWARRANGE:
                        // Notifies an appbar that the user has selected the Cascade, Tile Horizontally, or Tile Vertically command from the taskbar's shortcut menu.
                        // We don't need to implement this, I think
                        break;
                }
            }
        }
    }
}
