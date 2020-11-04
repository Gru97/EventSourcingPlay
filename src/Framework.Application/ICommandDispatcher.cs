namespace Framework.Application
{
    public interface ICommandDispatcher
    {
        void Dispatch<T>(T command);
    }
}