namespace pimonova_WebAPI.Helpers
{
    public class QueryObjectForCompany
    {
        public string? FullName { get; set; } = null;
        public string? ShortName { get; set; } = null;
        public string? LineOfWork { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
    }
}
