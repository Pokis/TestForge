namespace TestForge.OpenAI
{
    public class OpenAiSettings
    {
        public string ApiKey { get; set; }
        public string OrganisationId { get; set; }

        public OpenAiSettings(string apiKey, string organisationId)
        {
            ApiKey = apiKey;
            OrganisationId = organisationId;
        }
    }
}