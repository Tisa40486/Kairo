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
        public required string Title { get; set; }
        public string? Description { get; set; } 
        public bool Done { get; set; } = false;

    }
}