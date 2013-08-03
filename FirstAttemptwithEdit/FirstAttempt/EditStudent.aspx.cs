using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentEntities;
using DataLayer;

namespace FirstAttempt
{
    public partial class EditStudent : System.Web.UI.Page
    {
        //now to load the edit web page
        //instantiate student class
        Student stn = null;
        int studentid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
                   //declaring studentid to 0
                
                //if requested string is not null then
                if (Request.QueryString != null)
                {
                    //get the studentid
                    studentid = Convert.ToInt32(Request.QueryString["StudentID"]);
                    //instantiate datacommunication
                }
            if(!IsPostBack)
            {
                    DataCommunication dcom = new DataCommunication();
                    stn = dcom.GetStudentDetailsByStudentID(studentid);
                    if (stn != null)
                    {
                        //populate the textboxes with objects in studententity framework
                        tbStudentName.Text = stn.StudentName;
                        ddlTeacherID.Text = stn.TeacherID;
                        ddlGrade.Text = stn.Grade;
                        tbAddress.Text = stn.Address;
                        tbCity.Text = stn.City;
                        tbZipCode.Text = stn.ZipCode;
                        ddlState.Text = stn.State;
                        tbTotalMarks.Text = stn.TotalMarks.ToString();

                    }
                }
            }
        
        protected void btnUpdateStudent_Click(object sender, EventArgs e)
        {
            //int returncode = 0;
            if (stn==null)
            {
                stn = new Student();
            }
            //when we click edit button then the studententities should be updated with new informations
            stn.StudentID = studentid;
            stn.StudentName = tbStudentName.Text;
            stn.TeacherID = ddlTeacherID.Text;
            stn.Grade = ddlGrade.Text;
            stn.Address = tbAddress.Text;
            stn.City = tbCity.Text;
            stn.ZipCode = tbZipCode.Text;
            stn.State = ddlState.Text;
            stn.TotalMarks =Convert.ToInt16( tbTotalMarks.Text);
            DataCommunication dcom = new DataCommunication();
            if (dcom.UpdatesStudentDetails(stn) == 1)
            {
                lblResult.Text = "Update student data successfull....";
            }
            else
            {
                lblResult.Text = "Failed";
            }

        }
    }
}