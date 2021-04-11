using Heroes.Commands;

namespace Heroes.Actions.Execution
{
    public interface IHeroActionExecutioner
    {
        void Execute(ICommand actionCommand);
    }
}