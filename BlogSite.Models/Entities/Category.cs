using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Entities
{
    public sealed class Category : Entity<int>
    {
        public string Name { get; set; }
        public List<Post> Posts { get; set; }
    }
}
