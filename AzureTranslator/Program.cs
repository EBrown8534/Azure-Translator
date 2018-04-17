using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureTranslator
{
    static class Program
    {
        public const string MESSAGEBOX_TITLE = "Translation Clipboard Helper";

        private static IEnumerable<string> _cultures = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.SpecificCultures).Select(x => $"{x.Name}: {x.DisplayName}");
        private static KeyboardHookHandler _keyboardHook = new KeyboardHookHandler(_cultures);
        private static NotifyIcon _notifyIcon;
        private static Mutex _sharedMutex = new Mutex();

        private static void _ShowMenuItem_Click(object sender, EventArgs e) => _keyboardHook.ShowWindow();

        private static void _SettingsMenuItem_Click(object sender, EventArgs e)
        {
            var form = new SettingsForm(_cultures);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _keyboardHook.ReloadSettings();
            }
        }

        static void _ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Exit?", MESSAGEBOX_TITLE, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _notifyIcon.Visible = false;
                Application.Exit();
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var bitmap = new Bitmap("Translate Icon.png");

            _sharedMutex.WaitOne();
            MessageBox.Show("Translation Clipboard Helper Started, CTRL+SHIFT+V to use.", MESSAGEBOX_TITLE, MessageBoxButtons.OK);

            var menu = new ContextMenu();
            var showMenuItem = new MenuItem()
            {
                Name = "Show",
                Enabled = true,
                Text = "Show",
                Visible = true
            };
            showMenuItem.Click += _ShowMenuItem_Click;
            menu.MenuItems.Add(showMenuItem);
            var settingsMenuItem = new MenuItem()
            {
                Name = "Settings",
                Enabled = true,
                Text = "Settings",
                Visible = true
            };
            settingsMenuItem.Click += _SettingsMenuItem_Click;
            menu.MenuItems.Add(settingsMenuItem);
            var exitMenuItem = new MenuItem()
            {
                Name = "Exit",
                Enabled = true,
                Text = "Exit",
                Visible = true
            };
            exitMenuItem.Click += _ExitMenuItem_Click;
            menu.MenuItems.Add(exitMenuItem);

            _notifyIcon = new NotifyIcon
            {
                Icon = Icon.FromHandle(bitmap.GetHicon()),
                Text = MESSAGEBOX_TITLE,
                Visible = true,
                ContextMenu = menu
            };

            Application.Run();
            _sharedMutex.ReleaseMutex();
        }
    }
}
