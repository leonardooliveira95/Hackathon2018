using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface ICidadeRepository
    {
        IEnumerable<Cidade> Get();
        IEnumerable<Cidade> Get(string _Nome);
        IEnumerable<Cidade> GetUf(string _Estado);
        bool Add(Cidade _Cidade);
        bool Update(Cidade _Cidade);
        bool Delete(int _Id);
    }
}
