using CSharpSeleniumTemplate.Bases;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class PlanejamentoPage : PageBase
    {
        #region Mapping
        By msgEmTela = By.XPath("//p[@class='lead']");
        By campoPesquisaTarefa = By.Name("bug_id");
        #endregion

        #region Actions
        public void ClicarPlanejamento()
        {

        }

        public void RetornoPlanejamentoIndisponivel()
        {

        }

        public void PesquisarTaredaId()
        {
        
        }
        #endregion
    }
}
