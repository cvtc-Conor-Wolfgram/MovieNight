<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="MovieNight.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div id="createEvent">
            <div class="card text-white bg-secondary mb-3" style="max-width: 30rem;">
              <div class="card-header">Creat Event</div>
              <div class="card-body">
                  <ul>
                      <li>
                          <asp:Label ID="lblEventName" runat="server" Text="Event Name"></asp:Label>
                          <asp:TextBox ID="txtEName" runat="server" MaxLength="25" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvTxtEName" ControlToValidate="txtEName" runat="server" ErrorMessage="Event Name is required"></asp:RequiredFieldValidator>

                      </li>

                      <li>
                          <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
                          <asp:TextBox ID="txtLocation" runat="server" MaxLength="25" CssClass="form-control"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="txtLocation" ErrorMessage="Location is required."></asp:RequiredFieldValidator>

                      </li>

                      <li>
                          <asp:Label ID="lblDateTime" runat="server" Text="Date and Time"></asp:Label>
                          <asp:TextBox ID="txtDate" textmode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:TextBox ID="txtTime" textmode="Time" runat="server" CssClass="form-control"></asp:TextBox>
                          <asp:Label ID="lblDateTimeError" Visible="false" runat="server" Text="" ForeColor="#CC3300"></asp:Label>

                      </li>

                      <li>
                         
                                          <ul>
                                              <li><asp:Label ID="lblTickets" runat="server" Text="Tickets Bought"></asp:Label></li>
                                              <li><asp:TextBox ID="txtTickets" TextMode="Number" runat="server" CssClass="form-control"></asp:TextBox></li>
                                              <li><asp:CheckBox ID="cbTheater" Text="In a Theater?" runat="server" OnCheckedChanged="cbTheater_CheckedChanged" AutoPostBack="true"  /></li>
                                              <li><asp:RangeValidator ID="rvTickets" runat="server" ControlToValidate="txtTickets" Type="Integer" MinimumValue="0" MaximumValue="100" ErrorMessage="Spots open must be an integer" Display="Dynamic"></asp:RangeValidator></asp:CheckBox>
                                          </ul>


                      </li>
                         <li><asp:Button ID="btnCreate" runat="server" Text="Create Event" OnClick="btnCreate_Click" CssClass="btn btn-primary" /></li>
                      </ul>



              </div>

            </div>

        </div>
        
        <div id="mapContainer">
            <div class="card text-white bg-secondary mb-3" style="max-width: 41.5rem;">
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
        </div>
        
</div>
    
</asp:Content>
