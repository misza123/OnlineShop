using Autofac;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.DataExample;
using OnlineShop.WebApi.Products;
using OnlineShop.WebApi.Products.Photos;
using OnlineShop.WebApi.Users;

namespace OnlineShop.WebApi.IoC
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // TODO: add test for lifetime cycle of uow and dataContext
            builder.RegisterType<DataContext>().InstancePerLifetimeScope();
            builder.RegisterType<Seed>().InstancePerDependency();
            builder.RegisterType<AuthService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TransactionScopeUnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IRepository<User>>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IRepository<Product>>().InstancePerLifetimeScope();
            builder.RegisterType<CloudinaryStoreService>().As<IPhotoStoreService>().SingleInstance();
            builder.RegisterType<PhotoService>().As<IPhotoService>().SingleInstance();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}