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
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand, TestimonialResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateTestimonialCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<TestimonialResultDto> Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = Domain.Entities.Testimonial.Create(
                request.Dto.Name,
                request.Dto.Title,
                request.Dto.Comment,
                request.Dto.ImageUrl
            );

            await _unitOfWork.Testimonials.AddAsync(testimonial);
            await _unitOfWork.SaveEntitiesAsync();

            return new TestimonialResultDto
            {
                TestimonialID = testimonial.TestimonialID,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl
            };
        }
    }

    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand, TestimonialResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTestimonialCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<TestimonialResultDto> Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _unitOfWork.Testimonials.GetByIdAsync(request.Dto.TestimonialID);
            if (testimonial == null)
                throw new NotFoundException(nameof(Domain.Entities.Testimonial), request.Dto.TestimonialID);

            testimonial.Update(
                request.Dto.Name,
                request.Dto.Title,
                request.Dto.Comment,
                request.Dto.ImageUrl
            );

            await _unitOfWork.Testimonials.UpdateAsync(testimonial);
            await _unitOfWork.SaveEntitiesAsync();

            return new TestimonialResultDto
            {
                TestimonialID = testimonial.TestimonialID,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl
            };
        }
    }

    public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTestimonialCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteTestimonialCommand request, CancellationToken cancellationToken)
        {
            var testimonial = await _unitOfWork.Testimonials.GetByIdAsync(request.TestimonialID);
            if (testimonial == null)
                throw new NotFoundException(nameof(Domain.Entities.Testimonial), request.TestimonialID);

            await _unitOfWork.Testimonials.DeleteAsync(testimonial);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
