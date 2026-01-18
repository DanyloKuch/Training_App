namespace Training_App.Api.Contracts
{
    public record TrainingRequest(
        string Typename,
        DateTime Date,
        DateTime EndTime
    );
    public record TrainingRequestCreate(
       string Typename,
       Guid ApplicationUserId
   );
}
