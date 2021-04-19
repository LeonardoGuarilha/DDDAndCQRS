using System.Threading.Tasks;
using DDD.Infra.CrossCutting.Bus.Core.Data;
using Flunt.Notifications;

namespace DDD.Infra.CrossCutting.Bus.Core.Messages
{
    public class CommandHandler : Notifiable, ICommandHandler
    {

        private void AdicionarErros(string mensagem)
        {
            AddNotification("Error", mensagem);
        }

        public async Task<CommandResult> PersistirDados(IUnitOfWork uow)
        {
            if (!await uow.Commit()) 
                AdicionarErros("Houve um erro ao persistir os dados");

            return Valid ? new CommandResult(true, "success", null) 
                : new CommandResult(false, "error", null);
        }
    }
}