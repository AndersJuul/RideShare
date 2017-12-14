
namespace Ajf.RideShare.Api.UnitOfWork
{
    public enum UnitOfWorkStatus
    {
        Ok,
        NotFound,
        Conflict,
        Exception,
        Invalid,
        Forbidden
    }
}
