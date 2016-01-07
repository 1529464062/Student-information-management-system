using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// student_info:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class student_info
	{
		public student_info()
		{}
		#region Model
		private int _id;
		private string _studentid;
		private string _studentpassword;
		private string _studentname;
		private string _studentphoto;
		private string _studentsex;
		private string _studentnation;
		private string _studenttelehpone;
		private string _studentqq;
		private string _studentclass;
		private string _studentdormitory;
		private string _studentaddress;
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
		public string StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentPassword
		{
			set{ _studentpassword=value;}
			get{return _studentpassword;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentName
		{
			set{ _studentname=value;}
			get{return _studentname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentPhoto
		{
			set{ _studentphoto=value;}
			get{return _studentphoto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentSex
		{
			set{ _studentsex=value;}
			get{return _studentsex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentNation
		{
			set{ _studentnation=value;}
			get{return _studentnation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentTelehpone
		{
			set{ _studenttelehpone=value;}
			get{return _studenttelehpone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentQQ
		{
			set{ _studentqq=value;}
			get{return _studentqq;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentClass
		{
			set{ _studentclass=value;}
			get{return _studentclass;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentDormitory
		{
			set{ _studentdormitory=value;}
			get{return _studentdormitory;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string StudentAddress
		{
			set{ _studentaddress=value;}
			get{return _studentaddress;}
		}
		#endregion Model

	}
}

