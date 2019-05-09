<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="MovieNight.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="innerContent">
        <div id="accountInfo" class="card text-white bg-secondary mb-3" style="width: 25rem; height: 100%;">
            <div id="groupName" runat="server" class="card-header"></div>
            <span class="badge badge-warning" id="ownerName" runat="server" style="position: absolute; right: 10px; top: 15px;"></span>

            <div class="card-body">


                <div class="card-header">
                    Members
                    <div style="position: absolute; right: 30px; top: 78px;">
                        <asp:Button ID="createEvent" runat="server" Text="Create Event" OnClick="createEvent_Click" CssClass="btn btn-primary btn-sm" />

                    </div>

                </div>

                <ul data-simplebar class="list-group" style="height: 500px;">

                    <asp:PlaceHolder ID="phMembers" runat="server"></asp:PlaceHolder>

                </ul>


            </div>

        </div>

        <div id="movieShowcase" class="card text-white bg-secondary mb-3" style="max-width: 26rem;">
            <div class="card-header">
                Movies
                <div style="position: absolute; right: 10px; top: 10px">
                    <asp:Button ID="finishedMovie" runat="server" Text="Finished Movie" OnClick="finishedMovie_Click" CssClass="btn btn-primary btn-sm" />
                </div>
            </div>
            <div class="card-body" style="height: 588px; width: 398px;">

                        <ul>
                            <li>

                                <asp:DropDownList ID="movieDropdown" runat="server" CssClass="movieDropdown" OnSelectedIndexChanged="movieDropdown_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>



                            </li>

                            <li>

                                <asp:PlaceHolder ID="phNextMovies" runat="server"></asp:PlaceHolder>



                            </li>

                        </ul>

                    </div>
   


        </div>

    </div>
</asp:Content>
