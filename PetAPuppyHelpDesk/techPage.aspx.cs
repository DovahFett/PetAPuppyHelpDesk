using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace PetAPuppyHelpDesk
{
    public partial class WebForm4 : System.Web.UI.Page
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
                //Get list of tickets for the tech.
                //Create new connection.
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
                //Load open tickets that have been assigned to the tech.
                conn.Open();
                SqlCommand cmdGetAssignedTickets = new SqlCommand("GetAssignedTickets", conn);
                cmdGetAssignedTickets.Parameters.AddWithValue("@TechID", (int)Session["User ID"]);
                cmdGetAssignedTickets.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmdGetAssignedTickets.ExecuteReader();
                ddlSelectOpenTicket.DataSource = dr;
                ddlSelectOpenTicket.DataTextField = "TicketID";
                ddlSelectOpenTicket.DataValueField = "TicketID";
                ddlSelectOpenTicket.DataBind();
                conn.Close();


            }
        }

        //Returns information about the selected ticket.
        protected void btnReturnTicket_Click(object sender, EventArgs e)
        {
            //Store currently selected Ticket ID.
            int ticketID = Int16.Parse(ddlSelectOpenTicket.SelectedValue);
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
            string ticketHolderID = "";
            string ticketSolution = "";
            string ticketPriority = "";
            while (rdr.Read())
            {
                ticketStatus = rdr["TicketStatus"].ToString();
                ticketDescription = rdr["TicketDescription"].ToString();
                ticketType = rdr["TicketType"].ToString();
                ticketDate = rdr["TicketLastModified"].ToString();
                ticketHolderID = rdr["TicketHolderID"].ToString();
                ticketSolution = rdr["TicketSolution"].ToString();
                ticketPriority = rdr["TicketPriority"].ToString();
            }
            lblTicketStatus.Text = "Ticket Status: " + ticketStatus;
            lblReturnTicketType.Text = "Ticket Type: " + ticketType;
            txtReturnDescription.Text = ticketDescription;
            lblLastModified.Text = "Last Modified:" + ticketDate;
            lblTicketHolderID.Text = "Customer ID: " + ticketHolderID.ToString();
            txtSolution.Text = ticketSolution;
            lblPriority.Text = "Priority: " + ticketPriority;

        }

        protected void btnUpdateTicket_Click(object sender, EventArgs e)
        {
            int ticketID = Int16.Parse(ddlSelectOpenTicket.SelectedValue);
            string ticketSolution = txtSolution.Text;
            //get the connection property from web config
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
            //open the connection object
            conn.Open();
            SqlCommand cmdAddSolution = new SqlCommand("AddSolution", conn);
            cmdAddSolution.Parameters.AddWithValue("@TicketID", ticketID);
            cmdAddSolution.Parameters.AddWithValue("@Solution", ticketSolution);
            cmdAddSolution.CommandType = CommandType.StoredProcedure;
            cmdAddSolution.ExecuteNonQuery();
        }
    }
}