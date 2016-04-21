using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ManagePhones.DAL
{
	/// <summary>
	/// 数据访问类:good
	/// </summary>
	public partial class GoodDAL
	{
		public GoodDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string gid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from good");
			strSql.Append(" where gid=@gid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@gid", MySqlDbType.VarChar,255)			};
			parameters[0].Value = gid;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ManagePhones.Model.Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into good(");
			strSql.Append("gid,name)");
			strSql.Append(" values (");
			strSql.Append("@gid,@name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@gid", MySqlDbType.VarChar,255),
					new MySqlParameter("@name", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.gid;
			parameters[1].Value = model.name;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 更新一条数据
		/// </summary>
		public bool Update(ManagePhones.Model.Good model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update good set ");
			strSql.Append("name=@name");
			strSql.Append(" where gid=@gid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@name", MySqlDbType.VarChar,255),
					new MySqlParameter("@gid", MySqlDbType.VarChar,255)};
			parameters[0].Value = model.name;
			parameters[1].Value = model.gid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(string gid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from good ");
			strSql.Append(" where gid=@gid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@gid", MySqlDbType.VarChar,255)			};
			parameters[0].Value = gid;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string gidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from good ");
			strSql.Append(" where gid in ("+gidlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public ManagePhones.Model.Good GetModel(string gid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select gid,name from good ");
			strSql.Append(" where gid=@gid ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@gid", MySqlDbType.VarChar,255)			};
			parameters[0].Value = gid;

			ManagePhones.Model.Good model=new ManagePhones.Model.Good();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
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
		public ManagePhones.Model.Good DataRowToModel(DataRow row)
		{
			ManagePhones.Model.Good model=new ManagePhones.Model.Good();
			if (row != null)
			{
				if(row["gid"]!=null)
				{
					model.gid=row["gid"].ToString();
				}
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
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
			strSql.Append("select gid,name ");
			strSql.Append(" FROM good ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM good ");
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
				strSql.Append("order by T.gid desc");
			}
			strSql.Append(")AS Row, T.*  from good T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "good";
			parameters[1].Value = "gid";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

