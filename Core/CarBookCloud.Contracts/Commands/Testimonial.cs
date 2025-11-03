using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateTestimonialCommand(TestimonialCreateDto Dto) : IRequest<TestimonialResultDto>;
    public record DeleteTestimonialCommand(int TestimonialID) : IRequest<Unit>;
    public record UpdateTestimonialCommand(TestimonialUpdateDto Dto) : IRequest<TestimonialResultDto>;
}
