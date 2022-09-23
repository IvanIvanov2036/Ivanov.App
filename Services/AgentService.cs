using Ivanov.Model;
using System.Text.Json;

namespace Ivanov.Services
{
    public class AgentService
    {
        List<Agent> agentList = new();
        public async Task<IEnumerable<Agent>>GetAgent()
        {
            if (agentList?.Count > 0)
                return agentList;
            using var stream = await FileSystem.OpenAppPackageFileAsync("agent.json");
            using var reader=new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            agentList=JsonSerializer.Deserialize<List<Agent>>(contents);
            return agentList;
        }
    }
}
