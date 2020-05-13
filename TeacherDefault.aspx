<%@ Page Title="Panel dla prowadzących" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="TeacherDefault.aspx.cs" Inherits="VotingApp.TeacherDefault" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2>Opinie o zajęciach</h2>
        <div class="table-responsive">
            <asp:GridView runat="server" ID="Opinions1" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>  
                    <asp:TemplateField HeaderText="Opinia">  
                        <EditItemTemplate>  
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("OpinionContent") %>'></asp:TextBox>  
                        </EditItemTemplate>  
                        <ItemTemplate>  
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("OpinionContent") %>'></asp:Label>  
                        </ItemTemplate>  
                    </asp:TemplateField>   
                </Columns>  
            </asp:GridView>  
        </div>
    </div>
</asp:Content>