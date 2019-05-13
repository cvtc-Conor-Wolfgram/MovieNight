<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="AllMovies.aspx.cs" Inherits="MovieNight.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron bg-secondary" style="margin: 0px; padding-left: 24px; padding-right: 24px;">
    <div id="movies" class="row text-white" style="width: 132.28px; margin-left: 43%; margin-right: 57%; text-align: center;"><h5>Your Movies</h5></div>
    <asp:PlaceHolder ID="phMovies" runat="server"></asp:PlaceHolder>
    <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
        </div>
</asp:Content>
