using Edux.Contexts;
using Edux.Domains;
using Edux.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
            private readonly EduxContext _ctx;

            public CategoriaRepository()
            {
                _ctx = new EduxContext();
            }

            #region Leitura

            public Categoria BuscarPorId(int id)
            {
                try
                {
                    return _ctx.Categoria.Find(id);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public List<Categoria> Listar()
            {
                try
                {
                    return _ctx.Categoria.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            #endregion

            #region Gravacao
            public void Adicionar(Categoria categoria)
            {
                try
                {
                    // O contexto recebe o objeto inst do método
                    _ctx.Add(categoria);


                    //Salva as alterações no banco de dados Edux
                    _ctx.SaveChanges();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            public void Editar(int id, Categoria categoria)
            {
                try
                {
                    // BuscarPorId para verificar a existência do usuário informado
                    Categoria CategoriaTemp = BuscarPorId(id);

                    //Se ela não existir é informado que o usuário não foi encontrado
                    if (CategoriaTemp == null)
                    {
                        throw new Exception("Usuário não encontrado");
                    }
                    else
                    {
                        //Caso contrário salva todas as alterações no objeto usuarioTemp
                        CategoriaTemp.Tipo = categoria.Tipo;
                        CategoriaTemp.Objetivo = categoria.Objetivo;
                       


                        //Atualiza com o id informado
                        _ctx.Categoria.Update(CategoriaTemp);

                        //Salva as alterações no contexto
                        _ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            public void Remover(int id)
            {
                try
                {
                    //Usa o método BuscarPorId para verificar a existência da instituição informada
                    Categoria CategoriaTemp = BuscarPorId(id);

                    //Se ela não existir é informado que a instituição não foi encontrada
                    if (CategoriaTemp == null)
                    {
                        throw new Exception("Usuário não encontrado");
                    }
                    else
                    {
                        //Remove a instituição informada do contexto
                        _ctx.Categoria.Remove(CategoriaTemp);

                        //Salva todas as alterações
                        _ctx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            #endregion
        }

    }




   
        
     

     
    
   
