﻿using CSharpSeleniumTemplate.Helpers;
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
        public static void CriarProjetoViaQuerieBD(string nameProjeto, string descricaoProjeto)
        {
            string insertQuerie = GerenciarQueries.AdicionaProjetoPadrao
            .Replace("$nomeProjeto", nameProjeto)
            .Replace("$descricaoProjeto", descricaoProjeto);
            DataBaseHelpers.ExecuteQuery(insertQuerie);

        }

        public static int RetornaQuantidadeDeProjetosCriadosDB()
        {
            string executQuerie = GerenciarQueries.BuscarQuantidadeDeProjetosEmBanco;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(executQuerie)[0]);
        }

        public static string RetonarCategoriaCriadaDB(string novaCategoria)
        {
            string executQuerie = GerenciarQueries.BuscarCategoriaCriada.Replace("$novaCategoria", novaCategoria);
            return DataBaseHelpers.RetornaDadosQuery(executQuerie)[3];
        }

        // Querys para Gerenciar Marcadores
        public static void CriarMarcadorViaDB(string nomeMarcador, String descricaoMarcador)
        {
            string executQuerie = GerenciarQueries.AdicionarNovoMarcador.Replace("$marcadorDB", nomeMarcador).Replace("$descriçãoDB", descricaoMarcador);
            DataBaseHelpers.ExecuteQuery(executQuerie);
        }

        public static string RetornaQuantidadeDeMarcadorPorNome(string nome)
        {
            string queryMarcador = GerenciarQueries.SelecionarMarcadorPeloNome.Replace("$tag", nome);
            return DataBaseHelpers.RetornaDadosQuery(queryMarcador)[0];
        }

        public static int VerificarMarcadorDeletadoDB(string nome)
        {
            string queryMarcador = GerenciarQueries.PesquisarSeMarcadorXPTOFoiDeletado.Replace("$marcador", nome);
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(queryMarcador)[0]);
        }

        public static int RetornaQuantidadeTotalDeMarcadoresDB()
        {
            string executQuerie = GerenciarQueries.RetornarTotalDeMarcadorEmBanco;
            return Convert.ToInt32(DataBaseHelpers.RetornaDadosQuery(executQuerie)[0]);
        }
        // Fim Gerenciar Marcadores
    }
}
