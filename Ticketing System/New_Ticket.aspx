<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="New_Ticket.aspx.cs" Inherits="Ticketing_System.New_Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="col" >
    <asp:TextBox CssClass="form-control form-control-lg" ID="TextBox1" runat="server" placeholder="Title"></asp:TextBox>
    <center>
    <asp:DropDownList ID="Request_Type" runat="server" style="width:24.5%;">  
        </asp:DropDownList>  
    <asp:DropDownList ID="Status" runat="server" style="width:24.5%;">  
        </asp:DropDownList>  
    <asp:DropDownList ID="Category" runat="server" style="width:24.5%;">  
        </asp:DropDownList>  
    <asp:DropDownList ID="Technicians" runat="server" style="width:24.5%;">  
        </asp:DropDownList> 
    </center>
    <asp:TextBox TextMode="MultiLine" CssClass="form-control form-control-lg" ID="TextBox2" runat="server" style="height:100vh; text-align: match-parent;" placeholder="Start Writing Here"></asp:TextBox>
    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Add Your Ticket" OnClick="Button1_Click" />
    </div>
    </div>
</asp:Content>
