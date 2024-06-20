namespace BrSolution.Domain.Entities.App;

public class ExceptionLog : IEntity
{
    public int Id { get; set; }

    public string? RequestIp { get; set; }

    public string RequestUrl { get; set; }

    public string? RequestBody { get; set; }

    public string HttpMethod { get; set; }

    public Guid TransactionId { get; set; }

    public string? EndpointName { get; set; }

    public string ExceptionTypeName { get; set; }

    public string ExceptionMessage { get; set; }

    public string? StackTrace { get; set; }

    public int? UserId { get; set; }

    public User? User { get; set; }

    public DateTime CreateDate { get; set; }
}
