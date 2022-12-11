// <summary>
// Compamy: Transcom Electronics Limited
// Author: Abdul Hakim
// Date: Jun 06, 2017
// Time :  11:54 AM
// Description: Class for Enum Reader.
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class EnumReader
    {
        private int _nID;
        private string _sName;

        /// <summary>
        /// Get set property for ID
        /// </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        /// <summary>
        /// Get set property for Name
        /// </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }
    }
    public class EnumReaders : CollectionBase
    {
        public EnumReader this[int i]
        {
            get { return (EnumReader)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(EnumReader oEnumReader)
        {
            InnerList.Add(oEnumReader);
        }

        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }

    } 
}


