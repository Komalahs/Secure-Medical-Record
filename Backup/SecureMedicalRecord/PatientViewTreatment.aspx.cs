﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureMedicalRecord
{
    public partial class PatientViewTreatment : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            txtPatientId.Text = Session["UserId"].ToString();
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.PatientId = int.Parse(txtPatientId.Text);
            DataTable tab = new DataTable();
            tab = objSecureMedicalRecordBLL.GetPatient_MD(objSecureMedicalRecordDTO);
            if (tab.Rows.Count > 0)
            {
                txtPatientFirstName.Text = tab.Rows[0]["Name"].ToString();
                txtGender.Text = tab.Rows[0]["Gender"].ToString();
                txtAge.Text = tab.Rows[0]["Age"].ToString();
                txtReason.Text = tab.Rows[0]["Reason"].ToString();
                txtAddress.Text = tab.Rows[0]["Address"].ToString();
                txtMobileNo.Text = tab.Rows[0]["MobileNo"].ToString();

            }
            DataTable tab_PH = new DataTable();
            tab_PH = objSecureMedicalRecordBLL.GetPatient_PHD(objSecureMedicalRecordDTO);
            if (tab_PH.Rows.Count > 0)
            {

                string dk = tab_PH.Rows[0]["DataKey"].ToString();
                GetDecryptData obj = new GetDecryptData();
                string result = obj.GetData(dk);
                string data = AESCryptoClass.Decrypt(tab_PH.Rows[0]["PastData"].ToString(), result.ToString());
                txtMedicalHistory.Text = data.Split('-')[0];
                txtPatientAllergies.Text = data.Split('-')[1];
                txtSocialHistory.Text = data.Split('-')[2];

                LoadData();
            }
        }
        private void LoadData()
        {
            try
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                objSecureMedicalRecordDTO.PatientId = int.Parse(txtPatientId.Text);
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetPatientDetails_Consult(objSecureMedicalRecordDTO);
                if (tab.Rows.Count > 0)
                {
                    Table1.Controls.Clear();
                    TableRow hr = new TableRow();

                    TableHeaderCell hc1 = new TableHeaderCell();
                    hc1.Text = "Doctor Name";

                    TableHeaderCell hc2 = new TableHeaderCell();
                    hc2.Text = "Problem Title";

                    TableHeaderCell hc3 = new TableHeaderCell();
                    hc3.Text = "Treatment Date";

                    TableHeaderCell hc4 = new TableHeaderCell();
                    hc4.Text = "Treatment Details";


                    hr.Cells.Add(hc1);
                    hr.Cells.Add(hc2);
                    hr.Cells.Add(hc3);
                    hr.Cells.Add(hc4);

                    Table1.Rows.Add(hr);
                    for (int i = 0; i < tab.Rows.Count; i++)
                    {
                        TableRow row = new TableRow();

                        Label lblDoctorName = new Label();
                        lblDoctorName.Text = tab.Rows[i]["DoctorName"].ToString();

                        TableCell DoctorName = new TableCell();
                        DoctorName.Controls.Add(lblDoctorName);

                        Label lblProblemTitle = new Label();
                        lblProblemTitle.Text = tab.Rows[i]["ProblemTitle"].ToString();

                        TableCell ProblemTitle = new TableCell();
                        ProblemTitle.Controls.Add(lblProblemTitle);

                        Label lblTDate = new Label();
                        lblTDate.Text = tab.Rows[i]["TDate"].ToString();

                        TableCell TDate = new TableCell();
                        TDate.Controls.Add(lblTDate);

                        string dk = tab.Rows[i]["DataKey"].ToString();
                        GetDecryptData obj = new GetDecryptData();
                        string result = obj.GetData(dk);

                        string data = AESCryptoClass.Decrypt(tab.Rows[i]["TData"].ToString(), result.ToString());

                        Label lblTDetails = new Label();
                        lblTDetails.Text = data;

                        TableCell TDetails = new TableCell();
                        TDetails.Controls.Add(lblTDetails);

                        row.Controls.Add(DoctorName);
                        row.Controls.Add(ProblemTitle);
                        row.Controls.Add(TDate);
                        row.Controls.Add(TDetails);

                        Table1.Controls.Add(row);
                    }
                }
            }
            catch
            { }
        }
    }
}