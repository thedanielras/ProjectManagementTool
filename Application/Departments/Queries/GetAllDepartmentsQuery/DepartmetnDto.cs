using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Departments.Queries.GetAllDepartmentsQuery
{
    public class DepartmetnDto: IMapFrom<Department>
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
    }
}
