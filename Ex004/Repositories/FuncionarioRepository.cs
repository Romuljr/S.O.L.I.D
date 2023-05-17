using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Ex004.Entities;

namespace Ex004.Repositories
{
    /// <summary>
    /// Classe para acesso a banco de dados e transações com a entidade Funcionario
    /// </summary>
    public class FuncionarioRepository : BaseRepository
    {
        /// <summary>
        /// Método para inserir um funcionario na base de dados
        /// </summary>
        /// <param name="funcionario">Objeto da classe Funcioanrio</param>
        public void Inserir(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_IncluirFuncionario",
                    new
                    {
                        funcionario.Nome,
                        funcionario.Cpf,
                        funcionario.DataAdmissao,
                        funcionario.EmpresaId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Método para Atualizar um funcionario na base de dados
        /// </summary>
        /// <param name="funcionario">Objeto da classe Funcioanrio</param>
        public void Atualizar(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_AlterarFuncionario",
                    new
                    {
                        funcionario.Id,
                        funcionario.Nome,
                        funcionario.Cpf,
                        funcionario.DataAdmissao,
                        funcionario.EmpresaId
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Método para Excluir um funcionario na base de dados
        /// </summary>
        /// <param name="funcionario">Objeto da classe Funcioanrio</param>
        public void Excluir(Funcionario funcionario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(
                    "SP_ExcluirFuncionario",
                    new
                    {
                        funcionario.Id,
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Método para consultar todos os funcionarios na base de dados
        /// </summary>
        /// <returns>Lista de objetos de entidade Funcionario</returns>  
        public List<Funcionario> ObterTodos()
        {
            var query = "select * from Funcionario f inner join Empresa e "
                      + "on e.Id = f.EmpresaId order by Nome asc";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query,
                    (Funcionario f, Empresa e) =>
                    {
                        f.Empresa = e;
                        return f;
                    },
                    splitOn: "EmpresaId")
                    .ToList();
            }


        }

        /// <summary>
        /// Método para consultar 1 funcionario pelo id na base de dados
        /// </summary>
        /// <param name="id">valor da chave primaria da empresa desejada</param> 
        /// <returns>Objeto da classe de entidade</returns>  
        public Funcionario ObterPorId(Guid id)
        {
            var query = "select * from Funcionario f inner join Empresa e "
                      + "on e.Id = f.EmpresaId where f.Id = @id";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query(query,
                    (Funcionario f, Empresa e) =>
                    {
                        f.Empresa = e;
                        return f;
                    },
                    new { id },
                    splitOn: "EmpresaId")
                    .FirstOrDefault();
            }

        }
    }
}
