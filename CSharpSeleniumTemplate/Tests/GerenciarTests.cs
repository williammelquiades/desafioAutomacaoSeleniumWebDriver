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
    public class GerenciarTests : TestBase
    {
        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows loginInSystem;
        [AutoInstance] GerenciarPage gerenciarPage;
        [AutoInstance] MenuMantis menuMantis;
        #endregion

        [Test]
        [Category("AcessarAbas")]
        public void AcessarAbaInformacaoSite()
        {
            #region Parameters
            string nameEsperado = "Informação do Site";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmAbaInformacaoSite();

            Assert.Multiple(() =>
            {
                Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDoFormulario());
            });
        }

        [Test]
        [Category("AcessarAbas")]
        public void AcessarAbaGerenciarUsuario()
        {
            #region Parameters
            string nameEsperado = "Gerenciar Contas";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            gerenciarPage.ClicarEmGerenciarUsuario();

            Assert.AreEqual(nameEsperado, gerenciarPage.CapturarNomeDoFormulario());
        }
    }
}
