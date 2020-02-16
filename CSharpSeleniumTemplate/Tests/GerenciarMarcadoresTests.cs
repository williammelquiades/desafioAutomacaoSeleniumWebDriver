using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using CSharpSeleniumTemplate.Flows;
using NUnit.Framework;
using System.Collections;
using System.Configuration;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class GerenciasMarcadoresTests : TestBase
    {
        #region Pages and Flows Objects
        LoginFlows loginFlows;
        //LoginPage loginPage;
        MenuMantis menuMantis;
        //GerenciarProjetosPage gerenciarProjeto;
        GerenciarMarcadoresPage gerenciarMarcadores;
        #endregion

        [Test]
        [Category("Validar Criacao de marcadores")]
        public void CriarNovoMarcorComSucesso()
        {

            loginFlows = new LoginFlows();
            //  loginPage = new LoginPage();
            menuMantis = new MenuMantis();
            gerenciarMarcadores = new GerenciarMarcadoresPage();

            #region Parameters
            string usuario = ConfigurationManager.AppSettings["username"].ToString();
            string senha = ConfigurationManager.AppSettings["password"].ToString();
            string textoNomeMarcador = "Marcador " + GeneralHelpers.ReturnStringWithRandomNumbers(3);
            string textoDescricaoMarcador = "Marcador de teste automático" + GeneralHelpers.ReturnStringWithRandomCharacters(5);
            #endregion

            loginFlows.EfetuarLogin(usuario, senha);

            menuMantis.ClicarItemMenuGerenciar();
            gerenciarMarcadores.ClicarEmAbaGerenciarMarcadores();
            gerenciarMarcadores.PreencherNomeMarcado(textoNomeMarcador);
            gerenciarMarcadores.preencherDescricaoMarcador(textoDescricaoMarcador);
            //gerenciarMarcadores.ClicarEmCriarMarcador();

            //Assert.AreEqual(mensagemEsperada, gerenciarProjeto.RetornaMensagem());

        }
    }
}
