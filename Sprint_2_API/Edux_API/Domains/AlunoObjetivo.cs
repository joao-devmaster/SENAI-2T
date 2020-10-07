using System;
using System.Collections.Generic;

namespace Edux.Domains
{
    public partial class AlunoObjetivo
    {
        public int IdAlunoObjetivo { get; set; }
        public decimal? Nota { get; set; }
        public DateTime? DataAlcancada { get; set; }
        public int IdAlunoTurma { get; set; }
        public int IdObjetivo { get; set; }

        public virtual AlunoTurma IdAlunoTurmaNavigation { get; set; }
        public virtual Objetivo IdObjetivoNavigation { get; set; }
    }
}
