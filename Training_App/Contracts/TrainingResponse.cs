namespace Training_App.Api.Contracts
{
    public record TrainingResponse(
        Guid id, 
        string typename, 
        DateTime date, 
        DateTime endTime
        );
}
