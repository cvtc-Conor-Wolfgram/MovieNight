<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="movieSearch.aspx.cs" Inherits="MovieNight.movieSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="movies" class="row">Search movies to see list.</div>
    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" Text="Search Movies" OnClick="btnSearch_Click" PostBackUrl="movieSearch.aspx" />
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
    <asp:PlaceHolder ID="phMovieResults" runat="server"></asp:PlaceHolder>
    
</asp:Content>
