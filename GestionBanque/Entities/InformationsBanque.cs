using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanqueDbContext.Entities
{
    public class InformationsBanque
    {
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public string? Libelle { get; set; }
        public int? Montant { get; set; }
        public override string ToString()
        {
            return $"[{Id}] {Date} {Libelle} {Montant}";
        }
    }
}