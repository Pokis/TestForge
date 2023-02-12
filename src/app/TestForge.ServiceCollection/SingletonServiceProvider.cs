using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenAI.GPT3.Extensions;

namespace TestForge.ServiceCollection
{
    public class SingletonServiceProvider
    {
        private static SingletonServiceProvider _instance;
        private static readonly object _lock = new object();
        private ServiceProvider _serviceProvider;

        private SingletonServiceProvider()
        {
            var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public static SingletonServiceProvider Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonServiceProvider();
                        }
                    }
                }

                return _instance;
            }
        }

        public T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Add any required services to the collection here.
            AddOpenApi(services);
        }

        private void AddOpenApi(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<SingletonServiceProvider>();
            var configuration = builder.Build();

            string apiKey = configuration["OpenAI:ApiKey"];

            services.AddOpenAIService(settings =>
            {
                settings.ApiKey = apiKey;
            });
        }
    }
}