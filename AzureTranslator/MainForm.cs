using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureTranslator
{
    public partial class MainForm : Form
    {
        private string _key;

        public const byte VK_CONTROL = 0x11;
        public const byte VK_V = (byte)'v';
        public const int KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte vk, byte scan, int flags, int extraInfo);
        [DllImport("user32", EntryPoint = "VkKeyScan")]
        public static extern short VkKeyScan(byte charRenamed);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(int hWnd);
        [DllImport("user32.dll")]
        private static extern int SetFocus(int hWnd);

        public string Translation { get; set; }
        public int DestinationLanguageId { get; set; }
        
        public MainForm(string key, string text, int destinationLanguageId, IEnumerable<string> cultures)
        {
            InitializeComponent();
            tbText.Text = text;
            _key = key;

            cbDestinationLanguage.Items.AddRange(cultures.ToArray());
            cbSourceLanguage.SelectedIndex = 0;
            cbDestinationLanguage.SelectedIndex = destinationLanguageId;
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            cbDestinationLanguage.Focus();
        }

        private async void btnTranslate_Click(object sender, EventArgs e)
        {
            DestinationLanguageId = cbDestinationLanguage.SelectedIndex;
            Translation = await AzureTranslateApi.TranslateText(_key, tbText.Text, cbDestinationLanguage.Text.Split(':')[0]);
            DialogResult = DialogResult.OK;
            Close();
        }

        public void SendToClipboard()
        {
            keybd_event(VK_CONTROL, 0, 0, 0);
            keybd_event((byte)VkKeyScan(VK_V), 0, 0, 0);
            keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, 0);
            keybd_event((byte)VkKeyScan(VK_V), 0, KEYEVENTF_KEYUP, 0);
        }
    }
}
