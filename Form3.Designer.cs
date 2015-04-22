/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 17.2.2010
 * Time: 12:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PDFv2
{
	partial class Form3
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
			this.listresult = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.showDB = new System.Windows.Forms.Button();
			this.filecont = new System.Windows.Forms.Label();
			this.listviewdb = new System.Windows.Forms.ListView();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.download = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.DropDB = new System.Windows.Forms.Button();
			this.listCompare = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.CondTextBox = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listresult
			// 
			this.listresult.AllowColumnReorder = true;
			this.listresult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.listresult.AutoArrange = false;
			this.listresult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.listresult.FullRowSelect = true;
			this.listresult.GridLines = true;
			this.listresult.Location = new System.Drawing.Point(10, 265);
			this.listresult.Name = "listresult";
			this.listresult.Size = new System.Drawing.Size(709, 193);
			this.listresult.TabIndex = 65;
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
			this.columnHeader2.Width = 562;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "FileSize";
			this.columnHeader3.Width = 88;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(10, 33);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(709, 226);
			this.richTextBox1.TabIndex = 66;
			this.richTextBox1.Text = "";
			// 
			// showDB
			// 
			this.showDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.showDB.Location = new System.Drawing.Point(878, 435);
			this.showDB.Name = "showDB";
			this.showDB.Size = new System.Drawing.Size(75, 23);
			this.showDB.TabIndex = 67;
			this.showDB.Text = "Show db";
			this.showDB.UseVisualStyleBackColor = true;
			this.showDB.Click += new System.EventHandler(this.ShowDBClick);
			// 
			// filecont
			// 
			this.filecont.Location = new System.Drawing.Point(12, 7);
			this.filecont.Name = "filecont";
			this.filecont.Size = new System.Drawing.Size(541, 23);
			this.filecont.TabIndex = 68;
			this.filecont.Text = "Content of FileID:";
			// 
			// listviewdb
			// 
			this.listviewdb.AllowColumnReorder = true;
			this.listviewdb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
			this.listviewdb.Location = new System.Drawing.Point(10, 464);
			this.listviewdb.Name = "listviewdb";
			this.listviewdb.Size = new System.Drawing.Size(709, 253);
			this.listviewdb.TabIndex = 69;
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
			this.columnHeader7.Width = 42;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "CondText";
			this.columnHeader8.Width = 339;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Date";
			this.columnHeader9.Width = 117;
			// 
			// download
			// 
			this.download.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.download.Location = new System.Drawing.Point(878, 549);
			this.download.Name = "download";
			this.download.Size = new System.Drawing.Size(75, 23);
			this.download.TabIndex = 72;
			this.download.Text = "Download";
			this.download.UseVisualStyleBackColor = true;
			this.download.Click += new System.EventHandler(this.DownloadClick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.StatusLabel,
									this.progressBar1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 722);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(976, 22);
			this.statusStrip1.TabIndex = 73;
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
			this.progressBar1.Size = new System.Drawing.Size(700, 16);
			this.progressBar1.Step = 1;
			// 
			// DropDB
			// 
			this.DropDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.DropDB.Location = new System.Drawing.Point(878, 678);
			this.DropDB.Name = "DropDB";
			this.DropDB.Size = new System.Drawing.Size(75, 23);
			this.DropDB.TabIndex = 74;
			this.DropDB.Text = "Drop DB";
			this.DropDB.UseVisualStyleBackColor = true;
			this.DropDB.Click += new System.EventHandler(this.DropDBClick);
			// 
			// listCompare
			// 
			this.listCompare.AllowColumnReorder = true;
			this.listCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.listCompare.AutoArrange = false;
			this.listCompare.BackColor = System.Drawing.Color.White;
			this.listCompare.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader4,
									this.columnHeader10});
			this.listCompare.GridLines = true;
			this.listCompare.Location = new System.Drawing.Point(727, 265);
			this.listCompare.Name = "listCompare";
			this.listCompare.Size = new System.Drawing.Size(122, 452);
			this.listCompare.TabIndex = 75;
			this.listCompare.UseCompatibleStateImageBehavior = false;
			this.listCompare.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "File_ID";
			this.columnHeader4.Width = 55;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "Compare";
			// 
			// CondTextBox
			// 
			this.CondTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.CondTextBox.Location = new System.Drawing.Point(734, 32);
			this.CondTextBox.Name = "CondTextBox";
			this.CondTextBox.Size = new System.Drawing.Size(230, 226);
			this.CondTextBox.TabIndex = 76;
			this.CondTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(734, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(113, 20);
			this.label1.TabIndex = 77;
			this.label1.Text = "Condition Text:";
			// 
			// Form3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(976, 744);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.CondTextBox);
			this.Controls.Add(this.listCompare);
			this.Controls.Add(this.DropDB);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.download);
			this.Controls.Add(this.listviewdb);
			this.Controls.Add(this.filecont);
			this.Controls.Add(this.showDB);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.listresult);
			this.Name = "Form3";
			this.Text = "MySql Editor";
			this.Load += new System.EventHandler(this.Form3Load);
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox CondTextBox;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ListView listCompare;
		private System.Windows.Forms.Button DropDB;
		private System.Windows.Forms.ToolStripProgressBar progressBar1;
		private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Button download;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.Label filecont;
		private System.Windows.Forms.Button showDB;
		private System.Windows.Forms.ListView listviewdb;
		private System.Windows.Forms.ListView listresult;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader5;
	}
}
