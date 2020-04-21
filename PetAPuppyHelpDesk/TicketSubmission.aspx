<%@ Page Title="" Language="C#" MasterPageFile="~/PetAPuppy.Master" AutoEventWireup="true" CodeBehind="ticketSubmission.aspx.cs" Inherits="PetAPuppyHelpDesk.WebForm2" %>
<asp:Content ID="Style" ContentPlaceHolderID="cphStyles" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="cphTitle" runat="server">
    <h1>Ticket Management</h1>
</asp:Content>


<asp:Content ID="Body" ContentPlaceHolderID="cphBody" runat="server">
    
        <h2 class="newAccount">Account Details </h2>
        <asp:Label ID="lblName" runat="server" Text="Name: " class="newAccount"></asp:Label>
        <br />
        <asp:Label ID="lblPassword" runat="server" Text="Password: " class="newAccount"></asp:Label>
        <br />
        <asp:Label ID="lblCompanyName" runat="server" Text="Company Name: N/A" class="newAccount"></asp:Label>
        <br />
        <asp:Label ID="lblEmail" runat="server" Text="Email: " class="newAccount"></asp:Label>
        <br />
        <asp:Label ID="lblAddress" runat="server" Text="Address" class="newAccount"></asp:Label>
        <br />
        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number: " class="newAccount"></asp:Label>
    
        <div><h2 class="headerTicketDetails"> Ticket Details </h2> </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>
             <asp:DropDownList ID="ddlSelectOpenTicket" runat="server" CssClass="alterTicket"></asp:DropDownList>
            <asp:Label ID="lblSelectOpenTicket" runat="server" Text="My Tickets:" class="lblSelectTicket" ></asp:Label>
        </div>
        <br />
        <br />
        <div>
            <asp:DropDownList ID="ddlSelectClosedTicket" runat="server" CssClass="alterTicket"></asp:DropDownList>
            <asp:Label ID="lblSelectClosedTicket" runat="server" Text="Previous Tickets:" class="lblSelectTicket" ></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblTicketStatus" runat="server" Text="Ticket Status:" class ="lblTicketStatus"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblChangeTicketStatus" runat="server" Text="Change Status:" CssClass="lblChangeTicketStatus"></asp:Label>
        </div>
        
        <div>        
            <asp:DropDownList ID="ddlTicketStatus" runat="server" class="alterTicket">
                     <asp:ListItem Value="None"> No Change </asp:ListItem>
                    <asp:ListItem Value="Closed"> Resolved </asp:ListItem>
                </asp:DropDownList>
        </div> 

        <br/>
        <div>
            <asp:Label ID="lblReturnTicketType" runat="server" Text="Ticket Type:" class="lblReturnTicketType"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblLastModified" runat="server" Text="Last Modified:" class="lblLastModified"></asp:Label>
        </div>
        <br />
        <br />
        <div>
                <asp:Button ID="btnReturnTicket" runat="server" Text="Load Ticket"  class="alterTicket" OnClick="btnReturnTicket_Click"/>
                <asp:Button ID="btnUpdateTicket" runat="server" Text="Update Ticket"  class="alterTicket" OnClick="btnUpdateTicket_Click"/>
        </div>
        <br />
        <br />
        <div>
            <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" class="issueReturnSolution" ></asp:TextBox>
            <asp:Label ID="lblSolution" runat="server" Text="Solution:" CssClass="lblReturnDescription"></asp:Label>
            <asp:TextBox ID="txtReturnDescription" runat="server" TextMode="MultiLine" class="issueReturnDescription" ></asp:TextBox>
            <asp:Label ID="lblReturnDescription" runat="server" Text="Description:" CssClass="lblReturnDescription"></asp:Label>
        </div>
        
        
        


        <h2 class="newAccount">Submit Ticket</h2>
        <asp:Label ID="lblTicketType" runat="server" Text="Issue Type: " class="newAccount">
            <asp:DropDownList ID="ddlTicketType" runat="server"></asp:DropDownList>
        </asp:Label>
        <br />
        <br />
        <asp:Label ID="lblScreenshot" runat="server" Text="Attach Screenshot" class="newAccount">
        
            <asp:FileUpload ID="fuScreenshot" runat="server" />
        </asp:Label>
        <br />
        <br />
        <asp:Label ID="lblDescription" runat="server" Text="Describe Issue: " class="newAccount"></asp:Label>
        <br />
        <asp:TextBox ID="txtDescription" runat="server" class="issueDescription" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit Ticket" class="newAccount" OnClick="btnSubmit_Click"/>
        <br />
        <br />
        <asp:Label ID="lblConfirmation" runat="server" Text="" CssClass="newAccount"></asp:Label>
    
    
  
        
    
    
    


</asp:Content>
