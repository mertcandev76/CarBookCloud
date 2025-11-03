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
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, TestimonialResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTestimonialByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<TestimonialResultDto?> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var testimonial = await _unitOfWork.Testimonials.GetByIdAsync(request.TestimonialID);
            if (testimonial == null) return null;

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

    public class GetAllTestimonialsQueryHandler : IRequestHandler<GetAllTestimonialsQuery, List<TestimonialResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTestimonialsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<TestimonialResultDto>> Handle(GetAllTestimonialsQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.Testimonials.GetAllAsync();
            return list.Select(t => new TestimonialResultDto
            {
                TestimonialID = t.TestimonialID,
                Name = t.Name,
                Title = t.Title,
                Comment = t.Comment,
                ImageUrl = t.ImageUrl
            }).ToList();
        }
    }
}
