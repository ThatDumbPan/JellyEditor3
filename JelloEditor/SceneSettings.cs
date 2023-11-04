using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace JelloEditor
{
    public partial class SceneSettings : Form
    {
        public string SceneName;
        public string CarName;
        public float CarX;
        public float CarY;

        public float FinishX;
        public float FinishY;

        public float SecretX;
        public float SecretY;

        public float FallLine;

        public SceneSettings()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            textSceneName.Text = SceneName;
            comboCarName.Text = CarName;
            textCarX.Text = CarX.ToString();
            textCarY.Text = CarY.ToString();

            textFinishX.Text = FinishX.ToString();
            textFinishY.Text = FinishY.ToString();

            textSecretX.Text = SecretX.ToString();
            textSecretY.Text = SecretY.ToString();

            textFallLine.Text = FallLine.ToString();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            SceneName = textSceneName.Text;
            CarName = comboCarName.Text;

            float val = 0.0f;
            if (float.TryParse(textCarX.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                CarX = val;

            if (float.TryParse(textCarY.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                CarY = val;

            if (float.TryParse(textFinishX.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                FinishX = val;

            if (float.TryParse(textFinishY.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                FinishY = val;

            if (float.TryParse(textSecretX.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                SecretX = val;

            if (float.TryParse(textSecretY.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                SecretY = val;

            if (float.TryParse(textFallLine.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                FallLine = val;

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }


    }
}