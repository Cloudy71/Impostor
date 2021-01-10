using System;
using System.Diagnostics;
using System.Windows.Forms;
using Impostor.Patcher.Shared;
using Impostor.Patcher.Shared.Events;

namespace Impostor.Patcher.WinForms.Forms
{
    public partial class FrmMain : Form
    {
        private readonly Configuration _config;
        private readonly AmongUsModifier _modifier;

        public FrmMain()
        {
            InitializeComponent();

            _config = new Configuration();
            _modifier = new AmongUsModifier();
            _modifier.Error += ModifierOnError;
            _modifier.Saved += ModifierOnSaved;
        }

        private void ModifierOnError(object sender, ErrorEventArgs e)
        {
        }

        private void ModifierOnSaved(object sender, SavedEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await _modifier.SaveIpAsync("128.0.180.18");
            Process.Start("steam://rungameid/945360");
        }
    }
}
