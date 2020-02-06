using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.Bases
{
    public class MenuMantis : PageBase
    {
        #region Mapping
        //Item de menu: de Minhas Vissão
        By categoryComboBox = By.Name("category_id");

        //Item de menu: Ver Tarefas
        By clicarEmCriarTarefas = By.XPath("//a[@href='/bug_report_page.php']");

        //Item de menu: Criar Tarefa
        By clicarEmCriarTarefa = By.XPath("//a[@href='/bug_report_page.php']");

        //Item de menu: Registro de Mudanças
        By clicarEmRegistroDeMudanca = By.XPath("//a[@href='/changelog_page.php']");

        //Item de menu: Planejamento
        By clicarEmPlanejamento = By.XPath("//a[@href='/roadmap_page.php']");

        //Item de menu: Resumo
        By clicarEmResumo = By.XPath("//a[@href='/summary_page.php']");

        //Item de menu: Gerenciamento  e subItem
        By clicarEmGerenciar = By.XPath("//a[@href='/manage_overview_page.php']");
        
        #endregion

        #region Actions
        //Actions de Minha Visão

        //Actions Ver Tarefas

        //Actions Registro de Mudanças

        //Actions Planejamento

        //Actions Resumo

        //Actions Gerenciamento
        public void ClicarItemMenuGerenciar() { Click(clicarEmGerenciar); }
        #endregion
    }
}
