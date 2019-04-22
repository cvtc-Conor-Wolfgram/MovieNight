<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="accountInfo.aspx.cs" Inherits="MovieNight.WebForm3" %>
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

    <asp:Label ID="lblGroupCode" runat="server" Text="Join A Group:"></asp:Label>
    <asp:TextBox ID="txtGroupCode" runat="server"></asp:TextBox>
    <asp:Button ID="btnJoinGroup" runat="server" Text="Join" OnClick="btnJoinGroup_Click" />
    <asp:Label ID="lblJoinResponse" runat="server" Text=""></asp:Label>
    <div id="accountImage">

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
