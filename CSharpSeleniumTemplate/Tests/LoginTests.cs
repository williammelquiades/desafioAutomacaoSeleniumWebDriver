using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.DataBaseSteps;
using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Pages;
using NUnit.Framework;
using System.Collections;
using System.Configuration;

namespace CSharpSeleniumTemplate.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        #region Pages and Flows Objects
        //LoginPage loginPage;
        MainPage mainPage;
        [AutoInstance] LoginPage loginPage;
        [AutoInstance] ContasDeAcessoPage minhaConta;

      
        #endregion

        #region Data Driven Providers
        public static IEnumerable EfetuarLoginInformandoUsuarioInvalidoIProvider()
        {
            return GeneralHelpers.ReturnCSVData(GeneralHelpers.ReturnProjectPath() + "Resources/TestData/Login/EfetuarLoginInformandoUsuarioInvalidoData.csv");
        }
        #endregion

        [Test]
        public void EfetuarLoginComSucesso()
        {
            //loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = ConfigurationManager.AppSettings["username"].ToString();
            string senha = ConfigurationManager.AppSettings["password"].ToString();
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();


            Assert.Multiple(() =>
            {
                Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
            });
        }

        [Test]
        public void EfetuarLoginComSucessoComJAVASCRIPT()
        {
            //loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = ConfigurationManager.AppSettings["username"].ToString();
            string senha = ConfigurationManager.AppSettings["password"].ToString();
            #endregion

            loginPage.PreencherUsuarioJS(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenhaJS(senha);
            loginPage.ClicarEmLogin();


            Assert.Multiple(() =>
            {
                Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
            });
        }


        [Test]
        public void EfetuarLoginInformandoSenhaInvalida()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = ConfigurationManager.AppSettings["username"].ToString();
            string senha = "rooot";
            string mensagemErroEsperada = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos."; 
                //"Your account may be disabled or blocked or the username/password you entered is incorrect.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErroEsperada, loginPage.RetornaMensagemDeErro());
        }


        //Exemplo utilizando um retorno de uma query de banco de dados
        [Test]
        public void EfetuarLoginDBComSucesso()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = "administrator"; // Buscar descrição do banco
            //string senha = UsuariosDBSteps.RetornaSenhaDoUsuario(usuario);
            string senha = ConfigurationManager.AppSettings["password"].ToString();
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(usuario, mainPage.RetornaUsernameDasInformacoesDeLogin());
        }

        [Test, TestCaseSource("EfetuarLoginInformandoUsuarioInvalidoIProvider")]
        public void EfetuarLoginInformandoUsuarioInvalido(ArrayList testData)
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = testData[0].ToString();
            string senha = testData[1].ToString();
            string mensagemErroEsperada = "Sua conta pode estar desativada ou bloqueada ou o nome de usuário e a senha que você digitou não estão corretos.";
                //"Your account may be disabled or blocked or the username/password you entered is incorrect.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            Assert.AreEqual(mensagemErroEsperada, loginPage.RetornaMensagemDeErro());
        }

        [Test]
        [Category("Acessar Conta")]
        public void RealizarLogoff()
        {
            loginPage = new LoginPage();
            mainPage = new MainPage();

            #region Parameters
            string usuario = ConfigurationManager.AppSettings["username"].ToString();
            string senha = ConfigurationManager.AppSettings["password"].ToString();
            string mensagemErroEsperada = "Your account may be disabled or blocked or the username/password you entered is incorrect.";
            #endregion

            loginPage.PreencherUsuario(usuario);
            loginPage.ClicarEmLogin();
            loginPage.PreencherSenha(senha);
            loginPage.ClicarEmLogin();

            minhaConta.ClicarEmAbaToken();

            minhaConta.ClicarDropdownUsuarioLogado();

            minhaConta.ClicarEmSair();
        }

    }
}
