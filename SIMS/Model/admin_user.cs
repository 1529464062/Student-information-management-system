using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// admin_user:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class admin_user
	{
		public admin_user()
		{}
		#region Model
		private int _id;
		private string _username;
		private string _userpassword;
		private int _logintime;
		private string _truename;
		private string _linktelephone;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPassword
		{
			set{ _userpassword=value;}
			get{return _userpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int LoginTime
		{
			set{ _logintime=value;}
			get{return _logintime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrueName
		{
			set{ _truename=value;}
			get{return _truename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LinkTelephone
		{
			set{ _linktelephone=value;}
			get{return _linktelephone;}
		}
		#endregion Model

	}
}

