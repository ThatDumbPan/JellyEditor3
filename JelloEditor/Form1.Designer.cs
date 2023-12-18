namespace JelloEditor
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAllstripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAndCompileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decompileAndOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripShowGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleEditorThemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPolysInSceneEditModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aToolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.gridSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sceneSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autocenterObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectMotionSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editSpecialMassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.addNewCircleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jellyCar3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.goalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.secretToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stickyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.balloonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jellyCar2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemstickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemballoonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripMainStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.tabObject = new System.Windows.Forms.TabPage();
            this.groupObjectMode = new System.Windows.Forms.GroupBox();
            this.radioObjectEditPoints = new System.Windows.Forms.RadioButton();
            this.radioObjectSprings = new System.Windows.Forms.RadioButton();
            this.radioObjectPolygons = new System.Windows.Forms.RadioButton();
            this.groupPoints = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textObjectPointMass = new System.Windows.Forms.TextBox();
            this.groupSprings = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textObjectSpringK = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textObjectSpringDamping = new System.Windows.Forms.TextBox();
            this.butObjectSpringSetAll = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textObjectName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textEdgeK = new System.Windows.Forms.TextBox();
            this.textEdgeDamping = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBoxObjectKinematic = new System.Windows.Forms.CheckBox();
            this.butObjectColor = new System.Windows.Forms.Button();
            this.pictureBoxObjectColor = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxObjectShapeMatching = new System.Windows.Forms.CheckBox();
            this.textObjectShapeK = new System.Windows.Forms.TextBox();
            this.textObjectShapeDamping = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxPressureBody = new System.Windows.Forms.CheckBox();
            this.textObjectPressure = new System.Windows.Forms.TextBox();
            this.tabScene = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.butSceneAddObject = new System.Windows.Forms.Button();
            this.butSceneRemoveObject = new System.Windows.Forms.Button();
            this.butSceneNewObject = new System.Windows.Forms.Button();
            this.butSceneCloneObject = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.tabControlSceneObjectSettings = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxClosedPath = new System.Windows.Forms.CheckBox();
            this.buttonAttachObjectToPath = new System.Windows.Forms.Button();
            this.buttonClearPathObjects = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBoxMaterial = new System.Windows.Forms.GroupBox();
            this.numericMaterial = new System.Windows.Forms.NumericUpDown();
            this.labelMaterial = new System.Windows.Forms.Label();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
            this.buttonSceneColor = new System.Windows.Forms.Button();
            this.pictureBoxSceneColor = new System.Windows.Forms.PictureBox();
            this.checkBoxOverrideColor = new System.Windows.Forms.CheckBox();
            this.checkBoxIsTrigger = new System.Windows.Forms.CheckBox();
            this.buttonTriggerTarget = new System.Windows.Forms.Button();
            this.checkBoxTriggerNoCam = new System.Windows.Forms.CheckBox();
            this.groupBoxTransformation = new System.Windows.Forms.GroupBox();
            this.textScenePosY = new System.Windows.Forms.TextBox();
            this.textScenePosX = new System.Windows.Forms.TextBox();
            this.trackSceneAngle = new System.Windows.Forms.TrackBar();
            this.textSceneAngle = new System.Windows.Forms.TextBox();
            this.textSceneScaleY = new System.Windows.Forms.TextBox();
            this.textSceneScaleX = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tabObject.SuspendLayout();
            this.groupObjectMode.SuspendLayout();
            this.groupPoints.SuspendLayout();
            this.groupSprings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabScene.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControlSceneObjectSettings.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBoxMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaterial)).BeginInit();
            this.groupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSceneColor)).BeginInit();
            this.groupBoxTransformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSceneAngle)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.objectToolStripMenuItem,
            this.pointToolStripMenuItem,
            this.specialToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(886, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAllstripMenuItem,
            this.saveAndCompileToolStripMenuItem,
            this.decompileAndOpenToolStripMenuItem,
            this.toolStripMenuItem2,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loadToolStripMenuItem.Image")));
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.loadToolStripMenuItem.Text = "&Open";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAllstripMenuItem
            // 
            this.saveAllstripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAllstripMenuItem.Image")));
            this.saveAllstripMenuItem.Name = "saveAllstripMenuItem";
            this.saveAllstripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAllstripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.saveAllstripMenuItem.Text = "Save All";
            this.saveAllstripMenuItem.Click += new System.EventHandler(this.saveAllstripMenuItem_Click);
            // 
            // saveAndCompileToolStripMenuItem
            // 
            this.saveAndCompileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAndCompileToolStripMenuItem.Image")));
            this.saveAndCompileToolStripMenuItem.Name = "saveAndCompileToolStripMenuItem";
            this.saveAndCompileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAndCompileToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.saveAndCompileToolStripMenuItem.Text = "Compile and save";
            this.saveAndCompileToolStripMenuItem.Click += new System.EventHandler(this.saveAndCompileToolStripMenuItem_Click);
            // 
            // decompileAndOpenToolStripMenuItem
            // 
            this.decompileAndOpenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("decompileAndOpenToolStripMenuItem.Image")));
            this.decompileAndOpenToolStripMenuItem.Name = "decompileAndOpenToolStripMenuItem";
            this.decompileAndOpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.O)));
            this.decompileAndOpenToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.decompileAndOpenToolStripMenuItem.Text = "Decompile and open";
            this.decompileAndOpenToolStripMenuItem.Click += new System.EventHandler(this.decompileAndOpenToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(279, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(282, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShowGrid,
            this.toggleEditorThemeToolStripMenuItem,
            this.drawPolysInSceneEditModeToolStripMenuItem,
            this.snapToolStripMenuItem,
            this.aToolStripMenuItem1,
            this.gridSetupToolStripMenuItem,
            this.sceneSettingsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // toolStripShowGrid
            // 
            this.toolStripShowGrid.Checked = true;
            this.toolStripShowGrid.CheckOnClick = true;
            this.toolStripShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripShowGrid.Name = "toolStripShowGrid";
            this.toolStripShowGrid.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.toolStripShowGrid.Size = new System.Drawing.Size(192, 22);
            this.toolStripShowGrid.Text = "Show grid";
            this.toolStripShowGrid.Click += new System.EventHandler(this.toolStripShowGrid_Click);
            // 
            // toggleEditorThemeToolStripMenuItem
            // 
            this.toggleEditorThemeToolStripMenuItem.Name = "toggleEditorThemeToolStripMenuItem";
            this.toggleEditorThemeToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.toggleEditorThemeToolStripMenuItem.Text = "Toggle editor theme";
            this.toggleEditorThemeToolStripMenuItem.Click += new System.EventHandler(this.toggleEditorThemeToolStripMenuItem_Click);
            // 
            // drawPolysInSceneEditModeToolStripMenuItem
            // 
            this.drawPolysInSceneEditModeToolStripMenuItem.CheckOnClick = true;
            this.drawPolysInSceneEditModeToolStripMenuItem.Name = "drawPolysInSceneEditModeToolStripMenuItem";
            this.drawPolysInSceneEditModeToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.drawPolysInSceneEditModeToolStripMenuItem.Text = "Always draw polygons";
            this.drawPolysInSceneEditModeToolStripMenuItem.Click += new System.EventHandler(this.drawPolysInSceneEditModeToolStripMenuItem_Click);
            // 
            // snapToolStripMenuItem
            // 
            this.snapToolStripMenuItem.CheckOnClick = true;
            this.snapToolStripMenuItem.Name = "snapToolStripMenuItem";
            this.snapToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.snapToolStripMenuItem.Text = "Snap to grid";
            this.snapToolStripMenuItem.Visible = false;
            // 
            // aToolStripMenuItem1
            // 
            this.aToolStripMenuItem1.Name = "aToolStripMenuItem1";
            this.aToolStripMenuItem1.Size = new System.Drawing.Size(189, 6);
            // 
            // gridSetupToolStripMenuItem
            // 
            this.gridSetupToolStripMenuItem.Name = "gridSetupToolStripMenuItem";
            this.gridSetupToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.gridSetupToolStripMenuItem.Text = "Grid settings...";
            this.gridSetupToolStripMenuItem.Click += new System.EventHandler(this.gridSetupToolStripMenuItem_Click);
            // 
            // sceneSettingsToolStripMenuItem
            // 
            this.sceneSettingsToolStripMenuItem.Name = "sceneSettingsToolStripMenuItem";
            this.sceneSettingsToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.sceneSettingsToolStripMenuItem.Text = "Scene settings...";
            this.sceneSettingsToolStripMenuItem.Click += new System.EventHandler(this.sceneSettingsToolStripMenuItem_Click);
            // 
            // objectToolStripMenuItem
            // 
            this.objectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autocenterObjectToolStripMenuItem,
            this.objectMotionSettingsToolStripMenuItem});
            this.objectToolStripMenuItem.Name = "objectToolStripMenuItem";
            this.objectToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.objectToolStripMenuItem.Text = "Object";
            this.objectToolStripMenuItem.Visible = false;
            // 
            // autocenterObjectToolStripMenuItem
            // 
            this.autocenterObjectToolStripMenuItem.Name = "autocenterObjectToolStripMenuItem";
            this.autocenterObjectToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.autocenterObjectToolStripMenuItem.Text = "Center points";
            this.autocenterObjectToolStripMenuItem.Click += new System.EventHandler(this.autocenterObjectToolStripMenuItem_Click);
            // 
            // objectMotionSettingsToolStripMenuItem
            // 
            this.objectMotionSettingsToolStripMenuItem.Name = "objectMotionSettingsToolStripMenuItem";
            this.objectMotionSettingsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.objectMotionSettingsToolStripMenuItem.Text = "Object motion settings...";
            this.objectMotionSettingsToolStripMenuItem.Click += new System.EventHandler(this.objectMotionSettingsToolStripMenuItem_Click);
            // 
            // pointToolStripMenuItem
            // 
            this.pointToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editSpecialMassToolStripMenuItem});
            this.pointToolStripMenuItem.Name = "pointToolStripMenuItem";
            this.pointToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.pointToolStripMenuItem.Text = "Point";
            this.pointToolStripMenuItem.Visible = false;
            // 
            // editSpecialMassToolStripMenuItem
            // 
            this.editSpecialMassToolStripMenuItem.Name = "editSpecialMassToolStripMenuItem";
            this.editSpecialMassToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.editSpecialMassToolStripMenuItem.Text = "Edit special mass...";
            this.editSpecialMassToolStripMenuItem.Click += new System.EventHandler(this.editSpecialMassToolStripMenuItem_Click);
            // 
            // specialToolStripMenuItem
            // 
            this.specialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.toolStripSeparator2,
            this.addNewCircleToolStripMenuItem,
            this.addObjectToolStripMenuItem});
            this.specialToolStripMenuItem.Name = "specialToolStripMenuItem";
            this.specialToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.specialToolStripMenuItem.Text = "Other";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(193, 6);
            // 
            // addNewCircleToolStripMenuItem
            // 
            this.addNewCircleToolStripMenuItem.Name = "addNewCircleToolStripMenuItem";
            this.addNewCircleToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addNewCircleToolStripMenuItem.Text = "Add polygon";
            this.addNewCircleToolStripMenuItem.Click += new System.EventHandler(this.addNewCircleToolStripMenuItem_Click);
            // 
            // addObjectToolStripMenuItem
            // 
            this.addObjectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jellyCar3ToolStripMenuItem,
            this.jellyCar2ToolStripMenuItem});
            this.addObjectToolStripMenuItem.Name = "addObjectToolStripMenuItem";
            this.addObjectToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.addObjectToolStripMenuItem.Text = "Add object from preset";
            // 
            // jellyCar3ToolStripMenuItem
            // 
            this.jellyCar3ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goalToolStripMenuItem,
            this.secretToolStripMenuItem,
            this.stickyToolStripMenuItem,
            this.balloonToolStripMenuItem});
            this.jellyCar3ToolStripMenuItem.Name = "jellyCar3ToolStripMenuItem";
            this.jellyCar3ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.jellyCar3ToolStripMenuItem.Text = "JellyCar 3";
            // 
            // goalToolStripMenuItem
            // 
            this.goalToolStripMenuItem.Name = "goalToolStripMenuItem";
            this.goalToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.goalToolStripMenuItem.Text = "goal";
            this.goalToolStripMenuItem.Click += new System.EventHandler(this.goalToolStripMenuItem_Click);
            // 
            // secretToolStripMenuItem
            // 
            this.secretToolStripMenuItem.Name = "secretToolStripMenuItem";
            this.secretToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.secretToolStripMenuItem.Text = "secret";
            this.secretToolStripMenuItem.Click += new System.EventHandler(this.secretToolStripMenuItem_Click);
            // 
            // stickyToolStripMenuItem
            // 
            this.stickyToolStripMenuItem.Name = "stickyToolStripMenuItem";
            this.stickyToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.stickyToolStripMenuItem.Text = "sticky";
            this.stickyToolStripMenuItem.Click += new System.EventHandler(this.stickyToolStripMenuItem_Click);
            // 
            // balloonToolStripMenuItem
            // 
            this.balloonToolStripMenuItem.Name = "balloonToolStripMenuItem";
            this.balloonToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.balloonToolStripMenuItem.Text = "balloon";
            this.balloonToolStripMenuItem.Click += new System.EventHandler(this.balloonToolStripMenuItem_Click);
            // 
            // jellyCar2ToolStripMenuItem
            // 
            this.jellyCar2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemstickToolStripMenuItem,
            this.itemballoonToolStripMenuItem});
            this.jellyCar2ToolStripMenuItem.Name = "jellyCar2ToolStripMenuItem";
            this.jellyCar2ToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.jellyCar2ToolStripMenuItem.Text = "JellyCar 2";
            // 
            // itemstickToolStripMenuItem
            // 
            this.itemstickToolStripMenuItem.Name = "itemstickToolStripMenuItem";
            this.itemstickToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.itemstickToolStripMenuItem.Text = "itemstick";
            this.itemstickToolStripMenuItem.Click += new System.EventHandler(this.itemstickToolStripMenuItem_Click);
            // 
            // itemballoonToolStripMenuItem
            // 
            this.itemballoonToolStripMenuItem.Name = "itemballoonToolStripMenuItem";
            this.itemballoonToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.itemballoonToolStripMenuItem.Text = "itemballoon";
            this.itemballoonToolStripMenuItem.Click += new System.EventHandler(this.itemballoonToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(5, 29);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(9000, 9000);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(15, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(689, 619);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_Resize);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mouseClicked);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMoved);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripMainStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 652);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(886, 23);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBar1.AutoSize = false;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 17);
            // 
            // toolStripMainStatus
            // 
            this.toolStripMainStatus.AutoSize = false;
            this.toolStripMainStatus.Name = "toolStripMainStatus";
            this.toolStripMainStatus.Size = new System.Drawing.Size(700, 18);
            this.toolStripMainStatus.Text = "Welcome to JellyEditor 3, the JellyCar 3 compatible level editor";
            this.toolStripMainStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog1";
            this.openFileDialog2.Multiselect = true;
            // 
            // tabObject
            // 
            this.tabObject.Controls.Add(this.textObjectPressure);
            this.tabObject.Controls.Add(this.textObjectName);
            this.tabObject.Controls.Add(this.checkBoxPressureBody);
            this.tabObject.Controls.Add(this.groupBox3);
            this.tabObject.Controls.Add(this.pictureBoxObjectColor);
            this.tabObject.Controls.Add(this.butObjectColor);
            this.tabObject.Controls.Add(this.checkBoxObjectKinematic);
            this.tabObject.Controls.Add(this.groupBox2);
            this.tabObject.Controls.Add(this.label5);
            this.tabObject.Controls.Add(this.groupSprings);
            this.tabObject.Controls.Add(this.groupPoints);
            this.tabObject.Controls.Add(this.groupObjectMode);
            this.tabObject.Location = new System.Drawing.Point(4, 22);
            this.tabObject.Name = "tabObject";
            this.tabObject.Padding = new System.Windows.Forms.Padding(3);
            this.tabObject.Size = new System.Drawing.Size(177, 593);
            this.tabObject.TabIndex = 1;
            this.tabObject.Text = "Object";
            this.tabObject.UseVisualStyleBackColor = true;
            // 
            // groupObjectMode
            // 
            this.groupObjectMode.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupObjectMode.Controls.Add(this.radioObjectPolygons);
            this.groupObjectMode.Controls.Add(this.radioObjectSprings);
            this.groupObjectMode.Controls.Add(this.radioObjectEditPoints);
            this.groupObjectMode.Location = new System.Drawing.Point(5, 34);
            this.groupObjectMode.Name = "groupObjectMode";
            this.groupObjectMode.Size = new System.Drawing.Size(147, 92);
            this.groupObjectMode.TabIndex = 0;
            this.groupObjectMode.TabStop = false;
            this.groupObjectMode.Text = "Object Edit Mode";
            // 
            // radioObjectEditPoints
            // 
            this.radioObjectEditPoints.AutoSize = true;
            this.radioObjectEditPoints.Checked = true;
            this.radioObjectEditPoints.Location = new System.Drawing.Point(12, 21);
            this.radioObjectEditPoints.Name = "radioObjectEditPoints";
            this.radioObjectEditPoints.Size = new System.Drawing.Size(54, 17);
            this.radioObjectEditPoints.TabIndex = 0;
            this.radioObjectEditPoints.TabStop = true;
            this.radioObjectEditPoints.Text = "Points";
            this.radioObjectEditPoints.UseVisualStyleBackColor = true;
            this.radioObjectEditPoints.CheckedChanged += new System.EventHandler(this.radioObject_CheckedChanged);
            // 
            // radioObjectSprings
            // 
            this.radioObjectSprings.AutoSize = true;
            this.radioObjectSprings.Location = new System.Drawing.Point(12, 43);
            this.radioObjectSprings.Name = "radioObjectSprings";
            this.radioObjectSprings.Size = new System.Drawing.Size(98, 17);
            this.radioObjectSprings.TabIndex = 1;
            this.radioObjectSprings.TabStop = true;
            this.radioObjectSprings.Text = "Internal Springs";
            this.radioObjectSprings.UseVisualStyleBackColor = true;
            this.radioObjectSprings.CheckedChanged += new System.EventHandler(this.radioObject_CheckedChanged);
            // 
            // radioObjectPolygons
            // 
            this.radioObjectPolygons.AutoSize = true;
            this.radioObjectPolygons.Location = new System.Drawing.Point(12, 64);
            this.radioObjectPolygons.Name = "radioObjectPolygons";
            this.radioObjectPolygons.Size = new System.Drawing.Size(68, 17);
            this.radioObjectPolygons.TabIndex = 2;
            this.radioObjectPolygons.TabStop = true;
            this.radioObjectPolygons.Text = "Polygons";
            this.radioObjectPolygons.UseVisualStyleBackColor = true;
            this.radioObjectPolygons.CheckedChanged += new System.EventHandler(this.radioObject_CheckedChanged);
            // 
            // groupPoints
            // 
            this.groupPoints.Controls.Add(this.textObjectPointMass);
            this.groupPoints.Controls.Add(this.label2);
            this.groupPoints.Location = new System.Drawing.Point(6, 131);
            this.groupPoints.Name = "groupPoints";
            this.groupPoints.Size = new System.Drawing.Size(145, 49);
            this.groupPoints.TabIndex = 1;
            this.groupPoints.TabStop = false;
            this.groupPoints.Text = "Point Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mass Per Point";
            // 
            // textObjectPointMass
            // 
            this.textObjectPointMass.Location = new System.Drawing.Point(95, 18);
            this.textObjectPointMass.Name = "textObjectPointMass";
            this.textObjectPointMass.Size = new System.Drawing.Size(45, 20);
            this.textObjectPointMass.TabIndex = 3;
            this.textObjectPointMass.TextChanged += new System.EventHandler(this.textObjectPointMass_TextChanged);
            // 
            // groupSprings
            // 
            this.groupSprings.Controls.Add(this.butObjectSpringSetAll);
            this.groupSprings.Controls.Add(this.textObjectSpringDamping);
            this.groupSprings.Controls.Add(this.label4);
            this.groupSprings.Controls.Add(this.textObjectSpringK);
            this.groupSprings.Controls.Add(this.label3);
            this.groupSprings.Location = new System.Drawing.Point(6, 182);
            this.groupSprings.Name = "groupSprings";
            this.groupSprings.Size = new System.Drawing.Size(145, 111);
            this.groupSprings.TabIndex = 2;
            this.groupSprings.TabStop = false;
            this.groupSprings.Text = "Spring Settings";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Spring K";
            // 
            // textObjectSpringK
            // 
            this.textObjectSpringK.Location = new System.Drawing.Point(64, 20);
            this.textObjectSpringK.Name = "textObjectSpringK";
            this.textObjectSpringK.Size = new System.Drawing.Size(72, 20);
            this.textObjectSpringK.TabIndex = 1;
            this.textObjectSpringK.Text = "100";
            this.textObjectSpringK.TextChanged += new System.EventHandler(this.textObjectSpring_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Damping";
            // 
            // textObjectSpringDamping
            // 
            this.textObjectSpringDamping.Location = new System.Drawing.Point(64, 48);
            this.textObjectSpringDamping.Name = "textObjectSpringDamping";
            this.textObjectSpringDamping.Size = new System.Drawing.Size(72, 20);
            this.textObjectSpringDamping.TabIndex = 3;
            this.textObjectSpringDamping.Text = "10";
            this.textObjectSpringDamping.TextChanged += new System.EventHandler(this.textObjectSpring_TextChanged);
            // 
            // butObjectSpringSetAll
            // 
            this.butObjectSpringSetAll.Location = new System.Drawing.Point(11, 75);
            this.butObjectSpringSetAll.Name = "butObjectSpringSetAll";
            this.butObjectSpringSetAll.Size = new System.Drawing.Size(125, 27);
            this.butObjectSpringSetAll.TabIndex = 5;
            this.butObjectSpringSetAll.Text = "Set All";
            this.butObjectSpringSetAll.UseVisualStyleBackColor = true;
            this.butObjectSpringSetAll.Click += new System.EventHandler(this.butObjectSpringSetAll_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Name";
            // 
            // textObjectName
            // 
            this.textObjectName.Location = new System.Drawing.Point(45, 9);
            this.textObjectName.Name = "textObjectName";
            this.textObjectName.Size = new System.Drawing.Size(105, 20);
            this.textObjectName.TabIndex = 4;
            this.textObjectName.Leave += new System.EventHandler(this.textObjectName_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textEdgeDamping);
            this.groupBox2.Controls.Add(this.textEdgeK);
            this.groupBox2.Location = new System.Drawing.Point(6, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 78);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Edge Settings";
            // 
            // textEdgeK
            // 
            this.textEdgeK.Location = new System.Drawing.Point(64, 21);
            this.textEdgeK.Name = "textEdgeK";
            this.textEdgeK.Size = new System.Drawing.Size(71, 20);
            this.textEdgeK.TabIndex = 0;
            this.textEdgeK.Text = "100";
            this.textEdgeK.TextChanged += new System.EventHandler(this.textEdgeK_TextChanged);
            // 
            // textEdgeDamping
            // 
            this.textEdgeDamping.Location = new System.Drawing.Point(63, 49);
            this.textEdgeDamping.Name = "textEdgeDamping";
            this.textEdgeDamping.Size = new System.Drawing.Size(72, 20);
            this.textEdgeDamping.TabIndex = 1;
            this.textEdgeDamping.Text = "1";
            this.textEdgeDamping.TextChanged += new System.EventHandler(this.textEdgeDamping_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Spring K";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Damping";
            // 
            // checkBoxObjectKinematic
            // 
            this.checkBoxObjectKinematic.AutoSize = true;
            this.checkBoxObjectKinematic.Location = new System.Drawing.Point(14, 490);
            this.checkBoxObjectKinematic.Name = "checkBoxObjectKinematic";
            this.checkBoxObjectKinematic.Size = new System.Drawing.Size(123, 17);
            this.checkBoxObjectKinematic.TabIndex = 6;
            this.checkBoxObjectKinematic.Text = "Kinematic - fixed pos";
            this.checkBoxObjectKinematic.UseVisualStyleBackColor = true;
            this.checkBoxObjectKinematic.CheckedChanged += new System.EventHandler(this.checkBoxObjectKinematic_CheckedChanged);
            // 
            // butObjectColor
            // 
            this.butObjectColor.Location = new System.Drawing.Point(63, 513);
            this.butObjectColor.Name = "butObjectColor";
            this.butObjectColor.Size = new System.Drawing.Size(88, 27);
            this.butObjectColor.TabIndex = 7;
            this.butObjectColor.Text = "Color...";
            this.butObjectColor.UseVisualStyleBackColor = true;
            this.butObjectColor.Click += new System.EventHandler(this.butObjectColor_Click);
            // 
            // pictureBoxObjectColor
            // 
            this.pictureBoxObjectColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureBoxObjectColor.Location = new System.Drawing.Point(11, 513);
            this.pictureBoxObjectColor.Name = "pictureBoxObjectColor";
            this.pictureBoxObjectColor.Size = new System.Drawing.Size(48, 26);
            this.pictureBoxObjectColor.TabIndex = 8;
            this.pictureBoxObjectColor.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.textObjectShapeDamping);
            this.groupBox3.Controls.Add(this.textObjectShapeK);
            this.groupBox3.Controls.Add(this.checkBoxObjectShapeMatching);
            this.groupBox3.Location = new System.Drawing.Point(5, 377);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(145, 106);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Shape Matching";
            // 
            // checkBoxObjectShapeMatching
            // 
            this.checkBoxObjectShapeMatching.AutoSize = true;
            this.checkBoxObjectShapeMatching.Location = new System.Drawing.Point(11, 20);
            this.checkBoxObjectShapeMatching.Name = "checkBoxObjectShapeMatching";
            this.checkBoxObjectShapeMatching.Size = new System.Drawing.Size(123, 17);
            this.checkBoxObjectShapeMatching.TabIndex = 0;
            this.checkBoxObjectShapeMatching.Text = "Shape Matching ON";
            this.checkBoxObjectShapeMatching.UseVisualStyleBackColor = true;
            this.checkBoxObjectShapeMatching.CheckedChanged += new System.EventHandler(this.checkBoxObjectShapeMatching_CheckedChanged);
            // 
            // textObjectShapeK
            // 
            this.textObjectShapeK.Location = new System.Drawing.Point(69, 45);
            this.textObjectShapeK.Name = "textObjectShapeK";
            this.textObjectShapeK.Size = new System.Drawing.Size(66, 20);
            this.textObjectShapeK.TabIndex = 1;
            this.textObjectShapeK.TextChanged += new System.EventHandler(this.textObjectShapeK_TextChanged);
            // 
            // textObjectShapeDamping
            // 
            this.textObjectShapeDamping.Location = new System.Drawing.Point(70, 76);
            this.textObjectShapeDamping.Name = "textObjectShapeDamping";
            this.textObjectShapeDamping.Size = new System.Drawing.Size(66, 20);
            this.textObjectShapeDamping.TabIndex = 2;
            this.textObjectShapeDamping.TextChanged += new System.EventHandler(this.textObjectShapeDamping_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.CausesValidation = false;
            this.label10.Location = new System.Drawing.Point(19, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Spring K";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Damping";
            // 
            // checkBoxPressureBody
            // 
            this.checkBoxPressureBody.AutoSize = true;
            this.checkBoxPressureBody.Location = new System.Drawing.Point(11, 551);
            this.checkBoxPressureBody.Name = "checkBoxPressureBody";
            this.checkBoxPressureBody.Size = new System.Drawing.Size(91, 17);
            this.checkBoxPressureBody.TabIndex = 10;
            this.checkBoxPressureBody.Text = "PressureBody";
            this.checkBoxPressureBody.UseVisualStyleBackColor = true;
            this.checkBoxPressureBody.CheckedChanged += new System.EventHandler(this.checkBoxPressureBody_CheckedChanged);
            // 
            // textObjectPressure
            // 
            this.textObjectPressure.Location = new System.Drawing.Point(101, 547);
            this.textObjectPressure.Name = "textObjectPressure";
            this.textObjectPressure.Size = new System.Drawing.Size(49, 20);
            this.textObjectPressure.TabIndex = 11;
            this.textObjectPressure.TextChanged += new System.EventHandler(this.textObjectPressure_TextChanged);
            // 
            // tabScene
            // 
            this.tabScene.Controls.Add(this.moveDownButton);
            this.tabScene.Controls.Add(this.moveUpButton);
            this.tabScene.Controls.Add(this.groupBoxTransformation);
            this.tabScene.Controls.Add(this.tabControlSceneObjectSettings);
            this.tabScene.Controls.Add(this.groupBox1);
            this.tabScene.Controls.Add(this.butSceneCloneObject);
            this.tabScene.Controls.Add(this.butSceneNewObject);
            this.tabScene.Controls.Add(this.butSceneRemoveObject);
            this.tabScene.Controls.Add(this.butSceneAddObject);
            this.tabScene.Controls.Add(this.treeView1);
            this.tabScene.Location = new System.Drawing.Point(4, 22);
            this.tabScene.Name = "tabScene";
            this.tabScene.Padding = new System.Windows.Forms.Padding(3);
            this.tabScene.Size = new System.Drawing.Size(177, 593);
            this.tabScene.TabIndex = 0;
            this.tabScene.Text = "Scene";
            this.tabScene.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(2, 1);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(154, 166);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // butSceneAddObject
            // 
            this.butSceneAddObject.Location = new System.Drawing.Point(91, 169);
            this.butSceneAddObject.Name = "butSceneAddObject";
            this.butSceneAddObject.Size = new System.Drawing.Size(82, 25);
            this.butSceneAddObject.TabIndex = 1;
            this.butSceneAddObject.Text = "Import Object";
            this.butSceneAddObject.UseVisualStyleBackColor = true;
            this.butSceneAddObject.Click += new System.EventHandler(this.butSceneAddObject_Click);
            // 
            // butSceneRemoveObject
            // 
            this.butSceneRemoveObject.Enabled = false;
            this.butSceneRemoveObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butSceneRemoveObject.Location = new System.Drawing.Point(91, 197);
            this.butSceneRemoveObject.Name = "butSceneRemoveObject";
            this.butSceneRemoveObject.Size = new System.Drawing.Size(82, 25);
            this.butSceneRemoveObject.TabIndex = 4;
            this.butSceneRemoveObject.Text = "Delete Object";
            this.butSceneRemoveObject.UseVisualStyleBackColor = true;
            this.butSceneRemoveObject.Click += new System.EventHandler(this.butSceneRemoveObject_Click);
            // 
            // butSceneNewObject
            // 
            this.butSceneNewObject.Location = new System.Drawing.Point(6, 169);
            this.butSceneNewObject.Name = "butSceneNewObject";
            this.butSceneNewObject.Size = new System.Drawing.Size(82, 25);
            this.butSceneNewObject.TabIndex = 3;
            this.butSceneNewObject.Text = "New Object";
            this.butSceneNewObject.UseVisualStyleBackColor = true;
            this.butSceneNewObject.Click += new System.EventHandler(this.butSceneNewObject_Click);
            // 
            // butSceneCloneObject
            // 
            this.butSceneCloneObject.Enabled = false;
            this.butSceneCloneObject.Location = new System.Drawing.Point(6, 197);
            this.butSceneCloneObject.Name = "butSceneCloneObject";
            this.butSceneCloneObject.Size = new System.Drawing.Size(82, 25);
            this.butSceneCloneObject.TabIndex = 4;
            this.butSceneCloneObject.Text = "Clone Object";
            this.butSceneCloneObject.UseVisualStyleBackColor = true;
            this.butSceneCloneObject.Click += new System.EventHandler(this.butSceneCloneObject_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(0, 224);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 43);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Object Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Object";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(74, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Path";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // tabControlSceneObjectSettings
            // 
            this.tabControlSceneObjectSettings.Controls.Add(this.tabPage1);
            this.tabControlSceneObjectSettings.Controls.Add(this.tabPage2);
            this.tabControlSceneObjectSettings.Enabled = false;
            this.tabControlSceneObjectSettings.Location = new System.Drawing.Point(0, 269);
            this.tabControlSceneObjectSettings.Name = "tabControlSceneObjectSettings";
            this.tabControlSceneObjectSettings.SelectedIndex = 0;
            this.tabControlSceneObjectSettings.Size = new System.Drawing.Size(177, 200);
            this.tabControlSceneObjectSettings.TabIndex = 9;
            this.tabControlSceneObjectSettings.SelectedIndexChanged += new System.EventHandler(this.tabControlSceneObjectSettings_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonClearPathObjects);
            this.tabPage2.Controls.Add(this.buttonAttachObjectToPath);
            this.tabPage2.Controls.Add(this.checkBoxClosedPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(169, 174);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Path";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxClosedPath
            // 
            this.checkBoxClosedPath.AutoSize = true;
            this.checkBoxClosedPath.Location = new System.Drawing.Point(43, 23);
            this.checkBoxClosedPath.Name = "checkBoxClosedPath";
            this.checkBoxClosedPath.Size = new System.Drawing.Size(83, 17);
            this.checkBoxClosedPath.TabIndex = 0;
            this.checkBoxClosedPath.Text = "Closed Path";
            this.checkBoxClosedPath.UseVisualStyleBackColor = true;
            this.checkBoxClosedPath.CheckedChanged += new System.EventHandler(this.checkBoxClosedPath_CheckedChanged);
            // 
            // buttonAttachObjectToPath
            // 
            this.buttonAttachObjectToPath.Location = new System.Drawing.Point(10, 58);
            this.buttonAttachObjectToPath.Name = "buttonAttachObjectToPath";
            this.buttonAttachObjectToPath.Size = new System.Drawing.Size(142, 23);
            this.buttonAttachObjectToPath.TabIndex = 1;
            this.buttonAttachObjectToPath.Text = "Attach Object...";
            this.buttonAttachObjectToPath.UseVisualStyleBackColor = true;
            this.buttonAttachObjectToPath.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClearPathObjects
            // 
            this.buttonClearPathObjects.Location = new System.Drawing.Point(10, 102);
            this.buttonClearPathObjects.Name = "buttonClearPathObjects";
            this.buttonClearPathObjects.Size = new System.Drawing.Size(142, 23);
            this.buttonClearPathObjects.TabIndex = 2;
            this.buttonClearPathObjects.Text = "Clear Objects";
            this.buttonClearPathObjects.UseVisualStyleBackColor = true;
            this.buttonClearPathObjects.Click += new System.EventHandler(this.buttonClearPathObjects_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBoxSettings);
            this.tabPage1.Controls.Add(this.groupBoxMaterial);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(169, 174);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Scene Object";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBoxMaterial
            // 
            this.groupBoxMaterial.Controls.Add(this.labelMaterial);
            this.groupBoxMaterial.Controls.Add(this.numericMaterial);
            this.groupBoxMaterial.Location = new System.Drawing.Point(6, 6);
            this.groupBoxMaterial.Name = "groupBoxMaterial";
            this.groupBoxMaterial.Size = new System.Drawing.Size(154, 45);
            this.groupBoxMaterial.TabIndex = 7;
            this.groupBoxMaterial.TabStop = false;
            this.groupBoxMaterial.Text = "Material";
            // 
            // numericMaterial
            // 
            this.numericMaterial.Location = new System.Drawing.Point(6, 18);
            this.numericMaterial.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.numericMaterial.Name = "numericMaterial";
            this.numericMaterial.Size = new System.Drawing.Size(43, 20);
            this.numericMaterial.TabIndex = 8;
            this.numericMaterial.ValueChanged += new System.EventHandler(this.numericMaterial_ValueChanged);
            // 
            // labelMaterial
            // 
            this.labelMaterial.AutoSize = true;
            this.labelMaterial.Location = new System.Drawing.Point(55, 22);
            this.labelMaterial.Name = "labelMaterial";
            this.labelMaterial.Size = new System.Drawing.Size(96, 13);
            this.labelMaterial.TabIndex = 9;
            this.labelMaterial.Text = "No object selected";
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.checkBoxTriggerNoCam);
            this.groupBoxSettings.Controls.Add(this.buttonTriggerTarget);
            this.groupBoxSettings.Controls.Add(this.checkBoxIsTrigger);
            this.groupBoxSettings.Controls.Add(this.checkBoxOverrideColor);
            this.groupBoxSettings.Controls.Add(this.pictureBoxSceneColor);
            this.groupBoxSettings.Controls.Add(this.buttonSceneColor);
            this.groupBoxSettings.Location = new System.Drawing.Point(6, 50);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(154, 121);
            this.groupBoxSettings.TabIndex = 9;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // buttonSceneColor
            // 
            this.buttonSceneColor.Location = new System.Drawing.Point(58, 89);
            this.buttonSceneColor.Name = "buttonSceneColor";
            this.buttonSceneColor.Size = new System.Drawing.Size(88, 27);
            this.buttonSceneColor.TabIndex = 9;
            this.buttonSceneColor.Text = "Color...";
            this.buttonSceneColor.UseVisualStyleBackColor = true;
            this.buttonSceneColor.Click += new System.EventHandler(this.buttonSceneColor_Click);
            // 
            // pictureBoxSceneColor
            // 
            this.pictureBoxSceneColor.BackColor = System.Drawing.Color.YellowGreen;
            this.pictureBoxSceneColor.Location = new System.Drawing.Point(6, 89);
            this.pictureBoxSceneColor.Name = "pictureBoxSceneColor";
            this.pictureBoxSceneColor.Size = new System.Drawing.Size(48, 26);
            this.pictureBoxSceneColor.TabIndex = 10;
            this.pictureBoxSceneColor.TabStop = false;
            // 
            // checkBoxOverrideColor
            // 
            this.checkBoxOverrideColor.AutoSize = true;
            this.checkBoxOverrideColor.Location = new System.Drawing.Point(6, 72);
            this.checkBoxOverrideColor.Name = "checkBoxOverrideColor";
            this.checkBoxOverrideColor.Size = new System.Drawing.Size(93, 17);
            this.checkBoxOverrideColor.TabIndex = 11;
            this.checkBoxOverrideColor.Text = "Override Color";
            this.checkBoxOverrideColor.UseVisualStyleBackColor = true;
            this.checkBoxOverrideColor.CheckedChanged += new System.EventHandler(this.checkBoxOverrideColor_CheckedChanged);
            // 
            // checkBoxIsTrigger
            // 
            this.checkBoxIsTrigger.AutoSize = true;
            this.checkBoxIsTrigger.Location = new System.Drawing.Point(6, 19);
            this.checkBoxIsTrigger.Name = "checkBoxIsTrigger";
            this.checkBoxIsTrigger.Size = new System.Drawing.Size(70, 17);
            this.checkBoxIsTrigger.TabIndex = 12;
            this.checkBoxIsTrigger.Text = "Is Trigger";
            this.checkBoxIsTrigger.UseVisualStyleBackColor = true;
            this.checkBoxIsTrigger.CheckedChanged += new System.EventHandler(this.checkBoxIsTrigger_CheckedChanged);
            // 
            // buttonTriggerTarget
            // 
            this.buttonTriggerTarget.Location = new System.Drawing.Point(5, 35);
            this.buttonTriggerTarget.Name = "buttonTriggerTarget";
            this.buttonTriggerTarget.Size = new System.Drawing.Size(140, 27);
            this.buttonTriggerTarget.TabIndex = 13;
            this.buttonTriggerTarget.Text = "Target Object...";
            this.buttonTriggerTarget.UseVisualStyleBackColor = true;
            this.buttonTriggerTarget.Click += new System.EventHandler(this.buttonTriggerTarget_Click);
            // 
            // checkBoxTriggerNoCam
            // 
            this.checkBoxTriggerNoCam.AutoSize = true;
            this.checkBoxTriggerNoCam.Location = new System.Drawing.Point(78, 19);
            this.checkBoxTriggerNoCam.Name = "checkBoxTriggerNoCam";
            this.checkBoxTriggerNoCam.Size = new System.Drawing.Size(79, 17);
            this.checkBoxTriggerNoCam.TabIndex = 14;
            this.checkBoxTriggerNoCam.Text = "No Camera";
            this.checkBoxTriggerNoCam.UseVisualStyleBackColor = true;
            this.checkBoxTriggerNoCam.CheckedChanged += new System.EventHandler(this.checkBoxTriggerNoCam_CheckedChanged);
            // 
            // groupBoxTransformation
            // 
            this.groupBoxTransformation.Controls.Add(this.label8);
            this.groupBoxTransformation.Controls.Add(this.label7);
            this.groupBoxTransformation.Controls.Add(this.label6);
            this.groupBoxTransformation.Controls.Add(this.textSceneScaleX);
            this.groupBoxTransformation.Controls.Add(this.textSceneScaleY);
            this.groupBoxTransformation.Controls.Add(this.textSceneAngle);
            this.groupBoxTransformation.Controls.Add(this.trackSceneAngle);
            this.groupBoxTransformation.Controls.Add(this.textScenePosX);
            this.groupBoxTransformation.Controls.Add(this.textScenePosY);
            this.groupBoxTransformation.Enabled = false;
            this.groupBoxTransformation.Location = new System.Drawing.Point(0, 470);
            this.groupBoxTransformation.Name = "groupBoxTransformation";
            this.groupBoxTransformation.Size = new System.Drawing.Size(177, 124);
            this.groupBoxTransformation.TabIndex = 10;
            this.groupBoxTransformation.TabStop = false;
            this.groupBoxTransformation.Text = "Transformation";
            // 
            // textScenePosY
            // 
            this.textScenePosY.Location = new System.Drawing.Point(110, 19);
            this.textScenePosY.Name = "textScenePosY";
            this.textScenePosY.Size = new System.Drawing.Size(38, 20);
            this.textScenePosY.TabIndex = 2;
            this.textScenePosY.TextChanged += new System.EventHandler(this.textScene_TextChanged);
            // 
            // textScenePosX
            // 
            this.textScenePosX.Location = new System.Drawing.Point(66, 19);
            this.textScenePosX.Name = "textScenePosX";
            this.textScenePosX.Size = new System.Drawing.Size(38, 20);
            this.textScenePosX.TabIndex = 1;
            this.textScenePosX.TextChanged += new System.EventHandler(this.textScene_TextChanged);
            // 
            // trackSceneAngle
            // 
            this.trackSceneAngle.AutoSize = false;
            this.trackSceneAngle.BackColor = System.Drawing.Color.White;
            this.trackSceneAngle.Location = new System.Drawing.Point(66, 69);
            this.trackSceneAngle.Maximum = 360;
            this.trackSceneAngle.Name = "trackSceneAngle";
            this.trackSceneAngle.Size = new System.Drawing.Size(82, 20);
            this.trackSceneAngle.TabIndex = 3;
            this.trackSceneAngle.TabStop = false;
            this.trackSceneAngle.TickFrequency = 45;
            this.trackSceneAngle.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackSceneAngle.ValueChanged += new System.EventHandler(this.trackSceneAngle_ValueChanged);
            // 
            // textSceneAngle
            // 
            this.textSceneAngle.Location = new System.Drawing.Point(110, 46);
            this.textSceneAngle.Name = "textSceneAngle";
            this.textSceneAngle.Size = new System.Drawing.Size(38, 20);
            this.textSceneAngle.TabIndex = 3;
            this.textSceneAngle.TextChanged += new System.EventHandler(this.textScene_TextChanged);
            // 
            // textSceneScaleY
            // 
            this.textSceneScaleY.Location = new System.Drawing.Point(110, 95);
            this.textSceneScaleY.Name = "textSceneScaleY";
            this.textSceneScaleY.Size = new System.Drawing.Size(38, 20);
            this.textSceneScaleY.TabIndex = 5;
            this.textSceneScaleY.TextChanged += new System.EventHandler(this.textScene_TextChanged);
            // 
            // textSceneScaleX
            // 
            this.textSceneScaleX.Location = new System.Drawing.Point(66, 95);
            this.textSceneScaleX.Name = "textSceneScaleX";
            this.textSceneScaleX.Size = new System.Drawing.Size(38, 20);
            this.textSceneScaleX.TabIndex = 4;
            this.textSceneScaleX.TextChanged += new System.EventHandler(this.textScene_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Position";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Scale";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Angle";
            // 
            // moveUpButton
            // 
            this.moveUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveUpButton.Location = new System.Drawing.Point(156, 0);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(20, 85);
            this.moveUpButton.TabIndex = 11;
            this.moveUpButton.Text = "𝝠";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveDownButton.Location = new System.Drawing.Point(156, 84);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(20, 84);
            this.moveDownButton.TabIndex = 12;
            this.moveDownButton.Text = "𝗩";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabScene);
            this.tabControl1.Controls.Add(this.tabObject);
            this.tabControl1.Location = new System.Drawing.Point(700, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(185, 619);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 675);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "JellyEditor 3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabObject.ResumeLayout(false);
            this.tabObject.PerformLayout();
            this.groupObjectMode.ResumeLayout(false);
            this.groupObjectMode.PerformLayout();
            this.groupPoints.ResumeLayout(false);
            this.groupPoints.PerformLayout();
            this.groupSprings.ResumeLayout(false);
            this.groupSprings.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjectColor)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabScene.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControlSceneObjectSettings.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBoxMaterial.ResumeLayout(false);
            this.groupBoxMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMaterial)).EndInit();
            this.groupBoxSettings.ResumeLayout(false);
            this.groupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSceneColor)).EndInit();
            this.groupBoxTransformation.ResumeLayout(false);
            this.groupBoxTransformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackSceneAngle)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }      
        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridSetupToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMainStatus;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveAllstripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snapToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripShowGrid;
        private System.Windows.Forms.ToolStripMenuItem specialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCircleToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem saveAndCompileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator aToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem sceneSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autocenterObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectMotionSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jellyCar2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemstickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemballoonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jellyCar3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem goalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem secretToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stickyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem balloonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem drawPolysInSceneEditModeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.ToolStripMenuItem decompileAndOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editSpecialMassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toggleEditorThemeToolStripMenuItem;
        private System.Windows.Forms.TabPage tabObject;
        private System.Windows.Forms.TextBox textObjectPressure;
        private System.Windows.Forms.TextBox textObjectName;
        private System.Windows.Forms.CheckBox checkBoxPressureBody;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textObjectShapeDamping;
        private System.Windows.Forms.TextBox textObjectShapeK;
        private System.Windows.Forms.CheckBox checkBoxObjectShapeMatching;
        private System.Windows.Forms.PictureBox pictureBoxObjectColor;
        private System.Windows.Forms.Button butObjectColor;
        private System.Windows.Forms.CheckBox checkBoxObjectKinematic;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEdgeDamping;
        private System.Windows.Forms.TextBox textEdgeK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupSprings;
        private System.Windows.Forms.Button butObjectSpringSetAll;
        private System.Windows.Forms.TextBox textObjectSpringDamping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textObjectSpringK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupPoints;
        private System.Windows.Forms.TextBox textObjectPointMass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupObjectMode;
        private System.Windows.Forms.RadioButton radioObjectPolygons;
        private System.Windows.Forms.RadioButton radioObjectSprings;
        private System.Windows.Forms.RadioButton radioObjectEditPoints;
        private System.Windows.Forms.TabPage tabScene;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.GroupBox groupBoxTransformation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textSceneScaleX;
        private System.Windows.Forms.TextBox textSceneScaleY;
        private System.Windows.Forms.TextBox textSceneAngle;
        private System.Windows.Forms.TrackBar trackSceneAngle;
        private System.Windows.Forms.TextBox textScenePosX;
        private System.Windows.Forms.TextBox textScenePosY;
        private System.Windows.Forms.TabControl tabControlSceneObjectSettings;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.CheckBox checkBoxTriggerNoCam;
        private System.Windows.Forms.Button buttonTriggerTarget;
        private System.Windows.Forms.CheckBox checkBoxIsTrigger;
        private System.Windows.Forms.CheckBox checkBoxOverrideColor;
        private System.Windows.Forms.PictureBox pictureBoxSceneColor;
        private System.Windows.Forms.Button buttonSceneColor;
        private System.Windows.Forms.GroupBox groupBoxMaterial;
        private System.Windows.Forms.Label labelMaterial;
        private System.Windows.Forms.NumericUpDown numericMaterial;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonClearPathObjects;
        private System.Windows.Forms.Button buttonAttachObjectToPath;
        private System.Windows.Forms.CheckBox checkBoxClosedPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button butSceneCloneObject;
        private System.Windows.Forms.Button butSceneNewObject;
        private System.Windows.Forms.Button butSceneRemoveObject;
        private System.Windows.Forms.Button butSceneAddObject;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}

