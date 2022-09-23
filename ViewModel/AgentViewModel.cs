using Ivanov.Model;
using Ivanov.Services;
using System.Collections.ObjectModel;

namespace Ivanov.ViewModel
{
    public class AgentViewModel : BindableObject
    {
        private Agent _selectedltem;
        AgentService agentService = new();
        public ObservableCollection<Agent> Agents { get; } = new();
        public AgentViewModel()
        {
            GetAgentsAsync();
        }
        public string Desc{get; set;}
        public Agent Selectedltem
        {
            get =>_selectedltem;
            set
            {
                _selectedltem = value;
                Desc = value?.Description;
                OnPropertyChanged(nameof(Desc));
            }
        }
        async Task GetAgentsAsync()
        {
            try
            {
                var agents= await agentService.GetAgent();
                if (Agents.Count != 0)
                    Agents.Clear();
                foreach(var agent in agents)
                {
                    Agents.Add(agent);
                }
            }
            catch(Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка!", $"Что-то пошло не так:{ex.Message}", "OK");
            }
        }
    }
}
