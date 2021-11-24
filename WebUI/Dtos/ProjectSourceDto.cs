using Domain.Entities;

namespace WebUI.Dtos
{
    public class ProjectSourceDto
    {
        public string SourceUrl { get; set; }
        public ProjectSourceType Type { get; set; }
    }
}