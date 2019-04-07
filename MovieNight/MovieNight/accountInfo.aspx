<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieNight.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div id="accountInfo">
            <div class="card text-white bg-secondary mb-3" style="max-width: 20rem;">
              <div class="card-header">Account Info</div>
              <div class="card-body">
                
                <ul id="acctInfo">
                    <li>Name:</li>
                    <li>Username</li>
                    <li>Email Address:</li>
          <%--ChangePassword password will only be an option for users who havent signed up using google acct %>--%>
                    <li><button type="button" class="btn btn-primary">Change Password</button></li>
                </ul>
              </div>
            </div>
        
    </div>

    <div id="accountImage">

    </div>
</asp:Content>
