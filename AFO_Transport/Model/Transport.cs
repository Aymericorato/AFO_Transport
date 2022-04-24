using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AFO_Transport.Model
{
    [AddINotifyPropertyChangedInterface]
    public partial class Transport
    {
        public Transport()
        {
            Personnes = new HashSet<Personne>();
        }
        [Key]
        public int IdTransport { get; set; }
        public string Numero { get; set; }
        public string NombrePassagerMax { get; set; }
        public string Depart { get; set; }
        public string Arrivee { get; set; }
        public string TypeTransport { get; set; }

        public virtual ICollection<Personne> Personnes { get; set; }

        public override string ToString()
        {
            return IdTransport.ToString();
        }
    }
}
