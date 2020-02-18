using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Domain.Entity
{
    public class Armor : BaseEntity
    {
        public Armor(string description)
        {
            Deaths           = new HashSet<Death>();
            this.Description = description;
        }

        protected Armor()
        { 
        }

        public string Description { get; private set; }
        public virtual ICollection<Death> Deaths { get; set; }
    }
}
