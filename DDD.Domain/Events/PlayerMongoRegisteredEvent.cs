using System;
using DDD.Infra.CrossCutting.Bus.Core.Messages.Integration;

namespace DDD.Domain.Events
{
    public class PlayerMongoRegisteredEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? TeamId { get; set; }

        public PlayerMongoRegisteredEvent(Guid id, string name, Guid? teamId)
        {
            Id = id;
            Name = name;
            TeamId = teamId;
        }
    }
}