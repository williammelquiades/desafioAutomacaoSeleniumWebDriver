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
        public void CriarProjetoViaQuerieBD(string nameProjeto, string descricaoProjeto)
        {
        
        }

        public static int RetornaQuantidadeDeProjetosCriadosDB()
        {
            string executQuerie = QueriesGerenciar.BuscarQuantidadeDeProjetosEmBanco;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(executQuerie)[0]);
        }

        // Querys para Gerenciar Marcadores
        public static void CriarMarcadorViaDB(string nomeMarcador, String descricaoMarcador)
        {
            string executQuerie = QueriesGerenciar.AdicionarNovoMarcador.Replace("$marcadorDB", nomeMarcador).Replace("$descriçãoDB", descricaoMarcador);
            DataBaseHelpers.ExecuteQuery(executQuerie);
        }

        public static string RetornaQuantidadeDeMarcadorPorNome(string nome)
        {
            string queryMarcador = QueriesGerenciar.SelecionarMarcadorPeloNome.Replace("$tag", nome);
            return DataBaseHelpers.RetornaDadosQuery(queryMarcador)[0];
        }

        public static int VerificarMarcadorDeletadoDB(string nome)
        {
            string queryMarcador = QueriesGerenciar.PesquisarSeMarcadorXPTOFoiDeletado.Replace("$marcador", nome);
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(queryMarcador)[0]);
        }

        public static int RetornaQuantidadeTotalDeMarcadoresDB()
        {
            string executQuerie = QueriesGerenciar.RetornarTotalDeMarcadorEmBanco;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(executQuerie)[0]);
        }
        // Fim Gerenciar Marcadores
    }
}
