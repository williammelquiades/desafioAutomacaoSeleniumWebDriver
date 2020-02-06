using CSharpSeleniumTemplate.Bases;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Pages
{
    class CategoriasGlobaisPage :PageBase
    {
        #region Mapping
        By abaGerenciarProjetos = By.XPath("//a[@href='/manage_proj_page.php']");
        By botãoAdicionarCategoria = By.XPath("//input[@type='submit' or contains(text(), 'Adicionar Categoria')]");
        By campoNovaCategoria = By.Name("name");
        #endregion

        #region Actions
        public void ClicarEmAbaGerenciarProjeto()
        {
            Click(abaGerenciarProjetos);
        }

        public void PreencherNomeCategoria(string nomeCategoria)
        {
            SendKeys(this.campoNovaCategoria, nomeCategoria);
        }

        public void clicarEmAdicionar()
        {
            Click(botãoAdicionarCategoria);
        }

        public void RetornoValidacao() { 
            // Validar criação de nova categoria
        }
        #endregion
    }
}
