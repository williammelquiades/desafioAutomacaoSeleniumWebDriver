using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Flows;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class GerenciarCamposPersonalizadosTests : TestBase
    {

        #region Pages and Flows Objects
        String USUARIO = ConfigurationManager.AppSettings["username"].ToString();
        String SENHA = ConfigurationManager.AppSettings["password"].ToString();
        [AutoInstance] LoginFlows loginInSystem;
        [AutoInstance] MenuMantis menuMantis;
        [AutoInstance] GerenciarCamposPersonalizadosPage formularioCamposPersonalizados;
        #endregion

        [Test]
        public void CriarCampoPersonalizadoComSucesso() {

            #region Parameters
            String campoInfoPersonalizado = "Camp Person " + GeneralHelpers.ReturnStringWithRandomCharacters(4);
            #endregion


            // ações de teste
            loginInSystem.EfetuarLogin(USUARIO,SENHA);

            menuMantis.ClicarItemMenuGerenciar();

            formularioCamposPersonalizados.ClicarEmAba();
            formularioCamposPersonalizados.PreencherNovoCampoPersonalizado(campoInfoPersonalizado);
            formularioCamposPersonalizados.ClicarEmNovo();


            //Assert
        }

    }
}
