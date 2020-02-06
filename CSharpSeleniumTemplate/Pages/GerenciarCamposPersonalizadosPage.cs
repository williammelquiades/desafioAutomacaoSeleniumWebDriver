using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    public class GerenciarCamposPersonalizadosPage : PageBase
    {
        #region Mapping
        By abaGerenciarCamposPersonalizados = By.XPath("//a[@href='/manage_custom_field_page.php']");
        By campoInputNovoCampoPersonalizado = By.ClassName("input-sm");
        By botaoNovoCampoPersonalizado = By.XPath("//input[@type='submit' or contains(text(), 'Novo Campo Personalizado')]");
        By listItenstabela = By.XPath("//*[@class='table-responsive']//tbody//tr//td//a");

        #endregion

        #region Actions

        public void ClicarEmAba() {
            Click(abaGerenciarCamposPersonalizados);
        }

        public void PreencherNovoCampoPersonalizado(string novoCampoPersonalizado) {
            SendKeys(this.campoInputNovoCampoPersonalizado, novoCampoPersonalizado);
        }

        public void ClicarEmNovo() {
            Click(botaoNovoCampoPersonalizado);
        }

        public void ValidarItemCriadoEmTabela() { 
            // Criar validaçao de item em tela 
        }
        #endregion
    }
}
