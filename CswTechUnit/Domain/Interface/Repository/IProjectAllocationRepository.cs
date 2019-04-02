using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IProjectAllocationRepository
    {
        void Add(ProjectAllocation project);

        void Remove(int id);
    }
}
