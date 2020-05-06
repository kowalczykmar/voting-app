<%@ Page Title="Strona główna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" ValidateRequest="false" Inherits="VotingApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Dodaj opinię</h2>
        <p class="lead">Napisz poniżej swoją opinię o zajęciach na UP</p>
        <asp:Label runat="server" ID="NotLoggedIn1" CssClass="col-md-10 control-label">Zaloguj się, aby dodać opinię</asp:Label>
        <div class="container-fluid">   
            <asp:TextBox ID="Opinion1" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize:none" Rows="10" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="OpinionValidator1" runat="server" ControlToValidate="Opinion1" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button ID="SubmitButton1" runat="server" Text="Prześlij opinię" CssClass="btn btn-default" OnClick="Submit1Click" Visible="false" />
            <asp:TextBox ID="Code1" runat="server" CssClass="form-control" style="resize:none" Visible="false"></asp:TextBox>
            <asp:Button ID="CheckOpinionBtn1" runat="server" Text="Sprawdź" CssClass="btn btn-default" OnClick="CheckClick1" Visible="false" />
        </div>
    </div>
    <div class="jumbotron">
        <h2>Dodaj opinię</h2>
        <p class="lead">Napisz poniżej swoją opinię o zajęciach na UP</p>
        <asp:Label runat="server" ID="NotLoggedIn2" CssClass="col-md-10 control-label">Zaloguj się, aby dodać opinię</asp:Label>
        <div class="container-fluid">   
            <asp:TextBox ID="Opinion2" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize:none" Rows="10" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="OpinionValidator2" runat="server" ControlToValidate="Opinion2" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button ID="SubmitButton2" runat="server" Text="Prześlij opinię" CssClass="btn btn-default" OnClick="Submit2Click" Visible="false" />
            <asp:TextBox ID="Code2" runat="server" CssClass="form-control" style="resize:none" Visible="false"></asp:TextBox>
            <asp:Button ID="CheckOpinionBtn2" runat="server" Text="Sprawdź" CssClass="btn btn-default" OnClick="CheckClick2" Visible="false" />
        </div>
    </div>
    <div class="jumbotron">
        <h2>Dodaj opinię</h2>
        <p class="lead">Napisz poniżej swoją opinię o zajęciach na UP</p>
        <asp:Label runat="server" ID="NotLoggedIn3" CssClass="col-md-10 control-label">Zaloguj się, aby dodać opinię</asp:Label>
        <div class="container-fluid">   
            <asp:TextBox ID="Opinion3" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize:none" Rows="10" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="OpinionValidator3" runat="server" ControlToValidate="Opinion3" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Button ID="SubmitButton3" runat="server" Text="Prześlij opinię" CssClass="btn btn-default" OnClick="Submit3Click" Visible="false" />
            <asp:TextBox ID="Code3" runat="server" CssClass="form-control" style="resize:none" Visible="false"></asp:TextBox>
            <asp:Button ID="CheckOpinionBtn3" runat="server" Text="Sprawdź" CssClass="btn btn-default" OnClick="CheckClick3" Visible="false" />
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-4">
            <h2>Anonimowość</h2>
            <p>
               Wszystkie dane są przechowywane w sposób anonimowy i bezpieczny.
            </p>
            <p>
                <a class="btn btn-default" href="About.aspx">Dowiedz się więcej &raquo;</a>
            </p>
        </div>
        <%--
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>--%>
    </div>
</asp:Content>
