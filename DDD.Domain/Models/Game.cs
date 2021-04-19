using System;
using DDD.Infra.CrossCutting.Bus.Core.DomainObjects;

namespace DDD.Domain.Models
{
    public class Game : Entity, IAggregateRoot
    {
        public DateTime StartGameHour { get; private set; }
        public DateTime? EndGameHour { get; private set; }
        public Guid HomeTeamId { get; private set; }
        public Guid GuestTeamId { get; private set; }
        public int HomeTeamScore { get; private set; }
        public int VisitoursScore { get; private set; }

        public Game(DateTime startGameHour, DateTime? endGameHour, Guid homeTeamId, Guid guestTeamId, int homeTeamScore, int visitoursScore)
        {
            StartGameHour = startGameHour;
            EndGameHour = endGameHour;
            HomeTeamId = homeTeamId;
            GuestTeamId = guestTeamId;
            HomeTeamScore = homeTeamScore;
            VisitoursScore = visitoursScore;
        }
    }
}