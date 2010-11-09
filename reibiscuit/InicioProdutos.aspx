<%@ Page Title="" Language="C#" MasterPageFile="~/ReiBiscuit.Master" AutoEventWireup="true" CodeBehind="InicioProdutos.aspx.cs" Inherits="reibiscuit.InicioProdutos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <table width="987px" border="0" align="center" cellpadding="0" cellspacing="0">
			<tr>
			<th width="30%" scope="row" ><a href="~/ListarProdutos.aspx?IdCategoria=1"><img src="imagem/arranjos_albuns.JPG"  border="0"  /><br />
			</a>
			<label class="label"> Arranjos</label></th>
			<th scope="row"><a href="#"><img src="imagem/cestinhas_albuns.JPG"  border="0"  /><br /></a>
			<label class="label"> Cestinhas</label></th>
			<th scope="row"><a href="#"><img src="imagem/noivinhos_albuns.JPG"  border="0"  /><br /></a>
			<label class="label"> Noivinhos </label></th>
		  </tr>
		  <tr>
			<th scope="row" ><a href="#"><img src="imagem/estrelinhas_albuns.JPG" border="0"  /><br /></a>
			<label class="label">Estrelinhas</label></th>
			<th scope="row"><a href="#"><img src="imagem/florzinhas_albuns.JPG" border="0"  /><br /></a>
			<label class="label">Florzinhas</label></th>
			<th scope="row"><a href="#"><img src="Imagem/bonequinhas_albuns.jpg" border="0"  /><br /></a>
			<label class="label">Bonequinhas</label></th>
		  </tr>
		  <tr>
			<th scope="row" ><a href="#"><img src="imagem/biscuizinhos_albuns.JPG" border="0"  /><br /></a>
			<label class="label">Biscuizinhos</label></th>
			<th scope="row"><a href="#"><img src="imagem/fluflu_albuns.JPG" border="0"  /><br /></a>
			<label class="label">Flu Flu</label></th>
			<th scope="row"><a href="#"><img src="imagem/diversos_albuns.JPG" border="0"  /><br /></a>
			<label class="label">Diversos</label></th>
		  </tr>
		</table>
</asp:Content>
