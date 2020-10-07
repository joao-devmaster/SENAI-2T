using System;
using System.Collections.Generic;

namespace ProjetoNyous.Domains
{
    public partial class Convite
    {
        public int IdConvite { get; set; }
        public bool? Confirmado { get; set; }
        public int? IdEvento { get; set; }
        public int? IdUsuarioEmissor { get; set; }
        public int? IdUsuarioConvidado { get; set; }

        public virtual Evento IdEventoNavigation { get; set; }
        public virtual Usuario IdUsuarioConvidadoNavigation { get; set; }
        public virtual Usuario IdUsuarioEmissorNavigation { get; set; }
    }
}
