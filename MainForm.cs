/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 1.12.2008
 * Time: 18:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Data;
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
using SimMetricsUtilities;
using SimMetricsMetricUtilities;
using org.pdfbox.pdmodel;
using org.pdfbox.pdmodel.common;
using org.pdfbox.util;
using log4net;
using log4net.Config;


namespace PDFv2
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		private connect connect = new connect();
//		private static database db;
//		private MySqlConnection conn;
		
		//private connect connect;
		private string username;
		private string password;
		private string database;
		private string server;
		
		private static readonly ILog logger = LogManager.GetLogger(typeof (MainForm));

		/*
		private static readonly Levenstein _Levenstein;
        private static readonly NeedlemanWunch _NeedlemanWunch;
        private static readonly SmithWaterman _SmithWaterman;
        private static readonly SmithWatermanGotoh _SmithWatermanGotoh;
        private static readonly SmithWatermanGotohWindowedAffine _SmithWatermanGotohWindowedAffine;
        private static readonly Jaro _Jaro;
        private static readonly JaroWinkler _JaroWinkler;
        private static readonly ChapmanLengthDeviation _ChapmanLengthDeviation;
        private static readonly ChapmanMeanLength _ChapmanMeanLength;
        private static readonly QGramsDistance _QGramsDistance;
        private static readonly BlockDistance _BlockDistance;
        private static readonly CosineSimilarity _CosineSimilarity;
        private static readonly DiceSimilarity _DiceSimilarity;
        private static readonly EuclideanDistance _EuclideanDistance;
        private static readonly JaccardSimilarity _JaccardSimilarity;
        private static readonly MatchingCoefficient _MatchingCoefficient;
        private static readonly MongeElkan _MongeElkan;
        private static readonly OverlapCoefficient _OverlapCoefficient;
        */
	//	MySqlConnection conn = new MySqlConnection(connect.conndb());
        
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			log4net.Config.XmlConfigurator.Configure();
			
				    FileTable.Columns.Add("FtID", typeof(int));
        			FileTable.Columns.Add("FtName", typeof(string));
        			FileTable.Columns.Add("FtSize", typeof(int));
        			FileTable.Columns.Add("Ftriadok", typeof(string));
        			FileTable.Columns.Add("Fthash", typeof(string));
           			CondTable.Columns.Add("CtID", typeof(int));
        			CondTable.Columns.Add("CtName", typeof(string));
        			CondTable.Columns.Add("CtTruth", typeof(int));
        			CondTable.Columns.Add("CtText", typeof(string));
        			CondTable.Columns.Add("CtDate", typeof(DateTime));
        			CondTable.Columns.Add("CtFtID", typeof(int));
          			CompareTable.Columns.Add("FileID_A", typeof(int));
        			CompareTable.Columns.Add("FileID_B", typeof(int));
        			CompareTable.Columns.Add("Compare", typeof(double));
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

		
		int dbtest;
		int rdr;
		
        DataTable FileTable = new DataTable();
        DataTable CondTable = new DataTable();
        DataTable CompareTable = new DataTable();
		
		string ReadPDFFileContent(string fileName)
		{
	        string citaj;     
	        
	        PDDocument doc = PDDocument.load(fileName);
	        PDFTextStripper stripper = new PDFTextStripper();
	        citaj = stripper.getText(doc);
	        return citaj;
		}


        private Thread noveVlakno;
        private List<Podminka> conditionArray = new List<Podminka>();
		void Button1Click(object sender, EventArgs e)
		{   
			this.button1.Enabled = false;
			this.showDB.Enabled = false;
			this.BtnSqlEditor.Enabled = false;
			if(dbtest ==2)
			{
				this.compare.Enabled = false;
			}
			this.listresult.Items.Clear();
			this.listCompare.Items.Clear();
	        FileTable.Clear();
	        CondTable.Clear();
	        CompareTable.Clear();
            noveVlakno = new Thread(FunkceVlakna);
            noveVlakno.Start();
		}

        private void FunkceVlakna()
        {
        	rdr = 1;
//	        this.button1.Enabled = false;
//			this.listresult.Items.Clear();
			int numOfFiles = this.listBox1.Items.Count;
			int done = (numOfFiles-1);
			SetProgressBarMax(progressBar1, numOfFiles);
//			progressBar1.Maximum = numOfFiles;
			SetStatusLabelText(StatusLabel, "Loading");
			//StatusLabel.Text = "Loading";
//			StatusLabel.Invalidate();
//			this.Update();

// zaciatok cyklu pre kontrolu vsetkych vyskytu PODMIENOK(conditions) vo zvolenych suboroch
			
			for (int i = 0; i<numOfFiles; i++)
			{
				if (i > 0)
				{
					SetStatusLabelText(StatusLabel, "Checking");
				//	StatusLabel.Text = "Checking";
				//	StatusLabel.Invalidate();
				//	this.Update(); 
				}
				int FileSize;
				string fileName = (string)this.listBox1.Items[i];
		        string riadok = this.ReadPDFFileContent(fileName);
		        int ii = 0;

//	toto vsetko(PRACA SO SUBOROM a deklaracie) bolo v cykle foreach podminka p ::		        
		        	FileStream fs;
                    fs = new FileStream(@fileName, FileMode.Open, FileAccess.Read);
			        FileSize = (int)fs.Length;
			        fs.Close();
			        MySqlDataReader Reader;
			        string relationFile_ID = null;
			        string hashFile_ID = null;
			        string actualFile = null;
			        Crc32 crc32 = new Crc32();
			        string hash = string.Empty;
        			
				using (FileStream fss = File.Open(@fileName, FileMode.Open))
				foreach (byte b in crc32.ComputeHash(fss)) hash += b.ToString("x2").ToLower();
 

//	PRACA SO SUBOROM zacina		        
	//		        if (ii == 0)
    //        		 		{
			                    byte[] rawData;
			                    fs = new FileStream(@fileName, FileMode.Open, FileAccess.Read);
			                    FileSize = (int)fs.Length;
			                    rawData = new byte[FileSize];
			   					fs.Read(rawData, 0, FileSize);
			   					fs.Close();
			   					
			   	if (dbtest!=2)
			   	{
								Reader = connect.executeHashFileID(hash);
								while (Reader.Read())
								{
									hashFile_ID = Reader.GetValue(0).ToString();
						//			richTextBox2.Text = richTextBox2.Text + hashFile_ID + "\n";
								}
								Reader.Close();
								actualFile = hashFile_ID;
								relationFile_ID = hashFile_ID;
								
								if(hashFile_ID==null)
								{
									connect.executeFile(fileName, FileSize, riadok, rawData, hash);
								}		   					
			   					
			   					if(hashFile_ID==null)
			   					{
										Reader = connect.executeGetFileID();
										while (Reader.Read())
										{
											relationFile_ID =Reader.GetValue(0).ToString();	
										}
										Reader.Close();
			   					}
			   		}
			   	if (dbtest==2)
			   	{
			   		
			   		FileTable.Rows.Add(i, fileName, FileSize, riadok, hash);
			   	}
			   	
			   	if(relationFile_ID==null) {relationFile_ID=i.ToString();}
			   					ListViewItem row = new ListViewItem(relationFile_ID);
			                  	row.SubItems.Add(fileName);
			                  	row.SubItems.Add(FileSize.ToString());
			                  	SetListViewText(listresult, row);
			                   // listresult.Items.Add(row); 
    		   //     		}		        
		        
// 		PRACA SO SUBOROM konci	
// az po tade to bolo v tom cykle
		        
		        
		        foreach (Podminka p in conditionArray)
                    {
                    	bool matches = p.RegxExp.IsMatch(riadok);
                    	MatchCollection MatchList = p.RegxExp.Matches(riadok);
                    	int MatchIndex = MatchList.Count;
						string CondText = "";                                        	
                        if (matches)
                        {
                            p.CondStat = "TRUE";
                            for (int countcond=0;countcond<MatchList.Count;countcond++)
                            {
                            	int vyskyt = countcond + 1;
                            	CondText = CondText + vyskyt +".vyskyt: " +MatchList[countcond].Value + "\n";
                            }
                        }
                        else 
                        {
                            p.CondStat = "FALSE";
                        }
                    
//	TU BOLA PRACA SO SUBOROM co je hore pre if(ii==0)                    

			        MySqlDataReader ReaderC;

   					
					relationFile_ID= null;						        
					hashFile_ID = null;
		if(dbtest!=2)
		{
					Reader = connect.executeHashFileID(hash);
					while (Reader.Read())
					{
						hashFile_ID = Reader.GetValue(0).ToString();
				//		richTextBox2.Text = richTextBox2.Text + hashFile_ID + "\n";
					}
					Reader.Close();
					relationFile_ID = hashFile_ID;
					if(hashFile_ID==null)
					{
								Reader = connect.executeGetFileID();
								while (Reader.Read())
								{
									relationFile_ID =Reader.GetValue(0).ToString();
								}
								Reader.Close();
					}
					
 								connect.executeCond(p.Text, matches, CondText, relationFile_ID);  
		}
		if(dbtest==2)
		{
			CondTable.Rows.Add(i, p.Text, (matches) ? "1" : "0", CondText, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), relationFile_ID);
		}
		
								string relationCond_ID;
								relationCond_ID= null;
		if(dbtest!=2)
		{
								ReaderC = connect.executeGetCondID();
								while (ReaderC.Read())
								{
									relationCond_ID =ReaderC.GetValue(0).ToString();
								}
								ReaderC.Close();
								   						
    							connect.executeRelation(relationCond_ID, relationFile_ID);
		}
		if(relationCond_ID==null){relationCond_ID=ii.ToString();}
    				ii++;
					}  // Koniec cyklu PODMIENOK(conditions) foreach 
		        SetrichboxText(richTextBox1, riadok);
//                    richTextBox1.Text = riadok;
				SetProgressBarText(progressBar1, i+1);
//		        	progressBar1.Value = i + 1;
//					progressBar1.Invalidate();
//					this.Update(); 
		  
// zaciatok porovnavania aktualneho suboru so subormi ulozenymi v DB
			/*
			hashFile_ID = null;
			Reader = connect.executeHashFileID(hash);
			while (Reader.Read())
			{
				hashFile_ID = Reader.GetValue(0).ToString();
				richTextBox2.Text = richTextBox2.Text + hashFile_ID + "\n";
			}
			Reader.Close();
			*/
if(dbtest!=2)
{
	if(actualFile==null)
		{
		int lastFile_ID=0;
		Reader = connect.executeGetFileID();
		while (Reader.Read())
			{
			lastFile_ID = (int)Reader.GetUInt32(0);
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
		int ID;
		int count = fileIDs.Count;
		int c=count;
		int [] FileIDarray;
		FileIDarray = new int[count];
		for (c=count-1;c>-1;c--)
		{
			FileIDarray[c] = fileIDs.Pop();
		//	richTextBox2.Text = richTextBox2.Text + FileIDarray[c]+"\n";
		}
		for (ID=0;ID<count-1;ID++)
		{
			MySqlDataReader ReaderX;
			ReaderX = connect.GetFileText(FileIDarray[ID]);
			while (ReaderX.Read())
				{
					suborA = ReaderX.GetValue(0).ToString();
				}
			ReaderX.Close();
		double compare = Cosine.compare(riadok, suborA);
		compare = Math.Round(compare, 10);
	//	SetrichboxText(richTextBox2, compare.ToString());
		connect.executeCompare(lastFile_ID, FileIDarray[ID], compare);
		double cmpr = compare*100;
		cmpr = Math.Round(cmpr, 2);
		ListViewItem rowCompare = new ListViewItem(lastFile_ID+"::"+FileIDarray[ID]);
		rowCompare.SubItems.Add(cmpr.ToString());
		SetListViewText(listCompare, rowCompare);

		}
    	}
	}
//koniec porovnavania aktualneho suboru so subormi z DB
		  
			} // Koniec cyklu for pre kontrolu vyskytu podmienok zo zvolenych suborov
			SetStatusLabelText(StatusLabel, "Done");
			//StatusLabel.Text = "Done";
			
			SetbuttonEnable(button1, true);
			if(dbtest==2)
			{
			SetbuttonEnable(this.compare, true);
        	}
			if(dbtest!=2)
			{
			SetbuttonEnable(BtnSqlEditor, true);
			SetbuttonEnable(showDB, true);
			}
//	this.button1.Enabled = true;
			
		rdr=0;
		}
		
		void CompareClick(object sender, EventArgs e)
		{		  
			this.button1.Enabled = false;
			this.compare.Enabled = false;
			this.showDB.Enabled = false;
			this.BtnSqlEditor.Enabled = false;
			this.richTextBox1.Clear();
			this.richTextBox2.Clear();
			this.listresult.Items.Clear();
			this.listviewdb.Items.Clear();
			this.listCompare.Items.Clear();
	        FileTable.Clear();
	        CondTable.Clear();
	        CompareTable.Clear();
            noveVlakno = new Thread(FunkceVlakna3);
            noveVlakno.Start();
		}
        
		private void FunkceVlakna3()
        {
		SetStatusLabelText(StatusLabel, "Loading");
/*		int maxID=0;
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
*/
		int numOfFiles = this.listBox1.Items.Count;
		for (int i = 0; i<numOfFiles; i++)
			{
				if (i > 0)
				{
					SetStatusLabelText(StatusLabel, "Checking"); 
				}
				int FileSize;
				string fileName = (string)this.listBox1.Items[i];
		        string riadok = this.ReadPDFFileContent(fileName);
		        	FileStream fs;
                    fs = new FileStream(@fileName, FileMode.Open, FileAccess.Read);
			        FileSize = (int)fs.Length;
			        fs.Close();
		        FileTable.Rows.Add(i, fileName, FileSize, riadok, null);
		      		  ListViewItem row = new ListViewItem(i.ToString());
	                  	row.SubItems.Add(fileName);
	                  	row.SubItems.Add(FileSize.ToString());
	                  	SetListViewText(listresult, row);
		        
			}
		string asdf ="";
		double cmpr=0;
		string suborA="";
		string suborB="";
		int ID;
		int cID=0;
//		int count = fileIDs.Count;
		int count = FileTable.Rows.Count;
		int c=count;
		int [] FileIDarray;
		FileIDarray = new int[count];
		SetProgressBarMax(progressBar1, count);
	//		StatusLabel.Text = "Checking";
	//		StatusLabel.Invalidate();
	//		this.Update();
/*		for (c=count-1;c>-1;c--)
		{
			FileIDarray[c] = fileIDs.Pop();
		//	richTextBox2.Text = richTextBox2.Text + FileIDarray[c]+"\n";
		}
*/		
		for (ID=0;ID<count;ID++)
		{
	//		richTextBox2.Text = richTextBox2.Text + ID+"\n";

				for( int i = 0; i < FileTable.Rows.Count; i++)
				    {
				    	DataRow frow = FileTable.Rows[i];
				    	if (frow.RowState != DataRowState.Deleted)
				    	{
				    		if((int)frow["FtID"] == ID)
				        	{
				        	suborA = frow["Ftriadok"].ToString();
				        	}
				    	}
				    }	
	
	/*		MySqlDataReader ReaderX;
			ReaderX = connect.GetFileText(FileIDarray[ID]);
			while (ReaderX.Read())
				{
					suborA = ReaderX.GetValue(0).ToString();
				}
			ReaderX.Close();
	*/		
			cID = ID+1;
			for (cID=(1+ID);cID<count;cID++)
				{
				for( int i = 0; i < FileTable.Rows.Count; i++)
					    {
					    	DataRow frow = FileTable.Rows[i];
					    	if (frow.RowState != DataRowState.Deleted)
					    	{
					    		if((int)frow["FtID"] == cID)
					        	{
					        	suborB = frow["Ftriadok"].ToString();
					        	}
					    	}
					    }				
				
				
	/*			MySqlDataReader ReaderY;
				ReaderY = connect.GetFileText(FileIDarray[cID]);
				while (ReaderY.Read())
					{
					suborB = ReaderY.GetValue(0).ToString();
					}
				ReaderY.Close();
	*/
	//			richTextBox2.Text = richTextBox2.Text + cID+"\n";
		
		string compare = Cosine.compare(suborA, suborB).ToString();
		
	//	connect.executeCompare(FileIDarray[ID], FileIDarray[cID], compare);
				CompareTable.Rows.Add(ID, cID, compare);
				cmpr = Math.Round((Cosine.compare(suborA, suborB)*100), 2);
				asdf = asdf + ID +" = "+ cID+ " :: "+ cmpr +"\n";
	//			SetrichboxText(richTextBox2, asdf);
		ListViewItem rowCompare = new ListViewItem(ID+"::"+cID);
		rowCompare.UseItemStyleForSubItems = false;
			if(cmpr>60)
			{
				rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.Red, rowCompare.Font);
			}
			else
			{
			rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.White, rowCompare.Font);
			}
		//rowCompare.SubItems.Add(cmpr.ToString());
		SetListViewText(listCompare, rowCompare);

				}
			SetProgressBarText(progressBar1, ID + 1);
		//	richTextBox2.Text = richTextBox2.Text + FileIDarray[ID]+"\n";
		}
		
		SetStatusLabelText(StatusLabel, "Done");
//		richTextBox2.Text = richTextBox2.Text + Cosine.compare(suborA, suborB).ToString()+"\n";
//		richTextBox2.Text = richTextBox2.Text +"\n"+ suborA+ "\n"+ suborB+"\n" + ID +" blum "+ cID+"\n";
//		richTextBox2.Text = richTextBox2.Text + ID +" blum "+ cID+"\n";
			SetbuttonEnable(button1, true);
			SetbuttonEnable(this.compare, true);
			if(dbtest!=2)
			{
			SetbuttonEnable(BtnSqlEditor, true);
			SetbuttonEnable(showDB, true);
			}
		
		}
		
		
		void Button2Click(object sender, EventArgs e)
		{

			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "PDF Files (*.pdf)|*.pdf";
			ofd.Multiselect = true;
			DialogResult result = ofd.ShowDialog();
			if (result != DialogResult.OK)
			{
				return;
			}
			
			foreach (string filename in ofd.FileNames)
			{
				this.listBox1.Items.Add(filename);
			}
		}
		
		void ListBox1DoubleClick(object sender, EventArgs e)
		{
			if (this.listBox1.SelectedItem != null)
			{
			//Thread THcontent = new Thread(delegate() { while (true); });  
			//THcontent.Start();
			string fileName = (string)this.listBox1.SelectedItem;
			string fileContent = this.ReadPDFFileContent(fileName);
			filecont.Text ="File Content: "+ fileName;
			this.richTextBox1.Text = fileContent;
			//THcontent.Suspend();
			}
			
		}
		
		void clrFileClick(object sender, EventArgs e)
		{
			this.listBox1.Items.Clear();
		}
		
		void remFileClick(object sender, EventArgs e)
		{
			if (this.listBox1.SelectedItem != null)
			{
				this.listBox1.Items.RemoveAt(listBox1.SelectedIndex);
			}
		}
		
		private void btnAddCondition_Click(object sender, EventArgs e)
        {
            Podminka condition = new Podminka();
            string[] NOpole = new string[] {"", ".*\\n", ".*\\n.*\\n",".*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n.*\\n"};
			if (this.NOcombo.SelectedIndex >= 0)
			{
			condition.Text = textAddCondition.Text + NOpole[this.NOcombo.SelectedIndex];
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);

			}
			else
			{
			condition.Text = textAddCondition.Text;
			listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);
			}
            
        }

		void AddcondfileClick(object sender, EventArgs e)
		{
			OpenFileDialog opencondfile = new OpenFileDialog();
			opencondfile.Filter = "TXT Files (*.txt)|*.txt";
			DialogResult result = opencondfile.ShowDialog();
			if (result != DialogResult.OK)
			{
				return;
			}
			StreamReader sr = File.OpenText(opencondfile.FileName);
			bool r = true;
			string line;
			while(r)
			{
				Podminka co = new Podminka();
				line = sr.ReadLine();
				if (line==null)
				{
					r = false;	
					sr.Close();
				}
				else
				{
				co.Text = line;
				listConditions.Items.Add(co.Text);
				conditionArray.Add(co);
				}
			}
			
		}
		
		void ClrCondClick(object sender, EventArgs e)
		{
			this.listConditions.Items.Clear();
			this.conditionArray.Clear();
		}
		
		void RmCondClick(object sender, EventArgs e)
		{
			if (this.listConditions.SelectedItem != null)
			{
				int shit = this.listConditions.SelectedIndex;
				this.listConditions.Items.RemoveAt(listConditions.SelectedIndex);
				this.conditionArray.RemoveAt(shit);
			}
		}
	
	private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
            	btnAddCondition.PerformClick();
            }
        }
		
		void ContainsClick(object sender, EventArgs e)
		{
			Podminka condition = new Podminka();
            string[] NOpole = new string[] {"", ".*\\n", ".*\\n.*\\n",".*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n.*\\n"};
			if (this.NOcombo.SelectedIndex >= 0)
			{
			condition.Text = textAddCondition.Text + NOpole[this.NOcombo.SelectedIndex];
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);

			}
			else
			{
			condition.Text = textAddCondition.Text;
			listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);	
			}
          	
		}
		
		void BeginwithClick(object sender, EventArgs e)
		{
			Podminka condition = new Podminka();
            string[] NOpole = new string[] {"", ".*\\n", ".*\\n.*\\n",".*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n.*\\n"};
			if (this.NOcombo.SelectedIndex >= 0)
			{
			condition.Text = textAddCondition.Text + "\\w" + NOpole[this.NOcombo.SelectedIndex];
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);

			}
			else
			{
			condition.Text = textAddCondition.Text + "\\w";
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);			
			}
		}
		
		void EndwithClick(object sender, EventArgs e)
		{
			Podminka condition = new Podminka();
            string[] NOpole = new string[] {"", ".*\\n", ".*\\n.*\\n",".*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n.*\\n"};
			if (this.NOcombo.SelectedIndex >= 0)
			{
			condition.Text = "\\w" + textAddCondition.Text + NOpole[this.NOcombo.SelectedIndex];
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);

			}
			else
			{
			condition.Text = "\\w" + textAddCondition.Text;
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);			
			}
		}
		
		void SinglewordClick(object sender, EventArgs e)
		{
			Podminka condition = new Podminka();
            string[] NOpole = new string[] {"", ".*\\n", ".*\\n.*\\n",".*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n",".*\\n.*\\n.*\\n.*\\n.*\\n"};
			if (this.NOcombo.SelectedIndex >= 0)
			{
			condition.Text = "\\b" + textAddCondition.Text + "\\b" + NOpole[this.NOcombo.SelectedIndex];
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);

			}
			else
			{
			condition.Text = "\\b" + textAddCondition.Text + "\\b";
            listConditions.Items.Add(condition.Text);
            conditionArray.Add(condition);			
			}
		}
		
		void addcClick(object sender, EventArgs e)
		{
			string[] poleregex = new string[] {"|", "\\w","\\W","\\s","\\S","\\d","\\D","\\b"};
			if (this.condcombo.SelectedIndex >= 0)
			{
				int curpos = textAddCondition.SelectionStart;
			
				textAddCondition.Text = 
					textAddCondition.Text.Substring(0, curpos) +
					poleregex[this.condcombo.SelectedIndex] +
					textAddCondition.Text.Substring(curpos);
				
				textAddCondition.Focus();
				textAddCondition.SelectionStart = curpos + poleregex[this.condcombo.SelectedIndex].Length;
				textAddCondition.SelectionLength = 0;
			}
			else
			{
			condcombo.Text = "choose some condition";	
			}
		}
		
		void MySqlSetupToolStripMenuItemClick(object sender, EventArgs e)
		{
			Form1 form = new Form1();
			DialogResult res = form.ShowDialog();
			if (res == DialogResult.OK)
			{
				this.username = form.username;
				this.password = form.pwd;
				this.server = form.srv;
				this.database = form.db;
				
				// Set the INI file
				
				StreamWriter sw = File.CreateText("config.ini");
				sw.WriteLine("username = " + this.username);
				sw.WriteLine("password = " + this.password);
				sw.WriteLine("server = " + this.server);
				sw.WriteLine("database = " + this.database);
				sw.Close();
				
			}

				this.MainFormLoad(sender, e);
 
			
		}
		void EditorMySqlToolStripMenuItemClick(object sender, EventArgs e)
		{
			if(dbtest!=2)
			{
			Form3 form3 = new Form3();
			DialogResult res = form3.ShowDialog();
			}
		}
		void BtnSqlEditorClick(object sender, EventArgs e)
		{
			if(dbtest!=2)
			{
			Form3 form3 = new Form3();
			DialogResult res = form3.ShowDialog();
			}
		}
		
		void RegularExpToolStripMenuItemClick(object sender, EventArgs e)
		{
			Form2 form2 = new Form2();
			DialogResult res = form2.ShowDialog();
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			Form4 form4 = new Form4();
			DialogResult res = form4.ShowDialog();
		}

        System.Windows.Forms.Timer tmrCheckDB = new System.Windows.Forms.Timer(); 

		void BtnconClick(object sender, EventArgs e)
		{
			MainFormLoad(sender, e);
		}
		void BtndisconClick(object sender, EventArgs e)
		{
			connect.close();
	    		this.compare.Enabled = true;
	    		this.showDB.Enabled = false;
				this.BtnSqlEditor.Enabled = false;
				this.EditorMySqlToolStripMenuItem.Enabled = false;
			dbtest=2;
		}
		        
		void MainFormLoad(object sender, EventArgs e)
		{

			dbtest = connect.testDatabase();
	    	if(dbtest == 1)
			{
	   			Form1 form = new Form1();
				form.ShowDialog();
				this.MainFormLoad(sender, e);
//               tmrCheckDB.Interval = 1000;
 //               tmrCheckDB.Tick += new EventHandler(tmrCheckDB_Tick);
 //               tmrCheckDB.Start();
			}
	    	if(dbtest==2)
	    	{
	    		this.compare.Enabled = true;
	    		this.showDB.Enabled = false;
				this.BtnSqlEditor.Enabled = false;
				this.EditorMySqlToolStripMenuItem.Enabled = false;
	    	}
	    	if(dbtest==0)
	    	{
	    		this.compare.Enabled = false;
	    		this.showDB.Enabled = true;
				this.BtnSqlEditor.Enabled = true;
				this.EditorMySqlToolStripMenuItem.Enabled = true;	    		
	    	}

		}

        void tmrCheckDB_Tick(object sender, EventArgs e)
        {
   //         if (connect.testDatabase()) (sender as System.Windows.Forms.Timer).Stop();
        }

/*		void DowndbClick(object sender, EventArgs e)
		{
			//string myConnectionString = "Server = potion.synapsia.org; Database = test; Uid = root; Pwd = heslo;";                                                                             
			string myConnectionString =
				"SERVER=" + server + ";" +
				"DATABASE=" + database + ";" +
				"UID=" + username + ";" +
				"PASSWORD=" + password + ";";
			MySqlConnection myConnection = new MySqlConnection(myConnectionString);
             myConnection.Open();                                                                 
             MySqlDataAdapter adapter = new MySqlDataAdapter("select File from file", myConnection);                                                                                   
             DataTable soubory = new DataTable();                                                 
             adapter.Fill(soubory);
             myDB.Close();                                                                        
             int pdfindex = 0;                                                                    
             foreach (DataRow row in soubory.Rows)                                                
             {
             	Byte[] fileByteData = (Byte[])row[0];
                 MemoryStream fileMemoryStream = new MemoryStream(fileByteData);                  
                 FileStream fs = new FileStream(@"C:\temp\neco" + pdfindex + ".pdf", FileMode.Create);                                                                                
                 fileMemoryStream.WriteTo(fs);                                                    
                 fs.Flush();                                                                      
                 fs.Close();                                                                      
                 pdfindex++;                                                                      
             }                                
		}		
	*/
	
		void ShowDBClick(object sender, EventArgs e)
		{
			if (dbtest!=2)
			{
			rdr = 1;
			this.showDB.Enabled = false;
			this.button1.Enabled = false;
			this.BtnSqlEditor.Enabled = false;
			this.listviewdb.Items.Clear();
			this.listresult.Items.Clear();
            noveVlakno = new Thread(FunkceVlakna2);
            noveVlakno.Start();	
			}
		}
		
		private void FunkceVlakna2()
		{
			SetStatusLabelText(StatusLabel, "Loading");
//			this.showDB.Enabled = false;
//			this.button1.Enabled = false;
//			this.BtnSqlEditor.Enabled = false;
//			this.listviewdb.Items.Clear();
//			this.listresult.Items.Clear();
			MySqlDataReader Reader;
			Reader = connect.executeGetFile();
			while (Reader.Read())
				{

					ListViewItem rowFile = new ListViewItem(Reader.GetValue(0).ToString());
					rowFile.SubItems.Add(Reader.GetValue(1).ToString());
					rowFile.SubItems.Add(Reader.GetValue(2).ToString());
					SetListViewText(listresult, rowFile);
					//listresult.Items.Add(rowFile);
				}
							Reader.Close();
			SetbuttonEnable(button1, true);
			SetbuttonEnable(BtnSqlEditor, true);
			SetbuttonEnable(showDB, true);
			SetStatusLabelText(StatusLabel, "Done");
			rdr = 0;
			//this.button1.Enabled = true;
			//this.BtnSqlEditor.Enabled = true;
			//this.showDB.Enabled = true;
		}
		
		void ListresultColumnClick(object sender, ColumnClickEventArgs e)
		{
			
		}

		void ListresultSelectedIndexChanged(object sender, EventArgs e)
		{
			if(rdr==0)
			{
			string readrow = "";
			this.richTextBox1.Clear();
			this.richTextBox2.Clear();
			this.listviewdb.Items.Clear();
			

			filecont.Text ="Content of FileID: "+ listresult.FocusedItem.SubItems[0].Text;//.SelectedItems[0].SubItems[1].Text;
				if(dbtest!=2)
				{
							this.listCompare.Items.Clear();
							MySqlDataReader Reader;
		 					Reader = connect.executeGetFileText(listresult);
							while (Reader.Read())
							{
								
								for (int i=0;i<Reader.FieldCount;i++)
								{
									readrow = Reader.GetValue(i).ToString()+" \n";
									
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
								//	SetListViewText(listviewdb, rowCond);
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
								//	rowCompare.SubItems.Add(cmpr.ToString());
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
										rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.Red, rowCompare.Font);
									}
									else
									{
										rowCompare.SubItems.Add(cmpr.ToString(),Color.Black, Color.White, rowCompare.Font);
									}
								//	rowCompare.SubItems.Add(cmpr.ToString());
									listCompare.Items.Add(rowCompare);
						}
						Reader.Close();							
				}
				}
				if(dbtest==2)
				{
				    for (int i = 0; i < CondTable.Rows.Count; i++)
				    {
				        DataRow crow = CondTable.Rows[i];
				
				        if (crow.RowState != DataRowState.Deleted)
				        {
				        if(crow["CtID"].ToString() == listresult.FocusedItem.SubItems[0].Text)
				        	{
				            ListViewItem rowCond = new ListViewItem(crow["CtID"].ToString());
				            rowCond.SubItems.Add (crow["CtName"].ToString());
				            rowCond.SubItems.Add (crow["CtTruth"].ToString());
				            rowCond.SubItems.Add (crow["CtText"].ToString());
				            rowCond.SubItems.Add(crow["CtDate"].ToString());
				            listviewdb.Items.Add(rowCond);
				        	}
				          }
						}
				    for( int i = 0; i < FileTable.Rows.Count; i++)
				    {
				    	DataRow frow = FileTable.Rows[i];
				    	if (frow.RowState != DataRowState.Deleted)
				    	{
				        if(frow["FtID"].ToString() == listresult.FocusedItem.SubItems[0].Text)
				        	{
				        	richTextBox1.Text = frow["Ftriadok"].ToString();
				        	}
				    	}
				    }
				}
		}
		
		void ListviewdbSelectedIndexChanged(object sender, EventArgs e)
		{
			richTextBox2.Text = listviewdb.FocusedItem.SubItems[3].Text;
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

		delegate void SetrichTextboxCallback(RichTextBox ctrl, string text);
        private void SetrichboxText(RichTextBox ctrl, string text)
        {
            if (this.InvokeRequired)
            {
            	SetrichTextboxCallback d = new SetrichTextboxCallback(SetrichboxText);
                this.Invoke(d, new object[] { ctrl, text });
            }
            else
            {
            	ctrl.Text = text;
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

//		delegate void SetprogressBarCallback(ToolStripProgressBar ctrl, int number);
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
	
    class Podminka
    {
        private string text;

        public string Text
        {
            get { return text; }
            set 
            { 
                text = value; 
                regxExp = new Regex(text);
            }
        }
        private Regex regxExp;


        public Regex RegxExp
        {
            get { return regxExp; }
        }
        private string condStat;

        public string CondStat
        {
            get { return condStat; }
            set { condStat = value; }
        }

    }
	/*
    class Expression
    {
        int _cursorPosition = 0;
        bool _beginWith = false;
        bool _endWith = false;
        bool _singleWord = false;
        private string _value;
                
        public bool BeginWith
        {
            get { return _beginWith; }
            set //{ _beginWith = value; }
            { 
            	if (!_value.EndsWith("\\w")) _beginWith = value;
               else _beginWith=false;
           	}
        }

        public bool EndWith
        {
            get { return _endWith; }
            set //{ _endWith = value; }
            { 
               if (!_value.StartsWith("\\w")) _endWith = value;
               else _endWith=false;
            }
        }

        public bool SingleWord
        {
            get { return _singleWord; }
            set 
            { 
               if (!_value.Contains("\\b")) _singleWord = value;
               else _singleWord=false;
            }
        }

        public string Value
        {
            get 
            {
                return (_endWith ? "\\w" : "") + (_singleWord ? "\\b" : "") + _value + (_singleWord ? "\\b" : "") + (_beginWith ? "\\w" : ""); 
            }
            set 
            { 
                _value = value; 
            }
        }

        
    }
    */
}

