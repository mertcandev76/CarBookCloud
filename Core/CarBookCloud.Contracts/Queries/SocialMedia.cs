using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetSocialMediaByIdQuery(int SocialMediaID) : IRequest<SocialMediaResultDto?>;
    public record GetAllSocialMediasQuery() : IRequest<List<SocialMediaResultDto>>;
}
