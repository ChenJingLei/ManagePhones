using System;
namespace ManagePhones.Model
{
	/// <summary>
	/// good:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Good
	{
		public Good()
		{}
		#region Model
		private string _gid;
		private string _name;
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
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

