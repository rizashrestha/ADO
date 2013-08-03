using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//adding System.Data and class library made by us
using System.Data;
//using System.Data.SqlClient;
using DataLayer;

namespace FirstAttempt
{
    public partial class _Default : System.Web.UI.Page
    {
        DataCommunication dc;
        protected void Page_Load(object sender, EventArgs e)
        {
            //in UI we get the data and bind the data
            //create the datacommunication object
            dc = new DataCommunication();
            //get the tool we used in design view and get datasource and call GetAllStudent Method
            GridView1.DataSource = dc.GetAllStudent();
            //adding the Gridview1_RowDeleting() with delegate GridViewDeleteEventHandler calling Gridview1_RowDeleting method
            GridView1.RowDeleting += new GridViewDeleteEventHandler(Gridview1_RowDeleting);
            GridView1.RowEditing+=GridView1_RowEditing;


            //Then we need to bind the data
            GridView1.DataBind();
        }

        //making method to populate the edit form after clicking on the edit 
        void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.NewEditIndex];
            Response.Redirect(string.Format("EditStudent.aspx?studentid={0}", Convert.ToInt32(row.Cells[1].Text)));
        }



        //making method to delete the row which matches the signature with the GridViewDeleteEventHandler delegate
        void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        { 
            //declaring object and putting the value of the index
            GridViewRow row= GridView1.Rows[e.RowIndex];
            //communicating with data with DeleteStudent which communicate with the database
            dc.DeleteStudent(Convert.ToInt32(row.Cells[1].Text));
            //calling datatable and making it get all student with GetAllStudent()
            DataTable dt = dc.GetAllStudent();
            //call the datasource to put the value in the data in GridView1
            GridView1.DataSource = dt;
            //binding the data
            GridView1.DataBind();
        }
    }
}