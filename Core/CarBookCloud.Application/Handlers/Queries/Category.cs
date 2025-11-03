using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.Queries;
using CarBookCloud.Contracts.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Queries
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<CategoryResultDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryID);
            if (category == null) return null;

            return new CategoryResultDto
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            };
        }
    }

    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<CategoryResultDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            return categories.Select(c => new CategoryResultDto
            {
                CategoryID = c.CategoryID,
                Name = c.Name
            }).ToList();
        }
    }
}
