using SoftTeam.SoftBar.Core.Misc;
using System;
using System.Windows.Forms;

namespace SoftTeam.SoftBar.Core.ClipboardList
{
    public class ClipboardManager
    {
        private LimitedStack<ClipboardItem> _clipboard = null;
        private int _maxCapacity = 0;
        private System.Timers.Timer _timer = null;
        private int _lastHash = 0;

        public ClipboardManager(int maxCapacity)
        {
            _maxCapacity = maxCapacity;
            _timer = new System.Timers.Timer(500);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Clipboard.ContainsData(DataFormats.Text))
            {
                string text = Clipboard.GetText();
                int hash = text.GetHashCode();
                if (hash != _lastHash)
                {
                    Console.WriteLine("Ny text!");
                    _lastHash = hash;
                }
            }
        }

        public LimitedStack<ClipboardItem> ClipboardList { get => _clipboard; set => _clipboard = value; }
        public int MaxCapacity { get => _maxCapacity; set => _maxCapacity = value; }

        public void AddItem(ClipboardItem item)
        {

        }
    }
}
