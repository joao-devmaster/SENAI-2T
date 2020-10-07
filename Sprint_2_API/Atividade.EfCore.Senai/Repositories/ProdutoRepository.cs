using Atividade.EfCore.Senai.Contexts;
using Atividade.EfCore.Senai.Domains;
using Atividade.EfCore.Senai.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Repositories
{
    public class ProdutoRepository : IprodutoRepository
    {

        private readonly PedidoContext _ctx;

        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }
        /// <summary>
        /// adiciona um novo produto
        /// </summary>
        /// <param name="Produto">objeto do tipo produto</param>
        public void Adicionar(Produto Produto)
        {
           try
            {
                //adiciona o objeto do tipo produto ao dbet do contexto
                _ctx.Produto.Add(Produto);

                //salva as alterações no contexto
                _ctx.SaveChanges(); 

            }

            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }
        /// <summary>
        /// buscar um produto pelo seu id
        /// </summary>
        /// <param name="Id">Id do produto</param>
        /// <returns>Lista de produtos</returns>
        public Produto BuscarPorId(Guid Id) 
        {
            try
            {
                //return  _ctx.Produto.FirstOrDefault(c => c.Id == Id);
                return _ctx.Produto.Find(Id);
                

            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// busca de produtos pelo nome
        /// </summary>
        /// <param name="nome">nome do produto</param>
        /// <returns>retorna um produto</returns>
        public List <Produto> BuscarPorNome(string nome)
        {
            try
            {
                return _ctx.Produto.Where(c => c.Nome.Contains(nome)).ToList();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// edita um produto
        /// </summary>
        /// <param name="Produto">produto a ser editado</param>
        public void Editar(Produto Produto)
        {
            try
            {
                //buscar produto pelo id
                Produto produtoTemp = BuscarPorId(Produto.Id);
                
                //verifica se o produto existe
                //caso não existe, é gerado um exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //caso exista altera sua propriedade 
                produtoTemp.Nome = Produto.Nome;
                produtoTemp.preco = Produto.preco;

                //altera o produto no econtexto
                _ctx.Produto.Update(produtoTemp);
                //salva o contexto
                _ctx.SaveChanges();
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns></returns>
        public List<Produto> Listar()
        {
            try
            {
                return _ctx.Produto.ToList();

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
        /// <summary>
        /// remove o produto
        /// </summary>
        /// <param name="Id">Id do produto</param>
        public void Remover(Guid Id)
        {
            try
            {
                //buscar produto pelo id
                Produto produtoTemp = BuscarPorId(Id);

                //verifica se o produto existe
                //caso não existe, é gerado um exception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //remove o produto do dbset
                _ctx.Produto.Remove(produtoTemp);
                //salva as alteráções do contexto
                _ctx.SaveChanges();

            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
    }
}
