using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class sysdiagrams
	{
		public sysdiagrams()
		{}
		#region Model
		private string _name;
		private int _principal_id;
		private int _diagram_id;
		private int? _version;
		private byte[] _definition;
		/// <summary>
		/// 
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int principal_id
		{
			set{ _principal_id=value;}
			get{return _principal_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int diagram_id
		{
			set{ _diagram_id=value;}
			get{return _diagram_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? version
		{
			set{ _version=value;}
			get{return _version;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] definition
		{
			set{ _definition=value;}
			get{return _definition;}
		}
		#endregion Model

	}
}

