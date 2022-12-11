using System;
using System.Data;
using System.Collections;

namespace CJ.Class
{
	/// <summary>
	/// Provides the abstract base class for a strongly typed Collection 
	/// (Inherits from System.Collections.CollectionBase) and support Convert To DataSet.
	/// </summary>5
	public abstract class CollectionBaseCustom:CollectionBase
	{
		public DataSet ToDataSet()
		{
            return (new ClassToDataSet(this)).ToDataSet();
		}
	}
}
