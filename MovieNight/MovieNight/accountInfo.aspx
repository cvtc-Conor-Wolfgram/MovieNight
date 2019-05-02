<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="accountInfo.aspx.cs" Inherits="MovieNight.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="accountInfo">
            <div class="card text-white bg-secondary mb-3" style="max-width: 25rem;">
              
              <div class="card-body">
                  <div class="card-header">Account Info</div>
                <asp:SqlDataSource ID="UserConnection" runat="server" ConnectionString="<%$ ConnectionStrings:AccountInfoConnection %>" SelectCommand="SELECT UserName, password, email, fName, lName FROM [User] WHERE email = @userAccount">
                       <SelectParameters>
                            <asp:SessionParameter Name="userAccount" SessionField ="userAccount" DefaultValue =""  />
                       </SelectParameters>
                </asp:SqlDataSource>
                
                  <ul class="acctInfo">
                      <li>Name: <asp:Label ID="nameLbl" runat="server" Text="Label"></asp:Label></li>
                      <li>Username: <asp:Label ID="userNameLbl" runat="server" Text="Label"></asp:Label></li>
                      <li>Email Address: <asp:Label ID="emailLbl" runat="server" Text="Label"></asp:Label></li>
                      <li><button type="button" class="btn btn-primary">Change Password</button></li>

                  </ul>
                  <div class="card-header">Create Group</div>
                  <ul class="acctInfo">
                      <li><asp:Label ID="lblGroupName" runat="server" Text="Group Name:"></asp:Label><asp:TextBox ID="txtGroupName" runat="server" MaxLength="25" class="form-control"></asp:TextBox></li>
                      <li><asp:Button ID="btnCreate" runat="server" Text="Create Group" OnClick="btnCreate_Click" class="btn btn-primary" /></li>

                  </ul>
                  <div class="card-header">Join Group</div>
                  <ul class="acctInfo">
                      <li><asp:Label ID="lblGroupCode" runat="server" Text="Enter Group Code:"></asp:Label><asp:TextBox ID="txtGroupCode" runat="server" class="form-control"></asp:TextBox></li>
                      <li><asp:Button ID="btnJoinGroup" runat="server" Text="Join" OnClick="btnJoinGroup_Click" class="btn btn-primary" /></li>
                      <li><asp:Label ID="lblJoinResponse" runat="server" Text=""></asp:Label></li>

                  </ul>
              </div>
            </div>
        
    </div>

    <div>

        <asp:PlaceHolder ID="phUserMovies" runat="server"></asp:PlaceHolder>

    </div>


        <div class="form-group">

            
            
            <br /><br />
            
            
            
            
            
            <div id="accountImage">

            </div>

        </div> 



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

