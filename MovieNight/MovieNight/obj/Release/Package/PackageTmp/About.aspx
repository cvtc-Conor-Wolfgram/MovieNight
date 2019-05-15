<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="MovieNight.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron bg-secondary text-white" style="margin: 0px; border-radius: 0;">
        <p class="lead">Who are we?</p>
        <hr class="my-4">
        <p>
            Movie Night is an application created by David Kurshner, Chris Nimtz and Conor Wolgram for their IT-Developer Capstone Class at Chippewa
            Valley Technical College.  This application was created from conception to completion over a period of eight weeks with the intention of providing
            a way for groups of friends to organize movie viewing experiences together.
        </p>
        <p>The API used for calling up movie IMDB information and posters is the OMDb API created by Brian Fritz.</p>
        <p class="lead"></p>
        <table>
            <tbody>
                <tr>
                    <td style="padding:10px;"><div class="card bg-light ">
                        <div class="card-body">
                                    <h4 class="card-title">Conor Wolfgram</h4>
                                    <h6 class="card-subtitle mb-2 text-muted">Team Leader</h6>
                                    <p class="card-text">Team Lead and developer for this project.</p>
                                </div>
                            </div>

                    </td>
                     <td style="padding:10px;"><div class="card bg-light">
                        <div class="card-body">
                                    <h4 class="card-title">Chris Nimtz</h4>
                                    <h6 class="card-subtitle mb-2 text-muted">Quality Assurance</h6>
                                    <p class="card-text">Quality Assurance and developer for this project.</p>
                                </div>
                            </div>

                    </td>
                     <td style="padding:10px;"><div class="card bg-light">
                        <div class="card-body">
                                    <h4 class="card-title">David Kurschner</h4>
                                    <h6 class="card-subtitle mb-2 text-muted">User Experiance Designer</h6>
                                    <p class="card-text">User Experience Designer and developer for this project.</p>
                                </div>
                            </div>

                    </td>
                    </tr>
            </tbody>
            
           
        </table>
    </div>
</asp:Content>

