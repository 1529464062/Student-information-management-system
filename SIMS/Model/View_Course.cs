using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
namespace Maticsoft.Model
{
    //View_Course
    public class View_Course
    {

        /// <summary>
        /// StudentId
        /// </summary>		
        private string _studentid;
        public string StudentId
        {
            get { return _studentid; }
            set { _studentid = value; }
        }
        /// <summary>
        /// StudentName
        /// </summary>		
        private string _studentname;
        public string StudentName
        {
            get { return _studentname; }
            set { _studentname = value; }
        }
        /// <summary>
        /// StudentClass
        /// </summary>		
        private string _studentclass;
        public string StudentClass
        {
            get { return _studentclass; }
            set { _studentclass = value; }
        }
        /// <summary>
        /// CourseName
        /// </summary>		
        private string _coursename;
        public string CourseName
        {
            get { return _coursename; }
            set { _coursename = value; }
        }
        /// <summary>
        /// CourseScore
        /// </summary>		
        private decimal _coursescore;
        public decimal CourseScore
        {
            get { return _coursescore; }
            set { _coursescore = value; }
        }

    }
}

