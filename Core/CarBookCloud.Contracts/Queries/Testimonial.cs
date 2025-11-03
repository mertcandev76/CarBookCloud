using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetTestimonialByIdQuery(int TestimonialID) : IRequest<TestimonialResultDto?>;
    public record GetAllTestimonialsQuery() : IRequest<List<TestimonialResultDto>>;
}
