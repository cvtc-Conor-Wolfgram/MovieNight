<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="CreateAccount.aspx.cs" Inherits="MovieNight.CreateAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="forms">
        <div class="form-login">
            <div class="card text-white bg-gradient-primary mb-3" style="max-width: 25rem;">
                <div class="card-header">
                    <asp:Label ID="Label1" runat="server" Text="Sign In"></asp:Label>
                </div>
                <div class="card-body">

                    <asp:SqlDataSource ID="UserConnection" runat="server" ConnectionString="<%$ ConnectionStrings:MovieNightContext %>" SelectCommand="SELECT email, passwordHash FROM [User] WHERE email = @email">
                        <SelectParameters>
                            <asp:SessionParameter Name="email" SessionField="userAccount" DefaultValue="" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:SqlDataSource ID="UserConnection2" runat="server" ConnectionString="<%$ ConnectionStrings:MovieNightContext %>" SelectCommand="SELECT Username FROM [User] WHERE Username = @Username">
                        <SelectParameters>
                            <asp:SessionParameter Name="UserName" SessionField="createAccount" DefaultValue="" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <ul>
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                        <li>
                            <asp:Label ID="lblActiveEmail" runat="server" Text="Email:"></asp:Label></li>
                        <li class="textBox">
                            <asp:TextBox ID="txtActiveEmail" runat="server" class="form-control" ToolTip="Enter Email" OnTextChanged="txtActiveEmail_TextChanged" AutoPostBack="True"></asp:TextBox></li>
                        <li>
                            <asp:RequiredFieldValidator ID="rfvActiveEmail" runat="server" ControlToValidate="txtActiveEmail" ErrorMessage="Please Enter Your Email" ValidationGroup="login" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                        <li>
                            <asp:RegularExpressionValidator ID="revActiveEmail" runat="server" ControlToValidate="txtActiveEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter a Valid Email Address" ValidationGroup="login" ForeColor="#CC0000" Display="Dynamic"></asp:RegularExpressionValidator></li>
                        <li>
                            <asp:Label ID="emailCompare" runat="server" Text="Email not found. Please sign up." ForeColor="#CC0000" Display="Dynamic" Visible="False"></asp:Label></li>

                        <li>
                            <asp:Label ID="lblActivePass" runat="server" Text="Password:"></asp:Label></li>
                        <li>
                            <asp:TextBox ID="txtActivePass" runat="server" class="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox></li>

                        <li>
                            <asp:CheckBox ID="checkBoxPasswordToggle" Text="Show Password" runat="server" OnCheckedChanged="Toggle_Password" AutoPostBack="true" /></li>

                        <li>
                            <asp:Label ID="passCompare" runat="server" Text="Password Incorrect." ForeColor="#CC0000" Display="Dynamic" Visible="False"></asp:Label></li>
                        <li>
                            <asp:RequiredFieldValidator ID="rfvActivePass" runat="server" ControlToValidate="txtActivePass" ErrorMessage="Please Enter Your Password" ValidationGroup="login" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                        <li>
                            <asp:Button ID="btnLogin" runat="server" class="btn btn-primary btn-lg" Text="Login" ValidationGroup="login" OnClick="btnLogin_Click" TabIndex="1" UseSubmitBehavior="False" />
                        </li>
                    </ul>

                </div>
            </div>
        </div>
        <div class="form-create">
            <div class="card text-white bg-gradient-primary mb-3" style="max-width: 25rem;">
                <div class="card-header">Sign Up</div>
                <div class="card-body">
                    <table class="table table">
                        <tbody>
                            <tr class="table-secondary">
                                <th scope="col">
                                    <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label></th>
                                <td>
                                    <ul>
                                        <li>
                                            <asp:TextBox ID="txtUserName" runat="server" class="form-control" OnTextChanged="txtUserName_TextChanged" AutoPostBack="True"></asp:TextBox></li>
                                        <li>
                                            <asp:Label ID="usernameMatchFound" runat="server" Text="Username taken. Try again." ForeColor="#CC0000" Display="Dynamic" Visible="False"></asp:Label></li>
                                        <li>
                                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ControlToValidate="txtUserName" ErrorMessage="Please Enter a Username" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                                    </ul>
                                </td>

                            </tr>
                        </tbody>
                        <tbody>
                            <tr class="table-secondary">
                                <th scope="row">
                                    <asp:Label ID="lblUserEmail" runat="server" Text="Email:"></asp:Label></th>
                                <td>
                                    <ul>
                                        <li>
                                            <asp:TextBox ID="txtUserEmail" runat="server" class="form-control"></asp:TextBox></li>
                                        <li>
                                            <asp:Label ID="emailMatchFound" runat="server" Text="Email already on file please log in." ForeColor="#CC0000" Display="Dynamic" Visible="False"></asp:Label></li>
                                        <li>
                                            <asp:RequiredFieldValidator ID="rfvUserEmail" runat="server" ControlToValidate="txtUserEmail" ErrorMessage="Please Enter Your Email Address" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                                        <li>
                                            <asp:RegularExpressionValidator ID="regexUserEmail" runat="server" ControlToValidate="txtUserEmail" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please Enter a Valid Email Address" ForeColor="#CC0000" ValidationGroup="create" Display="Dynamic"></asp:RegularExpressionValidator></li>
                                    </ul>
                                </td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr class="table-secondary">
                                <th scope="row">
                                    <asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label></th>
                                <td>
                                    <ul>
                                        <li>
                                            <asp:TextBox ID="txtFName" runat="server" class="form-control"></asp:TextBox></li>
                                    </ul>

                                </td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr class="table-secondary">
                                <th scope="row">
                                    <asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label></th>
                                <td>
                                    <ul>
                                        <li>
                                            <asp:TextBox ID="txtLName" runat="server" class="form-control"></asp:TextBox></li>
                                    </ul>

                                </td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr class="table-secondary">
                                <th scope="row">
                                    <asp:Label ID="lblUserPass" runat="server" Text="Password:"></asp:Label></th>
                                <td>
                                    <ul>
                                        <li>
                                            <asp:TextBox ID="txtUserPass" runat="server" class="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox></li>
                                        <li>
                                            <asp:RequiredFieldValidator ID="rfvUserPass" runat="server" ControlToValidate="txtUserPass" ErrorMessage="Please Enter a Password" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                                    </ul>

                                </td>
                            </tr>
                        </tbody>
                        <tbody>
                            <tr class="table-secondary">
                                <th scope="row">
                                    <asp:Label ID="lblUserPassConfirm" runat="server" Text="Confirm Password:"></asp:Label></th>
                                <td>
                                    <ul>
                                        <li>
                                            <asp:TextBox ID="txtUserPassConfirm" runat="server" class="form-control" TextMode="Password" AutoCompleteType="Disabled"></asp:TextBox></li>

                                        <li>
                                            <asp:CompareValidator ID="cvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Passwords must match" ControlToCompare="txtUserPass" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:CompareValidator></li>
                                        <li>
                                            <asp:RequiredFieldValidator ID="rfvUserPassConfirm" runat="server" ControlToValidate="txtUserPassConfirm" ErrorMessage="Please Confirm Password" ValidationGroup="create" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator></li>
                                    </ul>

                                </td>
                            </tr>
                        </tbody>
                    </table>









                    <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary btn-lg" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="create" ValidateRequestMode="Inherit" UseSubmitBehavior="False" />

                </div>

            </div>
        </div>
    </div>
</asp:Content>
