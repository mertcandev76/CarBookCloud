using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetItemsByCategoryIdQuery(int CategoryID) : IRequest<List<object>>;
    public record GetAllCategoriesQuery() : IRequest<List<CategoryResultDto>>;
    public record GetCategoryByIdQuery(int CategoryID) : IRequest<CategoryResultDto?>;
}
