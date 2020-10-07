using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProjetoNyous.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            ConviteIdUsuarioConvidadoNavigation = new HashSet<Convite>();
            ConviteIdUsuarioEmissorNavigation = new HashSet<Convite>();
            Presenca = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int? IdAcesso { get; set; }

        public virtual Acesso IdAcessoNavigation { get; set; }
        public virtual ICollection<Convite> ConviteIdUsuarioConvidadoNavigation { get; set; }
        public virtual ICollection<Convite> ConviteIdUsuarioEmissorNavigation { get; set; }
        public virtual ICollection<Presenca> Presenca { get; set; }

       
    }
}
