﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecureMedicalRecord
{
    public partial class AddPatientTreatment : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        static int PatientId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PatientId"] != null)
                {
                    txtPatientId.Text=Request.QueryString["PatientId"].ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.PatientId =int.Parse(txtPatientId.Text);
            objSecureMedicalRecordDTO.DoctorId = int.Parse(Session["UserId"].ToString());
            objSecureMedicalRecordDTO.ProblemTitle = txtProblem.Text;
            Shamir obj = new Shamir();
            Random rnd = new Random();
            int key = rnd.Next(1000, 9999);
            string attributedata = obj.AttributeValue(key);
            attributedata = attributedata.Remove(0, 1);
            objSecureMedicalRecordDTO.PastData = AESCryptoClass.EncryptData(txtDesp.Text, key.ToString());

            objSecureMedicalRecordDTO.DataKey = attributedata;
            string res = objSecureMedicalRecordBLL.PatientTreatment(objSecureMedicalRecordDTO);

            if (res == "1")
            {
               
                txtPatientId.Text = txtDesp.Text = txtProblem.Text = "";
                lblMsg.ForeColor = System.Drawing.Color.Green;
                lblMsg.Text = "Patient Treatment Uploaded Successfully";
            }
            else
            {
                lblMsg.ForeColor = System.Drawing.Color.Red;
                lblMsg.Text = "Patient Treatment Upload Error";
            }
        }
    }
}