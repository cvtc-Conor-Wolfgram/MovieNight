<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MovieNight.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="jumbotron bg-gradient-secondary text-white" style="margin: 0px; border-radius: 0;">
        <h1 class="display-3">Welcome to Movie Night!</h1>
        <p class="lead">Because films are better with friends</p>
        <hr class="my-4">
        <p>
            With peoples busy lives it can be difficult to set aside time for enjoying a movie with your friends. 
            That is where Movie Night comes in.  Simply create an account and join in a movie watching group with 
            your friends.  Attatch movies you are interested in watching to your account with our simple and intuitive system. Take turns 
            creating and scheduling movie events, whether they are held at the comfort of 
            your own home or at your local movie theater.
        </p>
        <hr class="my-4">
        <h3>Want to get started?  Heres How!</h3>
        <table>
            <tbody>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Step 1:</div>
                            <div class="card-body">
                                <h4 class="card-title">Create a new Account or Login</h4>
                                <p class="card-text">
                                    If you do not have an account with us create one to join our movie loving community!  Or login to
                                    your current account!
                                </p>
                            </div>
                        </div>

                    </td>
                    
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Image Placeholder</p>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Step 2:</div>
                            <div class="card-body">
                                <h4 class="card-title">Add movies to your account!</h4>
                                <p class="card-text">
                                    Click the Add Movies tab to go to our movie search tool where you simply type your
                                    desired movie in and hit search to pull up movie data right from IMDB!  Just hover over
                                    the movies you want attatched to your account and click Add Movie!  Or you can click on 
                                    the other link to bring you to the movies IMDB page!
                                </p>
                            </div>
                        </div>

                    </td>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Image Placeholder</p>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Step 3:</div>
                            <div class="card-body">
                                <h4 class="card-title">View your account dashboard!</h4>
                                <p class="card-text">
                                    From here you can manage your movies and view movie groups you are a part of! 
                                    Not in a group yet?  Simply create a new one with Create Group!  Or join a group
                                    that already exists by entering in their group code!
                                </p>
                            </div>
                        </div>

                    </td>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Image Placeholder</p>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Step 4:</div>
                            <div class="card-body">
                                <h4 class="card-title">View your account dashboard!</h4>
                                <p class="card-text">
                                    From here you can manage your movies and view movie groups you are a part of! 
                                    Not in a group yet?  Simply create a new one with Create Group!  Or join a group
                                    that already exists by entering in their group code! 
                                </p>
                            </div>
                        </div>

                    </td>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Image Placeholder</p>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Step 5:</div>
                            <div class="card-body">
                                <h4 class="card-title">View your group info!</h4>
                                <p class="card-text">
                                     From your account dashboard click on the movie group that you want to view!
                                    This page will show your group members, currently scheduled movie event and 
                                    whos turn it is to pick the event!
                                </p>
                            </div>
                        </div>

                    </td>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Image Placeholder</p>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Step 6:</div>
                            <div class="card-body">
                                <h4 class="card-title">Create an event</h4>
                                <p class="card-text">
                                    If it is your turn to create a new event just click on the create event button!  Just fill in a few details
                                    like the name of the event, the date and time, the location of said event and most importantly which film
                                    from your account you want to be the next event!
                                </p>
                            </div>
                        </div>

                    </td>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            
                            <div class="card-body">
                                <h4 class="card-title">Secondary card title</h4>
                                <p class="card-text">Image Placeholder</p>
                            </div>
                        </div>

                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px;">
                        <div class="card text-dark bg-light mb-3" style="max-width: 20rem;">
                            <div id="one" class="card-header">Step 7:</div>
                            <div class="card-body">
                                <h4 class="card-title">Thats it!</h4>
                                <p class="card-text">
                                    You are all set to take advantage of Movie Night!  Enjoy your films with friends!
                                </p>
                            </div>
                        </div>

                    </td>
                    
                </tr>
            </tbody>


        </table>
    </div>
</asp:Content>
