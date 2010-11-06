<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditarProduto.aspx.cs" Inherits="reibiscuit.Admin.EditarProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../js/imgpreview.min.0.22.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            if ($('a.preview').exists())
                $('a.preview').imgPreview();
        });  
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<h1>Editar Produto</h1>
Descricao: <asp:TextBox ID="tbDescricao" runat="server"></asp:TextBox> <br />
Quantidade: <asp:TextBox ID="tbQuantidade" runat="server"></asp:TextBox> <br />
Disponivel: <asp:RadioButtonList ID="rblDisponibilidade" runat="server" 
        RepeatLayout="Flow" RepeatColumns="2">
<asp:ListItem Text="Sim" Value="S"></asp:ListItem><asp:ListItem Text="Não" Value="N"></asp:ListItem>
</asp:RadioButtonList><br />
Preço: <asp:TextBox ID="tbPreco" runat="server"></asp:TextBox><br />
Categoria:     <asp:DropDownList ID="ddlCategoria" runat="server">
    </asp:DropDownList><br />
    
    <asp:Panel ID="pImagens" runat="server">
    imagens:<asp:FileUpload ID="fuImagem" runat="server" />
        <br />
        
        <asp:Button ID="bEnviarImagem" runat="server" onclick="bEnviarImagem_Click" 
            Text="Enviar Imagem" />
        <asp:GridView ID="gvImagens" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="IdImagem" onrowdatabound="gvImagens_RowDataBound" 
            onrowdeleting="gvImagens_RowDeleting">
        <Columns>
        
            <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Nome") %>'></asp:Label>
                </ItemTemplate>                                
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Imagem">
            <ItemTemplate>
                <a id="aImagem" runat="server" class="preview">
                <asp:Image ID="ibImagem" runat="server" AlternateText='<%# Bind("Nome") %>' Width="100px" />                
                </a>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("IdImagem") %>'
                        CommandName="Delete" Text="Apagar" ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Button ID="bSalvar" runat="server" Text="Salvar" onclick="bSalvar_Click" />
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Footer" runat="server">

</asp:Content>
