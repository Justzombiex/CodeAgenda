using MediatR;

namespace CodeAgenda.Application.Abstract
{
    public interface IQuery<TReponse> : IRequest<TReponse>
    {

    }
}
