using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class BookDetails
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int price { get; set; }
        public int pages { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string AddedBy { get; set; }
        public string modifiedBy { get; set; }
        public int isActive { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }

    }
}
