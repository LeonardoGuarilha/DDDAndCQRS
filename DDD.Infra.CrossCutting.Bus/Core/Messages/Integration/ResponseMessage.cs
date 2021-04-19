namespace DDD.Infra.CrossCutting.Bus.Core.Messages.Integration
{
    public class ResponseMessage : Message
    {
        private CommandResult ValidationResult { get; set; }
        
        public ResponseMessage(CommandResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}