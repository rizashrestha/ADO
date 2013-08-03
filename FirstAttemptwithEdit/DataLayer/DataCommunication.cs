using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//adding these two namespace
using System.Data;
using System.Data.SqlClient;
using StudentEntities;
using System.Configuration; 

namespace DataLayer
{
    public class DataCommunication
    {
        //making a method to get students detail by student ID which as Student object as a return type because we want all the object in student entities to return 
        public Student GetStudentDetailsByStudentID(int studentid)
        {
            //it is null right now but later we have declared it as new student
            Student stn = null;
            DataTable dtable = new DataTable();
            using (SqlConnection scon= new SqlConnection())
            {
               // scon.ConnectionString = scon.ConnectionString = "Data Source=RIZA-PC\\SQLEXPRESS;Initial Catalog=Practice;User ID=riza;password=riza123";
                scon.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; 
                scon.Open();
                SqlDataAdapter sadapter = new SqlDataAdapter(string.Format("SELECT [StudentID],[StudentName],[TeacherID],[Grade],[Address],[City],[ZipCode],[State],[TotalMarks] FROM [dbo].[3rdNStudent] where [StudentID]= {0};", studentid),scon);
                sadapter.Fill(dtable);
            }

            foreach (var item in dtable.Rows)
            {
                stn = new Student();
                stn.StudentID = studentid;
               //getting the value of of that selected rows field name and the field type
                stn.StudentName = GetColumnValue((DataRow)item, "StudentName", "str");
                stn.TeacherID = GetColumnValue((DataRow)item, "TeacherID","str");
                stn.Grade = GetColumnValue((DataRow)item, "Grade", "str");
                stn.Address = GetColumnValue((DataRow)item, "Address", "str");
                stn.City = GetColumnValue((DataRow)item, "City", "str");
                stn.ZipCode = GetColumnValue((DataRow)item, "ZipCode", "str");
                stn.State = GetColumnValue((DataRow)item, "State", "str");
                stn.TotalMarks = Convert.ToInt32(GetColumnValue((DataRow)item, "TotalMarks", "int"));

            }
            //returning the whole stn object which is the Student class
            return stn;
        }
        //declaring method which needs data row, field name and the field type as a parameter
        public string GetColumnValue(DataRow row, string fieldname,string fieldtype)
        {
            //it is returning empty string so that we can return the value at the end

            string output="";
            //if DB is not null then return the value of the field in string
            //DBNull.Value gives the value of that field
            if (!DBNull.Value.Equals(row[fieldname]))
                return Convert.ToString(row[fieldname]);
            else
            {
                //if the field is null then return the the value which has fieldtype int to "0" and if its string then return the empty string
                switch (fieldtype)
                { 
                    case "int":
                        output = "0";
                        break;
                    case "str":
                        output = string.Empty;
                        break;
                    default:
                        break;

                }
            }
            //return the output
            return output;
        }

        //after making changes in the text boxes and when we click on Update button then we need a method for it
        //thus declaring method UpdatesStudentDetails
        public int UpdatesStudentDetails(Student stn)
        {
            //declaring a updates statement with the SQL query for update with the return objects
            string updatestatement = string.Format("UPDATE [dbo].[3rdNStudent] SET [StudentName] = '{0}' ,[TeacherID] = '{1}', [Grade] = '{2}' ,[Address] = '{3}' ,[City] = '{4}' ,[ZipCode] = '{5}' ,[State] = '{6}',[TotalMarks] = {7} WHERE [StudentID]={8}",
                stn.StudentName, stn.TeacherID, stn.Grade, stn.Address, stn.City, stn.ZipCode, stn.State, stn.TotalMarks, stn.StudentID);

            int iresult = 0;
            //connecting to database to make changes
            using (SqlConnection scon= new SqlConnection())
            {
                //scon.ConnectionString = "Data Source=RIZA-PC\\SQLEXPRESS;Initial Catalog=Practice;User ID=riza;password=riza123";
                scon.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; 
                scon.Open();
                SqlCommand scom = new SqlCommand(updatestatement,scon);

                iresult = scom.ExecuteNonQuery();
            }
            return iresult;
        }

        public DataTable GetAllStudent()
        {
            DataSet ds= new DataSet();
            //first set the connection
            //we are using "using" object creation so that we can call dispose method implicitly. We want to clear everything
            using (SqlConnection scon = new SqlConnection())
            {
                //we use connectionstring and put the connection string we get through notepad or though SQL server explorer
                //scon.ConnectionString="Data Source=RIZA-PC\\SQLEXPRESS;Initial Catalog=Practice;User ID=riza;password=riza123";
                scon.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; 
                //after we set the connection we need to open it. it is very important otherwise it will not communicate
                scon.Open();
                //we create SqlDataAdapter object and pass command and the connection name
                SqlDataAdapter sda= new SqlDataAdapter("select * from [3rdNStudent]",scon);
                //this is done to fill the data in dataset
                sda.Fill(ds);
            }
            //we are using just one table and the index of that table is 0. so return the dataset first table
            return ds.Tables[0];
        }
  
        //first declare the method for AddStudent with parameter as the column
        public int AddStudent(string studentname, int teacherid, string grade, string address, string city, int zipcode, string state, int marks)
        {
            int iresult = 0;
            using (SqlConnection scon= new SqlConnection())
            {
                //scon.ConnectionString = "Data Source=RIZA-PC\\SQLEXPRESS;Initial Catalog=Practice;User ID=riza;password=riza123";
                scon.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; 
                scon.Open();
                //the command has a @@IDENTITY which is auto generated
                SqlCommand scom = new SqlCommand(string.Format("INSERT INTO [dbo].[3rdNStudent]  ([StudentName] ,[TeacherID] ,[Grade] ,[Address] ,[City] ,[ZipCode] ,[State] ,[TotalMarks]) VALUES ('{0}',{1},'{2}','{3}','{4}','{5}','{6}','{7}') select @@IDENTITY", studentname, teacherid, grade,address, city,zipcode, state, marks), scon);
                //?? what is ExecuteScalar
                //Visual Studio definition is it executes the query and returns the first column of the first row in the result set returned by the query
                iresult = Convert.ToInt32(scom.ExecuteScalar());
            }
            return iresult;

        }

        //creating method DeleteStudent 
        public int DeleteStudent(int studentid)
        {
            //we have made the return type of this method as int so we have to use some int variable to return 
            int iresult = 0;
            using (SqlConnection scon= new SqlConnection())
            {
                //scon.ConnectionString = "Data Source=RIZA-PC\\SQLEXPRESS;Initial Catalog=Practice;User ID=riza;password=riza123";
                scon.ConnectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString; 
                scon.Open();
                SqlCommand scom = new SqlCommand(string.Format("Delete from [3rdNStudent] where StudentID={0}", studentid),scon);
                //we use ExecuteNonQuery() in delete, insert and update
                iresult = scom.ExecuteNonQuery();
            }
            return iresult;
        }




        
    }
}
