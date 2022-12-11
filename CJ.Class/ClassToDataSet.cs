using System;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Diagnostics;

namespace CJ.Class
{
    public class ClassToDataSet
    {
        #region Private Declaration

		private CollectionBase _CollectionBaseData;

		#endregion

		#region Constructor

        public ClassToDataSet(CollectionBase Data)
		{
			_CollectionBaseData = Data;
		}

		#endregion

		#region Private Property
		
		private PropertyInfo[] _PropertyInfos = null;
		private  PropertyInfo[] PropertyInfos
		{
			get
			{
				if ( _PropertyInfos == null)
				{
					_PropertyInfos = GetPropertyInfo();

				}
				return _PropertyInfos;
			}
		}


		#endregion

		#region Private Function
        
		private  PropertyInfo[] GetPropertyInfo()
		{
			if (_CollectionBaseData.Count > 0)
			{
				IEnumerator oEnumerator = _CollectionBaseData.GetEnumerator();
				oEnumerator.MoveNext();
				return oEnumerator.Current.GetType().GetProperties();
			}

			return null;
		}


		private DataTable CreateDataTable()
		{
            DataTable oDataTable = new DataTable(_CollectionBaseData.GetType().Name);

			foreach (PropertyInfo oProperty in PropertyInfos)
			{
				Type oType = oProperty.PropertyType; // oProperty.GetValue(DummyData,null).GetType();
				oDataTable.Columns.Add(oProperty.Name.ToString(),oType);
			}

			return oDataTable;
		}

//		private DataTable CreateDataTable()
//		{
//			DataTable oDataTable = new DataTable("GridDataTable");
//
//			foreach (PropertyInfo oProperty in PropertyInfos)
//			{
//				oDataTable.Columns.Add(oProperty.Name.ToString());
//			}
//
//			return oDataTable;
//		}


		private DataSet CreateDataSet()
		{
            DataSet oDataSet = new DataSet("DS" + _CollectionBaseData.GetType().Name);
		
			oDataSet.Tables.Add(FillDataTable());

			return oDataSet;
		}


        private DataRow FillDataRow(DataRow oDataRow, object oData)
        {
            foreach (PropertyInfo oPropertyInfo in PropertyInfos)
            {
                oDataRow[oPropertyInfo.Name.ToString()] = oPropertyInfo.GetValue(oData, null);
            }
            return oDataRow;
        }

        //** Blocked by Arif Khan dated on 29-APR-2015 deu to in error in report number 701**
        //private DataRow FillDataRow(DataRow oDataRow, object oData)
        //{
        //    foreach (PropertyInfo oPropertyInfo in PropertyInfos)
        //    {
        //        Type oType = oPropertyInfo.GetValue(oData,null).GetType();
        //        oDataRow[oPropertyInfo.Name.ToString()] = Convert.ChangeType(oPropertyInfo.GetValue(oData,null),oType) ;
        //    }
        //    return oDataRow;
        //}

		private DataTable FillDataTable()
		{			
			CollectionBase oCollectionBase = (CollectionBase)_CollectionBaseData;

			IEnumerator oEnumerator = oCollectionBase.GetEnumerator();

			DataTable oDataTable = CreateDataTable();

			while (oEnumerator.MoveNext())
			{
				oDataTable.Rows.Add(FillDataRow(oDataTable.NewRow(),oEnumerator.Current));
       
			}

			return oDataTable;
		}


		#endregion

		#region Public Function

		public DataSet ToDataSet()
		{
			return CreateDataSet();
		}

		#endregion
    }
}
