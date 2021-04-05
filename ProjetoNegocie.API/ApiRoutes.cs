using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNegocie.API
{
    public static class ApiRoutes
    {
        private const string Base = "api/";

        public static class Endereco
        {
            private const string Prefix = Base + "endereco/";

            public const string GetFromDB = Prefix + "getDB" + "{cep}";
            public const string GetFromAPI = Prefix + "getAPI" + "{cep}";

            public const string PostDB = Prefix;

        }
    }
}
