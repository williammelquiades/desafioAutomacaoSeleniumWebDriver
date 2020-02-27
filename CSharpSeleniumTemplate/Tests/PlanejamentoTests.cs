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
using CSharpSeleniumTemplate.Pages;

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
        [AutoInstance] PlanejamentoPage planejamento;
        #endregion

        [Test]
        [Category("Planejamento")]
        public void AcessarTelaDePlanejamento()
        {
            #region Parameters
            string mensagemNaTela = "Nenhum planejamento disponível.";
            #endregion

            logarNoSistema.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuPlanejamento();

            Assert.That(planejamento.CapturaMensagemNaTela().Contains(mensagemNaTela));
        }

        /* Cenario relacionado a Cenario
        [Test]
        [Category("Planejamento")]
        public void PesquisaTarefaComCaracteres()
        {
            //Test
        }

        [Test]
        [Category("Planejamento")]
        public void PesquisarTarefaComIdInexistente()
        {
            //Test
        }*/
    }
}
