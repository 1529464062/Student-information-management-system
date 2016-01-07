using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL
{
    //View_Course
    public partial class View_Course
    {

        public bool Exists(string StudentId, string StudentName, string StudentClass, string CourseName, decimal CourseScore)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_Course");
            strSql.Append(" where ");
            strSql.Append(" StudentId = @StudentId and  ");
            strSql.Append(" StudentName = @StudentName and  ");
            strSql.Append(" StudentClass = @StudentClass and  ");
            strSql.Append(" CourseName = @CourseName and  ");
            strSql.Append(" CourseScore = @CourseScore  ");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentClass", SqlDbType.NVarChar,50),
					new SqlParameter("@CourseName", SqlDbType.NVarChar,50),
					new SqlParameter("@CourseScore", SqlDbType.Decimal,9)			};
            parameters[0].Value = StudentId;
            parameters[1].Value = StudentName;
            parameters[2].Value = StudentClass;
            parameters[3].Value = CourseName;
            parameters[4].Value = CourseScore;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Maticsoft.Model.View_Course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_Course(");
            strSql.Append("StudentId,StudentName,StudentClass,CourseName,CourseScore");
            strSql.Append(") values (");
            strSql.Append("@StudentId,@StudentName,@StudentClass,@CourseName,@CourseScore");
            strSql.Append(") ");

            SqlParameter[] parameters = {
			            new SqlParameter("@StudentId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@StudentName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@StudentClass", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CourseName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CourseScore", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.StudentId;
            parameters[1].Value = model.StudentName;
            parameters[2].Value = model.StudentClass;
            parameters[3].Value = model.CourseName;
            parameters[4].Value = model.CourseScore;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Maticsoft.Model.View_Course model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_Course set ");

            strSql.Append(" StudentId = @StudentId , ");
            strSql.Append(" StudentName = @StudentName , ");
            strSql.Append(" StudentClass = @StudentClass , ");
            strSql.Append(" CourseName = @CourseName , ");
            strSql.Append(" CourseScore = @CourseScore  ");
            strSql.Append(" where StudentId=@StudentId and StudentName=@StudentName and StudentClass=@StudentClass and CourseName=@CourseName and CourseScore=@CourseScore  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@StudentId", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@StudentName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@StudentClass", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CourseName", SqlDbType.NVarChar,50) ,            
                        new SqlParameter("@CourseScore", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.StudentId;
            parameters[1].Value = model.StudentName;
            parameters[2].Value = model.StudentClass;
            parameters[3].Value = model.CourseName;
            parameters[4].Value = model.CourseScore;
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
        public bool Delete(string StudentId, string StudentName, string StudentClass, string CourseName, decimal CourseScore)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_Course ");
            strSql.Append(" where StudentId=@StudentId and StudentName=@StudentName and StudentClass=@StudentClass and CourseName=@CourseName and CourseScore=@CourseScore ");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentClass", SqlDbType.NVarChar,50),
					new SqlParameter("@CourseName", SqlDbType.NVarChar,50),
					new SqlParameter("@CourseScore", SqlDbType.Decimal,9)			};
            parameters[0].Value = StudentId;
            parameters[1].Value = StudentName;
            parameters[2].Value = StudentClass;
            parameters[3].Value = CourseName;
            parameters[4].Value = CourseScore;


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
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM View_Course ");
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
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.View_Course GetModel(string StudentId, string StudentName, string StudentClass, string CourseName, decimal CourseScore)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select StudentId, StudentName, StudentClass, CourseName, CourseScore  ");
            strSql.Append("  from View_Course ");
            strSql.Append(" where StudentId=@StudentId and StudentName=@StudentName and StudentClass=@StudentClass and CourseName=@CourseName and CourseScore=@CourseScore ");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentName", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentClass", SqlDbType.NVarChar,50),
					new SqlParameter("@CourseName", SqlDbType.NVarChar,50),
					new SqlParameter("@CourseScore", SqlDbType.Decimal,9)			};
            parameters[0].Value = StudentId;
            parameters[1].Value = StudentName;
            parameters[2].Value = StudentClass;
            parameters[3].Value = CourseName;
            parameters[4].Value = CourseScore;


            Maticsoft.Model.View_Course model = new Maticsoft.Model.View_Course();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model.StudentId = ds.Tables[0].Rows[0]["StudentId"].ToString();
                model.StudentName = ds.Tables[0].Rows[0]["StudentName"].ToString();
                model.StudentClass = ds.Tables[0].Rows[0]["StudentClass"].ToString();
                model.CourseName = ds.Tables[0].Rows[0]["CourseName"].ToString();
                if (ds.Tables[0].Rows[0]["CourseScore"].ToString() != "")
                {
                    model.CourseScore = decimal.Parse(ds.Tables[0].Rows[0]["CourseScore"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM View_Course ");
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
            strSql.Append(" * ");
            strSql.Append(" FROM View_Course ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(")AS Row, T.*  from View_Course T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}

