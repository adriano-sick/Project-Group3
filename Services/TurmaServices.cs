using Group3.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TurmaServices
    {
        private readonly TurmaRepository _turmaRepository;

        public TurmaServices()
        {
            _turmaRepository = new TurmaRepository();
        }

        public List<Turma> GetTurmas()
        {
            try
            {
                var list = _turmaRepository.GetTurmas();
                return list;
            }
            catch (Exception)
            {
                return new();
            }
        }

        public async Task<Turma> AddAvaliacao(Turma turma)
        {
            return await _turmaRepository.AddTurma(turma);
        }
    }
}
