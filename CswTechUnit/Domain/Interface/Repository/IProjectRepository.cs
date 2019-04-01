using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IProjectRepository
    {
        void Add(Project project);
        void Remove(int id);
        
    }
}
