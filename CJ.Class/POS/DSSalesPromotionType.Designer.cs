//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5420
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#pragma warning disable 1591

namespace CJ.Class.POS {
    
    
    /// <summary>
    ///Represents a strongly typed in-memory cache of data.
    ///</summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
    [global::System.Serializable()]
    [global::System.ComponentModel.DesignerCategoryAttribute("code")]
    [global::System.ComponentModel.ToolboxItem(true)]
    [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
    [global::System.Xml.Serialization.XmlRootAttribute("DSSalesPromotionType")]
    [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class DSSalesPromotionType : global::System.Data.DataSet {
        
        private SalesPromotionTypeDataTable tableSalesPromotionType;
        
        private global::System.Data.SchemaSerializationMode _schemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public DSSalesPromotionType() {
            this.BeginInit();
            this.InitClass();
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected DSSalesPromotionType(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                base(info, context, false) {
            if ((this.IsBinarySerialized(info, context) == true)) {
                this.InitVars(false);
                global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
                this.Tables.CollectionChanged += schemaChangedHandler1;
                this.Relations.CollectionChanged += schemaChangedHandler1;
                return;
            }
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((this.DetermineSchemaSerializationMode(info, context) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
                if ((ds.Tables["SalesPromotionType"] != null)) {
                    base.Tables.Add(new SalesPromotionTypeDataTable(ds.Tables["SalesPromotionType"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXmlSchema(new global::System.Xml.XmlTextReader(new global::System.IO.StringReader(strSchema)));
            }
            this.GetSerializationData(info, context);
            global::System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new global::System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.Browsable(false)]
        [global::System.ComponentModel.DesignerSerializationVisibility(global::System.ComponentModel.DesignerSerializationVisibility.Content)]
        public SalesPromotionTypeDataTable SalesPromotionType {
            get {
                return this.tableSalesPromotionType;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.BrowsableAttribute(true)]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Visible)]
        public override global::System.Data.SchemaSerializationMode SchemaSerializationMode {
            get {
                return this._schemaSerializationMode;
            }
            set {
                this._schemaSerializationMode = value;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataTableCollection Tables {
            get {
                return base.Tables;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.ComponentModel.DesignerSerializationVisibilityAttribute(global::System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public new global::System.Data.DataRelationCollection Relations {
            get {
                return base.Relations;
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void InitializeDerivedDataSet() {
            this.BeginInit();
            this.InitClass();
            this.EndInit();
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public override global::System.Data.DataSet Clone() {
            DSSalesPromotionType cln = ((DSSalesPromotionType)(base.Clone()));
            cln.InitVars();
            cln.SchemaSerializationMode = this.SchemaSerializationMode;
            return cln;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override void ReadXmlSerializable(global::System.Xml.XmlReader reader) {
            if ((this.DetermineSchemaSerializationMode(reader) == global::System.Data.SchemaSerializationMode.IncludeSchema)) {
                this.Reset();
                global::System.Data.DataSet ds = new global::System.Data.DataSet();
                ds.ReadXml(reader);
                if ((ds.Tables["SalesPromotionType"] != null)) {
                    base.Tables.Add(new SalesPromotionTypeDataTable(ds.Tables["SalesPromotionType"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, global::System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.ReadXml(reader);
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected override global::System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            global::System.IO.MemoryStream stream = new global::System.IO.MemoryStream();
            this.WriteXmlSchema(new global::System.Xml.XmlTextWriter(stream, null));
            stream.Position = 0;
            return global::System.Xml.Schema.XmlSchema.Read(new global::System.Xml.XmlTextReader(stream), null);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars() {
            this.InitVars(true);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        internal void InitVars(bool initTable) {
            this.tableSalesPromotionType = ((SalesPromotionTypeDataTable)(base.Tables["SalesPromotionType"]));
            if ((initTable == true)) {
                if ((this.tableSalesPromotionType != null)) {
                    this.tableSalesPromotionType.InitVars();
                }
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "DSSalesPromotionType";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSSalesPromotionType.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = global::System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableSalesPromotionType = new SalesPromotionTypeDataTable();
            base.Tables.Add(this.tableSalesPromotionType);
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeSalesPromotionType() {
            return false;
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void SchemaChanged(object sender, global::System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == global::System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
            DSSalesPromotionType ds = new DSSalesPromotionType();
            global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
            global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
            global::System.Xml.Schema.XmlSchemaAny any = new global::System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
            if (xs.Contains(dsSchema.TargetNamespace)) {
                global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                try {
                    global::System.Xml.Schema.XmlSchema schema = null;
                    dsSchema.Write(s1);
                    for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                        schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                        s2.SetLength(0);
                        schema.Write(s2);
                        if ((s1.Length == s2.Length)) {
                            s1.Position = 0;
                            s2.Position = 0;
                            for (; ((s1.Position != s1.Length) 
                                        && (s1.ReadByte() == s2.ReadByte())); ) {
                                ;
                            }
                            if ((s1.Position == s1.Length)) {
                                return type;
                            }
                        }
                    }
                }
                finally {
                    if ((s1 != null)) {
                        s1.Close();
                    }
                    if ((s2 != null)) {
                        s2.Close();
                    }
                }
            }
            xs.Add(dsSchema);
            return type;
        }
        
        public delegate void SalesPromotionTypeRowChangeEventHandler(object sender, SalesPromotionTypeRowChangeEvent e);
        
        /// <summary>
        ///Represents the strongly named DataTable class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [global::System.Serializable()]
        [global::System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class SalesPromotionTypeDataTable : global::System.Data.DataTable, global::System.Collections.IEnumerable {
            
            private global::System.Data.DataColumn columnSalesPromotionTypeID;
            
            private global::System.Data.DataColumn columnSalesPromotionTypeName;
            
            private global::System.Data.DataColumn columnIsActive;
            
            private global::System.Data.DataColumn columnCreateUserID;
            
            private global::System.Data.DataColumn columnCreateDate;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SalesPromotionTypeDataTable() {
                this.TableName = "SalesPromotionType";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SalesPromotionTypeDataTable(global::System.Data.DataTable table) {
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
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected SalesPromotionTypeDataTable(global::System.Runtime.Serialization.SerializationInfo info, global::System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn SalesPromotionTypeIDColumn {
                get {
                    return this.columnSalesPromotionTypeID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn SalesPromotionTypeNameColumn {
                get {
                    return this.columnSalesPromotionTypeName;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn IsActiveColumn {
                get {
                    return this.columnIsActive;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn CreateUserIDColumn {
                get {
                    return this.columnCreateUserID;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataColumn CreateDateColumn {
                get {
                    return this.columnCreateDate;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SalesPromotionTypeRow this[int index] {
                get {
                    return ((SalesPromotionTypeRow)(this.Rows[index]));
                }
            }
            
            public event SalesPromotionTypeRowChangeEventHandler SalesPromotionTypeRowChanging;
            
            public event SalesPromotionTypeRowChangeEventHandler SalesPromotionTypeRowChanged;
            
            public event SalesPromotionTypeRowChangeEventHandler SalesPromotionTypeRowDeleting;
            
            public event SalesPromotionTypeRowChangeEventHandler SalesPromotionTypeRowDeleted;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddSalesPromotionTypeRow(SalesPromotionTypeRow row) {
                this.Rows.Add(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SalesPromotionTypeRow AddSalesPromotionTypeRow(int SalesPromotionTypeID, string SalesPromotionTypeName, int IsActive, int CreateUserID, System.DateTime CreateDate) {
                SalesPromotionTypeRow rowSalesPromotionTypeRow = ((SalesPromotionTypeRow)(this.NewRow()));
                object[] columnValuesArray = new object[] {
                        SalesPromotionTypeID,
                        SalesPromotionTypeName,
                        IsActive,
                        CreateUserID,
                        CreateDate};
                rowSalesPromotionTypeRow.ItemArray = columnValuesArray;
                this.Rows.Add(rowSalesPromotionTypeRow);
                return rowSalesPromotionTypeRow;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual global::System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override global::System.Data.DataTable Clone() {
                SalesPromotionTypeDataTable cln = ((SalesPromotionTypeDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataTable CreateInstance() {
                return new SalesPromotionTypeDataTable();
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnSalesPromotionTypeID = base.Columns["SalesPromotionTypeID"];
                this.columnSalesPromotionTypeName = base.Columns["SalesPromotionTypeName"];
                this.columnIsActive = base.Columns["IsActive"];
                this.columnCreateUserID = base.Columns["CreateUserID"];
                this.columnCreateDate = base.Columns["CreateDate"];
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnSalesPromotionTypeID = new global::System.Data.DataColumn("SalesPromotionTypeID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnSalesPromotionTypeID);
                this.columnSalesPromotionTypeName = new global::System.Data.DataColumn("SalesPromotionTypeName", typeof(string), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnSalesPromotionTypeName);
                this.columnIsActive = new global::System.Data.DataColumn("IsActive", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnIsActive);
                this.columnCreateUserID = new global::System.Data.DataColumn("CreateUserID", typeof(int), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCreateUserID);
                this.columnCreateDate = new global::System.Data.DataColumn("CreateDate", typeof(global::System.DateTime), null, global::System.Data.MappingType.Element);
                base.Columns.Add(this.columnCreateDate);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SalesPromotionTypeRow NewSalesPromotionTypeRow() {
                return ((SalesPromotionTypeRow)(this.NewRow()));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Data.DataRow NewRowFromBuilder(global::System.Data.DataRowBuilder builder) {
                return new SalesPromotionTypeRow(builder);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override global::System.Type GetRowType() {
                return typeof(SalesPromotionTypeRow);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.SalesPromotionTypeRowChanged != null)) {
                    this.SalesPromotionTypeRowChanged(this, new SalesPromotionTypeRowChangeEvent(((SalesPromotionTypeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.SalesPromotionTypeRowChanging != null)) {
                    this.SalesPromotionTypeRowChanging(this, new SalesPromotionTypeRowChangeEvent(((SalesPromotionTypeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.SalesPromotionTypeRowDeleted != null)) {
                    this.SalesPromotionTypeRowDeleted(this, new SalesPromotionTypeRowChangeEvent(((SalesPromotionTypeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(global::System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.SalesPromotionTypeRowDeleting != null)) {
                    this.SalesPromotionTypeRowDeleting(this, new SalesPromotionTypeRowChangeEvent(((SalesPromotionTypeRow)(e.Row)), e.Action));
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveSalesPromotionTypeRow(SalesPromotionTypeRow row) {
                this.Rows.Remove(row);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static global::System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(global::System.Xml.Schema.XmlSchemaSet xs) {
                global::System.Xml.Schema.XmlSchemaComplexType type = new global::System.Xml.Schema.XmlSchemaComplexType();
                global::System.Xml.Schema.XmlSchemaSequence sequence = new global::System.Xml.Schema.XmlSchemaSequence();
                DSSalesPromotionType ds = new DSSalesPromotionType();
                global::System.Xml.Schema.XmlSchemaAny any1 = new global::System.Xml.Schema.XmlSchemaAny();
                any1.Namespace = "http://www.w3.org/2001/XMLSchema";
                any1.MinOccurs = new decimal(0);
                any1.MaxOccurs = decimal.MaxValue;
                any1.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any1);
                global::System.Xml.Schema.XmlSchemaAny any2 = new global::System.Xml.Schema.XmlSchemaAny();
                any2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
                any2.MinOccurs = new decimal(1);
                any2.ProcessContents = global::System.Xml.Schema.XmlSchemaContentProcessing.Lax;
                sequence.Items.Add(any2);
                global::System.Xml.Schema.XmlSchemaAttribute attribute1 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute1.Name = "namespace";
                attribute1.FixedValue = ds.Namespace;
                type.Attributes.Add(attribute1);
                global::System.Xml.Schema.XmlSchemaAttribute attribute2 = new global::System.Xml.Schema.XmlSchemaAttribute();
                attribute2.Name = "tableTypeName";
                attribute2.FixedValue = "SalesPromotionTypeDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                global::System.Xml.Schema.XmlSchema dsSchema = ds.GetSchemaSerializable();
                if (xs.Contains(dsSchema.TargetNamespace)) {
                    global::System.IO.MemoryStream s1 = new global::System.IO.MemoryStream();
                    global::System.IO.MemoryStream s2 = new global::System.IO.MemoryStream();
                    try {
                        global::System.Xml.Schema.XmlSchema schema = null;
                        dsSchema.Write(s1);
                        for (global::System.Collections.IEnumerator schemas = xs.Schemas(dsSchema.TargetNamespace).GetEnumerator(); schemas.MoveNext(); ) {
                            schema = ((global::System.Xml.Schema.XmlSchema)(schemas.Current));
                            s2.SetLength(0);
                            schema.Write(s2);
                            if ((s1.Length == s2.Length)) {
                                s1.Position = 0;
                                s2.Position = 0;
                                for (; ((s1.Position != s1.Length) 
                                            && (s1.ReadByte() == s2.ReadByte())); ) {
                                    ;
                                }
                                if ((s1.Position == s1.Length)) {
                                    return type;
                                }
                            }
                        }
                    }
                    finally {
                        if ((s1 != null)) {
                            s1.Close();
                        }
                        if ((s2 != null)) {
                            s2.Close();
                        }
                    }
                }
                xs.Add(dsSchema);
                return type;
            }
        }
        
        /// <summary>
        ///Represents strongly named DataRow class.
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class SalesPromotionTypeRow : global::System.Data.DataRow {
            
            private SalesPromotionTypeDataTable tableSalesPromotionType;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SalesPromotionTypeRow(global::System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableSalesPromotionType = ((SalesPromotionTypeDataTable)(this.Table));
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int SalesPromotionTypeID {
                get {
                    try {
                        return ((int)(this[this.tableSalesPromotionType.SalesPromotionTypeIDColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'SalesPromotionTypeID\' in table \'SalesPromotionType\' is DBNu" +
                                "ll.", e);
                    }
                }
                set {
                    this[this.tableSalesPromotionType.SalesPromotionTypeIDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string SalesPromotionTypeName {
                get {
                    try {
                        return ((string)(this[this.tableSalesPromotionType.SalesPromotionTypeNameColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'SalesPromotionTypeName\' in table \'SalesPromotionType\' is DB" +
                                "Null.", e);
                    }
                }
                set {
                    this[this.tableSalesPromotionType.SalesPromotionTypeNameColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int IsActive {
                get {
                    try {
                        return ((int)(this[this.tableSalesPromotionType.IsActiveColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'IsActive\' in table \'SalesPromotionType\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSalesPromotionType.IsActiveColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public int CreateUserID {
                get {
                    try {
                        return ((int)(this[this.tableSalesPromotionType.CreateUserIDColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'CreateUserID\' in table \'SalesPromotionType\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSalesPromotionType.CreateUserIDColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime CreateDate {
                get {
                    try {
                        return ((global::System.DateTime)(this[this.tableSalesPromotionType.CreateDateColumn]));
                    }
                    catch (global::System.InvalidCastException e) {
                        throw new global::System.Data.StrongTypingException("The value for column \'CreateDate\' in table \'SalesPromotionType\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSalesPromotionType.CreateDateColumn] = value;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsSalesPromotionTypeIDNull() {
                return this.IsNull(this.tableSalesPromotionType.SalesPromotionTypeIDColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetSalesPromotionTypeIDNull() {
                this[this.tableSalesPromotionType.SalesPromotionTypeIDColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsSalesPromotionTypeNameNull() {
                return this.IsNull(this.tableSalesPromotionType.SalesPromotionTypeNameColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetSalesPromotionTypeNameNull() {
                this[this.tableSalesPromotionType.SalesPromotionTypeNameColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsIsActiveNull() {
                return this.IsNull(this.tableSalesPromotionType.IsActiveColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetIsActiveNull() {
                this[this.tableSalesPromotionType.IsActiveColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCreateUserIDNull() {
                return this.IsNull(this.tableSalesPromotionType.CreateUserIDColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCreateUserIDNull() {
                this[this.tableSalesPromotionType.CreateUserIDColumn] = global::System.Convert.DBNull;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsCreateDateNull() {
                return this.IsNull(this.tableSalesPromotionType.CreateDateColumn);
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetCreateDateNull() {
                this[this.tableSalesPromotionType.CreateDateColumn] = global::System.Convert.DBNull;
            }
        }
        
        /// <summary>
        ///Row event argument class
        ///</summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SalesPromotionTypeRowChangeEvent : global::System.EventArgs {
            
            private SalesPromotionTypeRow eventRow;
            
            private global::System.Data.DataRowAction eventAction;
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SalesPromotionTypeRowChangeEvent(SalesPromotionTypeRow row, global::System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SalesPromotionTypeRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public global::System.Data.DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}

#pragma warning restore 1591