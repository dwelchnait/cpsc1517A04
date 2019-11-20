<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="ReceivingPage.aspx.cs" Inherits="WebApp.SamplePages.ReceivingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Receiving data from the Sqlquery Page</h1>
    <asp:Label ID="MessageLabel" runat="server" ></asp:Label><br />
    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
</asp:Content>
