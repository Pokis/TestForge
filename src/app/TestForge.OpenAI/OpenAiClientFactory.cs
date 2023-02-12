using Microsoft.Extensions.Configuration;

namespace TestForge.OpenAI
{
    public class OpenAiClientFactory
    {
        public OpenAiCodeClient Create()
        {
            var builder = new ConfigurationBuilder().AddUserSecrets<OpenAiClientFactory>();
            var configuration = builder.Build();

            string apiKey = configuration["OpenAI:ApiKey"];
            string organisationId = configuration["OpenAI:OrganisationId"];

            var openAiSettings = new OpenAiSettings(apiKey, organisationId);

            return new OpenAiCodeClient(openAiSettings);
        }
    }
}
