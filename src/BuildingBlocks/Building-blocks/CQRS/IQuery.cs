using MediatR;


namespace Building_blocks.CQRS
{

    public interface IQuery<out TResponse> : IRequest<TResponse>
        where TResponse : notnull
    {
    }
}

