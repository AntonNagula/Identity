using DomainInterface.Interfaces;
using DomainService.Services;
using InfrustructureInterfaces.Models;
using InfrustructureInterfaces.Repository;
using InfrustuctureData.Repositories;
using InfrustuctureData.Structure;
using Ninject.Modules;
using Ninject.Web.Common;
namespace IoC
{
    public class CoreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepositories<RepoStudent>>().To<StudentRepository>().InRequestScope();
            Bind<IRepositories<RepoLesson>>().To<LessonRepository>().InRequestScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            Bind<IService>().To<Service>().InRequestScope();
        }
    }
}
