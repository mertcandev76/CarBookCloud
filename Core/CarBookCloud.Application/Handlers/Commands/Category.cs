using CarBookCloud.Application.Extensions;
using CarBookCloud.Contracts.Commands;
using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.UnitOfWork;
using CarBookCloud.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<CategoryResultDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = Category.Create(request.Dto.Name!);

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.SaveEntitiesAsync();

            return new CategoryResultDto
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            };
        }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<CategoryResultDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(request.Dto.CategoryID);
            if (category == null)
                throw new NotFoundException(nameof(Category), request.Dto.CategoryID);

            category.UpdateName(request.Dto.Name!);

            await _unitOfWork.Categories.UpdateAsync(category);
            await _unitOfWork.SaveEntitiesAsync();

            return new CategoryResultDto
            {
                CategoryID = category.CategoryID,
                Name = category.Name
            };
        }
    }


    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(request.CategoryID);
            if (category == null)
                throw new NotFoundException(nameof(Category), request.CategoryID);

            await _unitOfWork.Categories.DeleteAsync(category);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
