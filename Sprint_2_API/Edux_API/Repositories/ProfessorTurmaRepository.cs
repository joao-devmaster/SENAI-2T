using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurmaRepository
    {
        private readonly EduxContext _ctx;

        public ProfessorTurmaRepository()
        {
            _ctx = new EduxContext();
        }

        #region Leitura

        public ProfessorTurma BuscarPorId(int id)
        {
            try
            {
                return _ctx.ProfessorTurma.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProfessorTurma> Listar()
        {
            try
            {
                return _ctx.ProfessorTurma.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Gravacao
        public void Adicionar(ProfessorTurma profturm)
        {
            try
            {
                // O contexto recebe o objeto inst do método
                _ctx.Add(profturm);


                //Salva as alterações no banco de dados Edux
                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Editar(int id, ProfessorTurma profturm)
        {
            try
            {
                // BuscarPorId para verificar a existência do usuário informado
                ProfessorTurma ProfTurmTemp = BuscarPorId(id);

                //Se ela não existir é informado que o usuário não foi encontrado
                if (ProfTurmTemp == null)
                {
                    throw new Exception("Usuário não encontrado");
                }
                else
                {
                    //Caso contrário salva todas as alterações no objeto usuarioTemp
                    ProfTurmTemp.Descricao = profturm.Descricao;
                   
                    //Atualiza com o id informado
                    _ctx.ProfessorTurma.Update(profturm);

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
                ProfessorTurma ProfTurmTemp = BuscarPorId(id);

                //Se ela não existir é informado que a instituição não foi encontrada
                if (ProfTurmTemp == null)
                {
                    throw new Exception("Professorturma não encontrado");
                }
                else
                {
                    //Remove a instituição informada do contexto
                    _ctx.ProfessorTurma.Remove(ProfTurmTemp);

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

