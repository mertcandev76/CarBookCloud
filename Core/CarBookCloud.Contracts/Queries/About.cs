using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetAboutByIdQuery(int AboutID) : IRequest<AboutResultDto?>;
    public record GetAllAboutsQuery() : IRequest<List<AboutResultDto>>;
}
