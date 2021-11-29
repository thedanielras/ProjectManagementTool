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
        //[FromBody]
        [Required]
        public string Name { get; set; }

        //[FromBody]
        [Required]
        public Guid DepartmentId { get; set; }

        //[FromBody]
        [Required]      
        public Guid ResponsibleUserId { get; set; }

        //[FromBody]
        public Guid? ForeignResponsibleUserId { get; set; }

        //[FromBody]
        public IEnumerable<ProjectSourceDto> ProjectSources { get; set; }
    }
}
