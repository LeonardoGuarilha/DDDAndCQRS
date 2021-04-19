using System.Linq;
using System.Threading.Tasks;
using DDD.Domain.Models;
using DDD.Infra.CrossCutting.Bus.Core.Data;
using DDD.Infra.CrossCutting.Bus.Core.DomainObjects;
using DDD.Infra.CrossCutting.Bus.Core.Mediator;
using DDD.Infra.CrossCutting.Bus.Core.Messages;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Data.Context
{
    public class TournamentContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public TournamentContext(DbContextOptions<TournamentContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Player> Players { get; set; }
        //public DbSet<Team> Teams { get; set; }
        //public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CommandResult>();
            modelBuilder.Ignore<Event>();
            
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            var success = await SaveChangesAsync() > 0;

            await _mediatorHandler.PublishDomainEvents(this);

            return success;
        }
    }
    
    public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notificacoes != null && x.Entity.Notificacoes.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notificacoes)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.LimparEventos());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublicarEvento(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}