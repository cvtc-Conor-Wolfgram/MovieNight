<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="MovieNight.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="forms">
        <div class="form-login">
            <h3>Log In To Your Account Here</h3>
            <asp:Label ID="lblActiveEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtActiveEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvActiveEmail" runat="server" ControlToValidate="txtActiveEmail" ErrorMessage="Please Enter Your Email" ValidationGroup="login"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revActiveEmail" runat="server" ControlToValidate="txtActiveEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter a Valid Email Address" ValidationGroup="login"></asp:RegularExpressionValidator>
            <br /><br />
            <asp:Label ID="lblActivePass" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtActivePass" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvActivePass" runat="server" ControlToValidate="txtActivePass" ErrorMessage="Please Enter Your Password" ValidationGroup="login"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Button ID="btnLogin" runat="server" Text="Login" ValidationGroup="login" OnClick="btnLogin_Click" />
        </div>
        <div class="form-create">
            <h3>Create A New Account Here</h3>
            <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please Enter a Username" ValidationGroup="create"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label>
            <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
            <br /><br />
            <asp:Label ID="lblUserEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Please Enter Your Email Address" ValidationGroup="create"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexUserEmail" runat="server" ControlToValidate="txtUserEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter a Valid Email Address" ValidationGroup="create"></asp:RegularExpressionValidator>
            <br /><br />
            <asp:Label ID="lblUserPass" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtUserPass" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUserPass" runat="server" ControlToValidate="txtUserPass" ErrorMessage="Please Enter a Password" ValidationGroup="create"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Label ID="lblUserPassConfirm" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="txtUserPassConfirm" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="cvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Passwords must match" ControlToCompare="txtUserPass" ValidationGroup="create"></asp:CompareValidator>
            <asp:RequiredFieldValidator ID="rfvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Please Confirm Password" ValidationGroup="create"></asp:RequiredFieldValidator>
            <br /><br />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="create" />
        </div>
    </div>
</asp:Content>
