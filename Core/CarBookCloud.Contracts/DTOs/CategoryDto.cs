using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.DTOs
{
    public class CategoryCreateDto
    {
        public string? Name { get; set; }
    }

    public class CategoryUpdateDto: CategoryCreateDto
    {
        public int CategoryID { get; set; }
    }

    public class CategoryResultDto: CategoryCreateDto
    {
        public int CategoryID { get; set; }
    }
}
