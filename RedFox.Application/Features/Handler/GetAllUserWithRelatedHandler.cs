#region

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RedFox.Application.DTO;
using RedFox.Application.Features.Query;
using RedFox.Application.Service.Infrastructure;

#endregion

namespace RedFox.Application.Features.Handler;

public class GetAllUserWithRelatedHandler(
    IAppDbContext context,
    IMapper mapper
) : IRequestHandler<GetAllUserWithRelatedQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUserWithRelatedQuery request, CancellationToken ct)
    {
        var users = await context.Users
            .Include(u => u.Company)
            .Include(u => u.Address)
                .ThenInclude(a => a!.Geo)
            .AsNoTracking()
            .ToListAsync(ct);

        return users.Select(u => mapper.Map<UserDto>(u));
    }
}