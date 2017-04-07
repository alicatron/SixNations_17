using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SixNations2017.Models
{
    public class SixNations2017Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SixNations2017Context() : base("name=SixNations2017Context")
        {
        }

        public System.Data.Entity.DbSet<SixNations2017.Models.Player> Players { get; set; }
    }
}
