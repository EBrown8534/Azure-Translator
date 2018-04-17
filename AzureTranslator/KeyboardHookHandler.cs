using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureTranslator
{
    public class KeyboardHookHandler
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int hookId, KeyboardHookProc callback, IntPtr hInstance, uint threadId);
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);
        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr hookId, int nCode, int wParam, ref KeyboardHookStruct lParam);
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);

        public struct KeyboardHookStruct
        {
            public int VKCode;
            public int ScanCode;
            public int Flags;
            public int Time;
            public int DWExtraInfo;
        }

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_KEYUP = 0x101;
        private const int WM_SYSKEYDOWN = 0x104;
        private const int WM_SYSKEYUP = 0x105;

        private const Keys KEY_LCTRL = Keys.LControlKey;
        private const Keys KEY_RCTRL = Keys.RControlKey;
        private const Keys KEY_LSHIFT = Keys.LShiftKey;
        private const Keys KEY_RSHIFT = Keys.RShiftKey;
        private const Keys KEY_V = Keys.V;

        private delegate int KeyboardHookProc(int code, int wParam, ref KeyboardHookStruct lParam);
        private KeyboardHookProc _keyboardHookProc;
        private IntPtr _hHook = IntPtr.Zero;
        private int _destinationLanguageId = 0;
        private bool _controlPressed = false;
        private bool _shiftPressed = false;
        private bool _vPressed = false;
        private bool _other = false;
        private bool _busy = false;

        private IEnumerable<string> _cultures;
        private Configuration _configuration = new Configuration();

        public KeyboardHookHandler(IEnumerable<string> cultures)
        {
            _cultures = cultures;
            if (Configuration.Exists(Configuration.DEFAULT_FILE))
            {
                _configuration = Configuration.Load(Configuration.DEFAULT_FILE);
            }

            _hookHandler();
        }

        public void ReloadSettings()
        {
            _configuration = Configuration.Load(Configuration.DEFAULT_FILE);
        }

        private bool _hookHandler()
        {
            _keyboardHookProc = new KeyboardHookProc(_wmHandler);
            _hHook = SetWindowsHookEx(WH_KEYBOARD_LL, _keyboardHookProc, LoadLibrary("User32"), 0);
            return _hHook.ToInt32() != 0;
        }
        
        private void _unhookHandler()
        {
            UnhookWindowsHookEx(_hHook);
        }
                
        public void ShowWindow()
        {
            if (string.IsNullOrWhiteSpace(_configuration.AzureCognitiveServicesTextTranslationApiKey))
            {
                MessageBox.Show("You have not entered an Azure Cognitive Services Text Translation API Key, please right-click the icon in the notification tray, select \"Settings\", and provide an appropriate key.", Program.MESSAGEBOX_TITLE, MessageBoxButtons.OK);
                return;
            }

            MainForm form = new MainForm(_configuration.AzureCognitiveServicesTextTranslationApiKey, ClipboardListener.GetClipboardText(), _destinationLanguageId, _cultures.Except(_configuration.DisabledLanguages));
            int x = Control.MousePosition.X - 30; // Offset to button
            int y = Control.MousePosition.Y - 190;

            if (x + form.Width > Screen.PrimaryScreen.Bounds.Width)
            {
                x = Screen.PrimaryScreen.Bounds.Width - form.Width;
            }
            if (y + form.Height > Screen.PrimaryScreen.Bounds.Height)
            {
                y = Screen.PrimaryScreen.Bounds.Height - form.Height;
            }

            form.Location = new Point(x, y);
            if (form.ShowDialog() == DialogResult.OK)
            {
                _destinationLanguageId = form.DestinationLanguageId;
                ClipboardListener.SetClipboardText(form.Translation);
                form.SendToClipboard();
            }
        }

        private int _wmHandler(int code, int wParam, ref KeyboardHookStruct lParam)
        {
            if (_busy) { return 0; } else { _busy = true; }

            if (code >= 0)
            {
                Keys key = (Keys)lParam.VKCode;
                if (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN)
                {
                    switch (key)
                    {
                        case KEY_LCTRL:
                        case KEY_RCTRL:
                            _controlPressed = true;
                            break;
                        case KEY_LSHIFT:
                        case KEY_RSHIFT:
                            _shiftPressed = true;
                            break;
                        case KEY_V:
                            _vPressed = true;
                            break;
                        default:
                            _other = true;
                            break;
                    }
                }
                if (wParam == WM_KEYUP || wParam == WM_SYSKEYDOWN)
                {
                    switch (key)
                    {
                        case KEY_LCTRL:
                        case KEY_RCTRL:
                            _controlPressed = false;
                            break;
                        case KEY_LSHIFT:
                        case KEY_RSHIFT:
                            _shiftPressed = false;
                            break;
                        case KEY_V:
                            _vPressed = false;
                            break;
                        default:
                            _other = true;
                            break;
                    }
                }
                if (_other)
                {
                    _controlPressed = false;
                    _vPressed = false;
                    _shiftPressed = false;
                    _other = false;
                }

                if (_controlPressed && _shiftPressed && _vPressed)
                {
                    _controlPressed = false;
                    _vPressed = false;
                    _shiftPressed = false;

                    ShowWindow();
                    _busy = false;
                    return 0;
                }
            }

            _busy = false;
            return CallNextHookEx(_hHook, code, wParam, ref lParam);
        }

        ~KeyboardHookHandler()
        {
            _unhookHandler();
        }
    }
}
