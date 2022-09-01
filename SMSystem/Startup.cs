using Microsoft.Extensions.DependencyInjection;
using SMSystem.Code;
using SMSystem.Core;
using SMSystem.Data;

namespace SMSystem
{
    public class Startup
    {
        //private readonly IServiceCollection services;
        private readonly ServiceCollection services;
        private readonly ServiceProviderOptions serviceProvider;
        private readonly DependencyInjection dependency;
        public Startup()
        {
            serviceProvider = new ServiceProviderOptions();
            services = new ServiceCollection();
            ConfigureServices();
            dependency = new DependencyInjection();
            ConfigDictionary.keyValuePairs.Add("ConString", Properties.Settings.Default.SQLServerConString);
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices()
        {
            services.AddSingleton<IDataHelper<Stores>, StoreEntity>();
            services.BuildServiceProvider(serviceProvider);
        }


    }
}
