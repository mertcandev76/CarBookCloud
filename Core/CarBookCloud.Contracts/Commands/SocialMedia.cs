using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateSocialMediaCommand(SocialMediaCreateDto Dto) : IRequest<SocialMediaResultDto>;
    public record DeleteSocialMediaCommand(int SocialMediaID) : IRequest<Unit>;
    public record UpdateSocialMediaCommand(SocialMediaUpdateDto Dto) : IRequest<SocialMediaResultDto>;
}
