namespace OnlineShop.WebApi.DataAccess
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork GetUOW();
    }
}