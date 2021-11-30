using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Dtos.Project.AddProject
{
    public class AddProjectDto
    {    
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }

        [Required]      
        public Guid ResponsibleUserId { get; set; }

        public Guid? ForeignResponsibleUserId { get; set; }

        public IEnumerable<ProjectSourceDto> ProjectSources { get; set; }
    }
}
