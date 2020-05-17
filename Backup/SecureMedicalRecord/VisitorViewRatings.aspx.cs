using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SecureMedicalRecord
{
    public partial class VisitorViewRatings : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetDeptDetails();
                ddlDept.DataSource = tab;
                ddlDept.DataTextField = "DeptName";
                ddlDept.DataValueField = "DeptId";
                ddlDept.DataBind();
                ddlDept.Items.Insert(0, "--Select--");


            }
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRatings();
        }
        private void LoadRatings()
        {
            try
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                objSecureMedicalRecordDTO.DeptId = int.Parse(ddlDept.SelectedItem.Value);
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetDoctorRating_DId(objSecureMedicalRecordDTO);
                if (tab.Rows.Count > 0)
                {
                    lblMsg.Text = "";
                    GridView1.DataSource = tab;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.Controls.Clear();
                    lblMsg.Text = "no records found...";
                }
            }
            catch
            {
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}