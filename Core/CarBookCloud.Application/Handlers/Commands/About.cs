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
    public class CreateAboutCommandHandler : IRequestHandler<CreateAboutCommand, AboutResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateAboutCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AboutResultDto> Handle(CreateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = Domain.Entities.About.Create(
                request.Dto.Title!,
                request.Dto.Description,
                request.Dto.ImageUrl
            );

            await _unitOfWork.Abouts.AddAsync(about);
            await _unitOfWork.SaveEntitiesAsync();

            return new AboutResultDto
            {
                AboutID = about.AboutID,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };
        }

    }
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand, AboutResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAboutCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<AboutResultDto> Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _unitOfWork.Abouts.GetByIdAsync(request.Dto.AboutID);
            if (about == null)
                throw new NotFoundException(nameof(Domain.Entities.About), request.Dto.AboutID);

            about.SetTitle(request.Dto.Title!);
            about.SetDescription(request.Dto.Description);
            about.SetImageUrl(request.Dto.ImageUrl);

            await _unitOfWork.Abouts.UpdateAsync(about);
            await _unitOfWork.SaveEntitiesAsync();

            return new AboutResultDto
            {
                AboutID = about.AboutID,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };
        }
    }
    public class DeleteAboutCommandHandler : IRequestHandler<DeleteAboutCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAboutCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _unitOfWork.Abouts.GetByIdAsync(request.AboutID);
            if (about == null)
                throw new NotFoundException(nameof(Domain.Entities.About), request.AboutID);

            await _unitOfWork.Abouts.DeleteAsync(about);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
