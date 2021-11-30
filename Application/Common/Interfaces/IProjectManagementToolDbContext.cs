using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IProjectManagementToolDbContext
    {
        DbSet<Project> Projects { get; set; }
    }
}
