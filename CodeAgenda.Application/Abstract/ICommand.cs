using MediatR;

namespace CodeAgenda.Application.Abstract
{
    public interface ICommand : IRequest
    {

    }

    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
