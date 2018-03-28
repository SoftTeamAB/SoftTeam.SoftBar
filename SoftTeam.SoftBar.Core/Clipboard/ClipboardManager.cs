using SoftTeam.SoftBar.Core.Forms;
using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardManager : IDisposable
    {
        private LimitedStack<ClipboardItem> _clipboard = null;
        private int _maxCapacity = 0;
        private System.Threading.Timer _timer = null;
        private int _lastHash = 0;
        private MainAppBarForm _form = null;

        public event EventHandler ClipboardItemAdded;

        private void onClipboardItemAdded()
        {
            ClipboardItemAdded?.Invoke(this,new EventArgs());
        }

        public ClipboardManager(MainAppBarForm form, int maxCapacity)
        {
            _maxCapacity = maxCapacity;
            _form = form;
            _clipboard = new LimitedStack<ClipboardItem>(_maxCapacity);
            // Setup a timer to check the clipboard for changes
            _timer = new System.Threading.Timer(_timer_Elapsed, null, 0, 100);
        }

        private void CheckClipboard()
        {
            if (Clipboard.ContainsText())
            {
                string text = Clipboard.GetText();
                int hash = text.GetHashCode();
                if (hash != _lastHash)
                {
                    ClipboardItemText textItem = new ClipboardItemText(text);
                    ClipboardList.Push(textItem);
                    onClipboardItemAdded();
                    // PrintClipboardList();
                    _lastHash = hash;
                }
            }
        }
        private void PrintClipboardList()
        {
            int count = 0;
            foreach (ClipboardItemText item in ClipboardList)
                Console.WriteLine($"{count++} : {item.Text}");
        }

        private void _timer_Elapsed(object sender)
        {
            // Force CheckClipboard to execute on the main thread
            // otherwise the Clipboard won't work
            _form.Invoke(new MethodInvoker(() => CheckClipboard()));
        }

        public LimitedStack<ClipboardItem> ClipboardList { get => _clipboard; set => _clipboard = value; }
        public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }

        public void Dispose()
        {
            // The timer must be disposed otherwise the app will crash on shutdown
            _timer.Dispose();
            _timer = null;
        }
    }
}
