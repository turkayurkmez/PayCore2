using Orders.API.Commands;

namespace Orders.API.Handlers
{
    public interface ICommandHandler<TCommand> where TCommand:ICommand
    {
        void Handle(TCommand command);
    }
}
