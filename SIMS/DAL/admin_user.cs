using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:admin_user
	/// </summary>
	public partial class admin_user
	{
		public admin_user()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "admin_user"); 
		}

		/// <summary>
		/// 是否存在该记录 根据ID
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from admin_user");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录 根据UserName
        /// </summary>
        public bool Exists_UserName(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from admin_user");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,500)
			};
            parameters[0].Value = UserName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.admin_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into admin_user(");
			strSql.Append("UserName,UserPassword,LoginTime,TrueName,LinkTelephone)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@UserPassword,@LoginTime,@TrueName,@LinkTelephone)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@UserPassword", SqlDbType.VarChar,50),
					new SqlParameter("@LoginTime", SqlDbType.Int,4),
					new SqlParameter("@TrueName", SqlDbType.VarChar,10),
					new SqlParameter("@LinkTelephone", SqlDbType.VarChar,12)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPassword;
			parameters[2].Value = model.LoginTime;
			parameters[3].Value = model.TrueName;
			parameters[4].Value = model.LinkTelephone;

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
		public bool Update(Maticsoft.Model.admin_user model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update admin_user set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("UserPassword=@UserPassword,");
			strSql.Append("LoginTime=@LoginTime,");
			strSql.Append("TrueName=@TrueName,");
			strSql.Append("LinkTelephone=@LinkTelephone");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,20),
					new SqlParameter("@UserPassword", SqlDbType.VarChar,50),
					new SqlParameter("@LoginTime", SqlDbType.Int,4),
					new SqlParameter("@TrueName", SqlDbType.VarChar,10),
					new SqlParameter("@LinkTelephone", SqlDbType.VarChar,12),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.UserPassword;
			parameters[2].Value = model.LoginTime;
			parameters[3].Value = model.TrueName;
			parameters[4].Value = model.LinkTelephone;
			parameters[5].Value = model.Id;

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
			strSql.Append("delete from admin_user ");
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from admin_user ");
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
		public Maticsoft.Model.admin_user GetModel_Id(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,UserName,UserPassword,LoginTime,TrueName,LinkTelephone from admin_user ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Maticsoft.Model.admin_user model=new Maticsoft.Model.admin_user();
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
        /// 得到一个对象实体 根据UserName
        /// </summary>
        public Maticsoft.Model.admin_user GetModel_UserName(string UserName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,UserName,UserPassword,LoginTime,TrueName,LinkTelephone from admin_user ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,500)
			};
            parameters[0].Value = UserName;

            Maticsoft.Model.admin_user model = new Maticsoft.Model.admin_user();
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
		public Maticsoft.Model.admin_user DataRowToModel(DataRow row)
		{
			Maticsoft.Model.admin_user model=new Maticsoft.Model.admin_user();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["UserPassword"]!=null)
				{
					model.UserPassword=row["UserPassword"].ToString();
				}
				if(row["LoginTime"]!=null && row["LoginTime"].ToString()!="")
				{
					model.LoginTime=int.Parse(row["LoginTime"].ToString());
				}
				if(row["TrueName"]!=null)
				{
					model.TrueName=row["TrueName"].ToString();
				}
				if(row["LinkTelephone"]!=null)
				{
					model.LinkTelephone=row["LinkTelephone"].ToString();
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
			strSql.Append("select Id,UserName,UserPassword,LoginTime,TrueName,LinkTelephone ");
			strSql.Append(" FROM admin_user ");
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
			strSql.Append(" Id,UserName,UserPassword,LoginTime,TrueName,LinkTelephone ");
			strSql.Append(" FROM admin_user ");
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
			strSql.Append("select count(1) FROM admin_user ");
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
			strSql.Append(")AS Row, T.*  from admin_user T ");
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
			parameters[0].Value = "admin_user";
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

