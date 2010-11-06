using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
namespace reibiscuit.Bussiness
{
    public class Mensagem
    {
        public enum TiposMensagem
        {
            Ok,
            Erro,
            Warning,
            Info
        }

        public static void EscreverMensagem(TiposMensagem tipoMensagem, HtmlGenericControl controle, string mensagem)
        {
            controle.InnerText = mensagem;
        }
    }
}
