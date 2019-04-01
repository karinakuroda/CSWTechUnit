using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces.Services
{
    public interface IProjectService
    {
        void Add(Project project);
        void Remove(int id);
    }
}
