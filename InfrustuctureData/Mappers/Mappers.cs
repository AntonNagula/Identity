using InfrustructureInterfaces.Models;
using InfrustuctureData.Models;
namespace InfrustuctureData.Mappers
{
    public static class Mappers
    {
        public static DataLesson FromRepoLessonToDataLesson(this RepoLesson item)
        {
            return new DataLesson
            {
                Id = item.Id,
                Name = item.Name,
                StudentNumber =item.StudentNumber
            };
        }

        public static RepoLesson FromDataLessonToRepoLesson(this DataLesson item)
        {
            return new RepoLesson
            {
                Id = item.Id,
                Name = item.Name,
                StudentNumber = item.StudentNumber               
                  
            };
        }

        public static DataStudent FromRepoStudentToDataStudent(this RepoStudent item)
        {
            return new DataStudent
            {
                Id = item.Id,
                Name = item.Name,                          
            };
        }

        public static RepoStudent FromDataStudentToRepoStudent(this DataStudent item)
        {
            return new RepoStudent
            {
                Id = item.Id,
                Name = item.Name,
            };
        }
    }
}
