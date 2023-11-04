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
    public partial class GridSettings : Form
    {
        private Form1 mParent;

        public GridSettings( Form1 parent)
        {
            InitializeComponent();
            mParent = parent;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // update values.
            textGridSizeX.Text = mParent.GridSizeX.ToString();
            textGridSizeY.Text = mParent.GridSizeY.ToString();
            numericGridDivisions.Value = (decimal)mParent.GridMajorSubdivision;
            numericSubdivisions.Value = mParent.GridMinorSubdivision;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void butOK_Click(object sender, EventArgs e)
        {
            // save grid settings here...
            int gs_x = int.Parse(textGridSizeX.Text, CultureInfo.InvariantCulture);
            int gs_y = int.Parse(textGridSizeY.Text, CultureInfo.InvariantCulture);
            float major_sub = (float)numericGridDivisions.Value;
            int minor_sub = (int)numericSubdivisions.Value;

            mParent.updateGridSettings(gs_x, gs_y, major_sub, minor_sub);
            Hide();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}