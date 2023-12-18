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
    public partial class MotionSettings : Form
    {
        public bool PlatformON;
        public float PlatformOffsetX;
        public float PlatformOffsetY;
        public float PlatformLoopLength;
        public float PlatformStartOffset;
        public float PlatformPauseAtEnds;
        public int PlatformTriggerBehavior;
        public bool noRope;

        public bool MotorON;
        public int MotorTriggerBehavior;

        public MotionSettings()
        {
            InitializeComponent();

            // custom stuff.
            dataGridViewMotorCommands.AutoGenerateColumns = false;
            
            DataGridViewComboBoxColumn typeColumn = new DataGridViewComboBoxColumn();
            typeColumn.DataPropertyName = "commandType";
            typeColumn.HeaderText = "Command Type";
            typeColumn.Items.Add("Rotate");
            typeColumn.Items.Add("Wait");
            typeColumn.Items.Add("Move");
            
            DataGridViewTextBoxColumn durColumn = new DataGridViewTextBoxColumn();
            durColumn.DataPropertyName = "duration";
            durColumn.HeaderText = "Duration";

            DataGridViewTextBoxColumn angleColumn = new DataGridViewTextBoxColumn();
            angleColumn.DataPropertyName = "angle";
            angleColumn.HeaderText = "Angle/Direction";

            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn();
            amountColumn.DataPropertyName = "amount";
            amountColumn.HeaderText = "Distance";

            dataGridViewMotorCommands.Columns.Add(typeColumn);
            dataGridViewMotorCommands.Columns.Add(durColumn);
            dataGridViewMotorCommands.Columns.Add(angleColumn);
            dataGridViewMotorCommands.Columns.Add(amountColumn);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // update data.
            checkBoxPlatform.Checked = PlatformON;
            if (PlatformON)
            {
                textPlatformX.Text = PlatformOffsetX.ToString();
                textPlatformY.Text = PlatformOffsetY.ToString();
                textPlatformLoop.Text = PlatformLoopLength.ToString();
                numericStartingOffset.Value = (decimal)PlatformStartOffset;
                textPauseAtEnds.Text = PlatformPauseAtEnds.ToString();
                comboBoxTriggerBehavior.SelectedIndex = PlatformTriggerBehavior;
            }

            checkBoxMotor.Checked = MotorON;
            comboBoxMotorTriggerBehavior.SelectedIndex = MotorTriggerBehavior;
            dataGridViewMotorCommands.Invalidate();

            checkBox1.Checked = noRope;
        }
        private void butOK_Click(object sender, EventArgs e)
        {
            PlatformON = checkBoxPlatform.Checked;
            if (PlatformON)
            {
                float val = 0.0f;
                if (float.TryParse(textPlatformX.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                    PlatformOffsetX = val;

                if (float.TryParse(textPlatformY.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                    PlatformOffsetY = val;

                if (float.TryParse(textPlatformLoop.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                    PlatformLoopLength = val;

                PlatformStartOffset = (float)numericStartingOffset.Value;

                if (float.TryParse(textPauseAtEnds.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out val))
                    PlatformPauseAtEnds = val;

                PlatformTriggerBehavior = comboBoxTriggerBehavior.SelectedIndex;
            }

            MotorON = checkBoxMotor.Checked;
            if (MotorON)
            {
                MotorTriggerBehavior = comboBoxMotorTriggerBehavior.SelectedIndex;
            }

            noRope = checkBox1.Checked;

            DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void checkBoxPlatform_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = checkBoxPlatform.Checked;
        }

        private void checkBoxMotor_CheckedChanged(object sender, EventArgs e)
        {
            comboBoxMotorTriggerBehavior.Enabled = checkBoxMotor.Checked;
            dataGridViewMotorCommands.Enabled = checkBoxMotor.Checked;
            if (checkBoxMotor.Checked)
            {
                dataGridViewMotorCommands.Invalidate();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            noRope = checkBox1.Checked;
        }
    }
}