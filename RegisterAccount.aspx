<%@ Page Title="Zaloguj się" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RegisterAccount.aspx.cs" Inherits="VotingApp.WebForm2" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Utwórz nowe konto</h4>
        <hr />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" ID="EmailLabel" CssClass="col-md-2 control-label">Adres e-mail</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="EmailTxt" CssClass="form-control" TextMode="Email" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="PasswordLabel" CssClass="col-md-2 control-label">Hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="PasswordTxt" TextMode="Password" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="ConfirmPasswordLabel" CssClass="col-md-2 control-label">Potwierdź hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPasswordTxt" TextMode="Password" CssClass="form-control" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="RegisterButton" runat="server" Text="Zarejestruj" CssClass="btn btn-default" OnClick="RegisterClick" />
            </div>
        </div>
        <div class="jumbotron">
            <asp:Label runat="server" ID="SuccesLabel" Visible="false">Sukces! Utworzono konto, wróć na <a href="Default.aspx">stronę główną</a></asp:Label>
        </div>
    </div>
</asp:Content>