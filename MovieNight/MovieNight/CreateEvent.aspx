<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="MovieNight.CreateEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <h3 id="welcomeText" runat="server"></h3>
        <div class="innerContent">
        <div id="createEvent">
            <div class="card text-white bg-secondary mb-3" style="width: 25rem;">
                <div class="card-header">Creat Event</div>
                <div class="card-body" style="height: 588px; width: 398px;">
                    <ul>
                        <li>
                            <asp:Label ID="lblEventName" runat="server" Text="Event Name"></asp:Label>
                            <asp:TextBox ID="txtEName" runat="server" MaxLength="25" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvTxtEName" ControlToValidate="txtEName" runat="server" ErrorMessage="Event Name is required" Display="Dynamic"></asp:RequiredFieldValidator>

                        </li>

                        <li style="padding-top: 12px;">
                            <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                            <asp:TextBox ID="txtLocation" runat="server" MaxLength="25" CssClass="form-control"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="txtLocation" ErrorMessage="Location is required." Display="Dynamic"></asp:RequiredFieldValidator>

                        </li>

                        <li>
                            <table class="table">
                                <tbody>
                                    <tr class="table-secondary">
                                        <td>
                                            <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTime" runat="server" Text="Time"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="padding-top: 0px;">

                                            <asp:TextBox ID="txtDate" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>



                                        </td>

                                        <td style="padding-top: 0px;">

                                            <asp:TextBox ID="txtTime" TextMode="Time" runat="server" CssClass="form-control"></asp:TextBox>



                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate" ErrorMessage="A date is required" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfvTime" runat="server" ControlToValidate="txtTime" ErrorMessage="A time is required" Display="Dynamic"></asp:RequiredFieldValidator>

                            <asp:Label ID="lblDateTimeError" Visible="false" runat="server" Text="" ForeColor="#CC3300"></asp:Label>


                        </li>

                        <li>

                            <ul>
                                <li>
                                    <asp:Label ID="lblTickets" runat="server" Text="Tickets Bought"></asp:Label></li>
                                <li>
                                    <asp:TextBox ID="txtTickets" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox></li>
                                <li>
                                    <asp:CheckBox ID="cbTheater" Text="In a Theater?" runat="server" OnCheckedChanged="cbTheater_CheckedChanged" AutoPostBack="true" /></li>
                                <li>
                                    <asp:RangeValidator ID="rvTickets" runat="server" ControlToValidate="txtTickets" Type="Integer" MinimumValue="0" MaximumValue="100" ErrorMessage="Spots open must be an integer" Display="Dynamic"></asp:RangeValidator></asp:CheckBox>
                            </ul>


                        </li>
                        <li>
                            <asp:Button ID="btnCreate" runat="server" Text="Create Event" OnClick="btnCreate_Click" CssClass="btn btn-primary" /></li>
                    </ul>



                </div>

            </div>

        </div>

        <div id="movieShowcase" class="card text-white bg-secondary mb-3" style="max-width: 26rem;">
            <div class="card-header" runat="server" id="lblMovie">
                Movies
            </div>
            <div class="card-body" style="height: 588px; width: 398px;">

                <ul>
                    <li>

                        <asp:DropDownList ID="movieDropdown" runat="server" CssClass="movieDropdown" OnSelectedIndexChanged="movieDropdown_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMovieDropdown" runat="server" ControlToValidate="movieDropdown" ErrorMessage="A movie is required" Display="Dynamic"></asp:RequiredFieldValidator>



                    </li>

                    <li>

                        <asp:PlaceHolder ID="phNextMovies" runat="server"></asp:PlaceHolder>



                    </li>

                </ul>

            </div>



        </div>
        
<%--        <div id="mapContainer">
            <div class="card text-white bg-secondary mb-3" style="max-width: 40rem;">
                <div class="card-header">Map</div>
                <div class="card-body">
                    <meta name="viewport" content="initial-scale=1.0">
                    <meta charset="utf-8">
                    <input id="pac-input" class="controls" type="text" placeholder="Search Box">
                    <div id="map"></div>



                    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBeCfdMttghOGJ4p7UeLGbjeuKQnmhfYjw&libraries=places&callback=initMap"
                        async defer></script>

                    <script src="js/main.js"></script>
                </div>

            </div>
        </div>--%>


    </div>

</asp:Content>
