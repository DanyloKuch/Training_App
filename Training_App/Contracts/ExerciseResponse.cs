namespace Training_App.Api.Contracts
{
    public record ExerciseResponse(
        Guid Id,
        string Name,
        string Muscles,
        int CountOfBasicSets,
        int CountOfWurmUpSets,
        decimal Weight
    );
}
