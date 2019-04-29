<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateEvent.aspx.cs" Inherits="MovieNight.CreateEvent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="lblEventName" runat="server" Text="Event Name"></asp:Label>
        <asp:TextBox ID="txtEName" runat="server" MaxLength="25"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvTxtEName" ControlToValidate="txtEName" runat="server" ErrorMessage="Event Name is required"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
        <asp:TextBox ID="txtLocation" runat="server" MaxLength="25"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLocation" runat="server" ControlToValidate="txtLocation" ErrorMessage="Location is required."></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Label ID="lblDateTime" runat="server" Text="Date and Time"></asp:Label>
        <asp:TextBox ID="txtDateTime" textmode="DateTimeLocal" runat="server"  ></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvDateTime" ControlToValidate="txtDateTime" runat="server" ErrorMessage="Date and time is required."></asp:RequiredFieldValidator>
        <br /><br />
        <asp:CheckBox ID="cbTheater" Text="In a Movie Theater?" runat="server" OnCheckedChanged="cbTheater_CheckedChanged" AutoPostBack="true" />
        <br />
        <asp:Label ID="lblTickets" runat="server" Text="Tickets Bought"></asp:Label>
        <asp:TextBox ID="txtTickets" TextMode="Number" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="rvTickets" runat="server" ControlToValidate="txtTickets" Type="Integer" MinimumValue="0" MaximumValue="100" ErrorMessage="Spots open must be an integer"></asp:RangeValidator>
        <br /><br />
        <asp:Button ID="btnCreate" runat="server" Text="Create Event" OnClick="btnCreate_Click" />
        <br /><br />



        <asp:Label ID="lblTest" runat="server" Text="Test"></asp:Label>


    </div>


</asp:Content>
