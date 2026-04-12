namespace Training_App.Domain.Models;
using CSharpFunctionalExtensions;

public class Muscle
{
    public Guid Id { get; }
    public string Name { get; }
    public Guid CreatedByUserId { get; }

    private Muscle(Guid id, string name, Guid createdByUserId)
    {
        Id = id;
        Name = name;
        CreatedByUserId = createdByUserId;
    }

    public static Result<Muscle> Create(Guid id, string name, Guid createdByUserId)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Muscle>("Muscle name cannot be empty.");

        if (name.Length > 100)
            return Result.Failure<Muscle>("Muscle name cannot exceed 100 characters.");

        return Result.Success(new Muscle(id, name, createdByUserId));
    }

    public static Result<Muscle> Load(Guid id, string name, Guid createdByUserId)
        => Result.Success(new Muscle(id, name, createdByUserId));
}