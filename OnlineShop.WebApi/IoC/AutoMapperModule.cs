using Autofac;
using AutoMapper;
using AutoMapper.Configuration;

namespace OnlineShop.WebApi.IoC
{
    public class AutoMapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfiles(System.Reflection.Assembly.GetExecutingAssembly());
            });
            mappingConfig.CreateMapper();
            builder.RegisterInstance(mappingConfig.CreateMapper()).As<IMapper>().SingleInstance();
            
            var cfg = new MapperConfigurationExpression();
            cfg.AddProfiles(System.Reflection.Assembly.GetExecutingAssembly());
            Mapper.Initialize(cfg);
        }
    }
}