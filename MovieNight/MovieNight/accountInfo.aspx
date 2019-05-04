<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="accountInfo.aspx.cs" Inherits="MovieNight.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="innerContent">
        <div id="accountInfo" class="card text-white bg-secondary mb-3" style="width: 25rem; height: 100%;">
            <div class="card-header">Manage Account</div>
            <div class="card-body">
                <ul class="nav nav-tabs">
                    <li class="nav-item">
                        <a class="nav-link active" data-toggle="tab" href="#profile">Profile</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#groupCreate">Create Group</a>
                    </li>

                    <li class="nav-item">
                        <a class="nav-link" data-toggle="tab" href="#groupJoin">Join Group</a>
                    </li>


                </ul>
                <div id="myTabContent" class="tab-content">
                    <div class="tab-pane fade active show" id="profile">
                        <ul class="acctInfo" style="padding-bottom: 0px;">
                            <li><strong>Name:</strong>
                    <asp:Label ID="nameLbl" runat="server" Text="Label"></asp:Label></li>
                            <li><strong>Username:</strong>
                  <asp:Label ID="userNameLbl" runat="server" Text="Label"></asp:Label></li>
                            <li><strong>Email Address:</strong>
                                <asp:Label ID="emailLbl" runat="server" Text="Label"></asp:Label></li>
                            <li>
                                <button type="button" class="btn btn-primary">Change Password</button></li>

                        </ul>
                    </div>
                    <div class="tab-pane fade " id="groupCreate" >
                        <ul class="acctInfo" style="height: 190px;">
                            <li>
                                <asp:Label ID="lblGroupName" runat="server" Text="Group Name:" CssClass="h5"></asp:Label><asp:TextBox ID="txtGroupName" runat="server" MaxLength="25" class="form-control"></asp:TextBox></li>
                            <li>
                                <asp:Button ID="btnCreate" runat="server" Text="Create" OnClick="btnCreate_Click" class="btn btn-primary" /></li>

                        </ul>
                    </div>

                    <div class="tab-pane fade " id="groupJoin">
                        <ul class="acctInfo" style="height: 190px;">
                            <li>
                                <asp:Label ID="lblGroupCode" runat="server" Text="Enter Group Code:" CssClass="h5"></asp:Label><asp:TextBox ID="txtGroupCode" runat="server" class="form-control"></asp:TextBox></li>
                            <li>
                                <asp:Button ID="btnJoinGroup" runat="server" Text="Join" OnClick="btnJoinGroup_Click" class="btn btn-primary" /></li>
                            <li>
                                <asp:Label ID="lblJoinResponse" runat="server" Text=""></asp:Label></li>

                        </ul>

                    </div>

                </div>
                <div class="card-header">Your Groups</div>
                <ul class="list-group" style="height: 45%; overflow-y: scroll;">
                    <asp:PlaceHolder ID="phGroupList" runat="server"></asp:PlaceHolder>
                </ul>
            </div>


        </div>



    <div id="movieShowcase" class="card text-white bg-secondary mb-3" style="max-width: 26rem;">
        <div class="card-header">Movies</div>
        <div class="card-body">
            <ul>
                <li>
                    <ul class="nav nav-tabs">
                        <asp:PlaceHolder ID="phUserMovieTab" runat="server"></asp:PlaceHolder>

                    </ul>

                </li>

                <li>
                    <div id="myTabContent2" class="tab-content" style="text-align: center;">
                        <asp:PlaceHolder ID="phUserMovies" runat="server"></asp:PlaceHolder>

                    </div>

                </li>

            </ul>




        </div>

    </div>

    </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

