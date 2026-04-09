namespace Training_App.Domain.Models;
using CSharpFunctionalExtensions;

public class Muscle
{
    public Guid Id { get; }
    public string Name { get; }
    private Muscle(Guid id, string name)
    {
        Id = id;
        Name = name; 
    }

    public static Result<Muscle> Create(Guid id, string name)
    {
        if (string.IsNullOrWhiteSpace(name)) return Result.Failure<Muscle>($"Name {name} is empty");
        return Result.Success<Muscle>(new Muscle(id, name));
    }
}