using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL
{
    //View_Course
    public partial class View_Course
    {

        private readonly Maticsoft.DAL.View_Course dal = new Maticsoft.DAL.View_Course();
        public View_Course()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string StudentId, string StudentName, string StudentClass, string CourseName, decimal CourseScore)
        {
            return dal.Exists(StudentId, StudentName, StudentClass, CourseName, CourseScore);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.View_Course model)
        {
            dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.View_Course model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string StudentId, string StudentName, string StudentClass, string CourseName, decimal CourseScore)
        {

            return dal.Delete(StudentId, StudentName, StudentClass, CourseName, CourseScore);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.View_Course GetModel(string StudentId, string StudentName, string StudentClass, string CourseName, decimal CourseScore)
        {

            return dal.GetModel(StudentId, StudentName, StudentClass, CourseName, CourseScore);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Maticsoft.Model.View_Course GetModelByCache(string StudentId, string StudentName, string StudentClass, string CourseName, decimal CourseScore)
        {

            string CacheKey = "View_Course_1Model-" + StudentId + StudentName + StudentClass + CourseName + CourseScore;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(StudentId, StudentName, StudentClass, CourseName, CourseScore);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Maticsoft.Model.View_Course)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.View_Course> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Maticsoft.Model.View_Course> DataTableToList(DataTable dt)
        {
            List<Maticsoft.Model.View_Course> modelList = new List<Maticsoft.Model.View_Course>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Maticsoft.Model.View_Course model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Maticsoft.Model.View_Course();
                    model.StudentId = dt.Rows[n]["StudentId"].ToString();
                    model.StudentName = dt.Rows[n]["StudentName"].ToString();
                    model.StudentClass = dt.Rows[n]["StudentClass"].ToString();
                    model.CourseName = dt.Rows[n]["CourseName"].ToString();
                    if (dt.Rows[n]["CourseScore"].ToString() != "")
                    {
                        model.CourseScore = decimal.Parse(dt.Rows[n]["CourseScore"].ToString());
                    }


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        #endregion

    }
}