<%@ Page Title="Panel dla prowadzących" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="TeacherDefault.aspx.cs" Inherits="VotingApp.TeacherDefault" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <h2 runat="server" id="Header1">Opinie o zajęciach</h2>
        <div class="table-responsive">
                        <table style="width: 100%">
                            <tr>
                                <td>
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
</td>
                                <td>
        <asp:GridView runat="server" ID="UsersWithOpinionSend1" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>  
                    <asp:TemplateField HeaderText="Użytkownicy, którzy przesłali opinię">  
                        <EditItemTemplate>  
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>  
                        </EditItemTemplate>  
                        <ItemTemplate>  
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Username") %>'></asp:Label>  
                        </ItemTemplate>  
                    </asp:TemplateField>   
                </Columns>  
            </asp:GridView>
</td>
</tr>
                <tr>
                    <td style="padding: 10px">
                        <asp:GridView runat="server" ID="OpinionIndexes1" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>  
                                <asp:BoundField DataField="Ocena" HeaderText="Ocena" />
                                <asp:BoundField DataField="Number" HeaderText="Ilość ocen" />
                            </Columns>  
                        </asp:GridView>
                    </td>
                    <td style="padding: 10px">
                        <asp:GridView runat="server" ID="OpinionNumbers1" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>  
                                <asp:BoundField DataField="Ocena" HeaderText="Ocena" />
                                <asp:BoundField DataField="Number" HeaderText="Ilość ocen" />
                            </Columns>  
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px"></td>
                    <td style="padding: 10px"><asp:Label runat="server" ID="Average1" style="font-size: 2rem; font-weight: bold">Średnia: </asp:Label></td>
                </tr> 
            </table>
        </div>
    </div>

    <div class="jumbotron">
        <h2 runat="server" id="Header2">Opinie o zajęciach</h2>
        <div class="table-responsive">
            <table style="width: 100%">
                <tr>
                    <td style="padding: 10px">
            <asp:GridView runat="server" ID="Opinions2" AutoGenerateColumns="False" CssClass="table table-striped">
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
                    </td><td style="padding: 10px">
        <asp:GridView runat="server" ID="UsersWithOpinionSend2" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>  
                    <asp:TemplateField HeaderText="Użytkownicy, którzy przesłali opinię">  
                        <EditItemTemplate>  
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>  
                        </EditItemTemplate>  
                        <ItemTemplate>  
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Username") %>'></asp:Label>  
                        </ItemTemplate>  
                    </asp:TemplateField>   
                </Columns>  
            </asp:GridView>
</td>
            </tr>
                <tr>
                    <td style="padding: 10px">
                        <asp:GridView runat="server" ID="OpinionIndexes2" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>  
                                <asp:BoundField DataField="Ocena" HeaderText="Ocena" />
                                <asp:BoundField DataField="Number" HeaderText="Ilość ocen" />
                            </Columns>  
                        </asp:GridView>
                    </td>
                    <td style="padding: 10px">
                        <asp:GridView runat="server" ID="OpinionNumbers2" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>  
                                <asp:BoundField DataField="Ocena" HeaderText="Ocena" />
                                <asp:BoundField DataField="Number" HeaderText="Ilość ocen" />
                            </Columns>  
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px"></td>
                    <td style="padding: 10px"><asp:Label runat="server" ID="Average2" style="font-size: 2rem; font-weight: bold">Średnia: </asp:Label></td>
                </tr> 
            </table>
        </div>
    </div>

    <div class="jumbotron">
        <h2 runat="server" id="Header3">Opinie o zajęciach</h2>
        <div class="table-responsive">
                    <table style="width: 100%">
                        <tr>
                            <td style="padding: 10px">
            <asp:GridView runat="server" ID="Opinions3" AutoGenerateColumns="False" CssClass="table table-striped">
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
        </td><td style="padding: 10px">
        <asp:GridView runat="server" ID="UsersWithOpinionSend3" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>  
                    <asp:TemplateField HeaderText="Użytkownicy, którzy przesłali opinię">  
                        <EditItemTemplate>  
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Username") %>'></asp:TextBox>  
                        </EditItemTemplate>  
                        <ItemTemplate>  
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("Username") %>'></asp:Label>  
                        </ItemTemplate>  
                    </asp:TemplateField>   
                </Columns>  
            </asp:GridView>
        </td>
        </tr>
                <tr>
                    <td style="padding: 10px">
                        <asp:GridView runat="server" ID="OpinionIndexes3" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>  
                                <asp:BoundField DataField="Ocena" HeaderText="Ocena" />
                                <asp:BoundField DataField="Number" HeaderText="Ilość ocen" />
                            </Columns>  
                        </asp:GridView>
                    </td>
                    <td style="padding: 10px">
                        <asp:GridView runat="server" ID="OpinionNumbers3" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>  
                                <asp:BoundField DataField="Ocena" HeaderText="Ocena" />
                                <asp:BoundField DataField="Number" HeaderText="Ilość ocen" />
                            </Columns>  
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 10px"></td>
                    <td style="padding: 10px"><asp:Label runat="server" ID="Average3" style="font-size: 2rem; font-weight: bold">Średnia: </asp:Label></td>
                </tr> 
            </table>
        </div>
        </div>
</asp:Content>