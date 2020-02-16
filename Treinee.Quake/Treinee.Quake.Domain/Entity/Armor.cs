using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Armor : BaseEntity
    {
        public Armor()
        {
            Deaths = new HashSet<Death>();
        }

        public string Description { get; set; }
        public virtual ICollection<Death> Deaths { get; set; }
    }
}
