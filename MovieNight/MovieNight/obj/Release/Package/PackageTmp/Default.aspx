<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieNight.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron bg-gradient-secondary text-white" style="margin: 0px; border-radius: 0;">
        <h1 class="display-3">Header!</h1>
        <p class="lead">I just put this here to get a head start on the styling.</p>
        <hr class="my-4">
        <p>Fill in what you want to keep. Remove what you don't.</p>
        <p class="lead">
            <a class="btn btn-primary btn-lg" href="#" role="button">Learn more</a>
        </p>

        <table>
            <tbody>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Header</div>
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            </div>
                        </div>

                    </td>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Header</div>
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            </div>
                        </div>

                    </td>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Header</div>
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                            </div>
                        </div>

                    </td>
                </tr>
            </tbody>


        </table>
    </div>
</asp:Content>
