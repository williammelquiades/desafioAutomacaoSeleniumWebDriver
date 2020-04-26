using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    public class MassaStartDBSteps
    {

        public static void CriaMassaDeTestesDB()
        {
            string executQueries = MassaQueries.TarefasVerFullStack;
            DataBaseHelpers.ExecuteQuery(executQueries);
        }

        public static void ClearMassaDeTestsDB()
        {
            string executQueries = MassaQueries.LimparBaseFullStack;
            DataBaseHelpers.ExecuteQuery(executQueries);
        }


    }
}
