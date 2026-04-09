using CSharpFunctionalExtensions;
using Training_App.Application.Contracts;

namespace Training_App.Application.Interfaces;

public interface IAuthService
{
    Task<Result> Register(UserRequest userRequest);
    Task<Result<string>> Login(UserRequest userRequest);
}