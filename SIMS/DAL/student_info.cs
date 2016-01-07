using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:student_info
	/// </summary>
	public partial class student_info
	{
		public student_info()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "student_info"); 
		}

		/// <summary>
		/// 是否存在该记录 根据Id
		/// </summary>
		public bool Exists_ID(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from student_info");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录 根据 名称
        /// </summary>
        public bool Exists_StudentName(string StudentName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from student_info");
            strSql.Append(" where StudentName=@StudentName");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentName", SqlDbType.NVarChar,500)
			};
            parameters[0].Value = StudentName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists_StudentId(string StudentId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from student_info");
            strSql.Append(" where StudentId=@StudentId");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.NVarChar,500)
			};
            parameters[0].Value = StudentId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.student_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into student_info(");
			strSql.Append("StudentId,StudentPassword,StudentName,StudentPhoto,StudentSex,StudentNation,StudentTelehpone,StudentQQ,StudentClass,StudentDormitory,StudentAddress)");
			strSql.Append(" values (");
			strSql.Append("@StudentId,@StudentPassword,@StudentName,@StudentPhoto,@StudentSex,@StudentNation,@StudentTelehpone,@StudentQQ,@StudentClass,@StudentDormitory,@StudentAddress)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.VarChar,20),
					new SqlParameter("@StudentPassword", SqlDbType.VarChar,50),
					new SqlParameter("@StudentName", SqlDbType.VarChar,50),
					new SqlParameter("@StudentPhoto", SqlDbType.VarChar,100),
					new SqlParameter("@StudentSex", SqlDbType.VarChar,50),
					new SqlParameter("@StudentNation", SqlDbType.VarChar,50),
					new SqlParameter("@StudentTelehpone", SqlDbType.VarChar,12),
					new SqlParameter("@StudentQQ", SqlDbType.VarChar,20),
					new SqlParameter("@StudentClass", SqlDbType.VarChar,20),
					new SqlParameter("@StudentDormitory", SqlDbType.VarChar,20),
					new SqlParameter("@StudentAddress", SqlDbType.VarChar,100)};
			parameters[0].Value = model.StudentId;
			parameters[1].Value = model.StudentPassword;
			parameters[2].Value = model.StudentName;
			parameters[3].Value = model.StudentPhoto;
			parameters[4].Value = model.StudentSex;
			parameters[5].Value = model.StudentNation;
			parameters[6].Value = model.StudentTelehpone;
			parameters[7].Value = model.StudentQQ;
			parameters[8].Value = model.StudentClass;
			parameters[9].Value = model.StudentDormitory;
			parameters[10].Value = model.StudentAddress;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(Maticsoft.Model.student_info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update student_info set ");
			strSql.Append("StudentId=@StudentId,");
			strSql.Append("StudentPassword=@StudentPassword,");
			strSql.Append("StudentName=@StudentName,");
			strSql.Append("StudentPhoto=@StudentPhoto,");
			strSql.Append("StudentSex=@StudentSex,");
			strSql.Append("StudentNation=@StudentNation,");
			strSql.Append("StudentTelehpone=@StudentTelehpone,");
			strSql.Append("StudentQQ=@StudentQQ,");
			strSql.Append("StudentClass=@StudentClass,");
			strSql.Append("StudentDormitory=@StudentDormitory,");
			strSql.Append("StudentAddress=@StudentAddress");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.VarChar,20),
					new SqlParameter("@StudentPassword", SqlDbType.VarChar,50),
					new SqlParameter("@StudentName", SqlDbType.VarChar,50),
					new SqlParameter("@StudentPhoto", SqlDbType.VarChar,100),
					new SqlParameter("@StudentSex", SqlDbType.VarChar,50),
					new SqlParameter("@StudentNation", SqlDbType.VarChar,50),
					new SqlParameter("@StudentTelehpone", SqlDbType.VarChar,12),
					new SqlParameter("@StudentQQ", SqlDbType.VarChar,20),
					new SqlParameter("@StudentClass", SqlDbType.VarChar,20),
					new SqlParameter("@StudentDormitory", SqlDbType.VarChar,20),
					new SqlParameter("@StudentAddress", SqlDbType.VarChar,100),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.StudentId;
			parameters[1].Value = model.StudentPassword;
			parameters[2].Value = model.StudentName;
			parameters[3].Value = model.StudentPhoto;
			parameters[4].Value = model.StudentSex;
			parameters[5].Value = model.StudentNation;
			parameters[6].Value = model.StudentTelehpone;
			parameters[7].Value = model.StudentQQ;
			parameters[8].Value = model.StudentClass;
			parameters[9].Value = model.StudentDormitory;
			parameters[10].Value = model.StudentAddress;
			parameters[11].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student_info ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
        /// 通过学号 删除
        /// </summary>
        /// <param name="StudentId"></param>
        /// <returns></returns>
        public bool Delete_StudentId(int StudentId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from student_info ");
            strSql.Append(" where StudentId=@StudentId");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.Int,4)
			};
            parameters[0].Value = StudentId;

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
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from student_info ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		/// 得到一个对象实体 根据ID
		/// </summary>
		public Maticsoft.Model.student_info GetModel_Id(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,StudentId,StudentPassword,StudentName,StudentPhoto,StudentSex,StudentNation,StudentTelehpone,StudentQQ,StudentClass,StudentDormitory,StudentAddress from student_info ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Maticsoft.Model.student_info model=new Maticsoft.Model.student_info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}
        /// <summary>
        /// 得到一个对象实体 根据ID
        /// </summary>
        public Maticsoft.Model.student_info GetModel_StudentName(string StudentName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,StudentId,StudentPassword,StudentName,StudentPhoto,StudentSex,StudentNation,StudentTelehpone,StudentQQ,StudentClass,StudentDormitory,StudentAddress from student_info ");
            strSql.Append(" where StudentName=@StudentName");
            SqlParameter[] parameters = {
					new SqlParameter("@StudentName", SqlDbType.NVarChar,500)
			};
            parameters[0].Value = StudentName;

            Maticsoft.Model.student_info model = new Maticsoft.Model.student_info();
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
		public Maticsoft.Model.student_info DataRowToModel(DataRow row)
		{
			Maticsoft.Model.student_info model=new Maticsoft.Model.student_info();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["StudentId"]!=null)
				{
					model.StudentId=row["StudentId"].ToString();
				}
				if(row["StudentPassword"]!=null)
				{
					model.StudentPassword=row["StudentPassword"].ToString();
				}
				if(row["StudentName"]!=null)
				{
					model.StudentName=row["StudentName"].ToString();
				}
				if(row["StudentPhoto"]!=null)
				{
					model.StudentPhoto=row["StudentPhoto"].ToString();
				}
				if(row["StudentSex"]!=null)
				{
					model.StudentSex=row["StudentSex"].ToString();
				}
				if(row["StudentNation"]!=null)
				{
					model.StudentNation=row["StudentNation"].ToString();
				}
				if(row["StudentTelehpone"]!=null)
				{
					model.StudentTelehpone=row["StudentTelehpone"].ToString();
				}
				if(row["StudentQQ"]!=null)
				{
					model.StudentQQ=row["StudentQQ"].ToString();
				}
				if(row["StudentClass"]!=null)
				{
					model.StudentClass=row["StudentClass"].ToString();
				}
				if(row["StudentDormitory"]!=null)
				{
					model.StudentDormitory=row["StudentDormitory"].ToString();
				}
				if(row["StudentAddress"]!=null)
				{
					model.StudentAddress=row["StudentAddress"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,StudentId,StudentPassword,StudentName,StudentPhoto,StudentSex,StudentNation,StudentTelehpone,StudentQQ,StudentClass,StudentDormitory,StudentAddress ");
			strSql.Append(" FROM student_info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,StudentId,StudentPassword,StudentName,StudentPhoto,StudentSex,StudentNation,StudentTelehpone,StudentQQ,StudentClass,StudentDormitory,StudentAddress ");
			strSql.Append(" FROM student_info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM student_info ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from student_info T ");
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
			parameters[0].Value = "student_info";
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

