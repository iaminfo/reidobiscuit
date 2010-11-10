<%@ Page Title="" Language="C#" MasterPageFile="~/ReiBiscuit.Master" AutoEventWireup="true" CodeBehind="ListarProdutos.aspx.cs" Inherits="reibiscuit.ListarProdutos" %>
<%@ MasterType TypeName="reibiscuit.ReiBiscuit"  %>
<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="main" runat="server">
    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:TemplateField HeaderText="IdProduto">
                <ItemTemplate>
                    <asp:Label ID="lIdProduto" runat="server" Text='<%# Bind("IdProduto") %>'></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descrição">
                <ItemTemplate>
                    <asp:Label ID="lDescricao" runat="server" Text='<%# Bind("Descricao") %>'></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Descrição">
                <ItemTemplate>
                    <asp:Label ID="lCategoria" runat="server" Text='<%# Bind("Descricao") %>'></asp:Label>
                </ItemTemplate>                
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="contentFooter" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
