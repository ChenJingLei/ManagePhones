using System;
namespace ManagePhones.Model
{
	/// <summary>
	/// out_warehouse:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class OutWarehouse
	{
		public OutWarehouse()
		{}
		#region Model
		private long _id;
		private string _gid;
		private string _imei;
		private DateTime? _outtime;
		/// <summary>
		/// auto_increment
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string gid
		{
			set{ _gid=value;}
			get{return _gid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string imei
		{
			set{ _imei=value;}
			get{return _imei;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? outtime
		{
			set{ _outtime=value;}
			get{return _outtime;}
		}
		#endregion Model

	}
}

