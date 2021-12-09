using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces.Repositories
{
    public interface IDepartmentRepository
    {
        public IEnumerable<Department> AlLDerartments { get; }

    }
}
