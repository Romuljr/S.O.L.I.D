using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex004.Entities
{
    public class Empresa
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }

        #endregion

        #region Associações

        public List<Funcionario> Funcionarios { get; set; }

        #endregion

    }
}
