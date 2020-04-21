using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
//Jonathon Hayden
//Code of Index page.  Handles accounts creation and login checks.  Redirects to other pages.
namespace PetAPuppyHelpDesk
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if page is being loaded for first time.
            if (!Page.IsPostBack)
            {
                //get the connection property from web config
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
                //open the connection object
                conn.Open();

                //set the stored procedure command
                SqlCommand cmdGetCompanies = new SqlCommand("GetCompanies", conn);

                SqlDataReader dr = cmdGetCompanies.ExecuteReader();

                ddlCompanyName.DataSource = dr;
                ddlCompanyName.DataTextField = "CompanyName";
                ddlCompanyName.DataValueField = "CompanyName";
                ddlCompanyName.DataBind();

                conn.Close();
            }
            


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            pnlResults.Visible = true;

            if (txtFirstName.Text != "")//If user didn't leave field empty
            {
                String firstName = txtFirstName.Text;

                if (txtLastName.Text != "")//If user didn't leave field empty
                {
                    String lastName = txtLastName.Text;

                    if (txtPassword.Text != "" && txtPassword.Text.Any(char.IsLetterOrDigit) && txtPassword.Text.Contains("@") || txtPassword.Text.Contains("!") || txtPassword.Text.Contains("%") || txtPassword.Text.Contains("#") || txtPassword.Text.Contains("$") || txtPassword.Text.Contains("^") || txtPassword.Text.Contains("&") || txtPassword.Text.Contains("*") || txtPassword.Text.Contains("(") || txtPassword.Text.Contains(")") || txtPassword.Text.Contains("-") || txtPassword.Text.Contains("+") || txtPassword.Text.Contains("<") || txtPassword.Text.Contains(">") || txtPassword.Text.Contains("?") && txtPassword.Text.Length >= 8) //If password is not empty, is 8 chars long, has at least 1 number, and contains a symbol
                    {
                        String password = txtPassword.Text;

                        if(txtAddress.Text != "")
                        {
                            String address = txtAddress.Text;

                            if (txtEmail.Text != "" && txtEmail.Text.Length >= 5 && txtEmail.Text.Contains("@"))
                            {
                                String emailAddress = txtEmail.Text;

                                if (txtPhoneNumber.Text != "" && txtPhoneNumber.Text.Length == 14)//Check phone number
                                {
                                   
                                    String phoneNumber = txtPhoneNumber.Text;

                                    //Create new session objects
                                    Session["First Name"] = firstName;
                                    Session["Last Name"] = lastName;
                                    Session["Password"] = password;
                                    Session["Address"] = address;
                                    String companyName = ddlCompanyName.SelectedItem.ToString();
                                    Session["Email Address"] = emailAddress;
                                    Session["Phone Number"] = phoneNumber;

                                    //get the connection property from web config
                                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
                                    //open the connection object
                                    conn.Open();
                                    //set the stored procedure command
                                    SqlCommand cmdAddUser = new SqlCommand("AddUser", conn);
                                    //Setup parameters
                                    cmdAddUser.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = Session["First Name"] + " " + Session["Last Name"];
                                    cmdAddUser.Parameters.Add("@UserPassword", SqlDbType.NVarChar).Value = Session["Password"];
                                    cmdAddUser.Parameters.Add("@UserAddress", SqlDbType.NVarChar).Value = Session["Address"];
                                    cmdAddUser.Parameters.Add("@UserCompanyName", SqlDbType.NVarChar).Value = companyName;
                                    cmdAddUser.Parameters.Add("@UserEmailAddress", SqlDbType.NVarChar).Value = Session["Email Address"];
                                    cmdAddUser.Parameters.Add("@UserPhoneNumber", SqlDbType.NVarChar).Value = Session["Phone Number"];

                                    cmdAddUser.CommandType = CommandType.StoredProcedure;//Set the command type

                                    //save data to database
                                    cmdAddUser.ExecuteNonQuery();

                                    //Close connection
                                    conn.Close();

                                    //Confirmation message
                                    ThrowError("Acccount successfully created", lblError);


                                }
                                else
                                {
                                    ThrowError("Enter a phone number in the format (###) ###-####.", lblError);
                                    pnlResults.Visible = true;
                                }
                            }
                            else
                            {
                                ThrowError("Enter an email address that is atleast 5 characters long and contains an @.", lblError);
                                pnlResults.Visible = true;
                            }
                                    
                            

                            

                        }
                        else
                        {
                            ThrowError("Enter an address.", lblError);
                            pnlResults.Visible = true;
                        }
                       
                    }
                    else
                    {
                        ThrowError("Password must be 8 characters long and contain at least 1 number & a @, !, %, #, $, ^, &, *, (, ), -, +, <, >, or ?.", lblError);
                        pnlResults.Visible = true;
                    }
                    
                }
                else//If last name is empty
                {
                    ThrowError("Enter a last name.", lblError);
                    pnlResults.Visible = true;
                }
            }
            else//If first name is empty
            {
                ThrowError("Enter a first name.", lblError);
                pnlResults.Visible = true;
            }
        }

        private static void ThrowError(String message, Label lblError)
        {
            lblError.Text = message;

        }
        protected void btnReset_Click(object sender, EventArgs e)//If button is pushed reset all entries
        { 
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            lblError.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            pnlResults.Visible = false;
        }

        protected void btnCheckForUser_Click(object sender, EventArgs e)
        {
            if(txtFNameCheck.Text != "")
            {
                string firstName = txtFNameCheck.Text;
                if(txtLNameCheck.Text != "")
                {
                    string lastName = txtLNameCheck.Text;
                    if (txtPasswordCheck.Text != "")
                    {
                        
                        string password = txtPasswordCheck.Text;

                        
                        //Create new session objects
                        Session["First Name"] = firstName;
                        Session["Last Name"] = lastName;
                        Session["Password"] = password;

                        //get the connection property from web config
                        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["PetAPuppyHelpDesk"].ConnectionString);
                        //open the connection object
                        conn.Open();
                        //set the stored procedure command
                        SqlCommand cmdCheckUser = new SqlCommand("CheckUser", conn);
                        //Setup parameters
                        cmdCheckUser.Parameters.Add("@UserName", SqlDbType.VarChar).Value = Session["First Name"] + " " + Session["Last Name"];
                        cmdCheckUser.Parameters.Add("@UserPassword", SqlDbType.VarChar).Value = Session["Password"];


                        cmdCheckUser.CommandType = CommandType.StoredProcedure;//Set the command type

                        //save data to database
                        cmdCheckUser.ExecuteNonQuery();
                        
                        //create a data reader to read the data
                        SqlDataReader rdr = null;
                        rdr = cmdCheckUser.ExecuteReader();

                        //variables for reader
                        string fullName = "";
                        password = "";
                        string address = "";
                        string companyName = "";
                        string emailAddress = "";
                        string phoneNumber = "";
                        int userID = 0;
                        string accountType = "";

                        //loop through the results
                        while (rdr.Read())
                        {
                            
                            fullName = rdr["UserName"].ToString();
                            password = rdr["UserPassword"].ToString();
                            address = rdr["UserAddress"].ToString();
                            companyName = rdr["UserCompanyName"].ToString();
                            emailAddress = rdr["UserEmailAddress"].ToString();
                            phoneNumber = rdr["UserPhoneNumber"].ToString();
                            userID = (int)rdr["UserID"];
                            accountType = rdr["UserType"].ToString();
                            

                        }
                        if(fullName == txtFNameCheck.Text + " " + txtLNameCheck.Text)//Check if entered data matches database.
                        {
                            if (password == txtPasswordCheck.Text)
                            {
                                //Second user to different page depending on if they are a customer, tech support worker, or administrator.
                                if(accountType == "Customer")
                                {
                                    //Create new sessions
                                    Session["Name"] = fullName;
                                    Session["Password"] = password;
                                    Session["Address"] = address;
                                    Session["Company Name"] = companyName;
                                    Session["Email Address"] = emailAddress;
                                    Session["Phone Number"] = phoneNumber;
                                    Session["User ID"] = userID;

                                    Response.Redirect(ResolveUrl("~//ticketSubmission.aspx"));//Redirect to ticket center
                                }
                                else if(accountType == "Technical Support")
                                {
                                    //Create new sessions
                                    Session["Name"] = fullName;
                                    Session["Password"] = password;
                                    Session["Address"] = address;
                                    Session["Company Name"] = companyName;
                                    Session["Email Address"] = emailAddress;
                                    Session["Phone Number"] = phoneNumber;
                                    Session["User ID"] = userID;

                                    Response.Redirect(ResolveUrl("~//techPage.aspx"));//Redirect to ticket center
                                }
                                else if(accountType == "Administrator")
                                {
                                    //Create new sessions
                                    Session["Name"] = fullName;
                                    Session["Password"] = password;
                                    Session["Address"] = address;
                                    Session["Company Name"] = companyName;
                                    Session["Email Address"] = emailAddress;
                                    Session["Phone Number"] = phoneNumber;
                                    Session["User ID"] = userID;

                                    Response.Redirect(ResolveUrl("~//adminPage.aspx"));//Redirect to ticket center
                                }
                            }
                            else
                            {
                                lblError.Text = "Incorrect password";
                                pnlResults.Visible = true;
                            }
                        }
                        else
                        {
                            lblError.Text = "Incorrect name";
                            pnlResults.Visible = true;
                        }
                            
                        
                        //Close connection
                        conn.Close();

                        
                    }
                    else
                    {
                        ThrowError("Enter a password.", lblError);
                        pnlResults.Visible = true;
                    }
                }
                else
                {
                    ThrowError("Enter a last name.", lblError);
                    pnlResults.Visible = true;
                }
            }
            else
            {
                ThrowError("Enter a first name.", lblError);
                pnlResults.Visible = true;
            }
        }
    }
}