using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiInovaPP.Models.Repository.Interface
{
    public interface IPessoaRepository
    {
        IEnumerable<Pessoa> GetAll();
        Pessoa GetById(int _Id);
        IEnumerable<Pessoa> GetByNome(string _Tipo, string _Nome);
        IEnumerable<Pessoa> GetByTipo(int _Tipo);
        IEnumerable<Pessoa> GetByCpfCnpj(string _Tipo, string _CpfCnpj);
        bool Add(Pessoa pessoa);
        bool Delete(int Id);
        bool Update(Pessoa pessoa);
    }
}
