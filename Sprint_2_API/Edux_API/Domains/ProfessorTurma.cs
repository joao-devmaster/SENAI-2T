using System;
using System.Collections.Generic;

namespace Edux.Domains
{
    public partial class ProfessorTurma
    {
        public int IdProfessorTurma { get; set; }
        public string Descricao { get; set; }
        public int IdUsuario { get; set; }
        public int IdTurma { get; set; }

        public virtual Turma IdTurmaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
