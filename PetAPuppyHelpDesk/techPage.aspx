<%@ Page Title="" Language="C#" MasterPageFile="~/PetAPuppy.Master" AutoEventWireup="true" CodeBehind="techPage.aspx.cs" Inherits="PetAPuppyHelpDesk.WebForm4" %>
<asp:Content ID="Style" ContentPlaceHolderID="cphStyles" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Header" ContentPlaceHolderID="cphTitle" runat="server">
    <h1>Technical Support Center</h1>
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

    <div><h2 class="headerTicketDetailsTech"> Ticket Details </h2> </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <div>
             <asp:DropDownList ID="ddlSelectOpenTicket" runat="server" CssClass="alterTicket"></asp:DropDownList>
            <asp:Label ID="lblSelectOpenTicket" runat="server" Text="Assigned Tickets:" class="lblSelectTicket" ></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblTicketHolderID" runat="server" Text="Customer ID:" class ="lblTicketStatus"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblTicketStatus" runat="server" Text="Ticket Status:" class ="lblTicketStatus"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblReturnTicketType" runat="server" Text="Ticket Type:" class="lblReturnTicketType"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblPriority" runat="server" Text="Priority:" class="lblReturnTicketType"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblLastModified" runat="server" Text="Last Modified:" class="lblLastModified"></asp:Label>
        </div>
        <br />
        <br />
        <div>
                <asp:Button ID="btnReturnTicket" runat="server" Text="Load Ticket"  class="alterTicketButtons" OnClick="btnReturnTicket_Click"/>
                <asp:Button ID="btnDownloadImage" runat="server" Text="Download Image"  class="alterTicketButtons" OnClick="btnDownloadImage_Click"/>
                <asp:Button ID="btnUpdateTicket" runat="server" Text="Update Ticket"  class="alterTicketButtons" OnClick="btnUpdateTicket_Click"/>
        </div>
        <br />
        <br />
        
        <div>
            <asp:TextBox ID="txtSolution" runat="server" TextMode="MultiLine" class="issueReturnSolution" ></asp:TextBox>
            <asp:Label ID="lblSolution" runat="server" Text="Solution:" CssClass="lblReturnDescription"></asp:Label>
            <asp:TextBox ID="txtReturnDescription" runat="server" TextMode="MultiLine" class="issueReturnDescription" ></asp:TextBox>
            <asp:Label ID="lblReturnDescription" runat="server" Text="Description:" CssClass="lblReturnDescription"></asp:Label>
        </div>
       
        
</asp:Content>
