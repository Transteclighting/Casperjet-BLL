using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace CJ.Class.Library
{
	public class TELReg
	{
		private string _sKeyValue;
		private string _sKeyName;
		private string _sSubKeyName;

		public TELReg(string sRegKeyName,string sRegSubKeyName)
		{
			_sKeyName=sRegKeyName;
			_sSubKeyName=sRegSubKeyName;
			this.GetSetting();
		}

		~TELReg()
		{
			this.SaveSetting();
		}

		public string KeyValue
		{
			get{return _sKeyValue;}
			set{_sKeyValue=value;}

		}

		public void SaveSetting()
		{
			RegistryKey oKey=Registry.CurrentUser.CreateSubKey(_sKeyName);
			oKey.SetValue(_sSubKeyName,_sKeyValue);
		}

		public void DeleteSetting()
		{
            RegistryKey oKey = Registry.CurrentUser;
			oKey.OpenSubKey(_sKeyName);
            //oKey.DeleteSubKey(_sKeyName);
        }

		public void GetSetting()
		{			
			RegistryKey oRegKey=Registry.CurrentUser;

			try
			{
				oRegKey=oRegKey.OpenSubKey(_sKeyName);
				object oValue=oRegKey.GetValue(_sSubKeyName);
				_sKeyValue=Convert.ToString(oValue);
			}
			catch {_sKeyValue="";}
		}
	}
}