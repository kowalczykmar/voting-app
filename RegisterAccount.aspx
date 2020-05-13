<%@ Page Title="Zarejestruj się" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="RegisterAccount.aspx.cs" Inherits="VotingApp.WebForm2" %>

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
            <asp:Label runat="server" ID="ConfirmPasswordLabel" CssClass="col-md-2 control-label">Potwierdź hasło</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPasswordTxt" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator id="ConfPassValidator" runat="server" ControlToValidate="ConfirmPasswordTxt" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="YearText" CssClass="col-md-2 control-label">Wybierz rocznik rozpoczęcia</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Year" runat="server" CssClass="col-md-2 control-label">
                    <asp:ListItem Value="2018">2018</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="GroupText" CssClass="col-md-2 control-label">Wybierz grupę</asp:Label>
            <div class="col-md-10">
                <asp:DropDownList ID="Group" runat="server" CssClass="col-md-2 control-label" AutoPostBack="false">
                    <asp:ListItem Value="L1">L1</asp:ListItem>
                    <asp:ListItem Value="L2">L2</asp:ListItem>
                    <asp:ListItem Value="L3">L3</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="RegisterButton" runat="server" Text="Zarejestruj" CssClass="btn btn-default" OnClick="RegisterClick" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" ID="LoggedInText" Visible="false">Użytkownik już zalogowany</asp:Label>
        </div>
    </div>
</asp:Content>