using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AzureTranslator
{
    public class ClipboardListener
    {
        public const uint GMEM_DDESHARE = 0x2000;
        public const uint GMEM_MOVEABLE = 0x2;
        public const int CLIPBOARD_FORMAT = 13;

        [DllImport("user32.dll")]
        public static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll")]
        public static extern bool EmptyClipboard();
        [DllImport("user32.dll")]
        public static extern IntPtr GetClipboardData(uint uFormat);
        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);
        [DllImport("user32.dll")]
        public static extern bool CloseClipboard();

        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, int size);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalLock(IntPtr hMem);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalUnlock(IntPtr hMem);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GlobalFree(IntPtr hMem);
        [DllImport("kernel32.dll")]
        public static extern UIntPtr GlobalSize(IntPtr hMem);

        public static string GetClipboardText()
        {
            IntPtr hInstance = IntPtr.Zero;
            OpenClipboard(hInstance);
            IntPtr buffer = GetClipboardData(13);
            string text = Marshal.PtrToStringUni(buffer);
            CloseClipboard();
            return text;
        }

        public static bool SetClipboardText(string text)
        {
            if (!OpenClipboard(IntPtr.Zero))
            {
                return false;
            }

            EmptyClipboard();
            IntPtr lockAllocation = GlobalAlloc(GMEM_MOVEABLE | GMEM_DDESHARE, (UIntPtr)(sizeof(char) * (text.Length + 1)));
            IntPtr lockObject;

            try
            {
                lockObject = GlobalLock(lockAllocation);

                if (text.Length > 0)
                {
                    Marshal.Copy(text.ToCharArray(), 0, lockObject, text.Length);
                }
            }
            finally
            {
                GlobalUnlock(lockAllocation);
            }

            SetClipboardData(CLIPBOARD_FORMAT, lockAllocation);

            CloseClipboard();
            return true;
        }

        protected void OnClipboardTextChanged(ClipboardTextChangedEventArgs args)
        {
            var e = ClipboardTextChanged;
            e?.Invoke(this, args);
        }

        public event EventHandler<ClipboardTextChangedEventArgs> ClipboardTextChanged;
    }
}
