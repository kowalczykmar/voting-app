<%@ Page Title="Strona główna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VotingApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="jumbotron">
        <h2>Dodaj opinię</h2>
        <p class="lead">Napisz poniżej swoją opinię o zajęciach na UP</p>
        <div class="container-fluid">   
            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize:none" Rows="10"></asp:TextBox>
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
