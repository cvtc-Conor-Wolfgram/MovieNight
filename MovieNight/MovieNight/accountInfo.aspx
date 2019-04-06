<%@ Page Title="" Language="C#" MasterPageFile="~/accountInfo.Master" AutoEventWireup="true" CodeBehind="accountInfo.aspx.cs" Inherits="MovieNight.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="accountInfo">
        <ul>
            <li>Name:</li>
            <li>Username</li>
            <li>Email Address:</li>
  <%--ChangePassword password will only be an option for users who havent signed up using google acct %>--%>
            <li><button type="button" class="btn btn-primary">Change Password</button></li>
        </ul>
    </div>

    <div id="accountImage">

    </div>
</asp:Content>
