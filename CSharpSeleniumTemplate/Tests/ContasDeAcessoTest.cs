using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
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
    public class ContasDeAcessoTest : TestBase
    {

        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows loginInSystem;
        [AutoInstance] MenuMantis menuMantis;
        [AutoInstance] GerenciarPage emGerenciarProjetos;
        [AutoInstance] ContasDeAcessoPage minhaConta;
        #endregion

        [Test]
        [Parallelizable]
        [Category("Acessar Conta")]
        public void AcessarContaPorDropdown()
        {

            #region Parameters
            string nomeEsperado = "Alterar Conta";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            minhaConta.ClicarDropdownUsuarioLogado();

            minhaConta.ClicarEmMinhaConta();

            Assert.That(minhaConta.CapturaTextoNaAba(nomeEsperado).Contains("Alterar Conta"));
        }

        [Test]
        [Parallelizable]
        [Category("Acessar Conta")]
        public void AcessarContaEmCliqueNoUsuario()
        {

            #region Parameters
            string nomeEsperado = "Alterar Conta";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            minhaConta.ClicarEmLinkUsuarioLogado();

            Assert.That(minhaConta.CapturaTextoNaAba(nomeEsperado).Contains(nomeEsperado));

        }

        [Test]
        [Parallelizable]
        [Category("Acessar Conta")]
        public void AcessarAbaMinhaConta()
        {
            #region Parameters
            string nomeEsperado = "Alterar Conta";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            minhaConta.ClicarDropdownUsuarioLogado();

            minhaConta.ClicarEmAbaMinhaConta();

            Assert.That(minhaConta.CapturaTextoNaAba(nomeEsperado).Contains("Alterar Conta"));
        }

        [Test]
        [Category("Acessar Conta")]
        public void AcessarAbaPreferencia()
        {
            #region Parameters
            string nomeEsperado = "Preferências da Conta";
            #endregion
            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            minhaConta.ClicarEmAbaPreferencia();

            Assert.True(minhaConta.CapturaTextoNaAba(nomeEsperado).Contains(nomeEsperado));
        }

        [Test]
        [Category("Acessar Conta")]
        public void AcessarAbaGerenciarColunas()
        {

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            minhaConta.ClicarEmAbaGerenciarColunas();

            Assert.True(minhaConta.GetBotaoAtualizarColunas());
        }

        [Test]
        [Category("Acessar Conta")]
        public void AcessarAbaPerfil()
        {

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            minhaConta.ClicarEmAbaPerfil();

            Assert.True(minhaConta.GetBotaoAddPerfil());


        }

        [Test]
        [Category("Acessar Conta")]
        public void AcessarAbaTokenAPI()
        {
            #region Parameters
            string nomeEsperado = "Criar token API";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            minhaConta.ClicarEmAbaToken();

            Assert.True(minhaConta.CapturaTextoNaAba(nomeEsperado).Contains(nomeEsperado));
        }

    }
}
