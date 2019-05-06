<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="YourGroups.aspx.cs" Inherits="MovieNight.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label>
    <div class="innerContent">
        <div id="groupList" class="card text-white bg-secondary mb-3" style="width: 25rem; height: 100%;">
            <div class="card-header">Your Groups</div>
            <ul class="list-group">
                <asp:PlaceHolder ID="phGroupList" runat="server"></asp:PlaceHolder>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
