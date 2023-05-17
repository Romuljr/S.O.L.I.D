using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex004.Controllers;

namespace Ex004
{
    public class Program
    {
        static void Main(string[] args)
        {

            var funcionarioController = new FuncionarioController();

            try
            {
                Console.Write("\n < RÔMULO S.A SOLUÇÕES > \n");
                Console.WriteLine("[ 1 ] - CADASTRAR FUNCIONÁRIO");
                Console.WriteLine("[ 2 ] - ATUALIZAR FUNCIONÁRIO");
                Console.WriteLine("[ 3 ] - CONSULTAR FUNCIONÁRIOS");
                Console.WriteLine("[ 4 ] - CONSULTAR FUNCIONÁRIO POR ID");
                Console.WriteLine("[ 5 ] - EXCLUIR FUNCIONÁRIO");
                Console.WriteLine("[ 6 ] - SAIR DO PROGRAMA");
                Console.WriteLine(" -------------<>------------- ");

                Console.Write("SUA OPÇÃO => ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        funcionarioController.CadastrarFuncionario();
                        break;

                    case 2:

                        Console.WriteLine(" DIGITE O NÚMERO DE 'ID' REFERENTE A UM FUNCIONÁRIO EXISTE ");
                        var idGuid = Console.ReadLine();

                        funcionarioController.AtualizarPorId(Guid.Parse(idGuid));
                        break;

                    case 3:

                        funcionarioController.ConsultarFuncionarios();
                        break;

                    case 4:
                        Console.WriteLine(" DIGITE O NÚMERO DE 'ID' REFERENTE A UM FUNCIONÁRIO EXISTE ");
                        var idGuid2 = Console.ReadLine();

                        funcionarioController.ConsultarPorId(Guid.Parse(idGuid2));
                        break;

                    case 5:
                        Console.WriteLine(" DIGITE O NÚMERO DE 'ID' REFERENTE A UM FUNCIONÁRIO EXISTE ");
                        var idGuid3 = Console.ReadLine();

                        funcionarioController.ExcluirPorId(Guid.Parse(idGuid3));    
                        break;

                    case 6:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("OPÇÃO INVÁLIDA: " + e.Message);
            }

        }
    }
}
