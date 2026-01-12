namespace Training_App.Api.Contracts
{
    public record ExerciseRequest(
        string Name,
        string Muscles,
        int CountOfBasicSets,
        int CountOfWurmUpSets,
        decimal Weight
    );
}
