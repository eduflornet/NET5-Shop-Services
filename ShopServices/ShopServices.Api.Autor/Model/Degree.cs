using System;

namespace ShopServices.Api.Author.Model
{
    public class Degree
    {
        public int DegreeId { get; set; }
        public string Name { get; set; }
        public string AcademicCenter { get; set; }
        public DateTime? DegreeDate { get; set; }

        public int AuthorBookId { get; set; }

        public AuthorBook AuthorBook { get; set; }

        public string DegreeGuid { get; set; }
    }
}