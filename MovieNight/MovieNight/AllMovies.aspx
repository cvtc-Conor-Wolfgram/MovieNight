<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AllMovies.aspx.cs" Inherits="MovieNight.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="movies" class="row" style="width: 132.28px; margin-left: 43%; margin-right: 57%; text-align: center;"><h5>Your Movies</h5></div>
    <asp:PlaceHolder ID="phMovies" runat="server"></asp:PlaceHolder>
    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
</asp:Content>
