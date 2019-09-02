using DomainInterface.Models;
using InfrustructureInterfaces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Mappers
{
    public static class Mapping
    {
        public static DomainLesson FromRepoLessonToDomainLesson(this RepoLesson item)
        {
            return new DomainLesson
            {
                Id = item.Id,
                Name = item.Name,
                StudentNumber = item.StudentNumber
            };
        }

        public static RepoLesson FromDomainLessonToRepoLesson(this DomainLesson item)
        {
            return new RepoLesson
            {
                Id = item.Id,
                Name = item.Name,
                StudentNumber = item.StudentNumber

            };
        }

        public static DomainStudent FromRepoStudentToDomainStudent(this RepoStudent item)
        {
            return new DomainStudent
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public static RepoStudent FromDomainStudentToRepoStudent(this DomainStudent item)
        {
            return new RepoStudent
            {
                Id = item.Id,
                Name = item.Name,
            };
        }
    }
}
