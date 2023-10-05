using Microsoft.AspNetCore.Mvc;

namespace grades.DTO
{
  
        public record GradeDto(Guid Id, int GradeT, string DescriptionT, string Created);
        public record CreateGrade(int GradeT, string DescriptionT);
        public record UpdateGrade(int GradeT, string DescriptionT);
    
}
