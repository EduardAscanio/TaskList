using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace TaskList.Models
{
    public class Tarea
    {
        [PrimaryKey, AutoIncrement]
        public int IdTarea { get; set; }
        [MaxLength(20)]
        public string Desc { get; set; }
        public bool Status { get; set; }
    }
}