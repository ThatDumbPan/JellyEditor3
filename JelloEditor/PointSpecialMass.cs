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
    public partial class PointSpecialMass : Form
    {
        float mMass = -1f;

        public PointSpecialMass()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            textBox1.Text = mMass.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = (-1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            mMass = float.Parse(textBox1.Text, CultureInfo.InvariantCulture);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Hide();
        }

        public float Mass
        {
            get { return mMass; }
            set { mMass = value; this.textBox1.Text = mMass.ToString(); }
        }
    }
}