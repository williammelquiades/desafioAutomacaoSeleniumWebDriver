using CSharpSeleniumTemplate.Helpers;
using CSharpSeleniumTemplate.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSeleniumTemplate.DataBaseSteps
{
    class VerTarefasDBSteps
    {

        public static void MassaDeTestesVerTaredasBD()
        {
            string executQueries = VerTarefasMassaQueries.TarefasVerFullStack;
            DataBaseHelpers.ExecuteQuery(executQueries);
        }


    }
}
