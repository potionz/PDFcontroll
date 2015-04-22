/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 17.2.2010
 * Time: 12:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions; 
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Data.OleDb;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlTypes;

namespace PDFv2
{
	/// <summary>
	/// Description of Form3.
	/// </summary>
	public partial class Form3 : Form
	{	
		private connect connect = new connect();
		
		public Form3()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		int rdr=0;
			void Form3Load(object sender, EventArgs e)
				{
	//			this.compare.Enabled = false;
				this.ShowDBClick(sender, e);
			//	ShDB();
				}
	/*		void showDBaseClick(object sender, EventArgs e)
			{
							//richSolutionX.Text = "";
							this.dbCondList.Items.Clear();
							this.dbFileList.Items.Clear();
							MySqlDataReader Reader;
							Reader = connect.executeGetFile();
							while (Reader.Read())
							{
									ListViewItem rowFile = new ListViewItem(Reader.GetValue(0).ToString());
									rowFile.SubItems.Add(Reader.GetValue(1).ToString());
									rowFile.SubItems.Add(Reader.GetValue(2).ToString());
									dbFileList.Items.Add(rowFile);
							}
							Reader.Close();

		    }
	*/
	public void disableBtn()
	{
		SetbuttonEnable(showDB, false);
	//	SetbuttonEnable(compare, false);
	//	SetbuttonEnable(createdb, false);
		SetbuttonEnable(download, false);
		SetbuttonEnable(DropDB, false);
/*		
		this.showDB.Enabled = false;
		this.compare.Enabled = false;
		this.createdb.Enabled = false;
		this.download.Enabled = false;
		this.DropDB.Enabled = false;
*/
	}
	
	private Thread noveVlakno;
	public void enableBtn()
	{

		SetbuttonEnable(showDB, true);
//		SetbuttonEnable(compare, true);
//		SetbuttonEnable(createdb, true);
		SetbuttonEnable(download, true);
		SetbuttonEnable(DropDB, true);
/*		
		this.showDB.Enabled = true;
//		this.compare.Enabled = true;
		this.createdb.Enabled = true;
		this.download.Enabled = true;
		this.DropDB.Enabled = true;
*/
	}
	void ShowDBClick(object sender, EventArgs e)
	{
			rdr = 1;
			disableBtn();
			SetStatusLabelText(StatusLabel, "Loading");
			this.CondTextBox.Clear();
			this.richTextBox1.Clear();
			this.listCompare.Items.Clear();
			this.listviewdb.Items.Clear();
			this.listresult.Items.Clear();
			noveVlakno = new Thread(ShDB);
            noveVlakno.Start();		
		
//		ShDB();
	}
	public void ShDB()
		{
			SetStatusLabelText(StatusLabel, "Loading");
			MySqlDataReader Reader;
			Reader = connect.executeGetFile();
			while (Reader.Read())
				{

					ListViewItem rowFile = new ListViewItem(Reader.GetValue(0).ToString());
					rowFile.SubItems.Add(Reader.GetValue(1).ToString());
					rowFile.SubItems.Add(Reader.GetValue(2).ToString());
					SetListViewText(listresult, rowFile);
				}
							Reader.Close();
		enableBtn();
		SetStatusLabelText(StatusLabel, "Done");
		rdr=0;
		}
		
/*		void CompareClick(object sender, EventArgs e)
		{

		int maxID=0;
		MySqlDataReader Reader;
		Reader = connect.executeGetFileID();
		while (Reader.Read())
			{
			maxID = (int)Reader.GetUInt32(0);
			}
		Reader.Close();
		
		Stack<int> fileIDs = new Stack<int>();
		MySqlDataReader ReaderF;
		ReaderF = connect.GetFileIDs();
		while (ReaderF.Read())
		{
			fileIDs.Push(ReaderF.GetInt32(0));
		}
		ReaderF.Close();
		
		string suborA="";
		string suborB="";
		int ID;
		int cID;
		int count = fileIDs.Count;
		int c=count;
		int [] FileIDarray;
		FileIDarray = new int[count];
			progressBar1.Maximum = count;
			StatusLabel.Text = "Checking";
			StatusLabel.Invalidate();
			this.Update();		
		for (c=count-1;c>-1;c--)
		{
			FileIDarray[c] = fileIDs.Pop();
		//	richTextBox2.Text = richTextBox2.Text + FileIDarray[c]+"\n";
		}
		for (ID=0;ID<count;ID++)
		{
	//		richTextBox2.Text = richTextBox2.Text + ID+"\n";
			MySqlDataReader ReaderX;
			ReaderX = connect.GetFileText(FileIDarray[ID]);
			while (ReaderX.Read())
				{
					suborA = ReaderX.GetValue(0).ToString();
				}
			ReaderX.Close();
			cID = ID+1;
			for (cID=(1+ID);cID<count;cID++)
				{
				
				MySqlDataReader ReaderY;
				ReaderY = connect.GetFileText(FileIDarray[cID]);
				while (ReaderY.Read())
					{
					suborB = ReaderY.GetValue(0).ToString();
					}
				ReaderY.Close();
	//			richTextBox2.Text = richTextBox2.Text + cID+"\n";
		
				double compare = Cosine.compare(suborA, suborB);
				connect.executeCompare(FileIDarray[ID], FileIDarray[cID], compare);
				}
			
			this.progressBar1.Value = ID + 1;
		}
		
		StatusLabel.Text = "Done";

		}
		*/		
//		private Thread newThread;
		void DownloadClick(object sender, EventArgs e)
		{
	
		disableBtn();

/*		
		newThread = new Thread(FnkcVlakna);
        newThread.Start();

		}
        private void FnkcVlakna()
        {
*/        
		int ID;
		try

			{
		//	    conn.Open();
		
		FolderBrowserDialog downloadFolder = new FolderBrowserDialog();
		DialogResult result = downloadFolder.ShowDialog();
		if (result != DialogResult.OK)
			{
			enableBtn();
				return;
			}
		
		string path = downloadFolder.SelectedPath;
		
						Stack<int> fileIDs = new Stack<int>();
						MySqlDataReader ReaderF;
						ReaderF = connect.GetFileIDs();
						while (ReaderF.Read())
						{
							fileIDs.Push(ReaderF.GetInt32(0));
						}
						ReaderF.Close();	

						int count = fileIDs.Count;
						int c=count;
						int [] FileIDarray;			
						FileIDarray = new int[count];
						SetProgressBarMax(progressBar1, count);
					//		progressBar1.Maximum = count;
					SetStatusLabelText(StatusLabel, "Download");
					//		StatusLabel.Text = "Checking";
					//		StatusLabel.Invalidate();
					//		this.Update();	
				for (c=count-1;c>-1;c--)
					{
						FileIDarray[c] = fileIDs.Pop();
					}
		for (ID=0;ID<count;ID++)
			{
		/*	MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand();
			MySqlDataReader myData;
			string SQL;
			string File_name;
			int File_size;
			byte[] rawData;
			FileStream fs;

				SQL = "SELECT FileName, FileSize, File FROM file WHERE File_ID='"+FileIDarray[ID]+"';";			
			    cmd.Connection = conn;
			    cmd.CommandText = SQL;
			
			    myData = cmd.ExecuteReader();
			
			    if (! myData.HasRows)
			        throw new Exception("There are no BLOBs to save");
			
			    myData.Read();
			
			    File_size = (int)myData.GetUInt32(myData.GetOrdinal("FileSize"));
			    rawData = new byte[File_size];
				
			    File_name = myData.GetValue(0).ToString();
			    myData.GetBytes(myData.GetOrdinal("File"), 0, rawData, 0, File_size);
			    string[] File_nam = File_name.Split('\\');
			    int FileN_count = File_nam.Length;
			    string FileN = File_nam[FileN_count-1];
			    
			    myData.Close();
			    fs = new FileStream(@"C:\TEST\"+FileN+"", FileMode.OpenOrCreate, FileAccess.Write);
			    fs.Write(rawData, 0, File_size);
			    fs.Close();
		 */	connect.downDB(FileIDarray, ID, path);
		SetProgressBarText(progressBar1, ID+1);
		//	this.progressBar1.Value = ID + 1;
		    }
		MessageBox.Show("File successfully written to disk in " +path,
			        "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		SetStatusLabelText(StatusLabel, "Done");
		//    StatusLabel.Text = "Done";
			    
		//	    conn.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
			    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
			        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		enableBtn();						
		}		
				
		void ListresultSelectedIndexChanged(object sender, EventArgs e)
		{
			if(rdr==0)
			{
			string readrow = "";
			//richTextBox1.Text = "";
			richTextBox1.Clear();
			this.CondTextBox.Clear();
			this.listviewdb.Items.Clear();
			this.listCompare.Items.Clear();
			
							filecont.Text ="Content of FileID: "+ listresult.FocusedItem.SubItems[0].Text;//.SelectedItems[0].SubItems[1].Text;
							MySqlDataReader Reader;
		 					Reader = connect.executeGetFileText(listresult);
							while (Reader.Read())
							{
								
								for (int i=0;i<Reader.FieldCount;i++)
								{
									readrow =Reader.GetValue(i).ToString()+" \n";
									
								//	richTextBox1.Text = readrow;
								}
								
							}
							Reader.Close();
							richTextBox1.Text = readrow;							
							
							Reader = connect.executeGetCondition(listresult);
							while(Reader.Read())
							{
		
									ListViewItem rowCond = new ListViewItem(Reader.GetValue(5).ToString());
									rowCond.SubItems.Add(Reader.GetValue(1).ToString());
									rowCond.SubItems.Add(Reader.GetValue(2).ToString());
									rowCond.SubItems.Add(Reader.GetValue(3).ToString());
									rowCond.SubItems.Add(Reader.GetValue(4).ToString());
									listviewdb.Items.Add(rowCond);

							}
						Reader.Close();
						
						Reader = connect.executeGetCompare(listresult);
						while (Reader.Read())
						{
									ListViewItem rowCompare = new ListViewItem(Reader.GetValue(0).ToString());
									double cmpr = Reader.GetDouble(1)*100;
									cmpr = Math.Round(cmpr, 2);
									rowCompare.UseItemStyleForSubItems = false;
									if(cmpr>60)
									{
										rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.Red, rowCompare.Font);
									}
									else
									{
										rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.White, rowCompare.Font);
									}
									listCompare.Items.Add(rowCompare);
						}
						Reader.Close();
						Reader = connect.executeGetCompareB(listresult);
						while(Reader.Read())
						{
									ListViewItem rowCompare = new ListViewItem(Reader.GetValue(0).ToString());
									double cmpr = Reader.GetDouble(1)*100;
									cmpr = Math.Round(cmpr, 2);
									rowCompare.UseItemStyleForSubItems = false;
									if(cmpr>40)
									{
										rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.Red,  rowCompare.Font);
									}
									else
									{
										rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.White,  rowCompare.Font);
									}
								//	rowCompare.SubItems.Add(cmpr.ToString());
									listCompare.Items.Add(rowCompare);
						}
						Reader.Close();
			
			}
		}
		
		void ListviewdbSelectedIndexChanged(object sender, EventArgs e)
		{
			CondTextBox.Text = listviewdb.FocusedItem.SubItems[3].Text;
		}
				
	/*	void CreatedbClick(object sender, EventArgs e)
		{
		try
		{
			connect.close();
			connect.testDatabase();
			connect.createDB();
			
			MessageBox.Show("Tabels in Database was successfully created!",
			        "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
		catch (MySql.Data.MySqlClient.MySqlException ex)
		{
		MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
			        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			
		}
		
		}
		*/

		
		void DropDBClick(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("\nDelete all data from database ?\n", "Warning" , MessageBoxButtons.YesNo,MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
			if (result == DialogResult.Yes)
	       	 {
				connect.executeDrop();	
			}
			if (result == DialogResult.No)
			{
			return;
			}
							
		}
		delegate void SetbuttonCallback(Button ctrl, bool text);
        private void SetbuttonEnable(Button ctrl, bool text)
        {
            if (this.InvokeRequired)
            {
                SetbuttonCallback d = new SetbuttonCallback(SetbuttonEnable);
                this.Invoke(d, new object[] { ctrl, text });
            }
            else
            {
                ctrl.Enabled = text;
            }
       	}
		delegate void SetListViewCallback(ListView ctrl, ListViewItem item);
        private void SetListViewText(ListView ctrl, ListViewItem item)
        {
            if (this.InvokeRequired)
            {
            	SetListViewCallback d = new SetListViewCallback(SetListViewText);
                this.Invoke(d, new object[] { ctrl, item });
            }
            else
            {
            	ctrl.Items.Add(item);
            }
        }  

		
		delegate void SetStatusLabelTextCallback(ToolStripItem ctrl, string text);
        private void SetStatusLabelText(ToolStripItem ctrl, string text)
        {
            if (this.InvokeRequired)
            {
                SetStatusLabelTextCallback d = new SetStatusLabelTextCallback(SetStatusLabelText);
                this.Invoke(d, new object[] { ctrl, text });
            }
            else
            {
                ctrl.Text = text;
                ctrl.Invalidate();
                this.Update();
            }
        }

		
		delegate void SetprogressBarCallback(ToolStripProgressBar ctrl, int number);
        private void SetProgressBarText(ToolStripProgressBar ctrl, int number)
        {
            if (this.InvokeRequired)
            {
            	SetprogressBarCallback d = new SetprogressBarCallback(SetProgressBarText);
                this.Invoke(d, new object[] { ctrl, number });
            }
            else
            {
            	ctrl.Value = number;
       		 	progressBar1.Invalidate();
				this.Update();
            }
        }         

        private void SetProgressBarMax(ToolStripProgressBar ctrl, int number)
        {
            if (this.InvokeRequired)
            {
            	SetprogressBarCallback d = new SetprogressBarCallback(SetProgressBarMax);
                this.Invoke(d, new object[] { ctrl, number });
            }
            else
            {
            	ctrl.Maximum = number;
       		 	progressBar1.Invalidate();
				this.Update();
            }
        } 		
		

	}
}
