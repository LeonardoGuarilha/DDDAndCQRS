using DDD.Infra.CrossCutting.Bus.Core.DomainObjects;

namespace DDD.Domain.Models
{
    public class Team : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Wins { get; private set; }
        public int Loses { get; private set; }

        public Team(string name, int wins, int loses)
        {
            Name = name;
            Wins = wins;
            Loses = loses;
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}