//------------------------------------------------------------------------------
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
    [System.Xml.Serialization.XmlRootAttribute("DSSMSMessageIn")]
    [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
    public partial class DSSMSMessageIn : System.Data.DataSet {
        
        private SMSInMessageDataTable tableSMSInMessage;
        
        private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public DSSMSMessageIn() {
            this.BeginInit();
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            base.Tables.CollectionChanged += schemaChangedHandler;
            base.Relations.CollectionChanged += schemaChangedHandler;
            this.EndInit();
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        protected DSSMSMessageIn(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
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
                if ((ds.Tables["SMSInMessage"] != null)) {
                    base.Tables.Add(new SMSInMessageDataTable(ds.Tables["SMSInMessage"]));
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
        public SMSInMessageDataTable SMSInMessage {
            get {
                return this.tableSMSInMessage;
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
            DSSMSMessageIn cln = ((DSSMSMessageIn)(base.Clone()));
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
                if ((ds.Tables["SMSInMessage"] != null)) {
                    base.Tables.Add(new SMSInMessageDataTable(ds.Tables["SMSInMessage"]));
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
            this.tableSMSInMessage = ((SMSInMessageDataTable)(base.Tables["SMSInMessage"]));
            if ((initTable == true)) {
                if ((this.tableSMSInMessage != null)) {
                    this.tableSMSInMessage.InitVars();
                }
            }
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private void InitClass() {
            this.DataSetName = "DSSMSMessageIn";
            this.Prefix = "";
            this.Namespace = "http://tempuri.org/DSSMSMessageIn.xsd";
            this.EnforceConstraints = true;
            this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            this.tableSMSInMessage = new SMSInMessageDataTable();
            base.Tables.Add(this.tableSMSInMessage);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private bool ShouldSerializeSMSInMessage() {
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
            DSSMSMessageIn ds = new DSSMSMessageIn();
            System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
            System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
            xs.Add(ds.GetSchemaSerializable());
            System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
            any.Namespace = ds.Namespace;
            sequence.Items.Add(any);
            type.Particle = sequence;
            return type;
        }
        
        public delegate void SMSInMessageRowChangeEventHandler(object sender, SMSInMessageRowChangeEvent e);
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        [System.Serializable()]
        [System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedTableSchema")]
        public partial class SMSInMessageDataTable : System.Data.DataTable, System.Collections.IEnumerable {
            
            private System.Data.DataColumn columnSMSMessageID;
            
            private System.Data.DataColumn columnReceiveDate;
            
            private System.Data.DataColumn columnSMSText;
            
            private System.Data.DataColumn columnMessageType;
            
            private System.Data.DataColumn columnMobileNo;
            
            private System.Data.DataColumn columnStatus;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SMSInMessageDataTable() {
                this.TableName = "SMSInMessage";
                this.BeginInit();
                this.InitClass();
                this.EndInit();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SMSInMessageDataTable(System.Data.DataTable table) {
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
            protected SMSInMessageDataTable(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
                    base(info, context) {
                this.InitVars();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn SMSMessageIDColumn {
                get {
                    return this.columnSMSMessageID;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn ReceiveDateColumn {
                get {
                    return this.columnReceiveDate;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn SMSTextColumn {
                get {
                    return this.columnSMSText;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MessageTypeColumn {
                get {
                    return this.columnMessageType;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn MobileNoColumn {
                get {
                    return this.columnMobileNo;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.Data.DataColumn StatusColumn {
                get {
                    return this.columnStatus;
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
            public SMSInMessageRow this[int index] {
                get {
                    return ((SMSInMessageRow)(this.Rows[index]));
                }
            }
            
            public event SMSInMessageRowChangeEventHandler SMSInMessageRowChanging;
            
            public event SMSInMessageRowChangeEventHandler SMSInMessageRowChanged;
            
            public event SMSInMessageRowChangeEventHandler SMSInMessageRowDeleting;
            
            public event SMSInMessageRowChangeEventHandler SMSInMessageRowDeleted;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void AddSMSInMessageRow(SMSInMessageRow row) {
                this.Rows.Add(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SMSInMessageRow AddSMSInMessageRow(long SMSMessageID, System.DateTime ReceiveDate, string SMSText, long MessageType, string MobileNo, long Status) {
                SMSInMessageRow rowSMSInMessageRow = ((SMSInMessageRow)(this.NewRow()));
                rowSMSInMessageRow.ItemArray = new object[] {
                        SMSMessageID,
                        ReceiveDate,
                        SMSText,
                        MessageType,
                        MobileNo,
                        Status};
                this.Rows.Add(rowSMSInMessageRow);
                return rowSMSInMessageRow;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public virtual System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public override System.Data.DataTable Clone() {
                SMSInMessageDataTable cln = ((SMSInMessageDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataTable CreateInstance() {
                return new SMSInMessageDataTable();
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal void InitVars() {
                this.columnSMSMessageID = base.Columns["SMSMessageID"];
                this.columnReceiveDate = base.Columns["ReceiveDate"];
                this.columnSMSText = base.Columns["SMSText"];
                this.columnMessageType = base.Columns["MessageType"];
                this.columnMobileNo = base.Columns["MobileNo"];
                this.columnStatus = base.Columns["Status"];
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private void InitClass() {
                this.columnSMSMessageID = new System.Data.DataColumn("SMSMessageID", typeof(long), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnSMSMessageID);
                this.columnReceiveDate = new System.Data.DataColumn("ReceiveDate", typeof(System.DateTime), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnReceiveDate);
                this.columnSMSText = new System.Data.DataColumn("SMSText", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnSMSText);
                this.columnMessageType = new System.Data.DataColumn("MessageType", typeof(long), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMessageType);
                this.columnMobileNo = new System.Data.DataColumn("MobileNo", typeof(string), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnMobileNo);
                this.columnStatus = new System.Data.DataColumn("Status", typeof(long), null, System.Data.MappingType.Element);
                base.Columns.Add(this.columnStatus);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SMSInMessageRow NewSMSInMessageRow() {
                return ((SMSInMessageRow)(this.NewRow()));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Data.DataRow NewRowFromBuilder(System.Data.DataRowBuilder builder) {
                return new SMSInMessageRow(builder);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override System.Type GetRowType() {
                return typeof(SMSInMessageRow);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanged(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.SMSInMessageRowChanged != null)) {
                    this.SMSInMessageRowChanged(this, new SMSInMessageRowChangeEvent(((SMSInMessageRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowChanging(System.Data.DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.SMSInMessageRowChanging != null)) {
                    this.SMSInMessageRowChanging(this, new SMSInMessageRowChangeEvent(((SMSInMessageRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleted(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.SMSInMessageRowDeleted != null)) {
                    this.SMSInMessageRowDeleted(this, new SMSInMessageRowChangeEvent(((SMSInMessageRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            protected override void OnRowDeleting(System.Data.DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.SMSInMessageRowDeleting != null)) {
                    this.SMSInMessageRowDeleting(this, new SMSInMessageRowChangeEvent(((SMSInMessageRow)(e.Row)), e.Action));
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void RemoveSMSInMessageRow(SMSInMessageRow row) {
                this.Rows.Remove(row);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public static System.Xml.Schema.XmlSchemaComplexType GetTypedTableSchema(System.Xml.Schema.XmlSchemaSet xs) {
                System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
                System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
                DSSMSMessageIn ds = new DSSMSMessageIn();
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
                attribute2.FixedValue = "SMSInMessageDataTable";
                type.Attributes.Add(attribute2);
                type.Particle = sequence;
                return type;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public partial class SMSInMessageRow : System.Data.DataRow {
            
            private SMSInMessageDataTable tableSMSInMessage;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            internal SMSInMessageRow(System.Data.DataRowBuilder rb) : 
                    base(rb) {
                this.tableSMSInMessage = ((SMSInMessageDataTable)(this.Table));
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public long SMSMessageID {
                get {
                    try {
                        return ((long)(this[this.tableSMSInMessage.SMSMessageIDColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'SMSMessageID\' in table \'SMSInMessage\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSMSInMessage.SMSMessageIDColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public System.DateTime ReceiveDate {
                get {
                    try {
                        return ((System.DateTime)(this[this.tableSMSInMessage.ReceiveDateColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'ReceiveDate\' in table \'SMSInMessage\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSMSInMessage.ReceiveDateColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string SMSText {
                get {
                    try {
                        return ((string)(this[this.tableSMSInMessage.SMSTextColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'SMSText\' in table \'SMSInMessage\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSMSInMessage.SMSTextColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public long MessageType {
                get {
                    try {
                        return ((long)(this[this.tableSMSInMessage.MessageTypeColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'MessageType\' in table \'SMSInMessage\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSMSInMessage.MessageTypeColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public string MobileNo {
                get {
                    try {
                        return ((string)(this[this.tableSMSInMessage.MobileNoColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'MobileNo\' in table \'SMSInMessage\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSMSInMessage.MobileNoColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public long Status {
                get {
                    try {
                        return ((long)(this[this.tableSMSInMessage.StatusColumn]));
                    }
                    catch (System.InvalidCastException e) {
                        throw new System.Data.StrongTypingException("The value for column \'Status\' in table \'SMSInMessage\' is DBNull.", e);
                    }
                }
                set {
                    this[this.tableSMSInMessage.StatusColumn] = value;
                }
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsSMSMessageIDNull() {
                return this.IsNull(this.tableSMSInMessage.SMSMessageIDColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetSMSMessageIDNull() {
                this[this.tableSMSInMessage.SMSMessageIDColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsReceiveDateNull() {
                return this.IsNull(this.tableSMSInMessage.ReceiveDateColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetReceiveDateNull() {
                this[this.tableSMSInMessage.ReceiveDateColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsSMSTextNull() {
                return this.IsNull(this.tableSMSInMessage.SMSTextColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetSMSTextNull() {
                this[this.tableSMSInMessage.SMSTextColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMessageTypeNull() {
                return this.IsNull(this.tableSMSInMessage.MessageTypeColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMessageTypeNull() {
                this[this.tableSMSInMessage.MessageTypeColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsMobileNoNull() {
                return this.IsNull(this.tableSMSInMessage.MobileNoColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetMobileNoNull() {
                this[this.tableSMSInMessage.MobileNoColumn] = System.Convert.DBNull;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public bool IsStatusNull() {
                return this.IsNull(this.tableSMSInMessage.StatusColumn);
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public void SetStatusNull() {
                this[this.tableSMSInMessage.StatusColumn] = System.Convert.DBNull;
            }
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
        public class SMSInMessageRowChangeEvent : System.EventArgs {
            
            private SMSInMessageRow eventRow;
            
            private System.Data.DataRowAction eventAction;
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SMSInMessageRowChangeEvent(SMSInMessageRow row, System.Data.DataRowAction action) {
                this.eventRow = row;
                this.eventAction = action;
            }
            
            [System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public SMSInMessageRow Row {
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