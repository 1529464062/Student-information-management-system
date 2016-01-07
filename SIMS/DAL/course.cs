using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
    /// <summary>
    /// 数据访问类:course
    /// </summary>
    public partial class course
    {
        public course()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Id", "course");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from course");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists_CourseId(int CourseId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from course");
            strSql.Append(" where CourseId=@CourseId");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Maticsoft.Model.course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into course(");
            strSql.Append("CourseId,CourseName,CourseTeacher,CourseInfo,CourseStudentNum,CourseStudentSumNum)");
            strSql.Append(" values (");
            strSql.Append("@CourseId,@CourseName,@CourseTeacher,@CourseInfo,@CourseStudentNum,@CourseStudentSumNum)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.VarChar,20),
					new SqlParameter("@CourseName", SqlDbType.VarChar,20),
					new SqlParameter("@CourseTeacher", SqlDbType.VarChar,20),
					new SqlParameter("@CourseInfo", SqlDbType.VarChar,500),
					new SqlParameter("@CourseStudentNum", SqlDbType.Int,4),
                    new SqlParameter("@CourseStudentSumNum", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseId;
            parameters[1].Value = model.CourseName;
            parameters[2].Value = model.CourseTeacher;
            parameters[3].Value = model.CourseInfo;
            parameters[4].Value = model.CourseStudentNum;
            parameters[5].Value = model.CourseStudentSumNum;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update course set ");
            strSql.Append("CourseId=@CourseId,");
            strSql.Append("CourseName=@CourseName,");
            strSql.Append("CourseTeacher=@CourseTeacher,");
            strSql.Append("CourseInfo=@CourseInfo,");
            strSql.Append("CourseStudentNum=@CourseStudentNum,");
            strSql.Append("CourseStudentSumNum=@CourseStudentSumNum");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.VarChar,20),
					new SqlParameter("@CourseName", SqlDbType.VarChar,20),
					new SqlParameter("@CourseTeacher", SqlDbType.VarChar,20),
					new SqlParameter("@CourseInfo", SqlDbType.VarChar,500),
					new SqlParameter("@CourseStudentNum", SqlDbType.Int,4),
                    new SqlParameter("@CourseStudentSumNum", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.CourseId;
            parameters[1].Value = model.CourseName;
            parameters[2].Value = model.CourseTeacher;
            parameters[3].Value = model.CourseInfo;
            parameters[4].Value = model.CourseStudentNum;
            parameters[5].Value = model.CourseStudentSumNum;
            parameters[6].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete_Id(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from course ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete_CourseId(int CourseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from course ");
            strSql.Append(" where CourseId=@CourseId");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseId;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from course ");
            strSql.Append(" where Id in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.course GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CourseId,CourseName,CourseTeacher,CourseInfo,CourseStudentNum,parameters[4].Value = model.CourseStudentSumNum; from course ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            Maticsoft.Model.course model = new Maticsoft.Model.course();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Maticsoft.Model.course GetModel_CourseId(int CourseId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,CourseId,CourseName,CourseTeacher,CourseInfo,CourseStudentNum,CourseStudentSumNum from course ");
            strSql.Append(" where CourseId=@CourseId");
            SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.Int,4)
			};
            parameters[0].Value = CourseId;

            Maticsoft.Model.course model = new Maticsoft.Model.course();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.course DataRowToModel(DataRow row)
        {
            Maticsoft.Model.course model = new Maticsoft.Model.course();
            if (row != null)
            {
                if (row["Id"] != null && row["Id"].ToString() != "")
                {
                    model.Id = int.Parse(row["Id"].ToString());
                }
                if (row["CourseId"] != null)
                {
                    model.CourseId = row["CourseId"].ToString();
                }
                if (row["CourseName"] != null)
                {
                    model.CourseName = row["CourseName"].ToString();
                }
                if (row["CourseTeacher"] != null)
                {
                    model.CourseTeacher = row["CourseTeacher"].ToString();
                }
                if (row["CourseInfo"] != null)
                {
                    model.CourseInfo = row["CourseInfo"].ToString();
                }
                if (row["CourseStudentNum"] != null && row["CourseStudentNum"].ToString() != "")
                {
                    model.CourseStudentNum = int.Parse(row["CourseStudentNum"].ToString());
                }
                if (row["CourseStudentSumNum"] != null && row["CourseStudentSumNum"].ToString() != "")
                {
                    model.CourseStudentSumNum = int.Parse(row["CourseStudentSumNum"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,CourseId,CourseName,CourseTeacher,CourseInfo,CourseStudentNum,CourseStudentSumNum ");
            strSql.Append(" FROM course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,CourseId,CourseName,CourseTeacher,CourseInfo,CourseStudentNum,CourseStudentSumNum ");
            strSql.Append(" FROM course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from course T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "course";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

