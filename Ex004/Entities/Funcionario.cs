using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex004.Entities
{
    public class Funcionario
    {
        #region

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataAdmissao { get; set; }
        public Guid EmpresaId { get; set; }
        #endregion

        #region Associações

        public Empresa Empresa { get; set; }

        #endregion
    }
}
