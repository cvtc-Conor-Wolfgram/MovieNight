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
                          <asp:TextBox ID="txtDateTime" textmode="DateTimeLocal" runat="server" CssClass="form-control" ></asp:TextBox>
                          <asp:RequiredFieldValidator ID="rfvDateTime" ControlToValidate="txtDateTime" runat="server" ErrorMessage="Date and time is required."></asp:RequiredFieldValidator>

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
                            <script>

                                function initAutocomplete() {
                                    var map = new google.maps.Map(document.getElementById('map'), {
                                        center: { lat: -33.8688, lng: 151.2195 },
                                        zoom: 13,
                                        mapTypeId: 'roadmap'
                                    });

                                    // Create the search box and link it to the UI element.
                                    var input = document.getElementById('pac-input');
                                    var searchBox = new google.maps.places.SearchBox(input);
                                    map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);

                                    // Bias the SearchBox results towards current map's viewport.
                                    map.addListener('bounds_changed', function () {
                                        searchBox.setBounds(map.getBounds());
                                    });

                                    var markers = [];
                                    // Listen for the event fired when the user selects a prediction and retrieve
                                    // more details for that place.
                                    searchBox.addListener('places_changed', function () {
                                        var places = searchBox.getPlaces();

                                        if (places.length == 0) {
                                            return;
                                        }

                                        // Clear out the old markers.
                                        markers.forEach(function (marker) {
                                            marker.setMap(null);
                                        });
                                        markers = [];

                                        // For each place, get the icon, name and location.
                                        var bounds = new google.maps.LatLngBounds();
                                        places.forEach(function (place) {
                                            if (!place.geometry) {
                                                console.log("Returned place contains no geometry");
                                                return;
                                            }
                                            var icon = {
                                                url: place.icon,
                                                size: new google.maps.Size(71, 71),
                                                origin: new google.maps.Point(0, 0),
                                                anchor: new google.maps.Point(17, 34),
                                                scaledSize: new google.maps.Size(25, 25)
                                            };

                                            // Create a marker for each place.
                                            markers.push(new google.maps.Marker({
                                                map: map,
                                                icon: icon,
                                                title: place.name,
                                                position: place.geometry.location
                                            }));

                                            if (place.geometry.viewport) {
                                                // Only geocodes have viewport.
                                                bounds.union(place.geometry.viewport);
                                            } else {
                                                bounds.extend(place.geometry.location);
                                            }
                                        });
                                        map.fitBounds(bounds);
                                    });
                                }

    </script>
                           
                          
                            <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBeCfdMttghOGJ4p7UeLGbjeuKQnmhfYjw&libraries=places&callback=initAutocomplete"
         async defer></script>
                        </div>

                    </div>
        </div>
        
</div>
    
</asp:Content>
