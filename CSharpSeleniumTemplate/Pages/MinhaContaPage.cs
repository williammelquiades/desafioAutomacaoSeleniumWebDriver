using CSharpSeleniumTemplate.Bases;
using CSharpSeleniumTemplate.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class MinhaContaPage : PageBase
    {
        #region Mapping
        By linkMinhasConta = By.XPath("(//a[contains(@href,'/account_page.php')])[2]");
        By linkPreferencias = By.LinkText("Preferências");
        By linkManageColumns = By.LinkText("Gerenciar Colunas");
        By linkProfile = By.XPath("//div[2]/div[2]/div/ul/li[4]/a");
        By linkTokenApi = By.LinkText("Tokens API");

        By btnRefreshUser = By.XPath("//input[@value='Atualizar Usuário']");
        By btnRefreshPreferences = By.XPath("//input[@value='Atualizar Preferências']");
        By btnRefreshColumns = By.Name("update_columns_for_current_project");
        By btnCreateTokenApi = By.XPath("//input[@value='Criar Token API']");
        By btnRevoke = By.XPath("//form[@id='revoke-api-token-form']/fieldset/input[3]");
        By btnAddProfile = By.XPath("//input[@value='Adicionar Perfil']");
        By btnSend = By.XPath("//input[@value='Enviar']");

        By fieldPlatform = By.Id("platform");
        By fieldSO = By.Id("os");
        By fieldSOVersion = By.Id("os-version");
        By fieldTokenName = By.Id("token_name");

        By selectProfile = By.Id("select-profile");
        By radioDelete = By.XPath("//tr[3]/td[2]/label/span");


        By returnMsgCreateToken = By.XPath("//div[2]/div[2]/div[2]/div/div/div");
        By firstElementTable = By.XPath("//div[4]/div/div[2]/div/div/table/tbody/tr/td");
        By msgTokenRevoke = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]");

        public string tokenRevoked;
        public string plataforma = GeneralHelpers.ReturnStringWithRandomCharacters(5);
        public string so = GeneralHelpers.ReturnStringWithRandomCharacters(2);
        public string versao = GeneralHelpers.ReturnStringWithRandomNumbers(2);
        public int amountOption;
        public int restOption;
        #endregion

        #region Actions
        public void ClicarAlterarConta()
        {
            Click(linkMinhasConta);
        }

        public void ClicarPreferencias()
        {
            Click(linkPreferencias);
        }

        public void ClicarGerenciarColunas()
        {
            Click(linkManageColumns);
        }

        public void ClicarPerfil()
        {
            Click(linkProfile);
        }

        public void ClicarEmTokenApi()
        {
            Click(linkTokenApi);
        }

        public void ClicarCriarTokenApi()
        {
            Click(btnCreateTokenApi);
        }

        public void ClicarEmRevogar()
        {
            Click(btnRevoke);
        }

        public void ClicarEmAdicionarPerfil()
        {
            Click(btnAddProfile);
        }

        public void ClicarEmApagar()
        {
            Click(radioDelete);
            restOption = amountOption;
            restOption--;
        }

        public void ClicarEnviar()
        {
            Click(btnSend);
        }

        public void PreecherCampoNomeToken(string token)
        {
            SendKeys(fieldTokenName, token);
        }

        public void PreencherCampoPlataforma(string plataforma)
        {
            SendKeys(fieldPlatform, plataforma);
        }

        public void PreencherCampoSO(string so)
        {
            SendKeys(fieldSO, so);
        }

        public void PreencherCampoVersaoSO(string versao)
        {
            SendKeys(fieldSOVersion, versao);
        }

        /*
        public void SelecionarPerfil()
        {
            SendKeysArrowDown(selectProfile);
        }
        */

        public bool GetBotaoAtualizarUsuario()
        {
            return ReturnIfElementIsDisplayed(btnRefreshUser);
        }

        public bool GetBotaoAtualizarPreferencias()
        {
            return ReturnIfElementIsDisplayed(btnRefreshPreferences);
        }

        public bool GetBotaoAtualizarColunas()
        {
            return ReturnIfElementIsDisplayed(btnRefreshColumns);
        }

        public bool ValidarAbaPerfil()
        {
            return ReturnIfElementIsDisplayed(fieldPlatform);
        }

        public bool ValidarAbaTokenApi()
        {
            return ReturnIfElementIsDisplayed(fieldTokenName);
        }

        /*
        public bool VerificarSeExisteToken()
        {
            return ReturnIfElementExists(firstElementTable);
        }

        public bool VerificarExistenciaDePerfil()
        {
            return ReturnIfElementExists(selectProfile);
        }
        */

        public string ValidarRetornoCriarToken()
        {
            return GetText(returnMsgCreateToken);
        }

        public string ValidarRetornoRevogarToken()
        {
            return GetText(msgTokenRevoke);
        }

        public void GetTokenRevogado()
        {
            tokenRevoked = GetText(firstElementTable);
        }

        public string GetMsgObrigatorioPlataforma(string atributo)
        {
            return GetAttribute(fieldPlatform, atributo);
        }

        public string GetMsgObrigatorioOS(string so)
        {
            return GetAttribute(fieldSO, so);
        }

        public string GetMsgObrigatorioVersao(string versao)
        {
            return GetAttribute(fieldSOVersion, versao);
        }

        public string GetValorPerfilAdicionado()
        {
            return plataforma + " " + so + " " + versao;
        }

        /*
        public string retornaValorDB()
        {
            List<string> controle = ProfileDBSteps.RetornaListPerfilDB(so);
            string plataformas;
            for (int i = 0; i < controle.Count; i++)
            {

                if (controle[i] == plataforma)
                {

                    plataformas = controle[i];
                }
            }
            return plataforma;
        }

        public string RetornaPerfisAdicionado()
        {
            return GetText(selectProfile);
        }

        public void RetornaQuantidadeDeOpcoesNoComboBox()
        {
            amountOption = ReturnAmountElementInComboBox(selectProfile);
        }*/
        #endregion
    }
}
