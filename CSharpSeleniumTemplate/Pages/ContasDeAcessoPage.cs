using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class ContasDeAcessoPage : PageBase
    {
        #region Mapping
        //Menu top
        By menuUsuarioLogado = By.XPath("//ul//li[@class='grey']//span");
        By linkMinhasContaDrop = By.XPath("(//a[contains(@href,'/account_page.php')])[1]");

        By nomeAbaConta = By.XPath("(//h4[contains(.,'Alterar Conta')])");

        By linkPreferencia = By.LinkText("Preferências");
        By linkGerenciarColunas = By.LinkText("Gerenciar Colunas");
        By linkProfile = By.XPath("//div[2]/div[2]/div/ul/li[4]/a");
        By linkTokenApi = By.LinkText("Tokens API");

        By botaoAtualizarUsuario = By.XPath("//input[@value='Atualizar Usuário']");
        By botaoAtualizarPreferencia = By.XPath("//input[@value='Atualizar Preferências']");
        By botaoAtualizarColunas = By.Name("update_columns_for_current_project");
        By botaoAdicionarPerfil = By.XPath("//input[@value='Adicionar Perfil']");
        By btnCreateTokenApi = By.XPath("//input[@value='Criar Token API']");
        By btnRevoke = By.XPath("//form[@id='revoke-api-token-form']/fieldset/input[3]");

        By btnSend = By.XPath("//input[@value='Enviar']");

        By fieldPlatform = By.Id("platform");
        By fieldSO = By.Id("os");
        By fieldSOVersion = By.Id("os-version");
        By fieldTokenName = By.Id("token_name");

        By selecionarPerfil = By.Id("select-profile");
        By radiouttonDelete = By.XPath("//tr[3]/td[2]/label/span");


        By mensagemTokenCriado = By.ClassName("lead red");    
        By msgTokenRevoke = By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]");

        #endregion

        #region Action
        //Acões
        public void ClicarDropdownUsuarioLogado()
        {
            Click(menuUsuarioLogado);
        }

        public void ClicarEmLinkUsuarioLogado()
        {
            Click(By.XPath("(//a[contains(@href,'/account_page.php')])[2]"));
        }

        public void ClicarEmAbaMinhaConta()
        {
            Click(By.XPath("(//a[contains(@href,'/account_page.php')])[1]"));
        }

        public void ClicarEmSair()
        {
            Click(By.XPath("(//a[contains(@href,'/logout_page.php')])"));
        }

        public void ClicarEmMinhaConta()
        {
            Click(linkMinhasContaDrop);
        }

        public void ClicarEmAbaPreferencia()
        {
            Click(linkPreferencia);
        }

        public void ClicarEmAbaGerenciarColunas()
        {
            Click(linkGerenciarColunas);
        }

        public void ClicarEmAbaPerfil()
        {
            Click(linkProfile);
        }

        public void ClicarEmAbaToken()
        {
            Click(linkTokenApi);
        }


        //Validacoes
        public string CapturaTextoNaAba(string nomeEsperado)
        {
            return GetText(By.XPath("(//h4[contains(.,'" + nomeEsperado + "')])"));
        }

        public bool GetBotaoAtualizarUsuario()
        {
            return ReturnIfElementIsDisplayed(botaoAtualizarUsuario);
        }

        public bool GetBotaoAtualizarPreferencias()
        {
            return ReturnIfElementIsDisplayed(botaoAtualizarPreferencia);
        }

        public bool GetBotaoAtualizarColunas()
        {
            return ReturnIfElementIsDisplayed(botaoAtualizarColunas);
        }

        public bool GetBotaoAddPerfil()
        {
            return ReturnIfElementIsDisplayed(botaoAdicionarPerfil);
        }

        #endregion
    }
}
