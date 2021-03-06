﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace iWork
{

    public partial class AssignEmployeesOnProject : System.Web.UI.Page
    {

        string connStr = ConfigurationManager.ConnectionStrings["MyDbConn"].ToString();
     


        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                if (Session["Username"] != null)
                {

                    ErrorMessage.Text = "";
                    SqlConnection conn = new SqlConnection(connStr);

                    SqlCommand cmd = new SqlCommand("getProjectsAviavlable", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@manager_name", Session["Username"].ToString()));

                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    Label Title = new Label();
                    Title.Text = "Choose the Project you want to assign Regular Empolyees in" + "<br />" + "<br />";
                    form1.Controls.Add(Title);
                    if (!rdr.HasRows)
                    {
                        Label errorName = new Label();
                        errorName.Text = "No Projects are available";

                        form1.Controls.Add(errorName);
                    }
                    while (rdr.Read())
                    {

                        Label projectTitle = new Label();
                        string project_title = rdr.GetString(rdr.GetOrdinal("name"));
                        projectTitle.Text = "<br />" + "Title: " + project_title

                           + "<br />";
                        Button ViewRegularEmployees = new Button();
                        ViewRegularEmployees.CssClass = "btn btn-default";
                        ViewRegularEmployees.ID = project_title;
                        form1.Controls.Add(projectTitle);
                        ViewRegularEmployees.Text = "See regeluar Employees avaliable";

                        ViewRegularEmployees.Click += new EventHandler(viewRegularEmployeesAvailable);
                        form1.Controls.Add(ViewRegularEmployees);

                    }


                }
                else
                {
                    Response.Redirect("Login.aspx", true);
                }  
            }catch{
                ErrorMessage.Text = "An unknow error has occurred";
            }
         


        }
        protected void viewRegularEmployeesAvailable(object sender, EventArgs e){
            try
            {
                Session["ProjectFor_RegualrEmployees_Avialable"] = ((Button)sender).ID;
                Response.Redirect("AssignEmployeesOnProject_Redicted.aspx", true);
            }catch
            {
                ErrorMessage.Text = "An unknow error has occurred";

            }
            
        }
            
    

    }
}
