using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
//Jonathon Hayden, 4/21/20
//Lets admins view their account details, as well as assign tickets to to tech support.
namespace PetAPuppyHelpDesk
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ///Retrieve sessions containing user info from last page.
                lblName.Text = "Name: " + Session["First Name"] + " " + Session["Last Name"];
                lblPassword.Text = "Password: " + Session["Password"];
                lblCompanyName.Text = "Company Name: " + Session["Company Name"];
                lblEmail.Text = "Email: " + Session["Email Address"];
                lblAddress.Text = "Address: " + Session["Address"];
                lblPhoneNumber.Text = "Phone Number: " + Session["Phone Number"];

                //Get the connection property from web config
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);

                //Load all ticket IDs regardless of user ID.
                conn.Open();
                SqlCommand cmdGetAllOpenTicketIDs = new SqlCommand("GetAllOpenTicketIDs", conn);
                cmdGetAllOpenTicketIDs.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmdGetAllOpenTicketIDs.ExecuteReader();
                ddlTicketList.DataSource = dr;
                ddlTicketList.DataTextField = "TicketID";
                ddlTicketList.DataValueField = "TicketID";
                ddlTicketList.DataBind();
                conn.Close();

                //Load a list of all tech support accounts.
                conn.Open();
                SqlCommand cmdGetTechList = new SqlCommand("GetTechList", conn);
                cmdGetTechList.CommandType = CommandType.StoredProcedure;
                dr = cmdGetTechList.ExecuteReader();
                ddlTechList.DataSource = dr;
                ddlTechList.DataTextField = "UserID";
                ddlTechList.DataValueField = "UserID";
                ddlTechList.DataBind();
                conn.Close();


            }

        }

        protected void btnAssignTicket_Click(object sender, EventArgs e)
        {
            //Get the ticket to be assigned and the tech to be assigned to it.
            int selectedTech = Int16.Parse(ddlTechList.SelectedValue);
            int selectedTicket = Int16.Parse(ddlTicketList.SelectedValue);
            string ticketPriority = ddlChangePriority.SelectedValue;

            //Get the connection property from web config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
            //Assign tech to ticket.
            conn.Open();
            SqlCommand cmdAssignTicket = new SqlCommand("AssignTicket", conn);
            cmdAssignTicket.Parameters.AddWithValue("@UserID", (int)selectedTech);
            cmdAssignTicket.Parameters.AddWithValue("@TicketID", (int)selectedTicket);
            cmdAssignTicket.Parameters.AddWithValue("@TicketPriority", ticketPriority);
            cmdAssignTicket.CommandType = CommandType.StoredProcedure;
            cmdAssignTicket.ExecuteNonQuery();
            conn.Close();

            //Update fields
            UpdateInfo();



        }

        protected void btnReturnTicket_Click(object sender, EventArgs e)
        {
            //Update fields
            UpdateInfo();
        }
        //Return latest informatiom about the ticket.
        void UpdateInfo()
        {
            //Store currently selected Ticket ID.
            string ticketID = ddlTicketList.SelectedValue;
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
            string assignedTech = "";
            string ticketPriority = "";

            while (rdr.Read())
            {
                ticketStatus = rdr["TicketStatus"].ToString();
                ticketDescription = rdr["TicketDescription"].ToString();
                ticketType = rdr["TicketType"].ToString();
                ticketDate = rdr["TicketLastModified"].ToString();
                assignedTech = rdr["TicketAssignedTechID"].ToString();
                ticketPriority = rdr["TicketPriority"].ToString();
            }
            //Return information about the tech assigned to the ticket.
            SqlCommand cmdGetTechInfo = new SqlCommand("GetTechInfo", conn);
            cmdGetTechInfo.Parameters.AddWithValue("@TechID", assignedTech);
            cmdGetTechInfo.CommandType = CommandType.StoredProcedure;
            rdr.Close();
            rdr = null;
            rdr = cmdGetTechInfo.ExecuteReader();
            string techName = "";
            while (rdr.Read())
            {
                techName = rdr["UserName"].ToString();
            }

            lblTicketStatus.Text = "Ticket Status: " + ticketStatus;
            lblReturnTicketType.Text = "Ticket Type: " + ticketType;
            txtReturnDescription.Text = ticketDescription;
            lblLastModified.Text = "Last Modified: " + ticketDate;
            lblCurrentTech.Text = "Current Tech: " + assignedTech;
            lblTechName.Text = "Tech Name: " + techName;
            lblPriority.Text = "Priority: " + ticketPriority;

            conn.Close();
        }


    }
    
}