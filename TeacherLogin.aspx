<%@ Page Title="Zaloguj się" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="TeacherLogin.aspx.cs" Inherits="VotingApp.TeacherLogin" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="FailureMessage" />
    </p>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Logowanie dla prowadzących</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" ID="EmailLabel" CssClass="col-md-2 control-label">ID</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="EmailTxt" CssClass="form-control" TextMode="SingleLine" />
                            <asp:RequiredFieldValidator id="EmailValidator" runat="server" ControlToValidate="EmailTxt" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="PasswordLabel" CssClass="col-md-2 control-label">Hasło</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PasswordTxt" TextMode="Password" CssClass="form-control" />
                            <asp:RequiredFieldValidator id="PassValidator" runat="server" ControlToValidate="PasswordTxt" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="LoginButton" runat="server" Text="Zaloguj" CssClass="btn btn-default" OnClick="LoginClick" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" ID="LoggedInText" Visible="false">Prowadzący już zalogowany</asp:Label>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
