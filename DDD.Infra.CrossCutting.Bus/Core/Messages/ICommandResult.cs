namespace DDD.Infra.CrossCutting.Bus.Core.Messages
{
    public interface ICommandResult
    {
        bool Success { get; set; }
        string Message { get; set; }
        object Data { get; set; }
    }
}