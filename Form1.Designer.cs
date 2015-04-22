/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 29.3.2009
 * Time: 13:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PDFv2
{
	partial class Form1
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
			this.label3 = new System.Windows.Forms.Label();
			this.lpass = new System.Windows.Forms.Label();
			this.luser = new System.Windows.Forms.Label();
			this.ldatabase = new System.Windows.Forms.Label();
			this.lserver = new System.Windows.Forms.Label();
			this.user = new System.Windows.Forms.TextBox();
			this.password = new System.Windows.Forms.TextBox();
			this.database = new System.Windows.Forms.TextBox();
			this.server = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(9, 3);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 20);
			this.label3.TabIndex = 68;
			this.label3.Text = "MySQL settings:";
			// 
			// lpass
			// 
			this.lpass.Location = new System.Drawing.Point(183, 55);
			this.lpass.Name = "lpass";
			this.lpass.Size = new System.Drawing.Size(71, 23);
			this.lpass.TabIndex = 67;
			this.lpass.Text = "Password:";
			// 
			// luser
			// 
			this.luser.Location = new System.Drawing.Point(183, 26);
			this.luser.Name = "luser";
			this.luser.Size = new System.Drawing.Size(71, 23);
			this.luser.TabIndex = 66;
			this.luser.Text = "User:";
			// 
			// ldatabase
			// 
			this.ldatabase.Location = new System.Drawing.Point(9, 55);
			this.ldatabase.Name = "ldatabase";
			this.ldatabase.Size = new System.Drawing.Size(62, 23);
			this.ldatabase.TabIndex = 65;
			this.ldatabase.Text = "DataBase:";
			// 
			// lserver
			// 
			this.lserver.Location = new System.Drawing.Point(9, 29);
			this.lserver.Name = "lserver";
			this.lserver.Size = new System.Drawing.Size(62, 23);
			this.lserver.TabIndex = 64;
			this.lserver.Text = "Server:";
			// 
			// user
			// 
			this.user.Location = new System.Drawing.Point(260, 23);
			this.user.Name = "user";
			this.user.Size = new System.Drawing.Size(100, 20);
			this.user.TabIndex = 62;
			// 
			// password
			// 
			this.password.Location = new System.Drawing.Point(260, 49);
			this.password.Name = "password";
			this.password.PasswordChar = '*';
			this.password.Size = new System.Drawing.Size(100, 20);
			this.password.TabIndex = 63;
			// 
			// database
			// 
			this.database.Location = new System.Drawing.Point(77, 52);
			this.database.Name = "database";
			this.database.Size = new System.Drawing.Size(100, 20);
			this.database.TabIndex = 61;
			this.database.Text = "pdfcontrol";
			// 
			// server
			// 
			this.server.Location = new System.Drawing.Point(77, 26);
			this.server.Name = "server";
			this.server.Size = new System.Drawing.Size(100, 20);
			this.server.TabIndex = 60;
			this.server.Text = "localhost";
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.Location = new System.Drawing.Point(285, 106);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 65;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(183, 106);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 64;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 150);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lpass);
			this.Controls.Add(this.luser);
			this.Controls.Add(this.ldatabase);
			this.Controls.Add(this.lserver);
			this.Controls.Add(this.user);
			this.Controls.Add(this.password);
			this.Controls.Add(this.database);
			this.Controls.Add(this.server);
			this.Name = "Form1";
			this.Text = "MySQL Setup";
			this.Load += new System.EventHandler(this.Form1Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.TextBox server;
		private System.Windows.Forms.TextBox database;
		private System.Windows.Forms.TextBox password;
		private System.Windows.Forms.TextBox user;
		private System.Windows.Forms.Label lserver;
		private System.Windows.Forms.Label ldatabase;
		private System.Windows.Forms.Label luser;
		private System.Windows.Forms.Label lpass;
		private System.Windows.Forms.Label label3;
	}
}
