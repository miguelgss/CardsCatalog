using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Entity
{
    public class Card // "Define" as tabelas
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
    }
}
