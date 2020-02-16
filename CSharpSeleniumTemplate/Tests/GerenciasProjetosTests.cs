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
    public class GerenciasProjetosTests : TestBase
    {
        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows loginInSystem;
        MenuMantis menuMantis;
        GerenciarProjetosPage gerenciarProjeto;
        #endregion

        [Test]
        public void CriarNovoProjetoComSucesso()
        {

            menuMantis = new MenuMantis();
            gerenciarProjeto = new GerenciarProjetosPage();
            

            #region Parameters
            string nomeProjeto = "Proj Test " + GeneralHelpers.ReturnStringWithRandomNumbers(2);
            string setEstado = "release";
            string setVisibilidade = "private"; // public - private || privado
            string descricaoProjeto = "Descrição teste automático" + GeneralHelpers.ReturnStringWithRandomCharacters(50);
            string mensagemEsperada = "Operation successful.";//"Operação realizada com sucesso."; "Operation successful.";
            //    string caminhoArquivo = GeneralHelpers.ReturnProjectPath() + "Resources/Files/anexo_ocorrencia.jpg";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO,SENHA);

            menuMantis.ClicarItemMenuGerenciar();
            gerenciarProjeto.ClicarEmAbaGerenciarProjeto();
            gerenciarProjeto.ClicarEmNovoProjeto();
            gerenciarProjeto.PreencherNomeProjeto(nomeProjeto);
            gerenciarProjeto.SelecionarEstado(setEstado);
            gerenciarProjeto.SelecionarVisibilidade(setVisibilidade);
            gerenciarProjeto.SetDescricao(descricaoProjeto);
            gerenciarProjeto.clicarEmAdicionar();

            //Assert.AreEqual(mensagemEsperada, gerenciarProjeto.RetornaMensagem());

        }
    }
}
