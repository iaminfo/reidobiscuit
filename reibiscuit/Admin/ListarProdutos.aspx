<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ListarProdutos.aspx.cs" Inherits="reibiscuit.Admin.ListarProdutos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div id="divMensagem" runat="server"></div>
    <asp:Button ID="bIncluir" runat="server" Text="Incluir" 
    onclick="bIncluir_Click" />
    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False" 
        onrowdatabound="gvProdutos_RowDataBound" 
        onrowdeleting="gvProdutos_RowDeleting" onrowediting="gvProdutos_RowEditing">
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
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lAlterar" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Alterar" CommandArgument='<%# Bind("IdProduto") %>'></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lDelete" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Excluir" CommandArgument='<%# Bind("IdProduto") %>'></asp:LinkButton>
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
