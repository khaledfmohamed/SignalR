using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    [Table("tasks")]
    public class Task
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Progress { get; set; }

    }
}