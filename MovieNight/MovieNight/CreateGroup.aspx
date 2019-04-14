<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateGroup.aspx.cs" Inherits="MovieNight.CreateGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="form-group">

        <asp:Label ID="lblGroupName" runat="server" Text="Group Name"></asp:Label>
        <asp:TextBox ID="txtGroupName" runat="server" MaxLength="25"></asp:TextBox>
        <br /><br />
        <asp:Label ID="lblGroupCode" runat="server" Text="Group Code"></asp:Label>
        <asp:TextBox ID="txtGroupCode" runat="server" TextMode="Number"></asp:TextBox>
        <br /><br />
        <asp:Button ID="btnCreate" runat="server" Text="Create Group" />



    </div>
</asp:Content>
