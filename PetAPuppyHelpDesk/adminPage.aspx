<%@ Page Title="" Language="C#" MasterPageFile="~/PetAPuppy.Master" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="PetAPuppyHelpDesk.WebForm3" %>
<asp:Content ID="Style" ContentPlaceHolderID="cphStyles" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Header" ContentPlaceHolderID="cphTitle" runat="server">
    <h1>Administrative Center</h1>
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

    <div><h2 class="headerTicketDetailsAdmin"> Ticket Details </h2> </div>
        <br />
        <br />
        <br />
        <br />
        
        <div>
            <asp:DropDownList ID="ddlTicketList" runat="server" CssClass="alterTicket"></asp:DropDownList>
            <asp:Label ID="lblTicketList" runat="server" Text="Ticket List:" class="lblSelectTicket" ></asp:Label>
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
            <asp:DropDownList ID="ddlChangePriority" runat="server" CssClass="alterTicket">
                <asp:ListItem Text="Low" Value="Low"></asp:ListItem>
                <asp:ListItem Text="Medium" Value="1"></asp:ListItem>
                <asp:ListItem Text="High" Value="1"></asp:ListItem>
            </asp:DropDownList>

            <asp:Label ID="lblChangePriority" runat="server" Text="Set Priority:" class="lblSelectTicket" ></asp:Label>
        </div>
        
        <br />
        <div>
            <asp:Label ID="lblLastModified" runat="server" Text="Last Modified:" class="lblLastModified"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblCurrentTech" runat="server" Text="Current Tech:" class="lblLastModified"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Label ID="lblTechName" runat="server" Text="Tech Name:" class="lblLastModified"></asp:Label>
        </div>
        <br />
        <div>
            <asp:DropDownList ID="ddlTechList" runat="server" CssClass="alterTicket"></asp:DropDownList>
            <asp:Label ID="lblTechList" runat="server" Text="Assign Tech:" class="lblSelectTicket" ></asp:Label>
        </div>
        <br />
        <br />
        <div>
                <asp:Button ID="btnReturnTicket" runat="server" Text="Load Ticket"  class="alterTicket" OnClick="btnReturnTicket_Click"/>
                <asp:Button ID="btnAssignTicket" runat="server" Text="Assign Ticket"  class="alterTicket" OnClick="btnAssignTicket_Click"/>
        </div>
        <br />
        <br />
        <div>
            <asp:TextBox ID="txtReturnDescription" runat="server" TextMode="MultiLine" class="issueReturnDescription" ></asp:TextBox>
            <asp:Label ID="lblReturnDescription" runat="server" Text="Description:" CssClass="lblReturnDescription"></asp:Label>
        </div>
</asp:Content>
