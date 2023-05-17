using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ex004.Entities;

namespace Ex004.Repositories
{
    /// <summary>
    /// Classe para acesso a banco de dados e transações com a entidade Empresa
    /// </summary>
    public class EmpresaRepository : BaseRepository
    {
        /// <summary>
        /// Método para gravar uma empresa na base de dados
        /// </summary>
        /// <param name="empresa">Objeto da entidade empresa</param>
        public void Inserir(Empresa empresa)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_IncluirEmpresa", //nome da procedure
                    new // passagem de parametros da procedure
                    {
                        empresa.RazaoSocial, //@RazaoSocial
                        empresa.Cnpj //Cnpj
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                    
            }
        }

        /// <summary>
        /// Método para atualizar uma empresa na base de dados
        /// </summary>
        /// <param name="empresa">Objeto da entidade empresa</param>
        public void Atualizar(Empresa empresa)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_AlterarEmpresa", //nome da procedure
                    new // passagem de parametros da procedure
                    {
                        empresa.Id, //@Id
                        empresa.RazaoSocial, //@RazaoSocial
                        empresa.Cnpj //Cnpj
                    },
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// Método para Excluir uma empresa na base de dados
        /// </summary>
        /// <param name="empresa">Objeto da entidade empresa</param>
        public void Exluir(Empresa empresa)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_ExcluirEmpresa", //nome da procedure
                    new // passagem de parametros da procedure
                    { 
                        empresa.Id, //@Id                  
                    },
                    commandType: System.Data.CommandType.StoredProcedure);

            }
        }
        /// <summary>
        /// Método para consultar empresas na base de dados
        /// </summary>
        /// <returns>Lista de objetos com a classe Empresa</returns>
        public List<Empresa> ObterTodos()
        {
            var query = "select * from Empresa order by RazaoSocial asc";

            using ( var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Empresa>(query).ToList();
            }
        }

        /// <summary>
        /// Método para consultar 1 empresa baseado no Id na base de dados
        /// </summary>
        /// <param name="Id">Valor da chave primária da empresa desejada</param>
        /// <returns>Objeto da entidade Empresa</returns>
        public Empresa ObterPorId(Guid id)
        {
            var query = "select * from Empresa where Id = @id";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Empresa>(query, new { id }).FirstOrDefault();
            }
        }

    }
}
