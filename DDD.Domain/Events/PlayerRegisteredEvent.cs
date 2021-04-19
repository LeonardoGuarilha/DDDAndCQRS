using System;
using DDD.Infra.CrossCutting.Bus.Core.Messages.Integration;

namespace DDD.Domain.Events
{
    public class PlayerRegisteredEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? TeamId { get; set; }

        public PlayerRegisteredEvent(Guid id, string name, Guid? teamId)
        {
            Id = id;
            Name = name;
            TeamId = teamId;
        }
    }
}