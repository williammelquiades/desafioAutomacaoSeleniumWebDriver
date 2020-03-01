using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class VerTarefasPage : PageBase
    {
        #region Mapping
        By pesquisaTarefaGlobal = By.Name("bug_id");
        By boxDeErro = By.XPath("//div[@class='alert alert-danger']//p[2]");
        By capturaTexto = By.XPath("//*[@id='bug_action']//h4");
        #endregion

        #region Acction
        public void PesquisarGlobalTarefas(string pesquisaTarefa)
        {
            ClearAndSendKeys(this.pesquisaTarefaGlobal, pesquisaTarefa);
            EnterKeyBoardInput(pesquisaTarefaGlobal);
        }

        public string CapturarMensagemRetornada()
        {
            return GetText(boxDeErro);
        }

        public string VerificarTextoNaTela()
        {
            return GetText(capturaTexto);
        }
        #endregion
    }
}
