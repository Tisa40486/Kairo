using KairoApi.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KairoApi.Model
{
    [Table("KairoApi_Task")]
    public class TaskDao : IModelDao
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; } 
    }
}
