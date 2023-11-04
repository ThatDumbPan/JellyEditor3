namespace JelloEditor
{
    partial class GridSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridSettings));
            this.numericGridDivisions = new System.Windows.Forms.NumericUpDown();
            this.textGridSizeX = new System.Windows.Forms.TextBox();
            this.textGridSizeY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericSubdivisions = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.butOK = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.HelpProvider();
            ((System.ComponentModel.ISupportInitialize)(this.numericGridDivisions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSubdivisions)).BeginInit();
            this.SuspendLayout();
            // 
            // numericGridDivisions
            // 
            this.help.SetHelpString(this.numericGridDivisions, "Sets the space between the major grid lines");
            this.numericGridDivisions.Location = new System.Drawing.Point(161, 36);
            this.numericGridDivisions.Name = "numericGridDivisions";
            this.help.SetShowHelp(this.numericGridDivisions, true);
            this.numericGridDivisions.Size = new System.Drawing.Size(63, 20);
            this.numericGridDivisions.TabIndex = 3;
            // 
            // textGridSizeX
            // 
            this.help.SetHelpString(this.textGridSizeX, "Alters the size of the grid.");
            this.textGridSizeX.Location = new System.Drawing.Point(75, 9);
            this.textGridSizeX.Name = "textGridSizeX";
            this.help.SetShowHelp(this.textGridSizeX, true);
            this.textGridSizeX.Size = new System.Drawing.Size(64, 20);
            this.textGridSizeX.TabIndex = 1;
            // 
            // textGridSizeY
            // 
            this.help.SetHelpString(this.textGridSizeY, "Alters the size of the grid.");
            this.textGridSizeY.Location = new System.Drawing.Point(161, 9);
            this.textGridSizeY.Name = "textGridSizeY";
            this.help.SetShowHelp(this.textGridSizeY, true);
            this.textGridSizeY.Size = new System.Drawing.Size(63, 20);
            this.textGridSizeY.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.help.SetHelpString(this.label1, "Alters the size of the grid.");
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.help.SetShowHelp(this.label1, true);
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Grid Size X";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.help.SetHelpString(this.label2, "Alters the size of the grid.");
            this.label2.Location = new System.Drawing.Point(147, 13);
            this.label2.Name = "label2";
            this.help.SetShowHelp(this.label2, true);
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.help.SetHelpString(this.label3, "Sets the space between the major grid lines");
            this.label3.Location = new System.Drawing.Point(67, 41);
            this.label3.Name = "label3";
            this.help.SetShowHelp(this.label3, true);
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Major Grid Lines";
            // 
            // numericSubdivisions
            // 
            this.help.SetHelpString(this.numericSubdivisions, "Sets the space between the subdivison lines on the grid");
            this.numericSubdivisions.Location = new System.Drawing.Point(161, 63);
            this.numericSubdivisions.Name = "numericSubdivisions";
            this.help.SetShowHelp(this.numericSubdivisions, true);
            this.numericSubdivisions.Size = new System.Drawing.Size(63, 20);
            this.numericSubdivisions.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.help.SetHelpString(this.label4, "Sets the space between the subdivison lines on the grid");
            this.label4.Location = new System.Drawing.Point(63, 70);
            this.label4.Name = "label4";
            this.help.SetShowHelp(this.label4, true);
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Grid Subdivisions";
            // 
            // butOK
            // 
            this.butOK.Location = new System.Drawing.Point(65, 97);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(75, 25);
            this.butOK.TabIndex = 5;
            this.butOK.Text = "OK";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // butCancel
            // 
            this.butCancel.Location = new System.Drawing.Point(146, 97);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 25);
            this.butCancel.TabIndex = 6;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // GridSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 131);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericSubdivisions);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textGridSizeY);
            this.Controls.Add(this.textGridSizeX);
            this.Controls.Add(this.numericGridDivisions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridSettings";
            this.Text = "Grid settings";
            ((System.ComponentModel.ISupportInitialize)(this.numericGridDivisions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericSubdivisions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericGridDivisions;
        private System.Windows.Forms.TextBox textGridSizeX;
        private System.Windows.Forms.TextBox textGridSizeY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericSubdivisions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.HelpProvider help;
    }
}