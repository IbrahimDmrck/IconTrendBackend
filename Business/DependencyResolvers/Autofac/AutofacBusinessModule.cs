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

            builder.RegisterType<AnnounceImageManager>().As<IAnnounceImageService>().SingleInstance();
            builder.RegisterType<EfAnnounceImageDal>().As<IAnnounceImageDal>().SingleInstance();

            builder.RegisterType<CongressImageManager>().As<ICongressImageService>().SingleInstance();
            builder.RegisterType<EfCongressImageDal>().As<ICongressImageDal>().SingleInstance();

            builder.RegisterType<CongressManager>().As<ICongressService>().SingleInstance();
            builder.RegisterType<EfCongressDal>().As<ICongressDal>().SingleInstance();

            builder.RegisterType<CongressPresidentManager>().As<ICongressPresidentService>().SingleInstance();
            builder.RegisterType<EfCongressPresidentDal>().As<ICongressPresidentDal>().SingleInstance();

            builder.RegisterType<RegulatoryBoardManager>().As<IRegulatoryBoardService>().SingleInstance();
            builder.RegisterType<EfRegulatoryBoardDal>().As<IRegulatoryBoardDal>().SingleInstance();

            builder.RegisterType<ScienceBoardManager>().As<IScienceBoardService>().SingleInstance();
            builder.RegisterType<EfScienceBoardDal>().As<IScienceBoardDal>().SingleInstance();

            builder.RegisterType<TopicManager>().As<ITopicService>().SingleInstance();
            builder.RegisterType<EfTopicDal>().As<ITopicDal>().SingleInstance();

            builder.RegisterType<TransportLayoverManager>().As<ITransportLayoverService>().SingleInstance();
            builder.RegisterType<EfTransportLayoverDal>().As<ITransportLayoverDal>().SingleInstance();

            builder.RegisterType<TransportlayoverImageManager>().As<ITransportLayoverImageService>().SingleInstance();
            builder.RegisterType<EfTransportLayoverImageDal>().As<ITransportLayoverImageDal>().SingleInstance();

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();

            builder.RegisterType<KongreManager>().As<IKongreService>().SingleInstance();
            builder.RegisterType<EfKongreDal>().As<IKongreDal>().SingleInstance();

            builder.RegisterType<KongreImageManager>().As<IKongreImageService>().SingleInstance();
            builder.RegisterType<EfKongreImageDal>().As<IKongreImageDal>().SingleInstance();


            builder.RegisterType<SaveManager>().As<ISaveService>().SingleInstance();
            builder.RegisterType<EfSaveDal>().As<ISaveDal>().SingleInstance();

            builder.RegisterType<BankAccountInfoManager>().As<IBankAccountInfoService>().SingleInstance();
            builder.RegisterType<EfBankAccountInfoDal>().As<IBankAccountInfoDal>().SingleInstance();

            builder.RegisterType<TrBankAccountInfoManager>().As<ITrBankAccountInfoService>().SingleInstance();
            builder.RegisterType<EfTrBankAccountInfoDal>().As<ITrBankAccountInfoDal>().SingleInstance();

            builder.RegisterType<GeneralInformationManager>().As<IGeneralInformationService>().SingleInstance();
            builder.RegisterType<EfGeneralInformationDal>().As<IGeneralInformationDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
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
