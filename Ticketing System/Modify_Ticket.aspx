<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Modify_Ticket.aspx.cs" Inherits="Ticketing_System.Modify_Ticket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="col" >
    <asp:TextBox CssClass="form-control form-control-lg" ID="TextBox1" runat="server" placeholder="Title"></asp:TextBox>
    <center>
       Choose Ticket Here:
    <asp:DropDownList ID="Titles" runat="server" style="width:19.4%;" DataTextField="Title" AutoPostBack="True" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="textChangedEventHandler" AppendDataBoundItems="true" > 
     <asp:ListItem Text="" Value="" /> 
        </asp:DropDownList>  
    <asp:DropDownList ID="Request_Type" runat="server" style="width:19.4%;">  
        </asp:DropDownList>  
    <asp:DropDownList ID="Status" runat="server" style="width:19.4%;">  
        </asp:DropDownList>  
    <asp:DropDownList ID="Category" runat="server" style="width:19.4%;">  
        </asp:DropDownList>  
    <asp:DropDownList ID="Technicians" runat="server" style="width:19.4%;">  
        </asp:DropDownList> 
    </center>
    <asp:TextBox TextMode="MultiLine" CssClass="form-control form-control-lg" ID="TextBox2" runat="server" style="height:100vh; text-align: match-parent;" placeholder="Start Writing Here"></asp:TextBox>
    <asp:Button class="btn btn-success btn-block btn-lg" ID="Button1" runat="server" Text="Modify your Selected Ticket" OnClick="Button1_Click" />
    </div>
    </div>
</asp:Content>
