using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EF6Demo.Models
{
    public class Class
    {
        public int ID { get; set; }

        public string Title { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}