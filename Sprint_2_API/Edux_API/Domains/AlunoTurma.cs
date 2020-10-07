using System;
using System.Collections.Generic;

namespace Edux.Domains
{
    public partial class AlunoTurma
    {
        public AlunoTurma()
        {
            AlunoObjetivo = new HashSet<AlunoObjetivo>();
        }

        public int IdAlunoTurma { get; set; }
        public string Matricula { get; set; }
        public int IdUsuario { get; set; }
        public int IdTurma { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<AlunoObjetivo> AlunoObjetivo { get; set; }
    }
}
