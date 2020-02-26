using CSharpSeleniumTemplate.Bases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class PlanejamentoTests : TestBase
    {
        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows logarNoSistema;
        [AutoInstance] MenuMantis menuMantis;

        #endregion

        [Test]
        [Category("Planejamento")]
        public void AcessarTelaDePlanejamento()
        {
            #region Parameters
            string mensagemNaTela = "";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuPlanejamento();
        }

        [Test]
        [Category("Planejamento")]
        public void PesquisaTarefaComCaracteres()
        {
            //Test
        }

        [Test]
        [Category("Planejamento")]
        public void PesquisarTarefaComIdInexistente() { }
    }
}
