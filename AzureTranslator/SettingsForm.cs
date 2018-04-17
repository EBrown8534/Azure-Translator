using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzureTranslator
{
    public partial class SettingsForm : Form
    {
        private Configuration _configuration = new Configuration();

        public SettingsForm(IEnumerable<string> cultures)
        {
            InitializeComponent();

            if (Configuration.Exists(Configuration.DEFAULT_FILE))
            {
                _configuration = Configuration.Load(Configuration.DEFAULT_FILE);
            }

            txtAzureCognitiveServicesTextTranslationApiKey.Text = _configuration.AzureCognitiveServicesTextTranslationApiKey;
            foreach (var culture in cultures)
            {
                lvDisabledLanguages.Items.Add(new ListViewItem(culture) { Selected = _configuration.DisabledLanguages.Contains(culture) });
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _configuration.AzureCognitiveServicesTextTranslationApiKey = txtAzureCognitiveServicesTextTranslationApiKey.Text;
            _configuration.DisabledLanguages = new List<string>();

            foreach (ListViewItem item in lvDisabledLanguages.Items)
            {
                if (item.Selected)
                {
                    _configuration.DisabledLanguages.Add(item.Text);
                }
            }

            Configuration.Save(Configuration.DEFAULT_FILE, _configuration);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
