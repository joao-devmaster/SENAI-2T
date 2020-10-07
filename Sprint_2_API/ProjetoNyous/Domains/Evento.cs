using System;
using System.Collections.Generic;

namespace ProjetoNyous.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Convite = new HashSet<Convite>();
            Presenca = new HashSet<Presenca>();
        }

        public int IdEvento { get; set; }
        public DateTime DataEvento { get; set; }
        public byte[] AcessoRestrito { get; set; }
        public int Capacidade { get; set; }
        public string Descricao { get; set; }
        public int? IdLocalizacao { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual Localizacao IdLocalizacaoNavigation { get; set; }
        public virtual ICollection<Convite> Convite { get; set; }
        public virtual ICollection<Presenca> Presenca { get; set; }
    }
}
