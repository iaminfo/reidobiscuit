<%@ Page Title="" Language="C#" MasterPageFile="~/ReiBiscuit.Master" AutoEventWireup="true" CodeBehind="ListarProdutos.aspx.cs" Inherits="reibiscuit.ListarProdutos" %>
<%@ MasterType TypeName="reibiscuit.ReiBiscuit"  %>
<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contentMain" ContentPlaceHolderID="main" runat="server">
    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False" OnRowDataBound="GvProdutosOnRowDataBound">
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
            <asp:TemplateField HeaderText="Descrição">
                <ItemTemplate>
                    <asp:Image ID="ibImagem" runat="server" Width="100px" />
                    <asp:GridView ID="gvImagens" runat="server" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Imagem">
                            <ItemTemplate>
                                <a id="aImagem" runat="server" class="preview">
                                <asp:Image ID="ibImagem" runat="server" AlternateText='<%# Bind("Nome") %>' Width="10px" />                
                                </a>
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>                
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
<asp:Content ID="contentFooter" ContentPlaceHolderID="footer" runat="server">
</asp:Content>
