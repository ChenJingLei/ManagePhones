using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ManagePhones.Model;
namespace ManagePhones.BLL
{
	/// <summary>
	/// good
	/// </summary>
	public partial class GoodBLL
	{
		private readonly ManagePhones.DAL.GoodDAL dal=new ManagePhones.DAL.GoodDAL();
		public GoodBLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string gid)
		{
			return dal.Exists(gid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ManagePhones.Model.Good model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ManagePhones.Model.Good model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string gid)
		{
			
			return dal.Delete(gid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string gidlist )
		{
			return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(gidlist,0) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ManagePhones.Model.Good GetModel(string gid)
		{
			
			return dal.GetModel(gid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ManagePhones.Model.Good GetModelByCache(string gid)
		{
			
			string CacheKey = "goodModel-" + gid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(gid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ManagePhones.Model.Good)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ManagePhones.Model.Good> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ManagePhones.Model.Good> DataTableToList(DataTable dt)
		{
			List<ManagePhones.Model.Good> modelList = new List<ManagePhones.Model.Good>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ManagePhones.Model.Good model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

