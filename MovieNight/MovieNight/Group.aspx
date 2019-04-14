<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Group.aspx.cs" Inherits="MovieNight.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 id="groupName" runat="server"></h1>
    <h3 id="ownerName" runat="server"></h3>
    <h2 id="pickerName" runat="server"></h2>

    <asp:Button ID="finishedMovie" runat="server" Text="FinishedMovie" OnClick="finishedMovie_Click" />
    <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1">
        <AlternatingItemTemplate>
            <li style="">Column1:
                <asp:Label ID="Column1Label" runat="server" Text='<%# Eval("Column1") %>' />
                <br />
                joinNumber:
                <asp:Label ID="joinNumberLabel" runat="server" Text='<%# Eval("joinNumber") %>' />
                <br />
                turnToPick:
                <asp:Label ID="turnToPickLabel" runat="server" Text='<%# Eval("turnToPick") %>' />
                <br />
            </li>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <li style="">Column1:
                <asp:TextBox ID="Column1TextBox" runat="server" Text='<%# Bind("Column1") %>' />
                <br />
                joinNumber:
                <asp:TextBox ID="joinNumberTextBox" runat="server" Text='<%# Bind("joinNumber") %>' />
                <br />
                turnToPick:
                <asp:TextBox ID="turnToPickTextBox" runat="server" Text='<%# Bind("turnToPick") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            </li>
        </EditItemTemplate>
        <EmptyDataTemplate>
            No data was returned.
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <li style="">Column1:
                <asp:TextBox ID="Column1TextBox" runat="server" Text='<%# Bind("Column1") %>' />
                <br />joinNumber:
                <asp:TextBox ID="joinNumberTextBox" runat="server" Text='<%# Bind("joinNumber") %>' />
                <br />turnToPick:
                <asp:TextBox ID="turnToPickTextBox" runat="server" Text='<%# Bind("turnToPick") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            </li>
        </InsertItemTemplate>
        <ItemSeparatorTemplate>
<br />
        </ItemSeparatorTemplate>
        <ItemTemplate>
            <li style="">Column1:
                <asp:Label ID="Column1Label" runat="server" Text='<%# Eval("Column1") %>' />
                <br />
                joinNumber:
                <asp:Label ID="joinNumberLabel" runat="server" Text='<%# Eval("joinNumber") %>' />
                <br />
                turnToPick:
                <asp:Label ID="turnToPickLabel" runat="server" Text='<%# Eval("turnToPick") %>' />
                <br />
            </li>
        </ItemTemplate>
        <LayoutTemplate>
            <ul id="itemPlaceholderContainer" runat="server" style="">
                <li runat="server" id="itemPlaceholder" />
            </ul>
            <div style="">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <li style="">Column1:
                <asp:Label ID="Column1Label" runat="server" Text='<%# Eval("Column1") %>' />
                <br />
                joinNumber:
                <asp:Label ID="joinNumberLabel" runat="server" Text='<%# Eval("joinNumber") %>' />
                <br />
                turnToPick:
                <asp:Label ID="turnToPickLabel" runat="server" Text='<%# Eval("turnToPick") %>' />
                <br />
            </li>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MovieNightContext %>" SelectCommand="SELECT CONCAT(fName, lName), joinNumber, turnToPick FROM [User] INNER JOIN [UserGroup] ON [User].userID = [UserGroup].userID WHERE [UserGroup].groupID = 1;"></asp:SqlDataSource>
</asp:Content>
