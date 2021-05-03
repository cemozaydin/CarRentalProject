using Autofac;
using Autofac.Core;
using Autofac.Core.Registration;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Biri senden ICarService isterse ona CarManager instance ı ver.
            builder.RegisterType<CarManager>().As<ICarService>(); 
            builder.RegisterType<EfCarDal>().As<ICarDal>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();

            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ModelManager>().As<IModelService>();
            builder.RegisterType<EfModelDal>().As<IModelDal>();

            builder.RegisterType<BodyTypeManager>().As<IBodyTypeService>();
            builder.RegisterType<EfBodyTypeDal>().As<IBodyTypeDal>();

            builder.RegisterType<FuelTypeManager>().As<IFuelTypeService>();
            builder.RegisterType<EfFuelTypeDal>().As<IFuelTypeDal>();

            builder.RegisterType<GearTypeManager>().As<IGearTypeService>();
            builder.RegisterType<EfGearTypeDal>().As<IGearTypeDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
