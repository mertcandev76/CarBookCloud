using CarBookCloud.Application.Extensions;
using CarBookCloud.Contracts.Commands;
using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Commands
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, BrandResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandResultDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = Domain.Entities.Brand.Create(request.Dto.Name!);

            await _unitOfWork.Brands.AddAsync(brand);
            await _unitOfWork.SaveEntitiesAsync();

            return new BrandResultDto
            {
                BrandID = brand.BrandID,
                Name = brand.Name
            };
        }
    }

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, BrandResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandResultDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.Brands.GetByIdAsync(request.Dto.BrandID);
            if (brand == null)
                throw new NotFoundException(nameof(Domain.Entities.Brand), request.Dto.BrandID);

            brand.SetName(request.Dto.Name!);

            await _unitOfWork.Brands.UpdateAsync(brand);
            await _unitOfWork.SaveEntitiesAsync();

            return new BrandResultDto
            {
                BrandID = brand.BrandID,
                Name = brand.Name
            };
        }
    }

    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.Brands.GetByIdAsync(request.BrandID);
            if (brand == null)
                throw new NotFoundException(nameof(Domain.Entities.Brand), request.BrandID);

            await _unitOfWork.Brands.DeleteAsync(brand);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
