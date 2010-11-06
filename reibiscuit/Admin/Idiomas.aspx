<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Idiomas.aspx.cs" Inherits="reibiscuit.Admin.Idiomas" %>
<%@ MasterType VirtualPath="~/Admin/Admin.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h1>Idiomas</h1>
    <p>
        <asp:Button ID="bIncluir" runat="server" Text="Incluir" 
            onclick="bIncluir_Click" />

        <asp:GridView ID="gvIdiomas" runat="server" AutoGenerateColumns="False" 
        onrowcancelingedit="gvIdiomas_RowCancelingEdit" 
        onrowdatabound="gvIdiomas_RowDataBound" 
        onrowdeleting="gvIdiomas_RowDeleting" onrowediting="gvIdiomas_RowEditing" onrowupdating="gvIdiomas_RowUpdating" 
        >
        <Columns>        
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("IdIdioma") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <EditItemTemplate>
                    <asp:TextBox ID="tbDescricao" runat="server" Text='<%# Bind("Descricao") %>' ></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lDescricao" runat="server" Text='<%# Bind("Descricao") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="lbUpdate" runat="server" CausesValidation="True" 
                        CommandName="Update" Text="Salvar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbCancel" runat="server" CausesValidation="False" 
                        CommandName="Cancel" Text="Cancelar"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lbEdit" runat="server" CausesValidation="False" 
                        CommandName="Edit" Text="Alterar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lbDelete" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Apagar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        </asp:GridView>
    </p>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
