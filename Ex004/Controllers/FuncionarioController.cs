using Ex004.Entities;
using Ex004.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex004.Controllers
{
    public class FuncionarioController
    {
        private readonly FuncionarioRepository funcionarioRepository;

        public FuncionarioController()
        {
            funcionarioRepository = new FuncionarioRepository();    
        }

        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\n < CADASTRO DE FUNCIONÁRIO > \n");
                Console.WriteLine(" SEJAM MUITO BEM-VINDO, PREENCHA AS INFORMAÇÕES ABAIXO COM SEUS DADOS PESSOAIS ");

                var funcionario = new Funcionario();

                Console.Write("NOME: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("CPF: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("DATA DE ADMISSÃO: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.Write("ID: ");
                funcionario.EmpresaId = Guid.Parse(Console.ReadLine());

                funcionarioRepository.Inserir(funcionario);

                Console.WriteLine("\n< FUNCIONÁRIO CADASTRADO COM SUCESSO >");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
        }

        public void ConsultarFuncionarios()
        {
            try
            {
                Console.WriteLine("\n < CONSULTAR FUNCIONÁRIO > \n");

                foreach (var item in funcionarioRepository.ObterTodos())
                {
                    Console.WriteLine("ID: " + item.Id);
                    Console.WriteLine("NOME: " + item.Nome);
                    Console.WriteLine("CPF: " + item.Cpf);
                    Console.WriteLine("DATA ADMISSAO: " + item.DataAdmissao.ToString("dd/MM/yyyy"));

                    Console.WriteLine("\tEMPRESA ID: " + item.Empresa.Id);
                    Console.WriteLine("\tRAZAO SOCIAL: " + item.Empresa.RazaoSocial);
                    Console.WriteLine("\tCNPJ: " + item.Empresa.Cnpj);

                    Console.WriteLine(" -------------<>------------- ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
        }
        
        public void ConsultarPorId(Guid id)
        {
            try
            {
                Console.WriteLine("\n < CONSULTAR FUNCIONÁRIO POR ID> \n");              

                var func = funcionarioRepository.ObterPorId(id);

                if (func != null)
                {
                    Console.WriteLine(" < FUNCIONÁRIO: " + func.Nome + " > ");   
                    Console.WriteLine("\tCPF: " + func.Cpf);
                    Console.WriteLine("\tID: " + func.Id);
                    Console.WriteLine("\tDATA ADMISSAO: " + func.DataAdmissao);
                    Console.WriteLine("\tEMPRESA ID: " + func.EmpresaId);
                    Console.WriteLine(" -------------<>------------- ");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
        }

        public void ExcluirPorId(Guid id)
        {
            try
            {
                Console.WriteLine($"\n < EXCLUIR FUNCIONÁRIO POR ID: {id} > ");

                var func = funcionarioRepository.ObterPorId(id);

                if (func != null)
                {
                    funcionarioRepository.Excluir(func);

                    Console.WriteLine("< FUNCIONÁRIO EXCLUIDO COM SUCESSO >");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
        }

        public void AtualizarPorId(Guid id)
        {
            try
            {
                Console.WriteLine($"\n < ATUALIZAR FUNCIONÁRIO POR ID: {id} > ");
                Console.WriteLine(" SEJAM MUITO BEM-VINDO, PREENCHA AS INFORMAÇÕES ABAIXO COM SEUS DADOS PESSOAIS ");

                var func = funcionarioRepository.ObterPorId(id);

                if (func != null)
                {
                    var funcionario = new Funcionario();

                    Console.Write("NOME: ");
                    func.Nome = Console.ReadLine();

                    Console.Write("CPF: ");
                    func.Cpf = Console.ReadLine();

                    Console.Write("DATA DE ADMISSÃO: ");
                    func.DataAdmissao = DateTime.Parse(Console.ReadLine());

                    Console.Write("ID: ");
                    func.EmpresaId = Guid.Parse(Console.ReadLine());

                    funcionarioRepository.Atualizar(func);

                    Console.WriteLine("\n< FUNCIONÁRIO ATUALIZADO COM SUCESSO >");
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRO: " + e.Message);
            }
        }
    }
}
