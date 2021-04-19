using System;
using MediatR;

namespace DDD.Infra.CrossCutting.Bus.Core.Messages
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        public Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}