<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="MovieNight.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="innerContent">
        <div id="accountInfo" class="card text-white bg-secondary mb-3" style="width: 25rem; height: 100%;">
            <div class="card-header">Manage Account</div>
            <div class="card-body">
                <h1 id="groupName" runat="server"></h1>
                <h3 id="ownerName" runat="server"></h3>
                <h3 id="pickerName" runat="server"></h3>


                <div class="card-header">Members</div>
                <div class="card-body">
                    <ul class="list-group">

                        <asp:PlaceHolder ID="phMembers" runat="server"></asp:PlaceHolder>

                    </ul>

                </div>
        </div>

    </div>

    <div id="movieShowcase" class="card text-white bg-secondary mb-3" style="max-width: 26rem;">
        <div class="card-header">Movies</div>
        <div class="card-body">
            <ul>
                <li>
                    <ul class="nav nav-tabs">
                        <asp:PlaceHolder ID="phNextMovieTab" runat="server"></asp:PlaceHolder>

                    </ul>

                </li>

                <li>
                    <div id="myTabContent2" class="tab-content" style="text-align: center;">
                        <asp:PlaceHolder ID="phNextMovies" runat="server"></asp:PlaceHolder>

                    </div>

                </li>

            </ul>




        </div>
        <asp:Button ID="finishedMovie" runat="server" Text="Finished Movie" OnClick="finishedMovie_Click" />

    </div>

    </div>
</asp:Content>
