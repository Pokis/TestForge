using OpenAI.GPT3.Interfaces;
using OpenAI.GPT3.ObjectModels;
using OpenAI.GPT3.ObjectModels.RequestModels;
using TestForge.ServiceCollection;

namespace TestForge.OpenAI
{
    public class OpenAiCodeClient
    {
        private readonly OpenAiSettings _settings;
        private readonly IOpenAIService _openAiService;

        public OpenAiCodeClient(OpenAiSettings settings)
        {
            _settings = settings;
            _openAiService = SingletonServiceProvider.Instance.GetService<IOpenAIService>();
            _openAiService.SetDefaultModelId(Models.CodeDavinciV2);
        }

        public void Test()
        {
            _openAiService.Edit.CreateEdit(new EditCreateRequest()
            {
                
            });
        }
    }
}
