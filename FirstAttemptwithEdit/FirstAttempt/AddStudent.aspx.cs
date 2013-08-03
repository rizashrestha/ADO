using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace FirstAttempt
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //to make the drop down button start with Select rather then any other teacher
            ddlTeacherID.Items.Insert(0,new ListItem("Select","0"));
        }

        // method made for click for add student
        protected void Button1_Click(object sender, EventArgs e)
        {
            //create object for DataCommunication so that we can use AddStudent method 
            DataCommunication dbcom = new DataCommunication();
            //calling the method using all the parameter from the text boxes and converiting to int where needed
            int response = dbcom.AddStudent(tbStudentName.Text,
                                            Convert.ToInt32(ddlTeacherID.Text),
                                            ddlGrade.Text,
                                            tbAddress.Text, 
                                            tbCity.Text,
                                            Convert.ToInt32(tbZipCode.Text),
                                            ddlState.Text,
                                            Convert.ToInt32(tbTotalMarks.Text)
                                            );

            //response is the return from the AddStudent method which is iresult in this case
            if (response == 0)
            {
                lblResult.Text = "Registration failed........ please try again.";
            }
            else
            {
                lblResult.Text = string.Format("Registration successfull........ and Student ID:{0}.", response);
            }
        }
    }
}