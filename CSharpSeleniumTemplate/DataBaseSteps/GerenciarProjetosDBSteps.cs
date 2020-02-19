using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    class GerenciarProjetosDBSteps
    {
        public void CriarProjetoViaQuerieBD(string nameProjeto, string descricaoProjeto) { }

        public static int RetornaQuantidadeDeProjetosCriadosDB()
        {
            string executQuerie = QueriesGerenciar.BuscaQuantidadeDeProjetosEmBanco;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(executQuerie)[0]);
        }
    }
}
