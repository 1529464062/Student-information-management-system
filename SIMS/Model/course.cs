using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class course
	{
		public course()
		{}
		#region Model
		private int _id;
		private string _courseid;
		private string _coursename;
		private string _courseteacher;
		private string _courseinfo;
		private int _coursestudentnum;
        private int _coursestudentsumnum;
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
		public string CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CourseName
		{
			set{ _coursename=value;}
			get{return _coursename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CourseTeacher
		{
			set{ _courseteacher=value;}
			get{return _courseteacher;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CourseInfo
		{
			set{ _courseinfo=value;}
			get{return _courseinfo;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int CourseStudentNum
		{
			set{ _coursestudentnum=value;}
			get{return _coursestudentnum;}
		}
        public int CourseStudentSumNum
        {
            set { _coursestudentsumnum = value; }
            get { return _coursestudentsumnum; }
        }
		#endregion Model

	}
}

