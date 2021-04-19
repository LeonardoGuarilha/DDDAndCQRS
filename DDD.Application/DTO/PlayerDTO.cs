using System;

namespace DDD.Application.DTO
{
    public class PlayerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? TeamId { get; set; }
    }
}