<%@ Page Title="Change your password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="WebApplication5.Manage" %>



<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" Width="387px">
        <Columns>
            <asp:BoundField HeaderText="Appli_no" ReadOnly="True" />
        </Columns>
    </asp:GridView>

</asp:Content>
