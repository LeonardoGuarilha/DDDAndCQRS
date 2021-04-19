using System;
using DDD.Infra.CrossCutting.Bus.Core.DomainObjects;

namespace DDD.Domain.Models
{
    public class Player : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public Guid? TeamId { get; private set; }

        public Player(string name, Guid? teamId)
        {
            Name = name;
            TeamId = teamId;
        }
        
        protected Player() {}

        public void ChangeName(string name)
        {
            Name = name;
        }

        public void AddTeam(Guid teamId)
        {
            TeamId = teamId;
        }
    }
}