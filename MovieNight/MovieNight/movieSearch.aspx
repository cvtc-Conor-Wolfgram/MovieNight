<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="movieSearch.aspx.cs" Inherits="MovieNight.movieSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron bg-gradient-primary" style="border-radius: 0; margin: 0px; padding-left: 24px; padding-right: 24px;">
    <div id="movies" class="row text-white" style="width: 132.28px; margin-left: 43%; margin-right: 57%; text-align: center;"><h5>Search Movies</h5></div>
    <div style="width: 50%; margin-left: 25%; margin-right: 25%; text-align: center;"><asp:TextBox ID="txtSearch" class="form-control" runat="server"></asp:TextBox></div>
    <div style="width: 50%; margin-top: 5px; margin-left: 25%; margin-right: 25%; text-align: center;"><asp:Button ID="btnSearch" class="btn btn-primary btn-sm" runat="server" Text="Search Movies" OnClick="btnSearch_Click" PostBackUrl="movieSearch.aspx" /></div>
    <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>

        <asp:PlaceHolder ID="phMovieResults" runat="server"></asp:PlaceHolder>
    </div>
    
    
</asp:Content>
