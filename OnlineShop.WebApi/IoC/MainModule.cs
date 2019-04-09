using Autofac;
using OnlineShop.WebApi.DataAccess;
using OnlineShop.WebApi.DataExample;
using OnlineShop.WebApi.Products;
using OnlineShop.WebApi.Users;

namespace OnlineShop.WebApi.IoC
{
    public class MainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Seed>().InstancePerDependency();
            builder.RegisterType<AuthService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<TransactionScopeUnitOfWorkFactory>().As<IUnitOfWorkFactory>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IRepository<User>>().InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IRepository<Product>>().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}