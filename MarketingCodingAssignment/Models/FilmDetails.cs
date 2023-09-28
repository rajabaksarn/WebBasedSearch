using System.Diagnostics;

namespace MarketingCodingAssignment.Models
{
    public class FilmDetails
    {
        public string id { get; set; } 
        public string budget                 {get;set;}
        public string genres                 {get;set;}
        public string original_language      {get;set;}
        public string overview               {get;set;}
        public string popularity             {get;set;}
        public string production_companies   {get;set;}
        public string release_date           {get;set;}
        public string revenue                {get;set;}
        public string runtime                {get;set;}
        public string tagline                {get;set;}
        public string title                  {get;set;}
        public string vote_average           {get;set;}
        public string vote_count { get; set; }

    }
    public class JqueryDatatableParam
    {
        public string sEcho { get; set; }
        public string sSearch { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public int iColumns { get; set; }
        public int iSortCol_0 { get; set; }
        public string sSortDir_0 { get; set; }
        public int iSortingCols { get; set; }
        public string sColumns { get; set; }
    }
}
