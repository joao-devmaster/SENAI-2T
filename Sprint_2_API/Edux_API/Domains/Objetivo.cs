using System;
using System.Collections.Generic;

namespace Edux.Domains
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            AlunoObjetivo = new HashSet<AlunoObjetivo>();
        }

        public int IdObjetivo { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<AlunoObjetivo> AlunoObjetivo { get; set; }
    }
}
