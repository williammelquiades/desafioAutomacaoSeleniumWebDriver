using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System;
using System.Configuration;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class CategoriasGlobaisTests : TestBase

    {
        #region Pages and Flows Objects
        string USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        string SENHA   = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows loginInSystem;
        [AutoInstance] MenuMantis menuMantis;
        [AutoInstance] GerenciarProjetosPage emGerenciarProjetos;
        [AutoInstance] CategoriaGlobalPage emCategoriaGlobal;
        #endregion
        
        [Test]
        public void CriarCategoriaGlobalComSucesso() {
           
            #region Parameters
            String nomeNovaCategoria = "Categoria[" + GeneralHelpers.ReturnStringWithRandomNumbers(2)+ "]";
            #endregion

            loginInSystem.EfetuarLogin(USUARIO, SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            emGerenciarProjetos.ClicarEmAbaGerenciarProjeto();
            emCategoriaGlobal.PreencherCategoriaGlobal(nomeNovaCategoria);
            emCategoriaGlobal.ClicarAdicionarEmNovaCategoria();

            //Desenvolver retorno //Assert.AreEqual(mensagem);
        }

        /*
        [Test]
        public void AlterarCategoriaGlobal() { }

        [Test]
        public void ExcluirCategoriaGlobal() { }
        */
    }
}
