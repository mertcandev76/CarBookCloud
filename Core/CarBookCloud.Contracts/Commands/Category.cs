using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateCategoryCommand(CategoryCreateDto Dto) : IRequest<CategoryResultDto>;
    public record DeleteCategoryCommand(int CategoryID) : IRequest<Unit>;
    public record UpdateCategoryCommand(CategoryUpdateDto Dto) : IRequest<CategoryResultDto>;
}
