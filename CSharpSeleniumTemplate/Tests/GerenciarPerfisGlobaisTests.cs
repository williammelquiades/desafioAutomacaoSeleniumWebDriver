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
    class GerenciarPerfisGlobaisTests : TestBase
    {
        #region Pages and Flows Objects
        [AutoInstance] LoginFlows loginInSystem;
        [AutoInstance] MenuMantis menuMantis;
        [AutoInstance] GerenciarPerfisGlobaisPage emPerfilGlobal;
        #endregion

        [Test]
        public void CriarPerfilGlobal() {

            #region Parameters
            String usuario = ConfigurationManager.AppSettings["username"].ToString();
            String senha = ConfigurationManager.AppSettings["password"].ToString();
            String plataforma = "Test";
            String sistemaOperaciona = "Automacao";
            String versaoSistema = GeneralHelpers.ReturnStringWithRandomNumbers(4);
            String descricaoAdicional = "Descrição SO " + GeneralHelpers.ReturnStringWithRandomCharacters(4);
            #endregion

            loginInSystem.EfetuarLogin(usuario,senha);

            menuMantis.ClicarItemMenuGerenciar();
            emPerfilGlobal.ClicarEmAba();
            emPerfilGlobal.PreencherCampoNomePlataforma(plataforma);
            emPerfilGlobal.PreencherCampoNomeSO(sistemaOperaciona);
            emPerfilGlobal.PreenhcerCampoVersaoSO(versaoSistema);
            emPerfilGlobal.PreencherCampoDescricao(descricaoAdicional);
            //emPerfilGlobal.ClicarEmAdicionarPerfil();
        }

    }
}
