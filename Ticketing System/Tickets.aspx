<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="Ticketing_System.Tickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:con %>" SelectCommand="SELECT * FROM [Ticket_Table]"></asp:SqlDataSource>
    <div class="col" >
        <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="User_Name" DataSourceID="SqlDataSource1" style="background-color:white;margin-top:10vh;border-style: solid;">
            <Columns>
                <asp:ImageField HeaderText="Tickets" NullImageUrl="img/hd-tickets-49014.png" DataImageUrlField ="">
                </asp:ImageField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="container-fluid">
                            <div class="row">
                                <div class="col-lg-10">
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("Title") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text='<%# Eval("Description") %>'></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-12">
                                            Date -
                                            <asp:Label ID="Label5" runat="server" Font-Bold="True" Text='<%# Eval("Date") %>'></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
