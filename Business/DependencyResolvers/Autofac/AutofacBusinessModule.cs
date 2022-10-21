using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().SingleInstance();
            builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>().SingleInstance();

            builder.RegisterType<CongressImageManager>().As<ICongressImageService>().SingleInstance();
            builder.RegisterType<EfCongressImageDal>().As<ICongressImageDal>().SingleInstance();

            builder.RegisterType<CongressManager>().As<ICongressService>().SingleInstance();
            builder.RegisterType<EfCongressDal>().As<ICongressDal>().SingleInstance();

            builder.RegisterType<EmailQueueManager>().As<IEmailQueueService>().SingleInstance();
            builder.RegisterType<EfEmailQueueDal>().As<IEmailQueueDal>().SingleInstance();

            builder.RegisterType<PaperFileManager>().As<IPaperFileService>().SingleInstance();
            builder.RegisterType<EfPaperFileDal>().As<IPaperFileDal>().SingleInstance();

            builder.RegisterType<PaperManager>().As<IPaperService>().SingleInstance();
            builder.RegisterType<EfPaperDal>().As<IPaperDal>().SingleInstance();

            builder.RegisterType<TopicManager>().As<ITopicService>().SingleInstance();
            builder.RegisterType<EfTopicDal>().As<ITopicDal>().SingleInstance();

            builder.RegisterType<TransportLayoverManager>().As<ITransportLayoverService>().SingleInstance();
            builder.RegisterType<EfTransportLayoverDal>().As<ITransportLayoverDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector=new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
