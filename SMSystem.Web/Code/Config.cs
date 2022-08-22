using Microsoft.Extensions.Configuration;
using SMSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMSystem.Web.Code
{
    public class Config
    {
        private readonly IConfiguration configuration;

        public Config()
        {

        }
        public Config(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void SetConString()
        {

            ConfigDictionary.keyValuePairs.Add("ConString", @"Server=.\SQLEXPRESS;DataBase=DBSMSystem;Integrated Security=True");

        }
    }
}
