﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace TEL.SMS.BO.BE {
    using System;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.ComponentModel.ToolboxItem(true)]
    [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [System.Xml.Serialization.XmlRootAttribute("DSPerson")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class DSPerson : System.Data.DataSet {
        
        private PersonDataTable tablePerson;
        
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public DSPerson() {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected DSPerson(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["Person"] != null)) {
                    base.Tables.Add(new PersonDataTable(ds.Tables["Person"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public PersonDataTable Person {
            get {
                return this.tablePerson;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.BrowsableAttribute(true)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override System.Data.DataSet Clone() {
            DSPerson cln = ((DSPerson)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                System.Data.DataSet ds = new System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["Person"] != null)) {
                    base.Tables.Add(new PersonDataTable(ds.Tables["Person"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tablePerson = ((PersonDataTable)(base.Tables["Person"]));
            if ((initTable == true)) {
                if ((this.tablePerson != null)) {
                    this.tablePerson.InitVars();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "DSPerson";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSPerson.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tablePerson = new PersonDataTable();
            base.Tables.Add(this.tablePerson);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializePerson() {
            return false;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
            DSPerson ds = new DSPerson();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }
        
        public delegate void PersonRowChangeEventHandler(object sender, PersonRowChangeEvent e);
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class PersonDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnMobileID;
            
            private System.Data.DataColumn columnPersonCode;
            
            private System.Data.DataColumn columnPersonName;
            
            private System.Data.DataColumn columnMobileNo;
            
            private System.Data.DataColumn columnIsActive;
            
            private System.Data.DataColumn columnEmployeeID;
            
            private System.Data.DataColumn columnEmployeeCode;
            
            private System.Data.DataColumn columnEmployeeName;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public PersonDataTable() {
                this.TableName = "Person";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal PersonDataTable(System.Data.DataTable table) {
                this.TableName = table.TableName;
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected PersonDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MobileIDColumn {
                get {
                    return this.columnMobileID;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn PersonCodeColumn {
                get {
                    return this.columnPersonCode;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn PersonNameColumn {
                get {
                    return this.columnPersonName;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MobileNoColumn {
                get {
                    return this.columnMobileNo;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn IsActiveColumn {
                get {
                    return this.columnIsActive;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn EmployeeIDColumn {
                get {
                    return this.columnEmployeeID;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn EmployeeCodeColumn {
                get {
                    return this.columnEmployeeCode;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn EmployeeNameColumn {
                get {
                    return this.columnEmployeeName;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public PersonRow this[int index] {
                get {
                    return ((PersonRow)(this.Rows[index]));
                }
            }
            
            public event PersonRowChangeEventHandler PersonRowChanging;
            
            public event PersonRowChangeEventHandler PersonRowChanged;
            
            public event PersonRowChangeEventHandler PersonRowDeleting;
            
            public event PersonRowChangeEventHandler PersonRowDeleted;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddPersonRow(PersonRow row) {
                this.Rows.Add(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public PersonRow AddPersonRow(long MobileID, string PersonCode, string PersonName, string MobileNo, short IsActive, long EmployeeID, string EmployeeCode, string EmployeeName) {
                PersonRow rowPersonRow = ((PersonRow)(this.NewRow()));
                rowPersonRow.ItemArray = new object[] {
                        MobileID,
                        PersonCode,
                        PersonName,
                        MobileNo,
                        IsActive,
                        EmployeeID,
                        EmployeeCode,
                        EmployeeName};
                this.Rows.Add(rowPersonRow);
                return rowPersonRow;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone() {
                PersonDataTable cln = ((PersonDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance() {
                return new PersonDataTable();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnMobileID = base.Columns["MobileID"];
                this.columnPersonCode = base.Columns["PersonCode"];
                this.columnPersonName = base.Columns["PersonName"];
                this.columnMobileNo = base.Columns["MobileNo"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnEmployeeID = base.Columns["EmployeeID"];
                this.columnEmployeeCode = base.Columns["EmployeeCode"];
                this.columnEmployeeName = base.Columns["EmployeeName"];
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnMobileID = new System.Data.DataColumn("MobileID", typeof(long), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMobileID);
                this.columnPersonCode = new System.Data.DataColumn("PersonCode", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnPersonCode);
                this.columnPersonName = new System.Data.DataColumn("PersonName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnPersonName);
                this.columnMobileNo = new System.Data.DataColumn("MobileNo", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMobileNo);
                this.columnIsActive = new System.Data.DataColumn("IsActive", typeof(short), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsActive);
                this.columnEmployeeID = new System.Data.DataColumn("EmployeeID", typeof(long), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnEmployeeID);
                this.columnEmployeeCode = new System.Data.DataColumn("EmployeeCode", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnEmployeeCode);
                this.columnEmployeeName = new System.Data.DataColumn("EmployeeName", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnEmployeeName);
                this.columnMobileID.Caption = "PersonID";
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public PersonRow NewPersonRow() {
                return ((PersonRow)(this.NewRow()));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new PersonRow(builder);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType() {
                return typeof(PersonRow);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.PersonRowChanged != null)) {
                    this.PersonRowChanged(this, new PersonRowChangeEvent(((PersonRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.PersonRowChanging != null)) {
                    this.PersonRowChanging(this, new PersonRowChangeEvent(((PersonRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.PersonRowDeleted != null)) {
                    this.PersonRowDeleted(this, new PersonRowChangeEvent(((PersonRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.PersonRowDeleting != null)) {
                    this.PersonRowDeleting(this, new PersonRowChangeEvent(((PersonRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemovePersonRow(PersonRow row) {
                this.Rows.Remove(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                DSPerson ds = new DSPerson();
                xs.Add(ds.GetSchemaSerializable());
                System.Xml.Schema.XmlSchemaAny any1 = new System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                System.Xml.Schema.XmlSchemaAny any2 = new System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                System.Xml.Schema.XmlSchemaAttribute attribute1 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                System.Xml.Schema.XmlSchemaAttribute attribute2 = new System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "PersonDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class PersonRow : System.Data.DataRow {
            
            private PersonDataTable tablePerson;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal PersonRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tablePerson = ((PersonDataTable)(this.Table));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public long MobileID {
                get {
                    try {
                        return ((long)(this[this.tablePerson.MobileIDColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'MobileID\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.MobileIDColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string PersonCode {
                get {
                    try {
                        return ((string)(this[this.tablePerson.PersonCodeColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'PersonCode\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.PersonCodeColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string PersonName {
                get {
                    try {
                        return ((string)(this[this.tablePerson.PersonNameColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'PersonName\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.PersonNameColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string MobileNo {
                get {
                    try {
                        return ((string)(this[this.tablePerson.MobileNoColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'MobileNo\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.MobileNoColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public short IsActive {
                get {
                    try {
                        return ((short)(this[this.tablePerson.IsActiveColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'IsActive\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.IsActiveColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public long EmployeeID {
                get {
                    try {
                        return ((long)(this[this.tablePerson.EmployeeIDColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'EmployeeID\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.EmployeeIDColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string EmployeeCode {
                get {
                    try {
                        return ((string)(this[this.tablePerson.EmployeeCodeColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'EmployeeCode\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.EmployeeCodeColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string EmployeeName {
                get {
                    try {
                        return ((string)(this[this.tablePerson.EmployeeNameColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'EmployeeName\' in table \'Person\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tablePerson.EmployeeNameColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMobileIDNull() {
                return this.IsNull(this.tablePerson.MobileIDColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMobileIDNull() {
                this[this.tablePerson.MobileIDColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsPersonCodeNull() {
                return this.IsNull(this.tablePerson.PersonCodeColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetPersonCodeNull() {
                this[this.tablePerson.PersonCodeColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsPersonNameNull() {
                return this.IsNull(this.tablePerson.PersonNameColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetPersonNameNull() {
                this[this.tablePerson.PersonNameColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMobileNoNull() {
                return this.IsNull(this.tablePerson.MobileNoColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMobileNoNull() {
                this[this.tablePerson.MobileNoColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsIsActiveNull() {
                return this.IsNull(this.tablePerson.IsActiveColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetIsActiveNull() {
                this[this.tablePerson.IsActiveColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEmployeeIDNull() {
                return this.IsNull(this.tablePerson.EmployeeIDColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEmployeeIDNull() {
                this[this.tablePerson.EmployeeIDColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEmployeeCodeNull() {
                return this.IsNull(this.tablePerson.EmployeeCodeColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEmployeeCodeNull() {
                this[this.tablePerson.EmployeeCodeColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsEmployeeNameNull() {
                return this.IsNull(this.tablePerson.EmployeeNameColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetEmployeeNameNull() {
                this[this.tablePerson.EmployeeNameColumn] = System.Convert.DBNull;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class PersonRowChangeEvent : System.EventArgs {
            
            private PersonRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public PersonRowChangeEvent(PersonRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public PersonRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591