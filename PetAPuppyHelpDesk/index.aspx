<%@ Page Title="" Language="C#" MasterPageFile="~/PetAPuppy.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="PetAPuppyHelpDesk.WebForm1" %>
<asp:Content ID="Style" ContentPlaceHolderID="cphStyles" runat="server">
    <link href="css/styles.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Header" ContentPlaceHolderID="cphTitle" runat="server">
    <h1>Welcome to the Help Desk</h1>
</asp:Content>


<asp:Content ID="Body" ContentPlaceHolderID="cphBody" runat="server">
    

    <h2 class="newAccount">New User? Create an Account</h2>

    <asp:Panel ID="pnlUserInfo" runat="server" Visible="True" CssClass="login">
       <h2 class="login">Existing User? Login</h2>
        
        <asp:Label for=txtFNameCheck ID="lblFNameCheck" runat="server" Text="First Name: " CssClass="loginLabel"></asp:Label> 
        <asp:TextBox ID="txtFNameCheck" runat="server" class="login"></asp:TextBox> 

        <asp:Label for="txtLNameCheck" ID="lblLNameCheck" runat="server" Text="Last Name: " CssClass="loginLabel"></asp:Label> 
        <asp:TextBox ID="txtLNameCheck" runat="server" class="login"></asp:TextBox>
        
        <asp:Label for="txtPasswordCheck" ID="lblPasswordCheck" runat="server" Text="Password: " CssClass="loginLabel"></asp:Label>
        <asp:TextBox ID="txtPasswordCheck" runat="server" class="login" TextMode="Password"></asp:TextBox> 

        <asp:Button ID="btnCheckForUser" runat="server" Text="Login" class="loginButton" OnClick="btnCheckForUser_Click"/>
                
    </asp:Panel>
    
    <asp:Label  ID="lblFirstName" runat="server" Text="First Name:" class="newAccount">
        <asp:TextBox ID="txtFirstName" runat="server" class="newAccount"></asp:TextBox> 
    </asp:Label> 
    <br />
    <br />
    <asp:Label ID="lblLastName" runat="server" Text="Last Name:" class="newAccount">
        <asp:TextBox ID="txtLastName" runat="server" class="newAccount"></asp:TextBox>
    </asp:Label>
    <br />
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Password:" class="newAccount">
        <asp:TextBox ID="txtPassword" runat="server" class="newAccount"></asp:TextBox>
    </asp:Label>
     <br />
     <br />
    <asp:Label ID="lblEmail" runat="server" Text="Email Address:" class="newAccount">
        <asp:TextBox ID="txtEmail" runat="server" class="newAccount"></asp:TextBox>
    </asp:Label>
    <br />
    <br />
    <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:" class="newAccount">
        <asp:TextBox ID="txtPhoneNumber" runat="server" class="newAccount"></asp:TextBox>
    </asp:Label>
    <br />
    <br />
     <asp:Label ID="lblCompanyName" runat="server" Text="Select Company:" class="newAccount">
         <asp:DropDownList ID="ddlCompanyName" runat="server" class="newAccount">  
         </asp:DropDownList>
     </asp:Label>
     <br />
     <br />
    <asp:Label ID="lblAddress" runat="server" Text="Address:" class="newAccount">
        <asp:TextBox ID="txtAddress" runat="server" class="newAccount"></asp:TextBox>
    </asp:Label>
    <br />
    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" class="newAccount"/>
    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" class="newAccount"/>
    <br />
    <br />
    <asp:Panel ID="pnlResults" runat="server" Visible="False" CssClass="lblError">
                <asp:Label ID="lblError" runat="server" Text="lblError" CssClass="lblError"></asp:Label>
    </asp:Panel>
</asp:Content>


