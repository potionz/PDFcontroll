/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 20.2.2010
 * Time: 12:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Threading;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.Data.OleDb;
using MySql.Data;
using MySql.Data.MySqlClient;
using log4net;
using log4net.Config;



namespace PDFv2
{
	/// <summary>
	/// Description of connect.
	/// </summary>
	public class connect
	{		
		private static readonly ILog logger = LogManager.GetLogger(typeof (connect));
		private static MySqlConnection conn;
		private static database dbbase = new database();
		private static Form1 form = new Form1();

		
		//private MySqlConnection conn;

		public connect()
		{
			log4net.Config.XmlConfigurator.Configure();
			//MySqlConnection conn = new MySqlConnection(conndb());
			
		}
		
		public static void getCredentials()
		{
			//database db = new database();
			if (!File.Exists("config.ini"))
		    {
		    	return;
		    	
		    }
			else
			{			    
			StreamReader sr = File.OpenText("config.ini");
			
			string line;
			int indexOfColon;

			line = sr.ReadLine();
			indexOfColon = line.IndexOf('=');
			dbbase.username = line.Substring(indexOfColon + 1);
	//		username = line.Substring(indexOfColon + 1);

			line = sr.ReadLine();
			indexOfColon = line.IndexOf('=');
			dbbase.password = line.Substring(indexOfColon + 1);
	//		password = line.Substring(indexOfColon + 1);
			
			line = sr.ReadLine();
			indexOfColon = line.IndexOf('=');
			dbbase.server = line.Substring(indexOfColon + 1);
	//		server = line.Substring(indexOfColon + 1);
			
			line = sr.ReadLine();
			indexOfColon = line.IndexOf('=');
			dbbase.dbase = line.Substring(indexOfColon + 1);
	//		database = line.Substring(indexOfColon + 1);
			
			sr.Close();
			}
		}
		
		public static string conndb()
		{
		getCredentials();
		string MyConString =
				"SERVER=" + dbbase.server + ";" +
				"DATABASE=" + dbbase.dbase + ";" +
				"UID=" + dbbase.username + ";" +
				"PASSWORD=" + dbbase.password + ";" + 
			//	"Min Pool Size=1;Max Pool Size=150;Connect Timeout=300;" +
			//	"SET SESSION max_allowed_packet=32M;" +
				"Allow Zero Datetime=true;";
		return MyConString;
		}
		
		public static MySqlConnection tryDatabase()
		{
			conn = new MySqlConnection(conndb());
 							try
							{
 								conn.Open();
 						// 		logger.Info(connect.state().ToString());
 								
							}
							catch (MySqlException ex)
							{
							
							DialogResult result = MessageBox.Show(ex.Message+"\n\nCannot connect to MySql server!\nDo you want to setup your MySql connection ?", "Error" , MessageBoxButtons.YesNo,MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
							if (result == DialogResult.Yes)
					        	 {
								Form1 form = new Form1();
								form.ShowDialog();
								}
							if (result == DialogResult.No)
								{
								Application.Exit();
								}
								
							}
							finally
							{

							}

		return conn;
		}
		
		public static int testDatabase()
		{		
		conn = new MySqlConnection(conndb());
		int tryconn;
			tryconn = 2;
 							try
							{
 								conn.Open();
 								tryconn = 0;
 							//	logger.Info(connect.state().ToString());
							}
							catch (MySqlException ex)
								{
							
							DialogResult result = MessageBox.Show(ex.Message+"\n\nCannot connect to MySql server!\nDo you want to setup your MySql connection ?", "Error" , MessageBoxButtons.YesNo,MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
							if (result == DialogResult.Yes)
					        	 {
								tryconn = 1;
//								Form1 form = new Form1();
//								form.ShowDialog();
								
								}
							if (result == DialogResult.No)
								{
								tryconn = 2;
							//	Application.Exit();
								}
								
							}
							finally
							{

							}
							
		return tryconn;
		}
		
		public void executeFile(string fileName, int FileSize, string riadok, byte[] rawData, string hash)
		{
	//	MySqlConnection conn = new MySqlConnection(conndb());
		//tryDatabase();
		MySqlCommand cmdF = new MySql.Data.MySqlClient.MySqlCommand();
//		string SQLF = "set max_allowed_packet = 16000000; INSERT INTO file VALUES(NULL, @FileName, @FileSize, @FileText ,@File, @Hash)";
		string SQLF = "INSERT INTO file VALUES(NULL, @FileName, @FileSize, @FileText ,@File, @Hash)";
		cmdF.Connection = conn;
		cmdF.CommandText = SQLF;
		cmdF.Parameters.Add("@FileName", MySqlDbType.MediumText).Value= fileName;
		cmdF.Parameters.Add("@FileSize", MySqlDbType.Int32).Value= FileSize;
		cmdF.Parameters.Add("@FileText", MySqlDbType.MediumText).Value= riadok;
		cmdF.Parameters.Add("@File", MySqlDbType.MediumBlob).Value= rawData;
		cmdF.Parameters.Add("@Hash", MySqlDbType.Text).Value = hash;
	//	conn.Open();
		cmdF.ExecuteNonQuery();
	//	conn.Close();
		}
		public void executeCond(string podmienka, bool matches, string CondText, string relationFile_ID)
		{
	//		MySqlConnection conn = new MySqlConnection(conndb());
			//connect.tryDatabase();
			MySqlCommand cmdC = new MySql.Data.MySqlClient.MySqlCommand();
		 	string SQLC;
		    SQLC = "INSERT INTO `condition` VALUES(NULL, @CondName, @CondTruth, @CondText, @Date, @File_ID)";
		    cmdC.Connection = conn;
		    cmdC.CommandText = SQLC;
		    cmdC.Parameters.Add("@CondName",MySqlDbType.Text).Value = podmienka;
		    cmdC.Parameters.Add("@CondTruth",MySqlDbType.Bit).Value = ((matches) ? "1" : "0");
		    cmdC.Parameters.Add("@CondText",MySqlDbType.Text).Value = CondText;
		    cmdC.Parameters.Add("@Date",MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		    cmdC.Parameters.Add("@File_ID", MySqlDbType.Int32).Value = relationFile_ID;
	//	    conn.Open();
		    cmdC.ExecuteNonQuery();
	//	    conn.Close();
		}
		public static void executeRelation(string relationCond_ID, string relationFile_ID)
		{
    	//    MySqlConnection conn = new MySqlConnection(conndb());
	   //     connect.tryDatabase();		
		    MySqlCommand cmdRelation = new MySql.Data.MySqlClient.MySqlCommand();
	        string SQLrelation;
	        SQLrelation = "INSERT INTO `filecondition` VALUES(NULL, @Cond_ID, @File_ID)";
	        cmdRelation.Connection = conn;
	        cmdRelation.CommandText = SQLrelation;
	        cmdRelation.Parameters.Add("@Cond_ID",MySqlDbType.Int32).Value = relationCond_ID;
	        cmdRelation.Parameters.Add("@File_ID",MySqlDbType.Int32).Value = relationFile_ID;
	 //       conn.Open();
	        cmdRelation.ExecuteNonQuery();
	 //       conn.Close();
		}
		
		public static void executeCompare(int ID, int cID, double compare)
		{
			MySqlCommand cmdCompare = new MySql.Data.MySqlClient.MySqlCommand();
			string SQLcompare;
			SQLcompare = "INSERT INTO `compare` VALUES(NULL, @FileID_A, @FileID_B, @Compare)";
			cmdCompare.Connection = conn;
			cmdCompare.CommandText = SQLcompare;
			cmdCompare.Parameters.Add("@FileID_A",MySqlDbType.Int32).Value = ID;
			cmdCompare.Parameters.Add("@FileID_B",MySqlDbType.Int32).Value = cID;
			cmdCompare.Parameters.Add("@Compare",MySqlDbType.Double).Value = compare;
			cmdCompare.ExecuteNonQuery();
		}
		public static void executeDrop()
		{
			MySqlCommand cmdDrop = new MySql.Data.MySqlClient.MySqlCommand();
			string SQLdrop;
			SQLdrop = "TRUNCATE `compare`;"+
					"TRUNCATE `condition`;"+
					"TRUNCATE `file`;"+
					"TRUNCATE `filecondition`;";
			cmdDrop.Connection = conn;
			cmdDrop.CommandText = SQLdrop;
			cmdDrop.ExecuteNonQuery();
		}
	
		// MySQL open state close		!!!!

		public static void open()
		{
		//	MySqlConnection conn = new MySqlConnection(conndb());
			conn.Open();
		}	
		public static void close()
		{
		//	MySqlConnection conn = new MySqlConnection(conndb());
			conn.Close();
			conn.Dispose();
		}
		public static ConnectionState state()
		{
		//	MySqlConnection conn = new MySqlConnection(conndb());
			return conn.State;
		}
		
		//
		//	MySQL data Readers			!!!!!
		
		public static MySqlDataReader executeGetFileID()
		{
	//		MySqlConnection conn = new MySqlConnection(conndb());
		//    connect.tryDatabase();
		MySqlCommand cmdrelaceF = conn.CreateCommand();
			cmdrelaceF.CommandText = "SELECT MAX(File_ID) FROM file;";// WHERE FileName='"+fileName.Replace("\\", "\\\\")+"' AND FileSize='"+FileSize+"';";
			MySqlDataReader Reader;
		//conn.Open();
			return Reader = cmdrelaceF.ExecuteReader();
		//	Reader.Close();
		  
		}
		
		public static MySqlDataReader executeGetCondID()
		{
	//		MySqlConnection conn = new MySqlConnection(conndb());
		//    connect.tryDatabase();			
		MySqlCommand cmdrelaceC = conn.CreateCommand();
			MySqlDataReader ReaderC;
			cmdrelaceC.CommandText = "SELECT MAX(Cond_ID) FROM `condition`;";// WHERE FileName='"+fileName.Replace("\\", "\\\\")+"' AND FileSize='"+FileSize+"';";
	//		conn.Open();
			return ReaderC = cmdrelaceC.ExecuteReader();
		//	ReaderC.Close();
		//	conn.Close();
		}
		
		public static MySqlDataReader executeGetFileText(ListView listresult)
		{
		//	MySqlConnection conn = new MySqlConnection(conndb());
		//    connect.tryDatabase();
		MySqlCommand commandShow = conn.CreateCommand();
			MySqlDataReader Reader;
			commandShow.CommandText = "SELECT `FileText` FROM `file` WHERE `File_ID`='"+listresult.FocusedItem.SubItems[0].Text.Replace("\\", "\\\\")+"';"; //  !!!SELECT FileText!!!
		//	conn.Open();
			return Reader = commandShow.ExecuteReader();
		//	Reader.Close();
		}
		public static MySqlDataReader executeGetCompare(ListView listresult)
		{
			MySqlCommand cmdcomp = conn.CreateCommand();
			MySqlDataReader Reader;
			cmdcomp.CommandText = "SELECT `FileID_B`, `Compare` FROM `compare` WHERE `FileID_A` = '"+listresult.FocusedItem.SubItems[0].Text.Replace("\\", "\\\\")+"';";
			return Reader = cmdcomp.ExecuteReader();
		}
		public static MySqlDataReader executeGetCompareB(ListView listresult)
		{
			MySqlCommand cmdcomp = conn.CreateCommand();
			MySqlDataReader Reader;
			cmdcomp.CommandText = "SELECT `FileID_A`, `Compare` FROM `compare` WHERE `FileID_B` = '"+listresult.FocusedItem.SubItems[0].Text.Replace("\\", "\\\\")+"';";
			return Reader = cmdcomp.ExecuteReader();
		}		
		public static MySqlDataReader executeHashFileID(string hash)
		{
			MySqlCommand commandShow = conn.CreateCommand();
			MySqlDataReader Reader;
			commandShow.CommandText = "SELECT `File_ID` FROM `file` WHERE `Hash`='"+hash+"';";
			return Reader = commandShow.ExecuteReader();
		}
		
		public static MySqlDataReader executeGetCondition(ListView listresult)
		{
		//	MySqlConnection conn = new MySqlConnection(conndb());
		//    connect.tryDatabase();
		MySqlCommand commandCond = conn.CreateCommand();
			MySqlDataReader Reader;
			commandCond.CommandText = "SELECT * FROM `condition` WHERE `File_ID`='"+listresult.FocusedItem.SubItems[0].Text+"';";
		//	conn.Open();
			return Reader = commandCond.ExecuteReader();
		//	Reader.Close();
		}
		public static MySqlDataReader executeGetFile()
		{
	//		MySqlConnection conn = new MySqlConnection(conndb());
		 //   connect.tryDatabase();			
		 MySqlCommand commandShow = conn.CreateCommand();
			MySqlDataReader Reader;
			commandShow.CommandText = "SELECT * FROM file";
	//		conn.Open();
			return Reader = commandShow.ExecuteReader();
		//	Reader.Close();
		}
	
	/////////zmazat:
	/// 
	public static MySqlDataReader GetFileText(int ID)
		{
	//		MySqlConnection conn = new MySqlConnection(conndb());
		  //  connect.tryDatabase();
		  MySqlCommand commandShow = conn.CreateCommand();
			MySqlDataReader Reader;
			commandShow.CommandText = "SELECT `FileText` FROM `file` WHERE `File_ID`='"+ID+"'AND FileText IS NOT NULL;";
		//	conn.Open();
			return Reader = commandShow.ExecuteReader();
		//	Reader.Close();
			//conn.Close();
		}
	public static MySqlDataReader GetFileIDs()
		{
		MySqlCommand cmdShow = conn.CreateCommand();
		MySqlDataReader ReaderF;
		cmdShow.CommandText = "SELECT `File_ID` FROM `file` WHERE FileText IS NOT NULL;";
		return ReaderF = cmdShow.ExecuteReader();
		}

		public void downDB(int [] FileIDarray, int ID, string path)
		{
			MySqlCommand cmd = conn.CreateCommand();
			MySqlDataReader myData;
		//	string SQL;
			string File_name;
			int File_size;
			byte[] rawData;
			FileStream fs;
			cmd.CommandText = "SELECT FileName, FileSize, File FROM file WHERE File_ID='"+FileIDarray[ID]+"';";
			
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
			    fs = new FileStream(path+"\\"+FileN, FileMode.OpenOrCreate, FileAccess.Write);
			    fs.Write(rawData, 0, File_size);
			    fs.Close();			
			
			
		}	
	
	
	public static void downloadDB()
	{
	//		conn = new MySqlConnection(conndb());
			MySqlCommand cmd = conn.CreateCommand();
			MySqlDataReader myData;
			string SQL;
			string File_name;
			int File_size;
			byte[] rawData;
			FileStream fs;
			int ID;

			try

			{
		//	    conn.Open();
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

				for (c=count-1;c>-1;c--)
					{
						FileIDarray[c] = fileIDs.Pop();
					}
		for (ID=0;ID<count;ID++)
			{				
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
			    
		    }
		MessageBox.Show("File successfully written to disk!",
			        "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		
			    
		//	    conn.Close();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
			    MessageBox.Show("Error " + ex.Number + " has occurred: " + ex.Message,
			        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		
		
		
	}
	
	
	// MySQL CREATE database 			!!!!
	
		public void createDB()
		{
			MySqlCommand cmdCreate = new MySqlCommand();
	        string SQLcreate;
	        SQLcreate = "CREATE TABLE IF NOT EXISTS `file` (" +
						" `File_ID` int(10) unsigned NOT NULL AUTO_INCREMENT,"+
						" `FileName` text COLLATE utf8_czech_ci NOT NULL,"+
						" `FileSize` mediumint(8) unsigned NOT NULL,"+
						" `FileText` text COLLATE utf8_czech_ci NOT NULL,"+
						" `File` mediumblob NOT NULL,"+
	        			" `Hash` text CHARACTER SET utf8 COLLATE utf8_czech_ci NOT NULL,"+
						" PRIMARY KEY (`File_ID`)"+
						") ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci ROW_FORMAT=DYNAMIC AUTO_INCREMENT=1 ;"+
	        	
						"CREATE TABLE IF NOT EXISTS `filecondition` ("+
						" `ID` int(10) unsigned NOT NULL AUTO_INCREMENT,"+
						" `Cond_ID` int(10) unsigned NOT NULL,"+
						" `File_ID` int(10) unsigned NOT NULL,"+
						" PRIMARY KEY (`ID`),"+
						" KEY `File_ID` (`File_ID`),"+
						" KEY `Cond_ID` (`Cond_ID`)"+
						") ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci ROW_FORMAT=FIXED AUTO_INCREMENT=1 ;"+
	        	
						"CREATE TABLE IF NOT EXISTS `condition` ("+
						" `Cond_ID` int(10) unsigned NOT NULL AUTO_INCREMENT,"+
						" `CondName` varchar(100) COLLATE utf8_czech_ci NOT NULL,"+
						" `CondTruth` tinyint(1) DEFAULT NULL,"+
						" `CondText` text COLLATE utf8_czech_ci NOT NULL,"+
						" `Date` datetime NOT NULL,"+
						" `File_ID` int(10) unsigned NOT NULL,"+
						" UNIQUE KEY `Cond_ID` (`Cond_ID`),"+
						" KEY `File_ID` (`File_ID`)"+
						") ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci ROW_FORMAT=DYNAMIC AUTO_INCREMENT=1 ;"+
	        	
						"CREATE TABLE IF NOT EXISTS `compare` ("+
						" `Compare_ID` int(10) NOT NULL AUTO_INCREMENT,"+
						" `FileID_A` int(10) NOT NULL,"+
						" `FileID_B` int(10) NOT NULL,"+
						" `Compare` double NOT NULL,"+
						" UNIQUE KEY `Compare_ID` (`Compare_ID`)"+
						") ENGINE=MyISAM  DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci AUTO_INCREMENT=1 ;";  
	        cmdCreate.Connection = conn;
	        cmdCreate.CommandText = SQLcreate;
	        cmdCreate.ExecuteNonQuery();
			
		}
	
	
	
}
	
}

