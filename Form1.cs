/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 29.3.2009
 * Time: 13:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace PDFv2
{
	/// <summary>
	/// Description of Form1.
	/// </summary>
	public partial class Form1 : Form
	{
		private connect connect = new connect();
		private static database dbbase = new database();
		
		public Form1()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		public string username
		{
			get
			{
				return m_username;
			}
			set
			{
				m_username = value;
			}
		}

		public string pwd
		{
			get
			{
				return m_password;
			}
			set
			{
				m_password = value;
			}
		}
		
		public string srv
		{
			get
			{
				return m_server;
			}
			set
			{
				m_server = value;
			}
		}
		
		public string db
		{
			get
			{
				return m_database;
			}
			set
			{
				m_database = value;
			}
		}
				
		private string m_username;
		private string m_password;
		private string m_server;
		private string m_database;
		
		void ButtonOKClick(object sender, EventArgs e)
		{
			username = user.Text;
			pwd = password.Text;
			srv = server.Text;
			db = database.Text;
			
			StreamWriter sw = File.CreateText("config.ini");
			sw.WriteLine("username = " + username);
			sw.WriteLine("password = " + pwd);
			sw.WriteLine("server = " + srv);
			sw.WriteLine("database = " + db);
			sw.Close();
			connect.close();
			//connect.testDatabase();
			/*
			while(connect.testDatabase()==false)
			{
			connect.testDatabase();
			}
			if(connect.testDatabase()==true)
			{
			connect.tryDatabase();
			}
*/			
		}
		void Form1Load(object sender, EventArgs e)
		{
	/*
			connect.getCredentials();
			user.Text = dbbase.username;
			password.Text = dbbase.password;
			server.Text = dbbase.server;
			database.Text = dbbase.dbase;
	*/
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
			user.Text = line.Substring(indexOfColon + 2);

			line = sr.ReadLine();
			indexOfColon = line.IndexOf('=');
			password.Text = line.Substring(indexOfColon + 2);
			
			line = sr.ReadLine();
			indexOfColon = line.IndexOf('=');
			server.Text = line.Substring(indexOfColon + 2);
			
			line = sr.ReadLine();
			indexOfColon = line.IndexOf('=');
			database.Text = line.Substring(indexOfColon + 2);

			sr.Close();
			}			
			
			
		}
	}
}
