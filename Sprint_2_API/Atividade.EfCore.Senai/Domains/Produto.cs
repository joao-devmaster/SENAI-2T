using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Domains
{
    public class Produto : BaseDomain
    {   
        /// <summary>
        /// Definição da classe produto
        /// </summary>
      
        public string Nome { get; set; }
        public float preco { get; set; }
        [NotMapped] // não mapeia a propriedade no banco de dados
        [JsonIgnore] //ignora proriedade com o retorno do json
        public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }

        //Relacionamento com a tabela pedidotens 1.N
        public List<PedidoItem> pedidoitens { get; set; }





    }
}
