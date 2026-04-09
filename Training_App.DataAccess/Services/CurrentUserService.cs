using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Training_App.Application.Interfaces;

namespace Training_App.DataAccess.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var idClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            return Guid.TryParse(idClaim, out var parsedId) ? parsedId : Guid.Empty;
        }
    }
}