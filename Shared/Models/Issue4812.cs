using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace mdmontesinos.Module.Issue4812.Models
{
    [Table("mdmontesinosIssue4812")]
    public class Issue4812 : IAuditable
    {
        [Key]
        public int Issue4812Id { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
