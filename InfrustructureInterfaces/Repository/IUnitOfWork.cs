using InfrustructureInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrustructureInterfaces.Repository
{
    public interface IUnitOfWork
    {
        IRepositories<RepoLesson> Lessons { get; }

        IRepositories<RepoStudent> Students { get; }
    }
}
