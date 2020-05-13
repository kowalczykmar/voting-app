<%@ Page Title="Zaloguj się" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="LoginAccount.aspx.cs" Inherits="VotingApp.WebForm1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="FailureMessage" />
    </p>

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Zaloguj się za pomocą zarejestrowanego konta.</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" ID="EmailLabel" CssClass="col-md-2 control-label">Adres e-mail</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="EmailTxt" CssClass="form-control" TextMode="Email" />
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
                        <asp:Label runat="server" ID="LoggedInText" Visible="false">Użytkownik już zalogowany</asp:Label>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
