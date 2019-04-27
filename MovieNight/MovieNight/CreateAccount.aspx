<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="MovieNight.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="forms">
        <div class="form-login">
            <div class="card text-white bg-secondary mb-3" style="max-width: 20rem;">
              <div class="card-header">Sign In</div>
              <div class="card-body">
                  <ul>
                    <li><asp:Label ID="lblActiveEmail" runat="server" Text="Email:"></asp:Label></li>
                    <li><asp:TextBox ID="txtActiveEmail" runat="server"></asp:TextBox></li>
                    <li><asp:RequiredFieldValidator ID="rfvActiveEmail" runat="server" ControlToValidate="txtActiveEmail" ErrorMessage="Please Enter Your Email" ValidationGroup="login" ForeColor="#CC0000"></asp:RequiredFieldValidator></li>
                    <li><asp:RegularExpressionValidator ID="revActiveEmail" runat="server" ControlToValidate="txtActiveEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter a Valid Email Address" ValidationGroup="login" ForeColor="#CC0000"></asp:RegularExpressionValidator></li>
                    <li><asp:Label ID="lblActivePass" runat="server" Text="Password:"></asp:Label></li>
                    <li><asp:TextBox ID="txtActivePass" runat="server"></asp:TextBox></li>
                    <li><asp:RequiredFieldValidator ID="rfvActivePass" runat="server" ControlToValidate="txtActivePass" ErrorMessage="Please Enter Your Password" ValidationGroup="login" ForeColor="#CC0000"></asp:RequiredFieldValidator></li>
                    <li><asp:Button ID="btnLogin" runat="server" class="btn btn-primary" Text="Login" ValidationGroup="login" OnClick="btnLogin_Click" /> </li>
                 </ul>
              </div>

            </div>
        </div>
        <div class="form-create">
           <div class="card text-white bg-secondary mb-3" style="max-width: 20rem;">
              <div class="card-header">Sign Up</div>
              <div class="card-body">
            <ul>            
                <li><asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label></li>
                <li><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></li>
                <li><asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please Enter a Username" ValidationGroup="create" ForeColor="#CC0000"></asp:RequiredFieldValidator></li>
                <li><asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label></li>
                <li><asp:TextBox ID="txtFName" runat="server"></asp:TextBox></li>
                <li><asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label></li>
                <li><asp:TextBox ID="txtLName" runat="server"></asp:TextBox></li>
                <li><asp:Label ID="lblUserEmail" runat="server" Text="Email:"></asp:Label></li>
                <li><asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox></li>
                <li><asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Please Enter Your Email Address" ValidationGroup="create" ForeColor="#CC0000"></asp:RequiredFieldValidator></li>
                <li><asp:RegularExpressionValidator ID="regexUserEmail" runat="server" ControlToValidate="txtUserEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter a Valid Email Address" ForeColor="#CC0000" ValidationGroup="create"></asp:RegularExpressionValidator></li>
                <li><asp:Label ID="lblUserPass" runat="server" Text="Password:"></asp:Label></li>
                <li><asp:TextBox ID="txtUserPass" runat="server"></asp:TextBox></li>
                <li><asp:RequiredFieldValidator ID="rfvUserPass" runat="server" ControlToValidate="txtUserPass" ErrorMessage="Please Enter a Password" ValidationGroup="create" ForeColor="#CC0000"></asp:RequiredFieldValidator></li>
                <li><asp:Label ID="lblUserPassConfirm" runat="server" Text="Confirm Password:"></asp:Label></li>
                <li><asp:TextBox ID="txtUserPassConfirm" runat="server"></asp:TextBox></li>
                <li><asp:CompareValidator ID="cvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Passwords must match" ControlToCompare="txtUserPass" ValidationGroup="create" ForeColor="#CC0000"></asp:CompareValidator></li>
                <li><asp:RequiredFieldValidator ID="rfvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Please Confirm Password" ValidationGroup="create" ForeColor="#CC0000"></asp:RequiredFieldValidator></li>
                <li><asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="create" /></li>
            </ul>
              </div>

           </div>
        </div>
    </div>
</asp:Content>
