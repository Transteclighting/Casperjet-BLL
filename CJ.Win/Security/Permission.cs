using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Security.Principal;
using System.Data;

using System.Resources;

using System.Windows.Forms;
using System.Drawing;

using CJ.Class;


namespace CJ.Win.Security
{
    public class Permission
    {
        public DSPermission getPermissionList()
        {
            DSPermission oDSPermission;
            oDSPermission = new DSPermission();
            //_sXmlPath = ConfigurationManager.AppSettings["MenuTree"];

            //ResourceManager resourceManager = new ResourceManager("CJ.Win.Properties.Resources", GetType().Assembly);
            ResourceManager resourceManager = new ResourceManager("CJ.Win.Properties.Resources", this.GetType().Assembly);
            string sMenuTree = (string)resourceManager.GetObject("MenuTree");

            // convert string to stream
            byte[] byteArray = Encoding.ASCII.GetBytes(sMenuTree);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            try
            {

                //oDSPermission.ReadXml(_sXmlPath);

                oDSPermission.ReadXml(stream);
            }
            catch
            {
                MessageBox.Show("There is an Error in Permission Table.\n There could be a duplicate or Null  Permission Key");
            }
            return oDSPermission;
        }
    }
}
