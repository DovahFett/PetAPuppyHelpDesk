using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net.Mail;

//Jonathon Hayden
//Ticket page.  Shows user data and allows submission of tickets.
namespace PetAPuppyHelpDesk
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if page is being loaded for first time.
            if (!Page.IsPostBack)
            {
                ///Retrieve sessions containing user info from last page.
                lblName.Text = "Name: " + Session["First Name"] + " " + Session["Last Name"];
                lblPassword.Text = "Password: " + Session["Password"];
                lblCompanyName.Text = "Company Name: " + Session["Company Name"];
                lblEmail.Text = "Email: " + Session["Email Address"];
                lblAddress.Text = "Address: " + Session["Address"];
                lblPhoneNumber.Text = "Phone Number: " + Session["Phone Number"];

                //Get list of issue types
                //get the connection property from web config
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
                //open the connection object
                conn.Open();
                //set the stored procedure command
                SqlCommand cmdGetIssueTypes = new SqlCommand("GetIssueTypes", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmdGetIssueTypes);    //new data adapter
                DataSet ds = new DataSet(); //new data set
                da.Fill(ds);    //fill data set
                ddlTicketType.DataTextField = ds.Tables[0].Columns["IssueType"].ToString();  //Set ddl text field
                ddlTicketType.DataValueField = ds.Tables[0].Columns["IssueType"].ToString(); //Set ddl value field
                ddlTicketType.DataSource = ds.Tables[0]; //Set data source
                ddlTicketType.DataBind(); //bind data to ddl
                conn.Close();

                //Load open tickets belonging to the user
                conn.Open();
                SqlCommand cmdGetUsersOpenTickets = new SqlCommand("GetOpenTicketIDs", conn);
                cmdGetUsersOpenTickets.Parameters.AddWithValue("@UserID", (int)Session["User ID"]);
                cmdGetUsersOpenTickets.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmdGetUsersOpenTickets.ExecuteReader();

                ddlSelectOpenTicket.DataSource = dr;
                ddlSelectOpenTicket.DataTextField = "TicketID";
                ddlSelectOpenTicket.DataValueField = "TicketID";
                ddlSelectOpenTicket.DataBind();

                conn.Close();

               
                //Load closed tickets belonging to the user
                conn.Open();
                SqlCommand cmdGetUsersClosedTickets = new SqlCommand("GetClosedTicketIDs", conn);
                cmdGetUsersClosedTickets.Parameters.AddWithValue("@UserID", (int)Session["User ID"]);
                cmdGetUsersClosedTickets.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr2 = cmdGetUsersClosedTickets.ExecuteReader();

                ddlSelectClosedTicket.DataSource = dr2;
                ddlSelectClosedTicket.DataTextField = "TicketID";
                ddlSelectClosedTicket.DataValueField = "TicketID";
                ddlSelectClosedTicket.DataBind();

                conn.Close();


            } 
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            

            //Create sessions for ticket type and description.
            Session["Ticket Type"] = ddlTicketType.SelectedValue.ToString();
            Session["Ticket Description"] = txtDescription.Text;

            //get the connection property from web config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
            //open the connection object
            conn.Open();



            //Convert posted file to bytes
            Stream fs = fuScreenshot.PostedFile.InputStream;
            string filename = Path.GetFileName(fuScreenshot.PostedFile.FileName);
            string contentType = fuScreenshot.PostedFile.ContentType;
            BinaryReader br = new BinaryReader(fs);
            byte[] bytes = br.ReadBytes((Int32)fs.Length);

            SqlDataReader rdr = null;
            //set the stored procedure command
            SqlCommand cmdAddTicket = new SqlCommand("AddTicket", conn);
            //Setup parameters
            cmdAddTicket.Parameters.Add("@TicketType", SqlDbType.VarChar).Value = Session["Ticket Type"];
            cmdAddTicket.Parameters.Add("@TicketDescription", SqlDbType.VarChar).Value = Session["Ticket Description"];
            cmdAddTicket.Parameters.Add("@TicketHolderID", SqlDbType.VarChar).Value = Session["User ID"];
            cmdAddTicket.Parameters.Add("@TicketScreenshot", SqlDbType.VarBinary).Value = bytes;
            cmdAddTicket.CommandType = CommandType.StoredProcedure;//Set the command type

            //Execute command and listen for response
            rdr = cmdAddTicket.ExecuteReader();


            //save data to database
            //cmdAddTicket.ExecuteNonQuery();




            int ticketID = 0;
            //Read response from command
            while (rdr.Read())
            {
                ticketID = (int)rdr["TicketID"];
            }


            //session for ticket id
            Session["Ticket ID"] = ticketID;
            //Confirmation text
            lblConfirmation.Text = "Ticket submitted, your ID is " + Session["Ticket ID"];


            //Close connection
            conn.Close();
            

            //open connection
            conn.Open();

            SqlCommand cmdGetScreenshot = new SqlCommand("GetScreenshot", conn);

            cmdGetScreenshot.Parameters.Add("@TicketID", SqlDbType.Int).Value = ticketID;
            cmdGetScreenshot.CommandType = CommandType.StoredProcedure;

            rdr = cmdGetScreenshot.ExecuteReader();

            while (rdr.Read())
            {
                bytes = (byte[])rdr["TicketScreenshot"];
            }

            //Close connection
            conn.Close();

           
            
               
            

            //Email user so that they know their ticket has been received.
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("petapuppysystem@gmail.com");
            mail.To.Add(Session["Email Address"].ToString());
            mail.Subject = "PetAPuppy Bug Report Received";
            mail.Body = "Your ticket has been received.  Your ticket ID is " + Session["Ticket ID"];

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("petapuppysystem@gmail.com", "B2v3fmX4VZuk");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            //Load tickets belonging to the specified user.
            conn.Open();
            SqlCommand cmdGetUsersOpenTickets = new SqlCommand("GetOpenTicketIDs", conn);
            cmdGetUsersOpenTickets.Parameters.AddWithValue("@UserID", (int)Session["User ID"]);
            cmdGetUsersOpenTickets.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmdGetUsersOpenTickets.ExecuteReader();

            ddlSelectOpenTicket.DataSource = dr;
            ddlSelectOpenTicket.DataTextField = "TicketID";
            ddlSelectOpenTicket.DataValueField = "TicketID";
            ddlSelectOpenTicket.DataBind();

            conn.Close();

            //Clear description box after submitting ticket.
            txtDescription.Text = "";
            
            //If file is an image, download it.
            if (fuScreenshot.PostedFile.ContentType.Equals("image/jpeg") || fuScreenshot.PostedFile.ContentType.Equals("image/png") || fuScreenshot.PostedFile.ContentType.Equals("image/gif"))
            {
                //Download image to user.
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = contentType;
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
                Response.BinaryWrite(bytes);
                Response.Flush();
                Response.End(); //Stops execution of the page.

            }
           
        }

        protected void btnReturnTicket_Click(object sender, EventArgs e)
        {
            //Store currently selected Ticket ID.
            string ticketID = ddlSelectOpenTicket.SelectedValue;

            //get the connection property from web config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);

            //open the connection object
            conn.Open();
            SqlCommand cmdGetTicketInfo = new SqlCommand("GetTicketInfo", conn);
            cmdGetTicketInfo.Parameters.AddWithValue("@TicketID", ticketID);
            cmdGetTicketInfo.CommandType = CommandType.StoredProcedure;

            SqlDataReader rdr = null;
            rdr = cmdGetTicketInfo.ExecuteReader();

            string ticketStatus = "";
            string ticketDescription = "";
            string ticketType = "";
            string ticketDate = "";
            string ticketSolution = "";

            
            while(rdr.Read())
            {
                ticketStatus = rdr["TicketStatus"].ToString();
                ticketDescription = rdr["TicketDescription"].ToString();
                ticketType = rdr["TicketType"].ToString();
                ticketDate = rdr["TicketLastModified"].ToString();
                ticketSolution = rdr["TicketSolution"].ToString();
            }

            lblTicketStatus.Text = "Ticket Status: " + ticketStatus;
            lblReturnTicketType.Text = "Ticket Type: " + ticketType;
            txtReturnDescription.Text = ticketDescription;
            lblLastModified.Text = "Last Modified: " + ticketDate;
            txtSolution.Text = ticketSolution;



            conn.Close();
        }

        protected void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            string ticketID = ddlSelectOpenTicket.SelectedValue;
            string ticketStatus = ddlTicketStatus.SelectedValue;
            string ticketDescription = txtReturnDescription.Text;

            //get the connection property from web config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);

            //open the connection object
            conn.Open();
            SqlCommand cmdUpdateTicketInfo = new SqlCommand("UpdateTicketInfo", conn);
            cmdUpdateTicketInfo.Parameters.AddWithValue("@TicketID", ticketID);
            cmdUpdateTicketInfo.Parameters.AddWithValue("@TicketStatus", ticketStatus);
            cmdUpdateTicketInfo.Parameters.AddWithValue("@TicketDescription", ticketDescription);
            cmdUpdateTicketInfo.CommandType = CommandType.StoredProcedure;
            cmdUpdateTicketInfo.ExecuteNonQuery();
            conn.Close();



        }
    }
}