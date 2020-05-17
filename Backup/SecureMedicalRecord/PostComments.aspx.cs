using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace SecureMedicalRecord
{
    public partial class PostComments : System.Web.UI.Page
    {
        SecureMedicalRecord.BLL.SecureMedicalRecordBLL objSecureMedicalRecordBLL = null;
        SecureMedicalRecord.DTO.SecureMedicalRecordDTO objSecureMedicalRecordDTO = null;
        float pcount = 0;
        float pwordcount = 0;
        float ncount = 0;
        float nwordcount = 0;
        string comment = null;
        Hashtable hneg = new Hashtable();
        Hashtable hpos = new Hashtable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
                objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
                objSecureMedicalRecordDTO.PatientId = int.Parse(Session["UserId"].ToString());
                DataTable tab = new DataTable();
                tab = objSecureMedicalRecordBLL.GetDoctorId_PId(objSecureMedicalRecordDTO);
                ddlDoctor.DataSource = tab;
                ddlDoctor.DataTextField = "DoctorName";
                ddlDoctor.DataValueField = "DoctorId";
                ddlDoctor.DataBind();
                ddlDoctor.Items.Insert(0, "--Select--");


            }
        }
        public string NLPmethod(string sentence)
        {
            NLP.Tokenizer tok = new NLP.Tokenizer();
            NLP.CleanSentence objcleansentence = new NLP.CleanSentence();
            string tokens = tok.btnGo_Click(sentence);
            NLP.CleanSentence cs = new NLP.CleanSentence();
            string articles = cs.RemoveArticles(tokens);
            string pronouns = cs.RemovePronouns(articles);
            string prepositions = cs.RemovePrepositions(pronouns);
            string conjunction = cs.RemoveConjunctions(prepositions);
            return conjunction;

        }
        float wordcount = 0;
        float count = 0;
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objSecureMedicalRecordBLL = new BLL.SecureMedicalRecordBLL();
            objSecureMedicalRecordDTO = new DTO.SecureMedicalRecordDTO();
            objSecureMedicalRecordDTO.PatientId = int.Parse(Session["UserId"].ToString());
            objSecureMedicalRecordDTO.Comments = txtComments.Text;
            comment = NLPmethod(txtComments.Text.ToLower());
            NLP.PosNeg objposneg = new NLP.PosNeg();

            hneg = objposneg.Negativemethod();
            hpos = objposneg.Positiveemethod();
            foreach (DictionaryEntry d in hneg)
            {
                string key = d.Key.ToString();
                if (comment.ToLower().Contains(key))
                {
                    wordcount += 1;
                    count += int.Parse(d.Value.ToString());
                }
            }

            foreach (DictionaryEntry d in hpos)
            {
                string key = d.Key.ToString();
                if (comment.ToLower().Contains(key))
                {
                    wordcount += 1;
                    count += int.Parse(d.Value.ToString());
                }
            }
            float rating = 0;
            if (wordcount == 0)
            {
                rating = 0.5F;
            }
            else
            {
                rating = (count / wordcount);
            }
            int Rt = Convert.ToInt32(Math.Ceiling(rating));
            objSecureMedicalRecordDTO.PRate = Rt.ToString();
            objSecureMedicalRecordDTO.DoctorId = int.Parse(ddlDoctor.SelectedItem.Value);
            int res = objSecureMedicalRecordBLL.PatientPostComments(objSecureMedicalRecordDTO);
            if (res == 1)
            {
                txtComments.Text = "";
                lblMsg.Text = "Comments Post Successfully";
                lblMsg.ForeColor = System.Drawing.Color.Green;

            }
            else 
            {
                txtComments.Text = "";
                lblMsg.Text = "Comments Post Error";
                lblMsg.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}