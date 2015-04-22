/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 1.12.2008
 * Time: 18:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PDFv2
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.conditionL1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.clrFile = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.filecont = new System.Windows.Forms.Label();
			this.results = new System.Windows.Forms.Label();
			this.remFile = new System.Windows.Forms.Button();
			this.listConditions = new System.Windows.Forms.ListBox();
			this.textAddCondition = new System.Windows.Forms.TextBox();
			this.btnAddCondition = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.clrCond = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.rmCond = new System.Windows.Forms.Button();
			this.contains = new System.Windows.Forms.Button();
			this.beginwith = new System.Windows.Forms.Button();
			this.endwith = new System.Windows.Forms.Button();
			this.singleword = new System.Windows.Forms.Button();
			this.condcombo = new System.Windows.Forms.ComboBox();
			this.addc = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Btncon = new System.Windows.Forms.ToolStripMenuItem();
			this.Btndiscon = new System.Windows.Forms.ToolStripMenuItem();
			this.mySqlSetupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.EditorMySqlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.regularExpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listresult = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.showDB = new System.Windows.Forms.Button();
			this.listviewdb = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.addcondfile = new System.Windows.Forms.Button();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.NOcombo = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.compare = new System.Windows.Forms.Button();
			this.BtnSqlEditor = new System.Windows.Forms.Button();
			this.listCompare = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.label4 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(361, 60);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(474, 238);
			this.richTextBox1.TabIndex = 24;
			this.richTextBox1.Text = "";
			// 
			// conditionL1
			// 
			this.conditionL1.Location = new System.Drawing.Point(8, 361);
			this.conditionL1.Name = "conditionL1";
			this.conditionL1.Size = new System.Drawing.Size(100, 23);
			this.conditionL1.TabIndex = 18;
			this.conditionL1.Text = "Conditions:";
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.button1.Location = new System.Drawing.Point(884, 704);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 35);
			this.button1.TabIndex = 8;
			this.button1.Text = "Check PDF";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(260, 60);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "Add File";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 60);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(242, 277);
			this.listBox1.TabIndex = 29;
			this.listBox1.DoubleClick += new System.EventHandler(this.ListBox1DoubleClick);
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1DoubleClick);
			// 
			// clrFile
			// 
			this.clrFile.Location = new System.Drawing.Point(260, 178);
			this.clrFile.Name = "clrFile";
			this.clrFile.Size = new System.Drawing.Size(75, 23);
			this.clrFile.TabIndex = 4;
			this.clrFile.Text = "Clear list";
			this.clrFile.UseVisualStyleBackColor = true;
			this.clrFile.Click += new System.EventHandler(this.clrFileClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 32;
			this.label1.Text = "File list:";
			// 
			// filecont
			// 
			this.filecont.Location = new System.Drawing.Point(361, 34);
			this.filecont.Name = "filecont";
			this.filecont.Size = new System.Drawing.Size(447, 23);
			this.filecont.TabIndex = 33;
			this.filecont.Text = "Content of File_ID:";
			// 
			// results
			// 
			this.results.Location = new System.Drawing.Point(361, 301);
			this.results.Name = "results";
			this.results.Size = new System.Drawing.Size(100, 23);
			this.results.TabIndex = 34;
			this.results.Text = "Results:";
			// 
			// remFile
			// 
			this.remFile.Location = new System.Drawing.Point(260, 116);
			this.remFile.Name = "remFile";
			this.remFile.Size = new System.Drawing.Size(75, 23);
			this.remFile.TabIndex = 3;
			this.remFile.Text = "Remove File";
			this.remFile.UseVisualStyleBackColor = true;
			this.remFile.Click += new System.EventHandler(this.remFileClick);
			// 
			// listConditions
			// 
			this.listConditions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.listConditions.FormattingEnabled = true;
			this.listConditions.Location = new System.Drawing.Point(12, 514);
			this.listConditions.Name = "listConditions";
			this.listConditions.Size = new System.Drawing.Size(242, 225);
			this.listConditions.TabIndex = 38;
			// 
			// textAddCondition
			// 
			this.textAddCondition.HideSelection = false;
			this.textAddCondition.Location = new System.Drawing.Point(8, 387);
			this.textAddCondition.Name = "textAddCondition";
			this.textAddCondition.Size = new System.Drawing.Size(246, 20);
			this.textAddCondition.TabIndex = 5;
			this.textAddCondition.Text = "Zobrazte";
			this.textAddCondition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckKeys);
			// 
			// btnAddCondition
			// 
			this.btnAddCondition.Location = new System.Drawing.Point(260, 514);
			this.btnAddCondition.Name = "btnAddCondition";
			this.btnAddCondition.Size = new System.Drawing.Size(82, 23);
			this.btnAddCondition.TabIndex = 1;
			this.btnAddCondition.Text = "Add Condition";
			this.btnAddCondition.UseVisualStyleBackColor = true;
			this.btnAddCondition.Click += new System.EventHandler(this.btnAddCondition_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.StatusLabel,
									this.progressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 750);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(971, 22);
			this.statusStrip1.TabIndex = 41;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// StatusLabel
			// 
			this.StatusLabel.AutoSize = false;
			this.StatusLabel.Name = "StatusLabel";
			this.StatusLabel.Size = new System.Drawing.Size(55, 17);
			this.StatusLabel.Text = "Ready";
			// 
			// progressBar1
			// 
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(800, 16);
			this.progressBar1.Step = 1;
			// 
			// clrCond
			// 
			this.clrCond.Location = new System.Drawing.Point(260, 677);
			this.clrCond.Name = "clrCond";
			this.clrCond.Size = new System.Drawing.Size(82, 23);
			this.clrCond.TabIndex = 7;
			this.clrCond.Text = "Clear list";
			this.clrCond.UseVisualStyleBackColor = true;
			this.clrCond.Click += new System.EventHandler(this.ClrCondClick);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 488);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 44;
			this.label2.Text = "Conditions list:";
			// 
			// rmCond
			// 
			this.rmCond.Location = new System.Drawing.Point(260, 617);
			this.rmCond.Name = "rmCond";
			this.rmCond.Size = new System.Drawing.Size(82, 35);
			this.rmCond.TabIndex = 6;
			this.rmCond.Text = "Remove Condition";
			this.rmCond.UseVisualStyleBackColor = true;
			this.rmCond.Click += new System.EventHandler(this.RmCondClick);
			// 
			// contains
			// 
			this.contains.Location = new System.Drawing.Point(8, 424);
			this.contains.Name = "contains";
			this.contains.Size = new System.Drawing.Size(75, 23);
			this.contains.TabIndex = 45;
			this.contains.Text = "Contains";
			this.contains.UseVisualStyleBackColor = true;
			this.contains.Click += new System.EventHandler(this.ContainsClick);
			// 
			// beginwith
			// 
			this.beginwith.Location = new System.Drawing.Point(89, 424);
			this.beginwith.Name = "beginwith";
			this.beginwith.Size = new System.Drawing.Size(75, 23);
			this.beginwith.TabIndex = 46;
			this.beginwith.Text = "Begin with";
			this.beginwith.UseVisualStyleBackColor = true;
			this.beginwith.Click += new System.EventHandler(this.BeginwithClick);
			// 
			// endwith
			// 
			this.endwith.Location = new System.Drawing.Point(170, 424);
			this.endwith.Name = "endwith";
			this.endwith.Size = new System.Drawing.Size(75, 23);
			this.endwith.TabIndex = 47;
			this.endwith.Text = "End with";
			this.endwith.UseVisualStyleBackColor = true;
			this.endwith.Click += new System.EventHandler(this.EndwithClick);
			// 
			// singleword
			// 
			this.singleword.Location = new System.Drawing.Point(251, 424);
			this.singleword.Name = "singleword";
			this.singleword.Size = new System.Drawing.Size(75, 23);
			this.singleword.TabIndex = 48;
			this.singleword.Text = "Whole word";
			this.singleword.UseVisualStyleBackColor = true;
			this.singleword.Click += new System.EventHandler(this.SinglewordClick);
			// 
			// condcombo
			// 
			this.condcombo.AccessibleRole = System.Windows.Forms.AccessibleRole.Cursor;
			this.condcombo.AutoCompleteCustomSource.AddRange(new string[] {
									"|",
									"\\\\w",
									"\\\\W",
									"\\\\s",
									"\\\\S",
									"\\\\d",
									"\\\\D",
									"\\\\b"});
			this.condcombo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.condcombo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.condcombo.DisplayMember = "0";
			this.condcombo.FormattingEnabled = true;
			this.condcombo.Items.AddRange(new object[] {
									"OR",
									"Word character value",
									"Non-Word character value",
									"Whitespace character",
									"Non-Whitespace character",
									"Digital character",
									"Non-Digital character",
									"Word border"});
			this.condcombo.Location = new System.Drawing.Point(12, 462);
			this.condcombo.Name = "condcombo";
			this.condcombo.Size = new System.Drawing.Size(215, 21);
			this.condcombo.TabIndex = 49;
			this.condcombo.Tag = "";
			// 
			// addc
			// 
			this.addc.Location = new System.Drawing.Point(251, 460);
			this.addc.Name = "addc";
			this.addc.Size = new System.Drawing.Size(75, 23);
			this.addc.TabIndex = 50;
			this.addc.Text = "Use";
			this.addc.UseVisualStyleBackColor = true;
			this.addc.Click += new System.EventHandler(this.addcClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.menuToolStripMenuItem,
									this.helpToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(971, 24);
			this.menuStrip1.TabIndex = 60;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// menuToolStripMenuItem
			// 
			this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.Btncon,
									this.Btndiscon,
									this.mySqlSetupToolStripMenuItem,
									this.EditorMySqlToolStripMenuItem});
			this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
			this.menuToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
			this.menuToolStripMenuItem.Text = "&Menu";
			// 
			// Btncon
			// 
			this.Btncon.Name = "Btncon";
			this.Btncon.Size = new System.Drawing.Size(166, 22);
			this.Btncon.Text = "connect MySql";
			this.Btncon.Click += new System.EventHandler(this.BtnconClick);
			// 
			// Btndiscon
			// 
			this.Btndiscon.Name = "Btndiscon";
			this.Btndiscon.Size = new System.Drawing.Size(166, 22);
			this.Btndiscon.Text = "disconnect Mysql";
			this.Btndiscon.Click += new System.EventHandler(this.BtndisconClick);
			// 
			// mySqlSetupToolStripMenuItem
			// 
			this.mySqlSetupToolStripMenuItem.Name = "mySqlSetupToolStripMenuItem";
			this.mySqlSetupToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.mySqlSetupToolStripMenuItem.Text = "MySql setup";
			this.mySqlSetupToolStripMenuItem.Click += new System.EventHandler(this.MySqlSetupToolStripMenuItemClick);
			// 
			// EditorMySqlToolStripMenuItem
			// 
			this.EditorMySqlToolStripMenuItem.Name = "EditorMySqlToolStripMenuItem";
			this.EditorMySqlToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.EditorMySqlToolStripMenuItem.Text = "MySql Editor";
			this.EditorMySqlToolStripMenuItem.Click += new System.EventHandler(this.EditorMySqlToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.regularExpToolStripMenuItem,
									this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// regularExpToolStripMenuItem
			// 
			this.regularExpToolStripMenuItem.Name = "regularExpToolStripMenuItem";
			this.regularExpToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.regularExpToolStripMenuItem.Text = "Regular E&xp";
			this.regularExpToolStripMenuItem.Click += new System.EventHandler(this.RegularExpToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
			this.aboutToolStripMenuItem.Text = "&About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// listresult
			// 
			this.listresult.AllowColumnReorder = true;
			this.listresult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listresult.AutoArrange = false;
			this.listresult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listresult.FullRowSelect = true;
			this.listresult.GridLines = true;
			this.listresult.Location = new System.Drawing.Point(361, 327);
			this.listresult.Name = "listresult";
			this.listresult.Size = new System.Drawing.Size(474, 193);
			this.listresult.TabIndex = 61;
			this.listresult.UseCompatibleStateImageBehavior = false;
			this.listresult.View = System.Windows.Forms.View.Details;
			this.listresult.Click += new System.EventHandler(this.ListresultSelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "File_ID";
			this.columnHeader1.Width = 45;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "FileName";
			this.columnHeader2.Width = 333;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "FileSize";
			this.columnHeader3.Width = 83;
			// 
			// showDB
			// 
			this.showDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.showDB.Location = new System.Drawing.Point(884, 633);
			this.showDB.Name = "showDB";
			this.showDB.Size = new System.Drawing.Size(75, 23);
			this.showDB.TabIndex = 62;
			this.showDB.Text = "Show db";
			this.showDB.UseVisualStyleBackColor = true;
			this.showDB.Click += new System.EventHandler(this.ShowDBClick);
			// 
			// listviewdb
			// 
			this.listviewdb.AllowColumnReorder = true;
			this.listviewdb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listviewdb.AutoArrange = false;
			this.listviewdb.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader5,
									this.columnHeader6,
									this.columnHeader7,
									this.columnHeader8,
									this.columnHeader9});
			this.listviewdb.FullRowSelect = true;
			this.listviewdb.GridLines = true;
			this.listviewdb.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
									listViewItem1});
			this.listviewdb.Location = new System.Drawing.Point(361, 539);
			this.listviewdb.Name = "listviewdb";
			this.listviewdb.Size = new System.Drawing.Size(474, 200);
			this.listviewdb.TabIndex = 63;
			this.listviewdb.UseCompatibleStateImageBehavior = false;
			this.listviewdb.View = System.Windows.Forms.View.Details;
			this.listviewdb.Click += new System.EventHandler(this.ListviewdbSelectedIndexChanged);
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "File_ID";
			this.columnHeader5.Width = 45;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Condition";
			this.columnHeader6.Width = 152;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Truth";
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "CondText";
			this.columnHeader8.Width = 146;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Date";
			// 
			// addcondfile
			// 
			this.addcondfile.Location = new System.Drawing.Point(260, 564);
			this.addcondfile.Name = "addcondfile";
			this.addcondfile.Size = new System.Drawing.Size(82, 23);
			this.addcondfile.TabIndex = 64;
			this.addcondfile.Text = "Add from File";
			this.addcondfile.UseVisualStyleBackColor = true;
			this.addcondfile.Click += new System.EventHandler(this.AddcondfileClick);
			// 
			// richTextBox2
			// 
			this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox2.Location = new System.Drawing.Point(841, 60);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.Size = new System.Drawing.Size(118, 238);
			this.richTextBox2.TabIndex = 65;
			this.richTextBox2.Text = "";
			// 
			// NOcombo
			// 
			this.NOcombo.AutoCompleteCustomSource.AddRange(new string[] {
									"1",
									"2",
									"3",
									"4",
									"5"});
			this.NOcombo.FormattingEnabled = true;
			this.NOcombo.Items.AddRange(new object[] {
									"0 rows",
									"1 row",
									"2 rows",
									"3 rows",
									"4 rows",
									"5 rows"});
			this.NOcombo.Location = new System.Drawing.Point(268, 386);
			this.NOcombo.Name = "NOcombo";
			this.NOcombo.Size = new System.Drawing.Size(58, 21);
			this.NOcombo.TabIndex = 66;
			this.NOcombo.Text = "0 rows";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(229, 361);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(97, 23);
			this.label3.TabIndex = 67;
			this.label3.Text = "No. of Saved lines:";
			// 
			// compare
			// 
			this.compare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.compare.Location = new System.Drawing.Point(884, 604);
			this.compare.Name = "compare";
			this.compare.Size = new System.Drawing.Size(75, 23);
			this.compare.TabIndex = 68;
			this.compare.Text = "Compare";
			this.compare.UseVisualStyleBackColor = true;
			this.compare.Click += new System.EventHandler(this.CompareClick);
			// 
			// BtnSqlEditor
			// 
			this.BtnSqlEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.BtnSqlEditor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.BtnSqlEditor.Location = new System.Drawing.Point(884, 662);
			this.BtnSqlEditor.Name = "BtnSqlEditor";
			this.BtnSqlEditor.Size = new System.Drawing.Size(75, 36);
			this.BtnSqlEditor.TabIndex = 69;
			this.BtnSqlEditor.Text = "MySQL Editor";
			this.BtnSqlEditor.UseVisualStyleBackColor = true;
			this.BtnSqlEditor.Click += new System.EventHandler(this.BtnSqlEditorClick);
			// 
			// listCompare
			// 
			this.listCompare.AllowColumnReorder = true;
			this.listCompare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.listCompare.AutoArrange = false;
			this.listCompare.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader4,
									this.columnHeader10});
			this.listCompare.GridLines = true;
			this.listCompare.Location = new System.Drawing.Point(841, 327);
			this.listCompare.Name = "listCompare";
			this.listCompare.Size = new System.Drawing.Size(118, 271);
			this.listCompare.TabIndex = 76;
			this.listCompare.UseCompatibleStateImageBehavior = false;
			this.listCompare.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "File_ID";
			this.columnHeader4.Width = 46;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Compare";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(840, 34);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(113, 20);
			this.label4.TabIndex = 78;
			this.label4.Text = "Condition Text:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(971, 772);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.listCompare);
			this.Controls.Add(this.BtnSqlEditor);
			this.Controls.Add(this.compare);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.NOcombo);
			this.Controls.Add(this.richTextBox2);
			this.Controls.Add(this.addcondfile);
			this.Controls.Add(this.listviewdb);
			this.Controls.Add(this.showDB);
			this.Controls.Add(this.listresult);
			this.Controls.Add(this.addc);
			this.Controls.Add(this.condcombo);
			this.Controls.Add(this.singleword);
			this.Controls.Add(this.endwith);
			this.Controls.Add(this.beginwith);
			this.Controls.Add(this.contains);
			this.Controls.Add(this.rmCond);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.clrCond);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.btnAddCondition);
			this.Controls.Add(this.textAddCondition);
			this.Controls.Add(this.listConditions);
			this.Controls.Add(this.remFile);
			this.Controls.Add(this.results);
			this.Controls.Add(this.filecont);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.clrFile);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.conditionL1);
			this.Controls.Add(this.button1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PDF Control v1.2";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem Btndiscon;
		private System.Windows.Forms.ToolStripMenuItem Btncon;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView listCompare;
		private System.Windows.Forms.Button BtnSqlEditor;
		private System.Windows.Forms.Button compare;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ToolStripMenuItem EditorMySqlToolStripMenuItem;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox NOcombo;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem regularExpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.Button addcondfile;
		private System.Windows.Forms.ListView listviewdb;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Button showDB;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ListView listresult;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ToolStripMenuItem mySqlSetupToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.Button addc;
		private System.Windows.Forms.Button remFile;
		private System.Windows.Forms.ComboBox condcombo;
		private System.Windows.Forms.Button singleword;
		private System.Windows.Forms.Button endwith;
		private System.Windows.Forms.Button beginwith;
		private System.Windows.Forms.Button contains;
		private System.Windows.Forms.Button rmCond;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button clrCond;
		private System.Windows.Forms.Button clrFile;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Label filecont;
		private System.Windows.Forms.Label results;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ToolStripProgressBar progressBar1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label conditionL1;
		private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ListBox listConditions;
        private System.Windows.Forms.TextBox textAddCondition;
        private System.Windows.Forms.Button btnAddCondition;
		
	}
}
