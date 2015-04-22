/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 18.5.2010
 * Time: 18:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace PDFv2
{
	partial class Form4
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(12, 115);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(268, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "PDF Control";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(12, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(268, 31);
			this.label2.TabIndex = 1;
			this.label2.Text = "VUT Brno";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(12, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(268, 23);
			this.label3.TabIndex = 2;
			this.label3.Text = "ÚSTAV MIKROELEKTRONIKY";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(268, 31);
			this.label4.TabIndex = 3;
			this.label4.Text = "Program pre overenie a kontrolu pdf dokumentov";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(12, 40);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(268, 23);
			this.label5.TabIndex = 4;
			this.label5.Text = "FAKULTA ELEKTROTECHNIKY A KOMUNIKAČNÍCH TECHNOLOGIÍ";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(118, 218);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(162, 23);
			this.label6.TabIndex = 5;
			this.label6.Text = "Bc. DÁVID KONEČNÝ";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(118, 241);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(162, 23);
			this.label7.TabIndex = 6;
			this.label7.Text = "Ing. JAROSLAV KADLEC, Ph.D.";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(12, 218);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 23);
			this.label8.TabIndex = 7;
			this.label8.Text = "Autor:";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(12, 241);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(61, 23);
			this.label9.TabIndex = 8;
			this.label9.Text = "Vedúci:";
			// 
			// Form4
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 273);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(300, 300);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 300);
			this.Name = "Form4";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "About";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
