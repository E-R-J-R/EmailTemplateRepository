namespace eCom.Interview.DTO
{
    public class SearchParam
    {
        public int Page { get; set; }
        public int? PageSize { get; set; }
        public string SearchField { get; set; }
        public string SearchText { get; set; }
        public string OrderBy { get; set; }
        public bool desc { get; set; } = false;
    }
}
