<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="New_Goal.aspx.cs" Inherits="Ticketing_System.New_Goal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="col" >
    <asp:TextBox CssClass="form-control form-control-lg" ID="TextBox1" runat="server" placeholder="Title"></asp:TextBox>
    <asp:TextBox TextMode="Multiline" CssClass="form-control form-control-lg" ID="TextBox2" runat="server" style="height:100vh; text-align: match-parent;" placeholder="Start Writing Here"></asp:TextBox>
    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Add Your New Goal" OnClick="Button1_Click" />
    </div>
    </div>
</asp:Content>
