<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="MovieNight.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:SqlDataSource ID="UserConnection" runat="server" ConnectionString="<%$ ConnectionStrings:MovieNightContext %>" SelectCommand="SELECT email, passwordHash FROM [User] WHERE email = @email">
        <SelectParameters>
            <asp:SessionParameter Name="email" SessionField="userAccount" DefaultValue="" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="changePassword">
        <div class="card text-white bg-secondary mb-3" style="max-width: 25rem;">
            <div class="card-header">Change Password</div>
            <div class="card-body bg-light">
                <table class="table table-borderless table-light text-right text-nowrap align-baseline">
                    <tbody>
                        <tr class="">
                            <th scope="col" class="align-baseline">
                                <asp:Label ID="oldPass" runat="server" Text="Old Password:"></asp:Label></th>
                            <td class="align-baseline">
                                <ul>
                                    <li>
                                        <asp:TextBox ID="txtOldPass" runat="server" class="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox></li>
                                    <li>
                                        <asp:Label ID="usernameMatchFound" runat="server" Text="Username taken. Try again." ForeColor="#CC0000" Display="Dynamic" Visible="False"></asp:Label></li>
                                    <li>
                                        <asp:RequiredFieldValidator ID="rfvOldPass" runat="server" ControlToValidate="txtOldPass" ErrorMessage="Please Enter Current Password" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                                    <li>
                                        <asp:Label ID="passCompare" runat="server" Text="Password Incorrect." ForeColor="#CC0000" Display="Dynamic" Visible="False"></asp:Label></li>
                                </ul>
                            </td>

                        </tr>
                    </tbody>
                    <tbody>
                        <tr class="">
                            <th scope="row" class="align-baseline">
                                <asp:Label ID="newPass" runat="server" Text="New Password:"></asp:Label></th>
                            <td class="align-baseline">
                                <ul>
                                    <li>
                                        <asp:TextBox ID="txtNewPass" runat="server" class="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox></li>
                                    <li>
                                        <asp:RequiredFieldValidator ID="rfvNewPass" runat="server" ControlToValidate="txtNewPass" ErrorMessage="Please Enter a New Password" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                                </ul>
                            </td>
                        </tr>
                    </tbody>
                    <tbody>
                        <tr class="">
                            <th scope="row" class="align-baseline">
                                <asp:Label ID="confirmPass" runat="server" Text="Confirm Password:"></asp:Label></th>
                            <td class="align-baseline">
                                <ul>
                                    <li>
                                        <asp:TextBox ID="txtConfirmPass" runat="server" class="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox></li>
                                    <li>
                                        <asp:CompareValidator ID="cvConfirmPass" runat="server" ControlToValidate="txtConfirmPass" ErrorMessage="Passwords must match" ControlToCompare="txtNewPass" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:CompareValidator></li>
                                    <li>
                                        <asp:RequiredFieldValidator ID="rfvConfirmPass" runat="server" ControlToValidate="txtConfirmPass" ErrorMessage="Please Confirm New Password" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                                </ul>

                            </td>
                        </tr>
                    </tbody>
                </table>

                <div style="text-align:center">
                    <asp:Button ID="btnChange" runat="server" class="btn btn-primary btn-lg" Text="Confirm Change" ValidationGroup="login" OnClick="btnChange_Click" TabIndex="1" UseSubmitBehavior="False" />
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>

