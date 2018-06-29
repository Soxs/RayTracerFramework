namespace OfflineEditor
{
    partial class MainDialog
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.objectList = new System.Windows.Forms.ListView();
            this.m_Count = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_Type = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_Location = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_Radius = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_SurfaceColour = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_Reflectivity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_Transparency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AppearanceBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.formRadius = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.formReflectivity = new System.Windows.Forms.NumericUpDown();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.textColourB = new System.Windows.Forms.TextBox();
            this.textColourG = new System.Windows.Forms.TextBox();
            this.textColourR = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.formTransparancy = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.locationZ = new System.Windows.Forms.TextBox();
            this.locationY = new System.Windows.Forms.TextBox();
            this.locationX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.typeSelection = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cameraZ = new System.Windows.Forms.TextBox();
            this.cameraY = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cameraX = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.useMultiThreading = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.resolutionHeight = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.resolutionWidth = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.numberOfFrames = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.useNotionOfTime = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.AppearanceBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReflectivity)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formTransparancy)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfFrames)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(637, 494);
            this.splitContainer1.SplitterDistance = 171;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(637, 171);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.objectList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(629, 145);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "List View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // objectList
            // 
            this.objectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_Count,
            this.m_Type,
            this.m_Location,
            this.m_Radius,
            this.m_SurfaceColour,
            this.m_Reflectivity,
            this.m_Transparency});
            this.objectList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectList.Location = new System.Drawing.Point(3, 3);
            this.objectList.Name = "objectList";
            this.objectList.Size = new System.Drawing.Size(623, 139);
            this.objectList.TabIndex = 1;
            this.objectList.UseCompatibleStateImageBehavior = false;
            this.objectList.View = System.Windows.Forms.View.Details;
            // 
            // m_Count
            // 
            this.m_Count.Text = "#";
            this.m_Count.Width = 44;
            // 
            // m_Type
            // 
            this.m_Type.Text = "Type";
            this.m_Type.Width = 85;
            // 
            // m_Location
            // 
            this.m_Location.Text = "Location";
            this.m_Location.Width = 120;
            // 
            // m_Radius
            // 
            this.m_Radius.Text = "Radius";
            this.m_Radius.Width = 83;
            // 
            // m_SurfaceColour
            // 
            this.m_SurfaceColour.Text = "Surface Colour";
            this.m_SurfaceColour.Width = 122;
            // 
            // m_Reflectivity
            // 
            this.m_Reflectivity.Text = "Reflectivity";
            this.m_Reflectivity.Width = 73;
            // 
            // m_Transparency
            // 
            this.m_Transparency.Text = "Transparency";
            this.m_Transparency.Width = 80;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(629, 145);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scene View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer2.Size = new System.Drawing.Size(637, 319);
            this.splitContainer2.SplitterDistance = 402;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.AppearanceBox);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.typeSelection);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add To Scene";
            // 
            // AppearanceBox
            // 
            this.AppearanceBox.Controls.Add(this.label10);
            this.AppearanceBox.Controls.Add(this.formRadius);
            this.AppearanceBox.Controls.Add(this.label9);
            this.AppearanceBox.Controls.Add(this.formReflectivity);
            this.AppearanceBox.Controls.Add(this.groupBox4);
            this.AppearanceBox.Controls.Add(this.label5);
            this.AppearanceBox.Controls.Add(this.formTransparancy);
            this.AppearanceBox.Location = new System.Drawing.Point(7, 142);
            this.AppearanceBox.Name = "AppearanceBox";
            this.AppearanceBox.Size = new System.Drawing.Size(389, 131);
            this.AppearanceBox.TabIndex = 4;
            this.AppearanceBox.TabStop = false;
            this.AppearanceBox.Text = "Appearance";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Transparancy";
            // 
            // formRadius
            // 
            this.formRadius.DecimalPlaces = 1;
            this.formRadius.Location = new System.Drawing.Point(258, 36);
            this.formRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.formRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.formRadius.Name = "formRadius";
            this.formRadius.Size = new System.Drawing.Size(120, 20);
            this.formRadius.TabIndex = 7;
            this.formRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(133, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Reflectivity";
            // 
            // formReflectivity
            // 
            this.formReflectivity.DecimalPlaces = 1;
            this.formReflectivity.Location = new System.Drawing.Point(132, 36);
            this.formReflectivity.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.formReflectivity.Name = "formReflectivity";
            this.formReflectivity.Size = new System.Drawing.Size(120, 20);
            this.formReflectivity.TabIndex = 5;
            this.formReflectivity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.textColourB);
            this.groupBox4.Controls.Add(this.textColourG);
            this.groupBox4.Controls.Add(this.textColourR);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(6, 67);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 58);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Surface Colour";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(236, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Colour &Picker...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textColourB
            // 
            this.textColourB.Location = new System.Drawing.Point(162, 32);
            this.textColourB.Name = "textColourB";
            this.textColourB.Size = new System.Drawing.Size(68, 20);
            this.textColourB.TabIndex = 5;
            this.textColourB.Text = "0";
            // 
            // textColourG
            // 
            this.textColourG.Location = new System.Drawing.Point(85, 32);
            this.textColourG.Name = "textColourG";
            this.textColourG.Size = new System.Drawing.Size(71, 20);
            this.textColourG.TabIndex = 4;
            this.textColourG.Text = "0";
            // 
            // textColourR
            // 
            this.textColourR.Location = new System.Drawing.Point(6, 32);
            this.textColourR.Name = "textColourR";
            this.textColourR.Size = new System.Drawing.Size(73, 20);
            this.textColourR.TabIndex = 3;
            this.textColourR.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "B";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(82, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "G";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "R";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Radius";
            // 
            // formTransparancy
            // 
            this.formTransparancy.DecimalPlaces = 2;
            this.formTransparancy.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.formTransparancy.Location = new System.Drawing.Point(6, 36);
            this.formTransparancy.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.formTransparancy.Name = "formTransparancy";
            this.formTransparancy.Size = new System.Drawing.Size(120, 20);
            this.formTransparancy.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.locationZ);
            this.groupBox3.Controls.Add(this.locationY);
            this.groupBox3.Controls.Add(this.locationX);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(7, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(389, 64);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Location";
            // 
            // locationZ
            // 
            this.locationZ.Location = new System.Drawing.Point(262, 32);
            this.locationZ.Name = "locationZ";
            this.locationZ.Size = new System.Drawing.Size(122, 20);
            this.locationZ.TabIndex = 5;
            this.locationZ.Text = "0";
            // 
            // locationY
            // 
            this.locationY.Location = new System.Drawing.Point(134, 32);
            this.locationY.Name = "locationY";
            this.locationY.Size = new System.Drawing.Size(122, 20);
            this.locationY.TabIndex = 4;
            this.locationY.Text = "0";
            // 
            // locationX
            // 
            this.locationX.Location = new System.Drawing.Point(6, 32);
            this.locationX.Name = "locationX";
            this.locationX.Size = new System.Drawing.Size(122, 20);
            this.locationX.TabIndex = 3;
            this.locationX.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(131, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Type";
            // 
            // typeSelection
            // 
            this.typeSelection.FormattingEnabled = true;
            this.typeSelection.Items.AddRange(new object[] {
            "Sphere"});
            this.typeSelection.Location = new System.Drawing.Point(6, 44);
            this.typeSelection.Name = "typeSelection";
            this.typeSelection.Size = new System.Drawing.Size(390, 21);
            this.typeSelection.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Location = new System.Drawing.Point(3, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(396, 37);
            this.button1.TabIndex = 0;
            this.button1.Text = "Add To &Scene";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.useNotionOfTime);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.useMultiThreading);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.numberOfFrames);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(231, 319);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cameraZ);
            this.groupBox6.Controls.Add(this.cameraY);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.cameraX);
            this.groupBox6.Controls.Add(this.label15);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Location = new System.Drawing.Point(6, 181);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(213, 69);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Camera Position";
            // 
            // cameraZ
            // 
            this.cameraZ.Location = new System.Drawing.Point(135, 37);
            this.cameraZ.Name = "cameraZ";
            this.cameraZ.Size = new System.Drawing.Size(60, 20);
            this.cameraZ.TabIndex = 11;
            this.cameraZ.Text = "0";
            // 
            // cameraY
            // 
            this.cameraY.Location = new System.Drawing.Point(68, 37);
            this.cameraY.Name = "cameraY";
            this.cameraY.Size = new System.Drawing.Size(61, 20);
            this.cameraY.TabIndex = 10;
            this.cameraY.Text = "0";
            this.cameraY.TextChanged += new System.EventHandler(this.cameraY_TextChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "X";
            // 
            // cameraX
            // 
            this.cameraX.Location = new System.Drawing.Point(9, 37);
            this.cameraX.Name = "cameraX";
            this.cameraX.Size = new System.Drawing.Size(53, 20);
            this.cameraX.TabIndex = 9;
            this.cameraX.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(68, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 13);
            this.label15.TabIndex = 7;
            this.label15.Text = "Y";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(132, 21);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Z";
            // 
            // useMultiThreading
            // 
            this.useMultiThreading.AutoSize = true;
            this.useMultiThreading.Checked = true;
            this.useMultiThreading.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useMultiThreading.Location = new System.Drawing.Point(7, 256);
            this.useMultiThreading.Name = "useMultiThreading";
            this.useMultiThreading.Size = new System.Drawing.Size(95, 17);
            this.useMultiThreading.TabIndex = 4;
            this.useMultiThreading.Text = "Multi-threading";
            this.useMultiThreading.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.resolutionHeight);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.resolutionWidth);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Location = new System.Drawing.Point(6, 71);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(213, 104);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Resolution";
            // 
            // resolutionHeight
            // 
            this.resolutionHeight.Location = new System.Drawing.Point(5, 71);
            this.resolutionHeight.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.resolutionHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resolutionHeight.Name = "resolutionHeight";
            this.resolutionHeight.Size = new System.Drawing.Size(202, 20);
            this.resolutionHeight.TabIndex = 11;
            this.resolutionHeight.Value = new decimal(new int[] {
            480,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Width";
            // 
            // resolutionWidth
            // 
            this.resolutionWidth.Location = new System.Drawing.Point(5, 32);
            this.resolutionWidth.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.resolutionWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.resolutionWidth.Name = "resolutionWidth";
            this.resolutionWidth.Size = new System.Drawing.Size(202, 20);
            this.resolutionWidth.TabIndex = 9;
            this.resolutionWidth.Value = new decimal(new int[] {
            640,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 55);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Height";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Number of frames:";
            // 
            // numberOfFrames
            // 
            this.numberOfFrames.Location = new System.Drawing.Point(10, 45);
            this.numberOfFrames.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfFrames.Name = "numberOfFrames";
            this.numberOfFrames.Size = new System.Drawing.Size(209, 20);
            this.numberOfFrames.TabIndex = 1;
            this.numberOfFrames.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 0;
            this.button2.Text = "Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // useNotionOfTime
            // 
            this.useNotionOfTime.AutoSize = true;
            this.useNotionOfTime.Checked = true;
            this.useNotionOfTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useNotionOfTime.Location = new System.Drawing.Point(106, 256);
            this.useNotionOfTime.Name = "useNotionOfTime";
            this.useNotionOfTime.Size = new System.Drawing.Size(91, 17);
            this.useNotionOfTime.TabIndex = 6;
            this.useNotionOfTime.Text = "Notion of time";
            this.useNotionOfTime.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(106, 279);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(113, 37);
            this.button4.TabIndex = 7;
            this.button4.Text = "&Export && &Build";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(637, 494);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Raytracer Offline Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.AppearanceBox.ResumeLayout(false);
            this.AppearanceBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formReflectivity)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.formTransparancy)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resolutionWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfFrames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView objectList;
        private System.Windows.Forms.ColumnHeader m_Count;
        private System.Windows.Forms.ColumnHeader m_Type;
        private System.Windows.Forms.ColumnHeader m_Location;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox typeSelection;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox locationZ;
        private System.Windows.Forms.TextBox locationY;
        private System.Windows.Forms.TextBox locationX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColumnHeader m_Radius;
        private System.Windows.Forms.ColumnHeader m_SurfaceColour;
        private System.Windows.Forms.ColumnHeader m_Reflectivity;
        private System.Windows.Forms.ColumnHeader m_Transparency;
        private System.Windows.Forms.GroupBox AppearanceBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown formRadius;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown formReflectivity;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textColourB;
        private System.Windows.Forms.TextBox textColourG;
        private System.Windows.Forms.TextBox textColourR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown formTransparancy;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numberOfFrames;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown resolutionHeight;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown resolutionWidth;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox useMultiThreading;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox cameraZ;
        private System.Windows.Forms.TextBox cameraY;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox cameraX;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox useNotionOfTime;
        private System.Windows.Forms.Button button4;
    }
}

