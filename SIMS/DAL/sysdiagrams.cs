using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:sysdiagrams
	/// </summary>
	public partial class sysdiagrams
	{
		public sysdiagrams()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("diagram_id", "sysdiagrams"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int diagram_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sysdiagrams");
			strSql.Append(" where diagram_id=@diagram_id");
			SqlParameter[] parameters = {
					new SqlParameter("@diagram_id", SqlDbType.Int,4)
			};
			parameters[0].Value = diagram_id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Maticsoft.Model.sysdiagrams model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sysdiagrams(");
			strSql.Append("name,principal_id,version,definition)");
			strSql.Append(" values (");
			strSql.Append("@name,@principal_id,@version,@definition)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,256),
					new SqlParameter("@principal_id", SqlDbType.Int,4),
					new SqlParameter("@version", SqlDbType.Int,4),
					new SqlParameter("@definition", SqlDbType.VarBinary,-1)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.principal_id;
			parameters[2].Value = model.version;
			parameters[3].Value = model.definition;

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
		public bool Update(Maticsoft.Model.sysdiagrams model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sysdiagrams set ");
			strSql.Append("name=@name,");
			strSql.Append("principal_id=@principal_id,");
			strSql.Append("version=@version,");
			strSql.Append("definition=@definition");
			strSql.Append(" where diagram_id=@diagram_id");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,256),
					new SqlParameter("@principal_id", SqlDbType.Int,4),
					new SqlParameter("@version", SqlDbType.Int,4),
					new SqlParameter("@definition", SqlDbType.VarBinary,-1),
					new SqlParameter("@diagram_id", SqlDbType.Int,4)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.principal_id;
			parameters[2].Value = model.version;
			parameters[3].Value = model.definition;
			parameters[4].Value = model.diagram_id;

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
		public bool Delete(int diagram_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysdiagrams ");
			strSql.Append(" where diagram_id=@diagram_id");
			SqlParameter[] parameters = {
					new SqlParameter("@diagram_id", SqlDbType.Int,4)
			};
			parameters[0].Value = diagram_id;

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
		public bool DeleteList(string diagram_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysdiagrams ");
			strSql.Append(" where diagram_id in ("+diagram_idlist + ")  ");
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.sysdiagrams GetModel(int diagram_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 name,principal_id,diagram_id,version,definition from sysdiagrams ");
			strSql.Append(" where diagram_id=@diagram_id");
			SqlParameter[] parameters = {
					new SqlParameter("@diagram_id", SqlDbType.Int,4)
			};
			parameters[0].Value = diagram_id;

			Maticsoft.Model.sysdiagrams model=new Maticsoft.Model.sysdiagrams();
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
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.sysdiagrams DataRowToModel(DataRow row)
		{
			Maticsoft.Model.sysdiagrams model=new Maticsoft.Model.sysdiagrams();
			if (row != null)
			{
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["principal_id"]!=null && row["principal_id"].ToString()!="")
				{
					model.principal_id=int.Parse(row["principal_id"].ToString());
				}
				if(row["diagram_id"]!=null && row["diagram_id"].ToString()!="")
				{
					model.diagram_id=int.Parse(row["diagram_id"].ToString());
				}
				if(row["version"]!=null && row["version"].ToString()!="")
				{
					model.version=int.Parse(row["version"].ToString());
				}
				if(row["definition"]!=null && row["definition"].ToString()!="")
				{
					model.definition=(byte[])row["definition"];
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
			strSql.Append("select name,principal_id,diagram_id,version,definition ");
			strSql.Append(" FROM sysdiagrams ");
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
			strSql.Append(" name,principal_id,diagram_id,version,definition ");
			strSql.Append(" FROM sysdiagrams ");
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
			strSql.Append("select count(1) FROM sysdiagrams ");
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
				strSql.Append("order by T.diagram_id desc");
			}
			strSql.Append(")AS Row, T.*  from sysdiagrams T ");
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
			parameters[0].Value = "sysdiagrams";
			parameters[1].Value = "diagram_id";
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

