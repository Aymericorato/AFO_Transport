using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace AFO_Transport.Model
{
    [AddINotifyPropertyChangedInterface]
    public partial class Personne
    {
        [Key]
        public int Identifiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string OptionSm { get; set; }
        public virtual Transport IdTransportNavigation { get; set; }
    }
}
