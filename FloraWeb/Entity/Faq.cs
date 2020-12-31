using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FloraWeb.Entity
{
    public class Faq
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectId { get; set; }
        public string Status { get; set; }
        public string UpVote { get; set; }
        public string DownVote { get; set; }
        public string ProjectName { get; set; }
    }
}