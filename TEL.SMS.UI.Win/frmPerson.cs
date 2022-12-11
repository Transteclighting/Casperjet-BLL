using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;

namespace TEL.SMS.UI.Win
{
    public partial class frmPerson : Form
    {
        public frmPerson()
        {
            InitializeComponent();
        }
        public void ShowDialog(DSPerson oDSPerson)
        {
            TEL.SMS.BO.DA.DAPerson oDAPerson = new DAPerson();
            oDAPerson.GetPerson(oDSPerson);

            this.Tag = oDSPerson;
            this.txtPersonCode.Text = oDSPerson.Person[0].PersonCode;
            this.txtPersonName.Text = oDSPerson.Person[0].PersonName;
            this.txtMobileNo.Text = oDSPerson.Person[0].MobileNo;
            this.ShowDialog();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            //Check whether add new or modify
            if (this.Tag == null)
            {
                //Add new Person
                DSPerson oDSPerson = new DSPerson();
                DSPerson.PersonRow oPerson = oDSPerson.Person.NewPersonRow();

                oPerson.PersonCode= this.txtPersonCode .Text ;
                oPerson.PersonName = this.txtPersonName.Text;
                oPerson.MobileNo = this.txtMobileNo.Text;

                oDSPerson.Person.AddPersonRow(oPerson);
                oDSPerson.AcceptChanges();

                DAPerson oDAPerson = new DAPerson();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDAPerson.Insert(oDSPerson);
                    DBController.Instance.CommitTransaction();
                    //if (oDSPerson.HasErrors)
                    //{
                    //    setError(oDSPerson.Person);
                    //}
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                //Modify Person
                DSPerson oDSPerson = (DSPerson)this.Tag;
                oDSPerson.Person[0].PersonCode = this.txtPersonCode.Text ;
                oDSPerson.Person[0].PersonName = this.txtPersonName.Text;
                oDSPerson.Person[0].MobileNo = this.txtMobileNo.Text;
                oDSPerson.AcceptChanges();

                DAPerson oDAPerson = new DAPerson();
                DBController.Instance.BeginNewTransaction();
                oDAPerson.Update(oDSPerson);
                DBController.Instance.CommitTransaction();
            }
            this.Close();
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            //Check whether add new or modify
            if (this.Tag == null)
            {
                this.Text = "Add new Person";
            }
            else
            {
                this.Text = "Modify Person";
            }
        }
    }
}