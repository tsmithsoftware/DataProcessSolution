using DataProcessSolution.DAL.Entities;
using DataProcessSolution.SharedObjects;

namespace DataProcessSolution.DAL
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("JobTable")]
    public partial class JobTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public int? ClientId { get; set; }

        public DateTime? LastUpdated { get; set; }

        public Status Status { get; set; }
    }
}
