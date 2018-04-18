using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using SoftTeam.SoftBar.Core.SoftBar.Builders;
using System.Drawing.Imaging;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardManager : IDisposable
    {
        #region Fields
        private LimitedStack<ClipboardItem> _clipboard = null;
        private int _maxCapacity = 0;
        private Timer _timer = null;
        private MainAppBarForm _form = null;
        private bool IsClipboardPopupMenuVisible = false;
        private string _dontAddHash = string.Empty;
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

            _timer = new Timer();
            _timer.Tick += new EventHandler(_timer_Elapsed);
            _timer.Interval = 100;
            _timer.Start();
        }
        #endregion

        #region Properties
        public LimitedStack<ClipboardItem> ClipboardList { get => _clipboard; set => _clipboard = value; }
        public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }
        #endregion

        #region Clipboard
        public void ChangeClipboardSize(int newMaxCapacity)
        {
            if (newMaxCapacity == _maxCapacity) return;

            var newStack = new LimitedStack<ClipboardItem>(newMaxCapacity);

            for (int i = 0; i < Math.Min(_clipboard.Count, newMaxCapacity); i++)
                newStack.Push(_clipboard[i]);

            _clipboard = newStack;
            _maxCapacity = newMaxCapacity;
        }

        private void CheckClipboard()
        {
            try
            {
                // Checks if a new item (text or image) has been added
                if (Clipboard.ContainsText())
                    CaptureText();
                else if (Clipboard.ContainsImage())
                    CaptureImage();
            }
            catch
            {
                // Ignore errors 
            }
        }

        private void CaptureImage()
        {
            Image image = Clipboard.GetImage();
            string hash = CalculateHashCode(image);
            // Don't add the image if it is already in the list
            if (image != null && !ContainsHash(hash) && hash != _dontAddHash)
            {
                ClipboardItemImage imageItem = new ClipboardItemImage(image, hash);
                SetAsCurrentlyInClipboard(imageItem);
                ClipboardList.Push(imageItem);
                onClipboardItemAdded();
                _dontAddHash = string.Empty;
            }
        }

        private void CaptureText()
        {
            string text = Clipboard.GetText();
            string hash = CalculateHashCode(text);
            // Don't add the text if it is already in the list
            if (!string.IsNullOrEmpty(text) && !ContainsHash(hash) && hash != _dontAddHash)
            {
                ClipboardItemText textItem = new ClipboardItemText(text, hash);
                SetAsCurrentlyInClipboard(textItem);
                ClipboardList.Push(textItem);
                onClipboardItemAdded();
                _dontAddHash = string.Empty;
            }
        }

        public void SetAsCurrentlyInClipboard(ClipboardItem clipboardItem)
        {
            // Mark all items as not in clipboard...
            foreach (ClipboardItem item in ClipboardList)
                item.CurrentlyInClipboard = false;

            // ...and set this item as CurrentlyInClipboard
            clipboardItem.CurrentlyInClipboard = true;
        }

        private void _timer_Elapsed(object sender, EventArgs e)
        {
            CheckClipboard();
        }

        internal void RemoveClipboardItem(ClipboardItem item)
        {
            // If the clipboard is containing the item we are about to delete, 
            // make sure it is not added again.
            if (isClipboardContaining(item))
                if (item is ClipboardItemText)
                    _dontAddHash = CalculateHashCode(((ClipboardItemText)item).Text);
                else if (item is ClipboardItemImage)
                    _dontAddHash = CalculateHashCode(((ClipboardItemImage)item).Image);

            _clipboard.RemoveItem(item);
        }

        private bool isClipboardContaining(ClipboardItem item)
        {
            if (item is ClipboardItemText)
            {
                if (Clipboard.ContainsText() && Clipboard.GetText() == ((ClipboardItemText)item).Text)
                    return true;
            }
            else if (item is ClipboardItemImage)
            {
                if (Clipboard.ContainsImage() && CompareImages(Clipboard.GetImage(), ((ClipboardItemImage)item).Image))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Compares two images
        /// </summary>
        /// <param name="image1"></param>
        /// <param name="image2"></param>
        /// <returns>True if they are identical</returns>
        private bool CompareImages(Image image1, Image image2)
        {
            if ((image1 == null && image2 != null) || (image1 != null && image2 == null))
                return false;
            if (image1 == null && image2 == null)
                return true;

            Bitmap bmp1 = new Bitmap(image1);
            Bitmap bmp2 = new Bitmap(image2);

            // Test to see if we have the same size of image
            if (bmp1.Size != bmp2.Size)
            {
                return false;
            }

            var rect = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
            var bmpData1 = bmp1.LockBits(rect, ImageLockMode.ReadOnly, bmp1.PixelFormat);

            try
            {
                var bmpData2 = bmp2.LockBits(rect, ImageLockMode.ReadOnly, bmp1.PixelFormat);

                try
                {
                    unsafe
                    {
                        var ptr1 = (byte*)bmpData1.Scan0.ToPointer();
                        var ptr2 = (byte*)bmpData2.Scan0.ToPointer();
                        var width = 3 * rect.Width; // for 24bpp pixel data

                        for (var y = 0; y < rect.Height; y++)
                        {
                            for (var x = 0; x < width; x++)
                            {
                                if (*ptr1 != *ptr2)
                                {
                                    return false;
                                }

                                ptr1++;
                                ptr2++;
                            }

                            ptr1 += bmpData1.Stride - width;
                            ptr2 += bmpData2.Stride - width;
                        }
                    }
                }
                finally
                {
                    bmp2.UnlockBits(bmpData2);
                }
            }
            finally
            {
                bmp1.UnlockBits(bmpData1);
            }

            return true;
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
            _timer.Stop();
            _timer.Dispose();
            _timer = null;
        }
        #endregion

        #region Clipboard hotKey
        public void HotKeyClicked(Point mousePosition)
        {
            if (_form.Manager.SpecialsArea.Menus[0].Item.Opened == true)
                _form.Manager.SpecialsArea.Menus[0].Item.HidePopup();
            else
            {
                // Clear clipboard menu
                _form.Manager.SpecialsArea.Menus.Clear();
                // Rebuild clipboard menu
                var specialsMenuBuilder = new SoftBarSpecialsMenuBuilder(_form.Manager);
                specialsMenuBuilder.Build();
                // Show clipboard menu
                _form.Manager.SpecialsArea.Menus[0].Item.ShowPopup(mousePosition);
            }

            IsClipboardPopupMenuVisible = !IsClipboardPopupMenuVisible;
        }
        #endregion
    }
}
