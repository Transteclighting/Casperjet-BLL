// <summary>
// Compamy: Transcom Electronics Limited
// Author: Unkonwn.
// Date: 
// Time :  
// Description: Class for Class Builder.
// Modify Person And Date: Md. Abdul Hakim (Oct 12, 2014)
// </summary>

namespace CJ.Win
{
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Data.OleDb;
    using System.Drawing;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using CJ.Class;

    public class frmClassBuilder : Form
    {
        private Button button1;
        private Button button2;
        private CheckedListBox chkColumns;
        private Button cmdGenerate;
        private Button cmdList;
        private Container components;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox lstTables;
        private GroupBox moo;
        private TextBox txtDatabase;
        private RichTextBox txtOutput;
        private TextBox txtPassword;
        private TextBox txtServer;
        private TextBox txtUsername;
        public ArrayList vars;

        string sTableName = "";
        object[] sFieldName ;
        string sField = "";
        string sValue = "";
        private CheckBox chkAll;
        string sEditField = "";
        string sPrefix = "";

        


        public frmClassBuilder()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(this.txtOutput.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
        //Modified by Md. Abdul Hakim(Oct 12, 2014)
        private void cmdGenerate_Click(object sender, EventArgs e)
        {
            //OleDbType oType;
 
            if (this.chkColumns.CheckedItems.Count != 0)
            {
                txtOutput.Clear();
                GetFieldName();

                OleDbConnection connection = new OleDbConnection(string.Format("Data Source={0}; Provider=SQLOLEDB;Initial Catalog={1};User Id={2};Password={3};", new object[] { this.txtServer.Text, this.txtDatabase.Text, this.txtUsername.Text, this.txtPassword.Text }));
                string str2 = this.lstTables.SelectedItem.ToString();
                string varType = "";
                try
                {
                    connection.Open();
                    object[] objArray3 = new object[4];
                    objArray3[2] = str2;
                    object[] restrictions = objArray3;
                    DataTable oleDbSchemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, restrictions);
                    for (int i = 0; i <= (this.chkColumns.CheckedItems.Count - 1); i++)
                    {
                        foreach (DataRow row in oleDbSchemaTable.Rows)
                        {
                            
                            if (!(((string)row["COLUMN_NAME"]) == this.chkColumns.CheckedItems[i].ToString()))
                            {
                                continue;
                            }

                            varType = GetDataType((OleDbType)row["DATA_TYPE"]);

                            Variables variables = new Variables(row["COLUMN_NAME"].ToString(), varType);
                            this.vars.Add(variables);
                        }
                    }
                    StringBuilder builder = new StringBuilder();

                    string sClassName = "";
                    if (str2.Length > 2)
                    {
                        sClassName = str2.Substring(0, 2);
                    }
                    else
                    {
                        sClassName = str2;
                    }
                    if (sClassName != "t_")
                    {
                        sClassName = str2;
                    }
                    else
                    {
                        sClassName = str2.Substring(2);
                    }
                    string dt = Convert.ToDateTime(DateTime.Today).ToString("MMM dd, yyyy");
                    string tm = Convert.ToDateTime(DateTime.Now).ToString("hh:mm tt");
                    builder.Append("// <summary>" + "\n");
                    builder.Append("// Company: Transcom Electronics Limited" + "\n");
                    builder.Append("// Author: " + Utility.UserFullname + "" + "\n");
                    builder.Append("// Date: " + dt + "" + "\n");
                    builder.Append("// Time : " + tm + "" + "\n");
                    builder.Append("// Description: Class for " + sClassName + "." + "\n");
                    builder.Append("// Modify Person And Date:" + "\n");
                    builder.Append("// </summary>" + "\n" + "\n");

                    builder.Append("using System;" + "\n");
                    builder.Append("using System.Collections.Generic;" + "\n");
                    builder.Append("using System.Text;" + "\n");
                    builder.Append("using System.Collections;" + "\n");
                    builder.Append("using System.Data;" + "\n");
                    builder.Append("using System.Data.OleDb;" + "\n");
                    builder.Append("using CJ.Class;" + "\n" + "\n");

                    builder.Append("namespace CJ.Class" + "\n");
                    builder.Append("{" + "\n");

                    builder.Append("public class " + sClassName + "" + "\n");
                    builder.Append("{" + "\n");

                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    #region Property
                    foreach (Variables variables2 in this.vars)
                    {
                        sPrefix = "";
                        sPrefix = GetPrefix(variables2.VarType);
                        builder.Append("private " + variables2.VarType + sPrefix + variables2.VarName + "; \n");
                    }
                    builder.Append("\n \n");
                    foreach (Variables variables3 in this.vars)
                    {
                        builder.Append("// <summary>" + "\n");
                        builder.Append("// Get set property for " + variables3.VarName + "\n");
                        builder.Append("// </summary>" + "\n");
                        builder.Append("public " + variables3.VarType + " " + variables3.VarName + "\n { \n       ");

                        sPrefix = "";
                        sPrefix = GetPrefix(variables3.VarType);

                        builder.Append("get { return " + sPrefix + variables3.VarName + "; }" + "\n       ");

                        if (variables3.VarType == "string")
                        {
                            builder.Append("set {" + sPrefix + variables3.VarName + " = value.Trim(); }" + "\n } \n");
                        }
                        else
                        {
                            builder.Append("set {" + sPrefix + variables3.VarName + " = value; }" + "\n } \n");
                        }
                        builder.Append("\n");
                    }
                    #endregion
                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    #region Add
                    builder.Append("public void Add()" + "\n ");
                    builder.Append("{" + "\n ");
                    builder.Append("    int nMax" + sFieldName[0] + " = 0;" + "\n ");
                    builder.Append("    OleDbCommand cmd = DBController.Instance.GetCommand();" + "\n ");
                    builder.Append("    string sSql = \"\";" + "\n ");

                    builder.Append("    try" + "\n ");
                    builder.Append("    {" + "\n ");
                    builder.Append("        sSql = \"SELECT MAX([" + sFieldName[0] + "]) FROM " + sTableName + "\";" + "\n ");
                    builder.Append("        cmd.CommandText = sSql;" + "\n ");
                    builder.Append("        object maxID = cmd.ExecuteScalar();" + "\n ");
                    builder.Append("        if (maxID == DBNull.Value)" + "\n ");
                    builder.Append("        {" + "\n ");
                    builder.Append("            nMax" + sFieldName[0] + " = 1;" + "\n ");
                    builder.Append("        }" + "\n ");
                    builder.Append("        else" + "\n ");
                    builder.Append("        {" + "\n ");
                    builder.Append("            nMax" + sFieldName[0] + " = Convert.ToInt32(maxID) + 1;" + "\n ");
                    builder.Append("        }" + "\n ");
                    builder.Append("        _n" + sFieldName[0] + " = nMax" + sFieldName[0] + ";" + "\n ");

                    builder.Append("        sSql = \"INSERT INTO " + sTableName + " (" + sField + ") VALUES(" + sValue + ")\";" + "\n ");
                    builder.Append("        cmd.CommandText = sSql;" + "\n ");
                    builder.Append("        cmd.CommandType = CommandType.Text;" + "\n" + "\n");

                    foreach (Variables variables3 in this.vars)
                    {
                        sPrefix = "";
                        sPrefix = GetPrefix(variables3.VarType);

                        builder.Append("        cmd.Parameters.AddWithValue(\"" + variables3.VarName + "\", " + sPrefix + "" + variables3.VarName + ");" + "\n ");

                    }
                    builder.Append("\n");
                    builder.Append("        cmd.ExecuteNonQuery();" + "\n ");
                    builder.Append("        cmd.Dispose();" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("    catch (Exception ex)" + "\n ");
                    builder.Append("    {" + "\n ");
                    builder.Append("        throw (ex);" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("}" + "\n ");
                    #endregion
                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    #region Edit
                    builder.Append("public void Edit() " + "\n ");
                    builder.Append("{ " + "\n ");
                    builder.Append("    OleDbCommand cmd = DBController.Instance.GetCommand();" + "\n ");
                    builder.Append("    string sSql = \"\"; " + "\n ");

                    builder.Append("    try" + "\n ");
                    builder.Append("    {" + "\n ");

                    builder.Append("        sSql = \"UPDATE " + sTableName + " SET " + sEditField + " WHERE " + sFieldName[0] + " = ?\";" + "\n ");
                    builder.Append("        cmd.CommandText = sSql;" + "\n ");
                    builder.Append("        cmd.CommandType = CommandType.Text;" + "\n " + "\n ");
                    int nCount = 0;
                    string sLastLine = "";
                    foreach (Variables variables3 in this.vars)
                    {
                        sPrefix = "";
                        sPrefix = GetPrefix(variables3.VarType);
                        if (nCount == 0)
                        {
                            sLastLine = "       \n" + "         cmd.Parameters.AddWithValue(\"" + variables3.VarName + "\", " + sPrefix + "" + variables3.VarName + ");" + "\n ";
                            nCount++;
                        }
                        else
                        {
                            builder.Append("        cmd.Parameters.AddWithValue(\"" + variables3.VarName + "\", " + sPrefix + "" + variables3.VarName + ");" + "\n ");
                            nCount++;
                        }

                    }
                    builder.Append(sLastLine);
                    builder.Append("\n");
                    builder.Append("        cmd.ExecuteNonQuery();" + "\n ");
                    builder.Append("        cmd.Dispose();" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("    catch (Exception ex)" + "\n ");
                    builder.Append("    {" + "\n ");
                    builder.Append("        throw (ex);" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("}" + "\n ");
                    #endregion
                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    #region Delete
                    builder.Append("public void Delete()" + "\n ");
                    builder.Append("{" + "\n ");
                    builder.Append("    OleDbCommand cmd = DBController.Instance.GetCommand();" + "\n ");
                    builder.Append("    string sSql = \"\";" + "\n ");

                    builder.Append("    try" + "\n ");
                    builder.Append("    {" + "\n ");
                    builder.Append("        sSql = \"DELETE FROM " + sTableName + " WHERE [" + sFieldName[0] + "]=?\";" + "\n ");

                    builder.Append("        cmd.CommandText = sSql;" + "\n ");
                    builder.Append("        cmd.CommandType = CommandType.Text;" + "\n ");
                    builder.Append("        cmd.Parameters.AddWithValue(\"" + sFieldName[0] + "\", _n" + sFieldName[0] + ");" + "\n ");
                    builder.Append("        cmd.ExecuteNonQuery();" + "\n ");
                    builder.Append("        cmd.Dispose();" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("    catch (Exception ex)" + "\n ");
                    builder.Append("    {" + "\n ");

                    builder.Append("        throw (ex);" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("}" + "\n ");
                    #endregion
                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    #region Refresh
                    builder.Append("public void Refresh()" + "\n ");
                    builder.Append("{" + "\n ");
                    builder.Append("    OleDbCommand cmd = DBController.Instance.GetCommand();" + "\n ");
                    builder.Append("    int nCount = 0;" + "\n ");
                    builder.Append("    try" + "\n ");
                    builder.Append("    {" + "\n ");
                    builder.Append("        cmd.CommandText = \"SELECT * FROM " + sTableName + " where " + sFieldName[0] + " =?\";" + "\n ");
                    builder.Append("        cmd.Parameters.AddWithValue(\"" + sFieldName[0] + "\", _n" + sFieldName[0] + ");" + "\n ");
                    builder.Append("        cmd.CommandType = CommandType.Text;" + "\n ");
                    builder.Append("        IDataReader reader = cmd.ExecuteReader();" + "\n ");
                    builder.Append("        if (reader.Read())" + "\n ");
                    builder.Append("        {" + "\n ");

                    foreach (Variables variables2 in this.vars)
                    {
                        if (variables2.VarType == "string")
                        {
                            builder.Append("            _s" + variables2.VarName + " = (string)reader[\"" + variables2.VarName + "\"];" + "\n ");
                        }
                        else if (variables2.VarType == "int")
                        {
                            builder.Append("            _n" + variables2.VarName + " = (int)reader[\"" + variables2.VarName + "\"];" + "\n ");
                        }
                        else if (variables2.VarType == "long")
                        {
                            builder.Append("            _n" + variables2.VarName + " = Convert.ToInt64(reader[\"" + variables2.VarName + "\"].ToString());" + "\n ");
                        }
                        else if (variables2.VarType == "bool")
                        {
                            builder.Append("            _b" + variables2.VarName + " = Convert.ToBoolean(reader[\"" + variables2.VarName + "\"]);" + "\n ");
                        }
                        else if (variables2.VarType == "DateTime")
                        {
                            builder.Append("            _d" + variables2.VarName + " = Convert.ToDateTime(reader[\"" + variables2.VarName + "\"].ToString());" + "\n ");
                        }
                        else if (variables2.VarType == "double")
                        {
                            builder.Append("            _" + variables2.VarName + " = Convert.ToDouble(reader[\"" + variables2.VarName + "\"].ToString());" + "\n ");
                        }
                        else if (variables2.VarType == "byte")
                        {
                            builder.Append("            _" + variables2.VarName + " = Convert.ToByte(reader[\"" + variables2.VarName + "\"]);" + "\n ");
                        }

                    }

                    builder.Append("            nCount++;" + "\n ");
                    builder.Append("        }" + "\n ");

                    builder.Append("        reader.Close();" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("    catch (Exception ex)" + "\n ");
                    builder.Append("    {" + "\n ");
                    builder.Append("        throw (ex);" + "\n ");
                    builder.Append("    }" + "\n ");
                    builder.Append("}" + "\n ");
                    #endregion

                    builder.Append("}" + "\n");

                    #region Collection Class
                    builder.Append("public class " + sClassName + "s : CollectionBase" + "\n");
                    builder.Append("{" + "\n");

                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    builder.Append("public " + sClassName + " this[int i]" + "\n");
                    builder.Append("{" + "\n");
                    builder.Append("    get { return (" + sClassName + ")InnerList[i]; }" + "\n");
                    builder.Append("    set { InnerList[i] = value; }" + "\n");
                    builder.Append("}" + "\n");
                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    builder.Append("public void Add(" + sClassName + " o" + sClassName + ")" + "\n");
                    builder.Append("{" + "\n");
                    builder.Append("    InnerList.Add(o" + sClassName + ");" + "\n");
                    builder.Append("}" + "\n");
                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    builder.Append("public int GetIndex(int n" + sFieldName[0] + ")" + "\n");
                    builder.Append("{" + "\n");
                    builder.Append("    int i;" + "\n");
                    builder.Append("    for (i = 0; i < this.Count; i++)" + "\n");
                    builder.Append("    {" + "\n");
                    builder.Append("        if (this[i]." + sFieldName[0] + " == n" + sFieldName[0] + ")" + "\n");
                    builder.Append("        {" + "\n");
                    builder.Append("            return i;" + "\n");
                    builder.Append("        }" + "\n");
                    builder.Append("    }" + "\n");
                    builder.Append("    return -1;" + "\n");
                    builder.Append("}" + "\n");
                    //Added by Md. Abdul Hakim(Oct 12, 2014)
                    builder.Append("public void Refresh()" + "\n");
                    builder.Append("{" + "\n");
                    builder.Append("    InnerList.Clear();" + "\n");
                    builder.Append("    OleDbCommand cmd = DBController.Instance.GetCommand();" + "\n");

                    builder.Append("    string sSql = \"SELECT * FROM " + sTableName + "\";\n");

                    builder.Append("    try" + "\n");
                    builder.Append("    {" + "\n");
                    builder.Append("        cmd.CommandText = sSql;" + "\n");
                    builder.Append("        cmd.CommandType = CommandType.Text;" + "\n");
                    builder.Append("        IDataReader reader = cmd.ExecuteReader();" + "\n");
                    builder.Append("        while (reader.Read())" + "\n");
                    builder.Append("        {" + "\n");
                    builder.Append("            " + sClassName + " o" + sClassName + " = new " + sClassName + "();" + "\n");

                    foreach (Variables variables2 in this.vars)
                    {
                        if (variables2.VarType == "string")
                        {
                            builder.Append("            o" + sClassName + "." + variables2.VarName + " = (string)reader[\"" + variables2.VarName + "\"];" + "\n ");
                        }
                        else if (variables2.VarType == "int")
                        {
                            builder.Append("            o" + sClassName + "." + variables2.VarName + " = (int)reader[\"" + variables2.VarName + "\"];" + "\n ");
                        }
                        else if (variables2.VarType == "long")
                        {
                            builder.Append("            o" + sClassName + "." + variables2.VarName + " = Convert.ToInt64(reader[\"" + variables2.VarName + "\"].ToString());" + "\n ");
                        }
                        else if (variables2.VarType == "bool")
                        {
                            builder.Append("            o" + sClassName + "." + variables2.VarName + " = Convert.ToBoolean(reader[\"" + variables2.VarName + "\"]);" + "\n ");
                        }
                        else if (variables2.VarType == "DateTime")
                        {
                            builder.Append("            o" + sClassName + "." + variables2.VarName + " = Convert.ToDateTime(reader[\"" + variables2.VarName + "\"].ToString());" + "\n ");
                        }
                        else if (variables2.VarType == "double")
                        {
                            builder.Append("            o" + sClassName + "." + variables2.VarName + " = Convert.ToDouble(reader[\"" + variables2.VarName + "\"].ToString());" + "\n ");
                        }
                        else if (variables2.VarType == "byte")
                        {
                            builder.Append("            o" + sClassName + "." + variables2.VarName + " = Convert.ToByte(reader[\"" + variables2.VarName + "\"]);" + "\n ");
                        }

                    }

                    builder.Append("            InnerList.Add(o" + sClassName + ");" + "\n");
                    builder.Append("        }" + "\n");
                    builder.Append("        reader.Close();" + "\n");
                    builder.Append("        InnerList.TrimToSize();" + "\n");

                    builder.Append("    }" + "\n");
                    builder.Append("    catch (Exception ex)" + "\n");
                    builder.Append("    {" + "\n");
                    builder.Append("        throw (ex);" + "\n");
                    builder.Append("    }" + "\n");
                    builder.Append("}" + "\n");


                    builder.Append("}" + "\n");

                    builder.Append("}" + "\n");
                    
                    this.Parse(builder.ToString());
                    #endregion
                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select at least a Field to generate code ");
            }
        }
        //Added by Md. Abdul Hakim(Oct 13, 2014)
        private string GetDataType(OleDbType oType)
        {
            string sDataType = "";

            if (oType == OleDbType.BigInt)
            {
                sDataType = "long";
            }
            else if (oType == OleDbType.Binary)
            {
                sDataType = "byte";
            }
            else if (oType == OleDbType.Boolean)
            {
                sDataType = "bool";
            }
            else if (oType == OleDbType.DBTimeStamp)
            {
                sDataType = "DateTime";
            }
            else if (oType == OleDbType.Numeric)
            {
                sDataType = "int";
            }
            else if (oType == OleDbType.Integer)
            {
                sDataType = "int";
            }
            else if (oType == OleDbType.SmallInt)
            {
                sDataType = "int";
            }
            else if (oType == OleDbType.UnsignedTinyInt)
            {
                sDataType = "int";
            }
            else if (oType == OleDbType.Double)
            {
                sDataType = "double";
            }
            else if (oType == OleDbType.Currency)
            {
                sDataType = "double";
            }
            else if (oType == OleDbType.Single)
            {
                sDataType = "double";
            }
            else if (oType == OleDbType.Currency)
            {
                sDataType = "double";
            }
            else
            {
                sDataType = "string";
            }

            return sDataType;
        }
        //Added by Md. Abdul Hakim(Oct 13, 2014)
        private string GetPrefix(string VarType)
        {
            string sPrefix = "";
            if (VarType == "string")
            {
                sPrefix = " _s";
            }
            else if (VarType == "int")
            {
                sPrefix = " _n";
            }
            else if (VarType == "long")
            {
                sPrefix = " _n";
            }
            else if (VarType == "DateTime")
            {
                sPrefix = " _d";
            }
            else if (VarType == "bool")
            {
                sPrefix = " _b";
            }
            else
            {
                sPrefix = " _";
            }
            return sPrefix;
        }

        private void cmdList_Click(object sender, EventArgs e)
        {
            this.listTables();
            this.vars = new ArrayList();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.moo = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.cmdList = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstTables = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.chkColumns = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.moo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // moo
            // 
            this.moo.Controls.Add(this.label3);
            this.moo.Controls.Add(this.txtPassword);
            this.moo.Controls.Add(this.label4);
            this.moo.Controls.Add(this.txtUsername);
            this.moo.Controls.Add(this.label2);
            this.moo.Controls.Add(this.txtDatabase);
            this.moo.Controls.Add(this.label1);
            this.moo.Controls.Add(this.txtServer);
            this.moo.Controls.Add(this.cmdList);
            this.moo.Location = new System.Drawing.Point(8, 8);
            this.moo.Name = "moo";
            this.moo.Size = new System.Drawing.Size(416, 112);
            this.moo.TabIndex = 0;
            this.moo.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(288, 40);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 20);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.Text = "telmis";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "User:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(288, 16);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(120, 20);
            this.txtUsername.TabIndex = 4;
            this.txtUsername.Text = "TELSysUser";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Database:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(64, 40);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(120, 20);
            this.txtDatabase.TabIndex = 2;
            this.txtDatabase.Text = "TELSysDB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(64, 16);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(120, 20);
            this.txtServer.TabIndex = 0;
            this.txtServer.Text = "TELSVRMIS01";
            // 
            // cmdList
            // 
            this.cmdList.Location = new System.Drawing.Point(316, 80);
            this.cmdList.Name = "cmdList";
            this.cmdList.Size = new System.Drawing.Size(95, 23);
            this.cmdList.TabIndex = 1;
            this.cmdList.Text = "&Get Tables List";
            this.cmdList.Click += new System.EventHandler(this.cmdList_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTables);
            this.groupBox1.Location = new System.Drawing.Point(8, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 176);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // lstTables
            // 
            this.lstTables.Location = new System.Drawing.Point(16, 24);
            this.lstTables.Name = "lstTables";
            this.lstTables.Size = new System.Drawing.Size(176, 134);
            this.lstTables.TabIndex = 2;
            this.lstTables.SelectedIndexChanged += new System.EventHandler(this.lstTables_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.chkColumns);
            this.groupBox2.Location = new System.Drawing.Point(216, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 176);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Field";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(10, 13);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(71, 17);
            this.chkAll.TabIndex = 1;
            this.chkAll.Text = "Check All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // chkColumns
            // 
            this.chkColumns.CheckOnClick = true;
            this.chkColumns.Location = new System.Drawing.Point(8, 30);
            this.chkColumns.Name = "chkColumns";
            this.chkColumns.Size = new System.Drawing.Size(192, 139);
            this.chkColumns.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtOutput);
            this.groupBox3.Location = new System.Drawing.Point(8, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(416, 176);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Output Code";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(16, 24);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(392, 136);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(8, 496);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(75, 23);
            this.cmdGenerate.TabIndex = 4;
            this.cmdGenerate.Text = "&Generate";
            this.cmdGenerate.Click += new System.EventHandler(this.cmdGenerate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 496);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "&Copy to Clipboard";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(367, 496);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Close";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmClassBuilder
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(432, 533);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.moo);
            this.Name = "frmClassBuilder";
            this.Text = "DB Enabled Property get/set generator";
            this.moo.ResumeLayout(false);
            this.moo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private void listTables()
        {
            string connectionString = string.Format("Data Source={0}; Provider=SQLOLEDB;Initial Catalog={1};User Id={2};Password={3};", new object[] { this.txtServer.Text, this.txtDatabase.Text, this.txtUsername.Text, this.txtPassword.Text });
            this.lstTables.Items.Clear();
            this.chkColumns.Items.Clear();
            OleDbConnection connection = new OleDbConnection(connectionString);
            try
            {
                connection.Open();
                object[] objArray3 = new object[4];
                objArray3[3] = "TABLE";
                object[] restrictions = objArray3;
                foreach (DataRow row in connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions).Rows)
                {
                    this.lstTables.Items.Add(row["TABLE_NAME"]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error: " + exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Added by Md. Abdul Hakim(Oct 12, 2014)
        private void GetFieldName()
        {
            int nCheckedField = 0;
            int nCount = 0;
            foreach (string s in chkColumns.CheckedItems)
            {
                nCheckedField++;
            }
            sFieldName = new object[nCheckedField];
            foreach (string s in chkColumns.CheckedItems)
            {
                if (sField == "")
                {
                    sField = s;
                    sValue = "?";
                    
                }
                else
                {
                    sField = sField + ", " + s;
                    sValue = sValue + ",?";

                    if (sEditField == "")
                    {
                        sEditField = s + " = ?";
                    }
                    else
                    {
                        sEditField = sEditField + ", " + s + " = ?";
                    }
                }

                sFieldName[nCount] = s;
                nCount++;
            }

        }

        //Modified by Md. Abdul Hakim(Oct 12, 2014)
        private void lstTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = string.Format("Data Source={0}; Provider=SQLOLEDB;Initial Catalog={1};User Id={2};Password={3};", new object[] { this.txtServer.Text, this.txtDatabase.Text, this.txtUsername.Text, this.txtPassword.Text });
            this.chkColumns.Items.Clear();
            OleDbConnection connection = new OleDbConnection(connectionString);
            string str2 = this.lstTables.SelectedItem.ToString();
            sTableName = str2;

            try
            {
                connection.Open();
                object[] objArray3 = new object[4];
                objArray3[2] = str2;
                object[] restrictions = objArray3;
               
                foreach (DataRow row in connection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, restrictions).Rows)
                {
                    this.chkColumns.Items.Add(row["COLUMN_NAME"]);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error" + exception.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void Parse(string input)
        {
            Regex regex = new Regex(@"\n");
            foreach (string str in regex.Split(input))
            {
                this.ParseLine(str);
            }
        }

        private void ParseLine(string line)
        {
            Regex regex = new Regex(@"([ \t{}();])");
            foreach (string str in regex.Split(line))
            {
                this.txtOutput.SelectionColor = Color.Black;
                this.txtOutput.SelectionFont = new Font("Courier New", 10f, FontStyle.Regular);
                if ((str == "//") || str.StartsWith("//"))
                {
                    int index = line.IndexOf("//");
                    string str2 = line.Substring(index, line.Length - index);
                    this.txtOutput.SelectionColor = Color.DarkGreen;
                    this.txtOutput.SelectionFont = new Font("Courier New", 10f, FontStyle.Regular);
                    this.txtOutput.SelectedText = str2;
                    break;
                }
                string[] strArray2 = new string[] { "public", "void", "using", "static", "class", "get", "set" };
                for (int i = 0; i < strArray2.Length; i++)
                {
                    if (strArray2[i] == str)
                    {
                        this.txtOutput.SelectionColor = Color.Blue;
                        this.txtOutput.SelectionFont = new Font("Courier New", 10f, FontStyle.Bold);
                        break;
                    }
                }
                this.txtOutput.SelectedText = str;
            }
            this.txtOutput.SelectedText = "\n";
        }

        //Added by Md. Abdul Hakim(Oct 12, 2014)
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                for (int i = 0; i < chkColumns.Items.Count; i++)
                {
                    {
                        chkColumns.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
            else
            {
                for (int i = 0; i < chkColumns.Items.Count; i++)
                {
                    {
                        chkColumns.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }                
            }
        }
    }

    public class Variables
    {
        public string VarName;
        public string VarType;

        public Variables(string VarName, string VarType)
        {
            this.VarName = VarName;
            this.VarType = VarType;
        }
    }
}

