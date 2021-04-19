using System;
using DDD.Infra.CrossCutting.Bus.Core.Messages;
using Flunt.Notifications;
using Flunt.Validations;

namespace DDD.Domain.Commands
{
    public class RegisterNewPlayerCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? TeamId { get; set; }
        
        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(Id, "Id", "O Id não pode ser nule")
                .IsNotNull(Name, "Name", "O nome não pode ser nulo"));
            
        }
    }
}