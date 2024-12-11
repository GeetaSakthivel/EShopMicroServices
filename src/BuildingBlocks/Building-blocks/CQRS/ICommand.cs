using MediatR;


namespace Building_blocks.CQRS
{
    public interface ICommand:IRequest<Unit>
    {

    }
    public interface ICommand<out TResponse> :IRequest<TResponse>
    {
    }
}
