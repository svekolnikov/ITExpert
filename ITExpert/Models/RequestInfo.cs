namespace ITExpert.Models;

public class RequestInfo
{
    public int Id { get; set; }
    public string Path { get; set; } = default!;
    public string Method { get; set; } = default!;
    public string QueryString { get; set; } = default!;
}