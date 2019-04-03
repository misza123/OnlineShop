namespace OnlineShop.WebApi.DataAccess
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IUnitOfWork _unitOfWork;

        public UnitOfWorkFactory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public IUnitOfWork GetUOW()
        {
            return _unitOfWork;
        }
    }
}