using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// student_course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class student_course
	{
		public student_course()
		{}
		#region Model
		private int _id;
		private string _studentid;
		private string _courseid;
		private decimal _coursescore;
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
		public string CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal CourseScore
		{
			set{ _coursescore=value;}
			get{return _coursescore;}
		}
		#endregion Model

	}
}

