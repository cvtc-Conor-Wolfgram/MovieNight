<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="MovieNight.CreateAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please Enter a Username"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblUserEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="txtUserEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Please Enter a Password"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="regexUserEmail" runat="server" ControlToValidate="txtUserEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter a Valid Email Address"></asp:RegularExpressionValidator>
        <br /><br />
        <asp:Label ID="lblUserPass" runat="server" Text="Password"></asp:Label>
        <asp:TextBox ID="txtUserPass" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvUserPass" runat="server" ControlToValidate="txtUserPass" ErrorMessage="Please Enter a Password"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblUserPassConfirm" runat="server" Text="Confirm Password"></asp:Label>
        <asp:TextBox ID="txtUserPassConfirm" runat="server"></asp:TextBox>
        <asp:CompareValidator ID="cvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Passwords must match" ValueToCompare="txtUserPass"></asp:CompareValidator>
        <asp:RequiredFieldValidator ID="rfvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Please Confirm Password"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
