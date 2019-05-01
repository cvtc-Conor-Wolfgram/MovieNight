<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="MovieNight.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 id="groupName" runat="server"></h1>
    <h3 id="ownerName" runat="server"></h3>
    <h3 id="pickerName" runat="server"></h3>

    <ul>

        <asp:PlaceHolder ID="phNextMovies" runat="server"></asp:PlaceHolder>

    </ul>

    <ul>

        <asp:PlaceHolder ID="phMembers" runat="server"></asp:PlaceHolder>

    </ul>

    <asp:Button ID="finishedMovie" runat="server" Text="Finished Movie" OnClick="finishedMovie_Click" />


</asp:Content>
