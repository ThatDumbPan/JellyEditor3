namespace JelloEditor
{
    partial class SceneSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SceneSettings));
            this.textCarX = new System.Windows.Forms.TextBox();
            this.textCarY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textFinishY = new System.Windows.Forms.TextBox();
            this.textFinishX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textFallLine = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textSceneName = new System.Windows.Forms.TextBox();
            this.comboCarName = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textSecretY = new System.Windows.Forms.TextBox();
            this.textSecretX = new System.Windows.Forms.TextBox();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.SuspendLayout();
            // 
            // textCarX
            // 
            this.helpProvider1.SetHelpString(this.textCarX, "Sets the spawn position");
            this.textCarX.Location = new System.Drawing.Point(222, 25);
            this.textCarX.Name = "textCarX";
            this.helpProvider1.SetShowHelp(this.textCarX, true);
            this.textCarX.Size = new System.Drawing.Size(51, 20);
            this.textCarX.TabIndex = 1;
            // 
            // textCarY
            // 
            this.helpProvider1.SetHelpString(this.textCarY, "Sets the spawn position");
            this.textCarY.Location = new System.Drawing.Point(306, 25);
            this.textCarY.Name = "textCarY";
            this.helpProvider1.SetShowHelp(this.textCarY, true);
            this.textCarY.Size = new System.Drawing.Size(51, 20);
            this.textCarY.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label1, "Sets the spawn position");
            this.label1.Location = new System.Drawing.Point(287, 29);
            this.label1.Name = "label1";
            this.helpProvider1.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label2, "Sets the spawn position");
            this.label2.Location = new System.Drawing.Point(203, 28);
            this.label2.Name = "label2";
            this.helpProvider1.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label3, "Sets which car to use while playing the level. It is recommended to set this to \"" +
        "car_and_truck\".");
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.helpProvider1.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Car Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label4, "Sets the spawn position");
            this.label4.Location = new System.Drawing.Point(200, 9);
            this.label4.Name = "label4";
            this.helpProvider1.SetShowHelp(this.label4, true);
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Spawn Position";
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(203, 147);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 23);
            this.butOK.TabIndex = 7;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(288, 147);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 8;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label5, "Sets the goal position. Note that this number is not actually used in JC3.");
            this.label5.Location = new System.Drawing.Point(199, 53);
            this.label5.Name = "label5";
            this.helpProvider1.SetShowHelp(this.label5, true);
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Finish Position";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label6, "Sets the goal position. Note that this number is not actually used in JC3.");
            this.label6.Location = new System.Drawing.Point(203, 71);
            this.label6.Name = "label6";
            this.helpProvider1.SetShowHelp(this.label6, true);
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label7, "Sets the goal position. Note that this number is not actually used in JC3.");
            this.label7.Location = new System.Drawing.Point(287, 72);
            this.label7.Name = "label7";
            this.helpProvider1.SetShowHelp(this.label7, true);
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Y";
            // 
            // textFinishY
            // 
            this.helpProvider1.SetHelpString(this.textFinishY, "Sets the goal position. Note that this number is not actually used in JC3.");
            this.textFinishY.Location = new System.Drawing.Point(306, 68);
            this.textFinishY.Name = "textFinishY";
            this.helpProvider1.SetShowHelp(this.textFinishY, true);
            this.textFinishY.Size = new System.Drawing.Size(51, 20);
            this.textFinishY.TabIndex = 11;
            // 
            // textFinishX
            // 
            this.helpProvider1.SetHelpString(this.textFinishX, "Sets the goal position. Note that this number is not actually used in JC3.");
            this.textFinishX.Location = new System.Drawing.Point(222, 68);
            this.textFinishX.Name = "textFinishX";
            this.helpProvider1.SetShowHelp(this.textFinishX, true);
            this.textFinishX.Size = new System.Drawing.Size(51, 20);
            this.textFinishX.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label8, "Sets the Y position of the fall line.");
            this.label8.Location = new System.Drawing.Point(255, 112);
            this.label8.Name = "label8";
            this.helpProvider1.SetShowHelp(this.label8, true);
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Fall Line";
            // 
            // textFallLine
            // 
            this.helpProvider1.SetHelpString(this.textFallLine, "Sets the Y position of the fall line.");
            this.textFallLine.Location = new System.Drawing.Point(307, 110);
            this.textFallLine.Name = "textFallLine";
            this.helpProvider1.SetShowHelp(this.textFallLine, true);
            this.textFallLine.Size = new System.Drawing.Size(51, 20);
            this.textFallLine.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label9, "Sets the name of the scene");
            this.label9.Location = new System.Drawing.Point(16, 9);
            this.label9.Name = "label9";
            this.helpProvider1.SetShowHelp(this.label9, true);
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Scene Name";
            // 
            // textSceneName
            // 
            this.helpProvider1.SetHelpString(this.textSceneName, "Sets the name of the scene");
            this.textSceneName.Location = new System.Drawing.Point(12, 25);
            this.textSceneName.Name = "textSceneName";
            this.helpProvider1.SetShowHelp(this.textSceneName, true);
            this.textSceneName.Size = new System.Drawing.Size(177, 20);
            this.textSceneName.TabIndex = 17;
            // 
            // comboCarName
            // 
            this.comboCarName.FormattingEnabled = true;
            this.helpProvider1.SetHelpString(this.comboCarName, "Sets which car to use while playing the level. It is recommended to set this to \"" +
        "car_and_truck\".");
            this.comboCarName.Items.AddRange(new object[] {
            "car_and_truck"});
            this.comboCarName.Location = new System.Drawing.Point(12, 69);
            this.comboCarName.Name = "comboCarName";
            this.helpProvider1.SetShowHelp(this.comboCarName, true);
            this.comboCarName.Size = new System.Drawing.Size(177, 21);
            this.comboCarName.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label10, "Sets the secret exit position. Note that this number is not actually used in JC3." +
        "");
            this.label10.Location = new System.Drawing.Point(16, 98);
            this.label10.Name = "label10";
            this.helpProvider1.SetShowHelp(this.label10, true);
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Secret Exit Position";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label11, "Sets the secret exit position. Note that this number is not actually used in JC3." +
        "");
            this.label11.Location = new System.Drawing.Point(16, 116);
            this.label11.Name = "label11";
            this.helpProvider1.SetShowHelp(this.label11, true);
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "X";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.helpProvider1.SetHelpString(this.label12, "Sets the secret exit position. Note that this number is not actually used in JC3." +
        "");
            this.label12.Location = new System.Drawing.Point(101, 116);
            this.label12.Name = "label12";
            this.helpProvider1.SetShowHelp(this.label12, true);
            this.label12.Size = new System.Drawing.Size(14, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Y";
            // 
            // textSecretY
            // 
            this.helpProvider1.SetHelpString(this.textSecretY, "Sets the secret exit position. Note that this number is not actually used in JC3." +
        "");
            this.textSecretY.Location = new System.Drawing.Point(120, 112);
            this.textSecretY.Name = "textSecretY";
            this.helpProvider1.SetShowHelp(this.textSecretY, true);
            this.textSecretY.Size = new System.Drawing.Size(51, 20);
            this.textSecretY.TabIndex = 21;
            // 
            // textSecretX
            // 
            this.helpProvider1.SetHelpString(this.textSecretX, "Sets the secret exit position. Note that this number is not actually used in JC3." +
        "");
            this.textSecretX.Location = new System.Drawing.Point(35, 113);
            this.textSecretX.Name = "textSecretX";
            this.helpProvider1.SetShowHelp(this.textSecretX, true);
            this.textSecretX.Size = new System.Drawing.Size(51, 20);
            this.textSecretX.TabIndex = 20;
            // 
            // SceneSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 182);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textSecretY);
            this.Controls.Add(this.textSecretX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboCarName);
            this.Controls.Add(this.textSceneName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textFallLine);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textFinishY);
            this.Controls.Add(this.textFinishX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textCarY);
            this.Controls.Add(this.textCarX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SceneSettings";
            this.Text = "Scene settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textCarX;
        private System.Windows.Forms.TextBox textCarY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textFinishY;
        private System.Windows.Forms.TextBox textFinishX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textFallLine;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textSceneName;
        private System.Windows.Forms.ComboBox comboCarName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textSecretY;
        private System.Windows.Forms.TextBox textSecretX;
        private System.Windows.Forms.HelpProvider helpProvider1;
    }
}