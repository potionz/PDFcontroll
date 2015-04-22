/*
 * Created by SharpDevelop.
 * User: JT
 * Date: 20.2.2010
 * Time: 12:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace PDFv2
{
	/// <summary>
	/// Description of database.
	/// </summary>
	public class database
	{
		private string m_username;
		private string m_password;
		private string m_server;
		private string m_database;
				
		public database()
		{

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
				public string password
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
		
		public string server
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
		
		public string dbase
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
		
	}
}
