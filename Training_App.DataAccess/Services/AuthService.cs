using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Training_App.Application.Contracts;
using Training_App.DataAccess.Entity;
using Training_App.Application.Interfaces;
using Training_App.Domain.Models;

namespace Training_App.DataAccess.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(UserManager<UserEntity> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<Result> Register(UserRequest userRequest)
    {
        var user = new UserEntity
        {
            Email = userRequest.Email
        };
        var result = await _userManager.CreateAsync(user, userRequest.Password);

        if (!result.Succeeded)
            return Result.Failure(result.Errors.First().Description);

        return Result.Success();
    }

    public async Task<Result<string>> Login(UserRequest userRequest)
    {
        var userDb = await _userManager.FindByEmailAsync(userRequest.Email);
        if (userDb == null) return Result.Failure<string>($"User {userRequest.Email} not found.");
        var IsRightPassord = await _userManager.CheckPasswordAsync(userDb, userRequest.Password);

        
        if (!IsRightPassord)
        {
            return Result.Failure<string>($"password doesn't match");
        }
        
        var token = GenerateJwtToken(userDb);
        
        return Result.Success<string>(token);

    }

    private string GenerateJwtToken(UserEntity user)
    {
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email!)
        };
        
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}