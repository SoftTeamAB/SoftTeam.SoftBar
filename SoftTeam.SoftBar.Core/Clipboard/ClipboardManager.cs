using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardManager : IDisposable
    {
        #region Fields
        private LimitedStack<ClipboardItem> _clipboard = null;
        private int _maxCapacity = 0;
        private System.Threading.Timer _timer = null;
        private MainAppBarForm _form = null;
        #endregion

        #region Events
        // Event to notify the app bar to recreate its menus when a new clipboard item is added
        public event EventHandler ClipboardItemAdded;

        private void onClipboardItemAdded()
        {
            ClipboardItemAdded?.Invoke(this, new EventArgs());
        }
        #endregion

        #region Constructor
        public ClipboardManager(MainAppBarForm form, int maxCapacity)
        {
            _maxCapacity = maxCapacity;
            _form = form;
            _clipboard = new LimitedStack<ClipboardItem>(_maxCapacity);
            // Setup a timer to check the clipboard for changes
            _timer = new System.Threading.Timer(_timer_Elapsed, null, 0, 100);
        }
        #endregion

        #region Properties
        public LimitedStack<ClipboardItem> ClipboardList { get => _clipboard; set => _clipboard = value; }
        public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }
        #endregion

        #region Clipboard
        private void CheckClipboard()
        {
            try
            {
                // Checks if a new item (text or image) has been added
                if (Clipboard.ContainsText())
                {
                    string text = Clipboard.GetText();
                    string hash = CalculateHashCode(text);
                    // Don't add the text if it is already in the list
                    if (!ContainsHash(hash))
                    {
                        ClipboardItemText textItem = new ClipboardItemText(text, hash);
                        ClipboardList.Push(textItem);
                        onClipboardItemAdded();
                    }
                }
                else if (Clipboard.ContainsImage())
                {
                    Image image = Clipboard.GetImage();
                    string hash = CalculateHashCode(image);
                    // Don't add the image if it is already in the list
                    if (!ContainsHash(hash))
                    {
                        ClipboardItemImage imageItem = new ClipboardItemImage(image, hash);
                        ClipboardList.Push(imageItem);
                        onClipboardItemAdded();
                    }
                }
            }
            catch
            {
                // Ignore errors 
            }
        }

        private void _timer_Elapsed(object sender)
        {
            try
            {
                // Force CheckClipboard to execute on the main thread
                // otherwise the Clipboard won't work
                if (_form != null && !_form.IsDisposed)
                    _form.Invoke(new MethodInvoker(() => CheckClipboard()));
            }
            catch
            {

            }
        }
        #endregion

        #region Hash
        /// <summary>
        /// Checks if a specific item already exists in the clipboard list
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private bool ContainsHash(string hash)
        {
            foreach (ClipboardItem item in ClipboardList)
                if (item.Hash == hash)
                    return true;

            return false;
        }

        /// <summary>
        /// Calculate hash for an image
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string CalculateHashCode(Image image)
        {
            byte[] hash;
            ImageConverter converter = new ImageConverter();
            byte[] rawImageData = converter.ConvertTo(image, typeof(byte[])) as byte[];

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
                hash = md5.ComputeHash(rawImageData);

            return ConvertHashToString(hash);
        }

        /// <summary>
        /// Calculate hash for a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string CalculateHashCode(string text)
        {
            byte[] hash;
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);

            using (MD5 md5 = System.Security.Cryptography.MD5.Create())
                hash = md5.ComputeHash(inputBytes);

            return ConvertHashToString(hash);
        }

        /// <summary>
        /// Convert hash byte array to a string
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        private static string ConvertHashToString(byte[] hash)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("X2"));

            return sb.ToString();
        }
        #endregion

        #region IDisposable
        public void Dispose()
        {
            // The timer must be disposed otherwise the app will crash on shutdown
            _timer.Change(System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            _timer.Dispose();
            _timer = null;
        }
        #endregion
    }
}
