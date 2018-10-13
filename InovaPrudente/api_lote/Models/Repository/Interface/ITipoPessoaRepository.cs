using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface ITipoPessoaRepository
    {
        IEnumerable<TipoPessoa> Get();
        TipoPessoa Get(int id);
        IEnumerable<TipoPessoa> Get(string descricao);
        bool Add(TipoPessoa tipopessoa);
        bool Update(TipoPessoa tipopessoa);
        bool Delete(int id);
    }
}
