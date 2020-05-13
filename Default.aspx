<%@ Page Title="Strona główna" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" ValidateRequest="false" Inherits="VotingApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Dodaj opinię</h2>
        <p class="lead">Napisz poniżej swoją opinię o zajęciach na UP</p>
        <asp:Label runat="server" ID="NotLoggedIn1" CssClass="col-md-10 control-label">Zaloguj się, aby dodać opinię</asp:Label>
        <div class="container-fluid">
            <asp:Label runat="server" ID="Subject1" Visible="false" CssClass="col-md-10 control-label">Przedmiot: </asp:Label>
            <asp:Label runat="server" ID="Teacher1" Visible="false" CssClass="col-md-10 control-label">Prowadzący: </asp:Label>
            <asp:TextBox ID="Opinion1" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize:none" Rows="10" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="OpinionValidator1" runat="server" ControlToValidate="Opinion1" Validationgroup="opinion1" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="RadioButtonText1" CssClass="col-md-10 control-label" Visible="false">Oceń zajęcia w skali 1-10</asp:Label>
            <asp:RadioButtonList ID="RadioButtonList1" CssClass="col-md-10 form-control" runat="server" Visible="false" ValidationGroup="opinion1">
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ControlToValidate="RadioButtonList1" Validationgroup="opinion1" ErrorMessage="Wybierz ocenę!" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="CheckboxText1" CssClass="col-md-10 control-label" Visible="false">Wybierz pasujące</asp:Label>
            <asp:CheckBoxList ID="CheckboxList1" CssClass="col-md-10 form-control" runat="server" Visible="false">
                <asp:ListItem>Zajęcia były bardziej wymagające od pozostałych zajęć w tym semestrze</asp:ListItem>
                <asp:ListItem>Zajęcia dużo mnie nauczyły</asp:ListItem>
                <asp:ListItem>Zajęcia poszerzyły moją wiedzę z tej dziedziny</asp:ListItem>
                <asp:ListItem>Chciałabym/chciałbym uczetsniczyć w kontynuacji zajęć, aby pogłębiać swoją wiedzę w tej dziedzinie</asp:ListItem>
            </asp:CheckBoxList>
            <asp:Button ID="SubmitButton1" runat="server" Text="Prześlij opinię" CssClass="btn btn-default" OnClick="Submit1Click" Visible="false" />
            <asp:TextBox ID="Code1" runat="server" CssClass="form-control" style="resize:none" Visible="false"></asp:TextBox>
            <asp:Button ID="CheckOpinionBtn1" runat="server" Text="Sprawdź" CssClass="btn btn-default" validationgroup="opinion1" OnClick="CheckClick1" Visible="false" />
        </div>
    </div>
    <div class="jumbotron">
        <h2>Dodaj opinię</h2>
        <p class="lead">Napisz poniżej swoją opinię o zajęciach na UP</p>
        <asp:Label runat="server" ID="NotLoggedIn2" CssClass="col-md-10 control-label">Zaloguj się, aby dodać opinię</asp:Label>
        <div class="container-fluid">
            <asp:Label runat="server" ID="Subject2" Visible="false" CssClass="col-md-10 control-label">Przedmiot: </asp:Label>
            <asp:Label runat="server" ID="Teacher2" Visible="false" CssClass="col-md-10 control-label">Prowadzący: </asp:Label>
            <asp:TextBox ID="Opinion2" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize:none" Rows="10" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="OpinionValidator2" runat="server" ControlToValidate="Opinion2" validationgroup="opinion2" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="RadioButtonText2" CssClass="col-md-10 control-label" Visible="false">Oceń zajęcia w skali 1-10</asp:Label>
            <asp:RadioButtonList ID="RadioButtonList2" CssClass="col-md-10 form-control" runat="server" Visible="false" ValidationGroup="opinion2">
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ControlToValidate="RadioButtonList2" Validationgroup="opinion2" ErrorMessage="Pole obowiązkowe" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="CheckboxText2" CssClass="col-md-10 control-label" Visible="false">Wybierz pasujące</asp:Label>
            <asp:CheckBoxList ID="CheckboxList2" CssClass="col-md-10 form-control" runat="server" Visible="false">
                <asp:ListItem>Zajęcia były bardziej wymagające od pozostałych zajęć w tym semestrze</asp:ListItem>
                <asp:ListItem>Zajęcia dużo mnie nauczyły</asp:ListItem>
                <asp:ListItem>Zajęcia poszerzyły moją wiedzę z tej dziedziny</asp:ListItem>
                <asp:ListItem>Chciałabym/chciałbym uczetsniczyć w kontynuacji zajęć, aby pogłębiać swoją wiedzę w tej dziedzinie</asp:ListItem>
            </asp:CheckBoxList>
            <asp:Button ID="SubmitButton2" runat="server" Text="Prześlij opinię" CssClass="btn btn-default" OnClick="Submit2Click" Visible="false" />
            <asp:TextBox ID="Code2" runat="server" CssClass="form-control" style="resize:none" Visible="false"></asp:TextBox>
            <asp:Button ID="CheckOpinionBtn2" runat="server" Text="Sprawdź" CssClass="btn btn-default" validationgroup="opinion2" OnClick="CheckClick2" Visible="false" />
    </div>
        </div>
    <div class="jumbotron">
        <h2>Dodaj opinię</h2>
        <p class="lead">Napisz poniżej swoją opinię o zajęciach na UP</p>
        <asp:Label runat="server" ID="NotLoggedIn3" CssClass="col-md-10 control-label">Zaloguj się, aby dodać opinię</asp:Label>
        <div class="container-fluid">
            <asp:Label runat="server" ID="Subject3" Visible="false" CssClass="col-md-10 control-label">Przedmiot: </asp:Label>
            <asp:Label runat="server" ID="Teacher3" Visible="false" CssClass="col-md-10 control-label">Prowadzący: </asp:Label>
            <asp:TextBox ID="Opinion3" runat="server" TextMode="MultiLine" CssClass="form-control" style="resize:none" Rows="10" Visible="false"></asp:TextBox>
            <asp:RequiredFieldValidator id="OpinionValidator3" runat="server" ControlToValidate="Opinion3" validationgroup="opinion3" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
              <asp:Label runat="server" ID="RadioButtonText3" CssClass="col-md-10 control-label" Visible="false">Oceń zajęcia w skali 1-10</asp:Label>
            <asp:RadioButtonList ID="RadioButtonList3" CssClass="col-md-10 form-control" runat="server" Visible="false" ValidationGroup="opinion3">
                <asp:ListItem Value="5">5</asp:ListItem>
                <asp:ListItem Value="4">4</asp:ListItem>
                <asp:ListItem Value="3">3</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
                <asp:ListItem Value="1">1</asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" ControlToValidate="RadioButtonList3" Validationgroup="opinion3" ErrorMessage="Pole obowiązkowe" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:Label runat="server" ID="CheckboxText3" CssClass="col-md-10 control-label" Visible="false">Wybierz pasujące</asp:Label>
            <asp:CheckBoxList ID="CheckboxList3" CssClass="col-md-10 form-control" runat="server" Visible="false">
                <asp:ListItem>Zajęcia były bardziej wymagające od pozostałych zajęć w tym semestrze</asp:ListItem>
                <asp:ListItem>Zajęcia dużo mnie nauczyły</asp:ListItem>
                <asp:ListItem>Zajęcia poszerzyły moją wiedzę z tej dziedziny</asp:ListItem>
                <asp:ListItem>Chciałabym/chciałbym uczetsniczyć w kontynuacji zajęć, aby pogłębiać swoją wiedzę w tej dziedzinie</asp:ListItem>
            </asp:CheckBoxList>
            <asp:Button ID="SubmitButton3" runat="server" Text="Prześlij opinię" CssClass="btn btn-default" OnClick="Submit3Click" Visible="false" />
            <asp:TextBox ID="Code3" runat="server" CssClass="form-control" style="resize:none" Visible="false"></asp:TextBox>
            <asp:Button ID="CheckOpinionBtn3" runat="server" Text="Sprawdź" CssClass="btn btn-default" validationgroup="opinion3" OnClick="CheckClick3" Visible="false" />
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
