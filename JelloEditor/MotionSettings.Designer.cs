namespace JelloEditor
{
    partial class MotionSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotionSettings));
            this.checkBoxPlatform = new System.Windows.Forms.CheckBox();
            this.checkBoxMotor = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTriggerBehavior = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textPauseAtEnds = new System.Windows.Forms.TextBox();
            this.numericStartingOffset = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textPlatformLoop = new System.Windows.Forms.TextBox();
            this.textPlatformY = new System.Windows.Forms.TextBox();
            this.textPlatformX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxMotorTriggerBehavior = new System.Windows.Forms.ComboBox();
            this.dataGridViewMotorCommands = new System.Windows.Forms.DataGridView();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.help = new System.Windows.Forms.HelpProvider();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartingOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMotorCommands)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxPlatform
            // 
            this.checkBoxPlatform.AutoSize = true;
            this.help.SetHelpString(this.checkBoxPlatform, "Enables platform motion");
            this.checkBoxPlatform.Location = new System.Drawing.Point(12, 12);
            this.checkBoxPlatform.Name = "checkBoxPlatform";
            this.help.SetShowHelp(this.checkBoxPlatform, true);
            this.checkBoxPlatform.Size = new System.Drawing.Size(99, 17);
            this.checkBoxPlatform.TabIndex = 0;
            this.checkBoxPlatform.Text = "Platform Motion";
            this.checkBoxPlatform.UseVisualStyleBackColor = true;
            this.checkBoxPlatform.CheckedChanged += new System.EventHandler(this.checkBoxPlatform_CheckedChanged);
            // 
            // checkBoxMotor
            // 
            this.checkBoxMotor.AutoSize = true;
            this.help.SetHelpString(this.checkBoxMotor, "Enables MotorCommands for this object.");
            this.checkBoxMotor.Location = new System.Drawing.Point(12, 155);
            this.checkBoxMotor.Name = "checkBoxMotor";
            this.help.SetShowHelp(this.checkBoxMotor, true);
            this.checkBoxMotor.Size = new System.Drawing.Size(53, 17);
            this.checkBoxMotor.TabIndex = 1;
            this.checkBoxMotor.Text = "Motor";
            this.checkBoxMotor.UseVisualStyleBackColor = true;
            this.checkBoxMotor.CheckedChanged += new System.EventHandler(this.checkBoxMotor_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.comboBoxTriggerBehavior);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textPauseAtEnds);
            this.groupBox1.Controls.Add(this.numericStartingOffset);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textPlatformLoop);
            this.groupBox1.Controls.Add(this.textPlatformY);
            this.groupBox1.Controls.Add(this.textPlatformX);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(13, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(325, 111);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Platform Motion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.help.SetHelpString(this.label7, "I THINK this decides weather the object just stops, or loops back to the start wh" +
        "en done with motion. Not completely sure, though.");
            this.label7.Location = new System.Drawing.Point(11, 84);
            this.label7.Name = "label7";
            this.help.SetShowHelp(this.label7, true);
            this.label7.Size = new System.Drawing.Size(85, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Trigger Behavior";
            // 
            // comboBoxTriggerBehavior
            // 
            this.comboBoxTriggerBehavior.FormattingEnabled = true;
            this.help.SetHelpString(this.comboBoxTriggerBehavior, "I THINK this decides weather the object just stops, or loops back to the start wh" +
        "en done with motion. Not completely sure, though.");
            this.comboBoxTriggerBehavior.Items.AddRange(new object[] {
            "Stop",
            "Return To Start"});
            this.comboBoxTriggerBehavior.Location = new System.Drawing.Point(102, 81);
            this.comboBoxTriggerBehavior.Name = "comboBoxTriggerBehavior";
            this.help.SetShowHelp(this.comboBoxTriggerBehavior, true);
            this.comboBoxTriggerBehavior.Size = new System.Drawing.Size(111, 21);
            this.comboBoxTriggerBehavior.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.help.SetHelpString(this.label6, resources.GetString("label6.HelpString"));
            this.label6.Location = new System.Drawing.Point(29, 58);
            this.label6.Name = "label6";
            this.help.SetShowHelp(this.label6, true);
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Pause At Ends";
            // 
            // textPauseAtEnds
            // 
            this.help.SetHelpString(this.textPauseAtEnds, resources.GetString("textPauseAtEnds.HelpString"));
            this.textPauseAtEnds.Location = new System.Drawing.Point(119, 55);
            this.textPauseAtEnds.Name = "textPauseAtEnds";
            this.help.SetShowHelp(this.textPauseAtEnds, true);
            this.textPauseAtEnds.Size = new System.Drawing.Size(38, 20);
            this.textPauseAtEnds.TabIndex = 11;
            // 
            // numericStartingOffset
            // 
            this.numericStartingOffset.DecimalPlaces = 2;
            this.help.SetHelpString(this.numericStartingOffset, "It\'s exactly what it sounds like.");
            this.numericStartingOffset.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericStartingOffset.Location = new System.Drawing.Point(267, 56);
            this.numericStartingOffset.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericStartingOffset.Name = "numericStartingOffset";
            this.help.SetShowHelp(this.numericStartingOffset, true);
            this.numericStartingOffset.Size = new System.Drawing.Size(47, 20);
            this.numericStartingOffset.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.help.SetHelpString(this.label5, "It\'s exactly what it sounds like.");
            this.label5.Location = new System.Drawing.Point(186, 58);
            this.label5.Name = "label5";
            this.help.SetShowHelp(this.label5, true);
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Starting Offset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.help.SetHelpString(this.label2, "The relative position to move the object to");
            this.label2.Location = new System.Drawing.Point(110, 25);
            this.label2.Name = "label2";
            this.help.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.help.SetHelpString(this.label3, "This sets the speed of the moving platform");
            this.label3.Location = new System.Drawing.Point(186, 25);
            this.label3.Name = "label3";
            this.help.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Seconds / Loop";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.help.SetHelpString(this.label1, "The relative position to move the object to");
            this.label1.Location = new System.Drawing.Point(11, 25);
            this.label1.Name = "label1";
            this.help.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Offset  X";
            // 
            // textPlatformLoop
            // 
            this.help.SetHelpString(this.textPlatformLoop, "This sets the speed of the moving platform");
            this.textPlatformLoop.Location = new System.Drawing.Point(276, 22);
            this.textPlatformLoop.Name = "textPlatformLoop";
            this.help.SetShowHelp(this.textPlatformLoop, true);
            this.textPlatformLoop.Size = new System.Drawing.Size(38, 20);
            this.textPlatformLoop.TabIndex = 4;
            // 
            // textPlatformY
            // 
            this.help.SetHelpString(this.textPlatformY, "The relative position to move the object to");
            this.textPlatformY.Location = new System.Drawing.Point(127, 22);
            this.textPlatformY.Name = "textPlatformY";
            this.help.SetShowHelp(this.textPlatformY, true);
            this.textPlatformY.Size = new System.Drawing.Size(38, 20);
            this.textPlatformY.TabIndex = 1;
            // 
            // textPlatformX
            // 
            this.help.SetHelpString(this.textPlatformX, "The relative position to move the object to");
            this.textPlatformX.Location = new System.Drawing.Point(65, 22);
            this.textPlatformX.Name = "textPlatformX";
            this.help.SetShowHelp(this.textPlatformX, true);
            this.textPlatformX.Size = new System.Drawing.Size(38, 20);
            this.textPlatformX.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.help.SetHelpString(this.label8, "I honestly don\'t know what this does yet, as the options are kinda vague. I\'ll ha" +
        "ve to do some testing later.");
            this.label8.Location = new System.Drawing.Point(15, 355);
            this.label8.Name = "label8";
            this.help.SetShowHelp(this.label8, true);
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Trigger Behavior";
            // 
            // comboBoxMotorTriggerBehavior
            // 
            this.comboBoxMotorTriggerBehavior.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxMotorTriggerBehavior.Enabled = false;
            this.comboBoxMotorTriggerBehavior.FormattingEnabled = true;
            this.help.SetHelpString(this.comboBoxMotorTriggerBehavior, "I honestly don\'t know what this does yet, as the options are kinda vague. I\'ll ha" +
        "ve to do some testing later.");
            this.comboBoxMotorTriggerBehavior.Items.AddRange(new object[] {
            "Stop",
            "One Shot"});
            this.comboBoxMotorTriggerBehavior.Location = new System.Drawing.Point(105, 352);
            this.comboBoxMotorTriggerBehavior.Name = "comboBoxMotorTriggerBehavior";
            this.help.SetShowHelp(this.comboBoxMotorTriggerBehavior, true);
            this.comboBoxMotorTriggerBehavior.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMotorTriggerBehavior.TabIndex = 14;
            // 
            // dataGridViewMotorCommands
            // 
            this.dataGridViewMotorCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewMotorCommands.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMotorCommands.Enabled = false;
            this.help.SetHelpString(this.dataGridViewMotorCommands, "Used to create MotorCommands.");
            this.dataGridViewMotorCommands.Location = new System.Drawing.Point(12, 178);
            this.dataGridViewMotorCommands.Name = "dataGridViewMotorCommands";
            this.help.SetShowHelp(this.dataGridViewMotorCommands, true);
            this.dataGridViewMotorCommands.Size = new System.Drawing.Size(423, 168);
            this.dataGridViewMotorCommands.TabIndex = 1;
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Location = new System.Drawing.Point(371, 377);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butOK.Location = new System.Drawing.Point(290, 377);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 5;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.help.SetHelpString(this.checkBox1, "Removes the chain indecator when attached to a trigger");
            this.checkBox1.Location = new System.Drawing.Point(19, 382);
            this.checkBox1.Name = "checkBox1";
            this.help.SetShowHelp(this.checkBox1, true);
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "Remove chain";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // help
            // 
            this.help.Tag = "";
            // 
            // MotionSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 408);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.dataGridViewMotorCommands);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.comboBoxMotorTriggerBehavior);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.checkBoxPlatform);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxMotor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MotionSettings";
            this.Text = "MotionSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericStartingOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMotorCommands)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxPlatform;
        private System.Windows.Forms.CheckBox checkBoxMotor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textPlatformLoop;
        private System.Windows.Forms.TextBox textPlatformY;
        private System.Windows.Forms.TextBox textPlatformX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.NumericUpDown numericStartingOffset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textPauseAtEnds;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxTriggerBehavior;
        public System.Windows.Forms.DataGridView dataGridViewMotorCommands;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxMotorTriggerBehavior;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.HelpProvider help;
    }
}