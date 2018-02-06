using System;
using System.Collections.Generic;

namespace TesteTecnico
{
    class Program
    {

        #region Variaveis e propriedades

        private static Core.Servicos.Pessoa _Pessoa;

        #endregion

        #region Funções dos menus e entrada de dados

        private static void MontarMenuCadastroPessoa()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Cadastrar a localização de amigos. ");
            Console.WriteLine("----------------------------------------");
            Console.Write("Digite o nome da pessoa: ");
            string strNome = Console.ReadLine();

            Console.Write("Entre com a latitude ( Formato: -21,5070334899 ): ");
            string strLatitude = Console.ReadLine();

            Console.Write("Entre com a longitude ( Formato: -55,4119080998 ): ");
            string strLongitude = Console.ReadLine();

            RegistrarPessoa(strNome, strLatitude, strLongitude);

            Console.WriteLine();
            Console.Write("Deseja continuar cadastrando (S / N)?");
            if (Console.ReadLine().ToUpper().Equals("S"))
            {
                MontarMenuCadastroPessoa();
            }
            else
            {
                MontarMensagemVoltarMenuPrincipal();
            }

        }

        private static void MontarMenuListarAmigosCadastrados()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Listar todos amigos já cadastrados. ");
            Console.WriteLine("----------------------------------------");

            var lisPessoasRegistradas = _Pessoa.ListarPessoasRegistradas();

            if (lisPessoasRegistradas.Count > 0)
            {
                foreach (var objPessoa in lisPessoasRegistradas)
                {
                    Console.WriteLine(string.Format("Nome: {{0}}; Lat.: {{1}}; Long.: {{2}} "), objPessoa.Nome, objPessoa.Latitude, objPessoa.Longitude);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Não foi cadastrado nenhuma pessoa no sistema.");

            }

            MontarMensagemVoltarMenuPrincipal();

        }

        private static void MontarMenuConsultaPorNome()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Consultar amigos mais proximos por nome. ");
            Console.WriteLine("----------------------------------------");

            Console.Write("Entre com o nome que deseja pesquisar: ");

            var objPessoaEncontrada = _Pessoa.ConsultarPorNome(Console.ReadLine());

            if (objPessoaEncontrada != null)
            {
                MostrarTresPessoasProximasPorPessoa(objPessoaEncontrada);
            }
            else
            {
                Console.WriteLine("Não foi encontrado ninguem com o nome informado.");
                Console.Write("Deseja continuar com as pesquisas (S / N)? ");
                if (Console.ReadLine().ToUpper().Equals("S"))
                {
                    MontarMenuConsultaPorNome();
                }
                else
                {
                    MontarMensagemVoltarMenuPrincipal();
                }

            }

            MontarMensagemVoltarMenuPrincipal();
        }

        private static void MontarMenuListarAmigosProximos()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Listar amigos proximos da lista de amigos cadastrados. ");
            Console.WriteLine("----------------------------------------");

            var lisPessoasRegistradas = _Pessoa.ListarPessoasRegistradas();

            if (lisPessoasRegistradas.Count > 0)
            {
                foreach (var objPessoa in lisPessoasRegistradas)
                {
                    Console.WriteLine(string.Format("Nome: {{0}}; Lat.: {{1}}; Long.: {{2}} "), objPessoa.Nome, objPessoa.Latitude, objPessoa.Longitude);

                    MostrarTresPessoasProximasPorPessoa(objPessoa);
                    Console.WriteLine();

                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Não foi cadastrado nenhuma pessoa no sistema.");

            }

            MontarMensagemVoltarMenuPrincipal();
        }

        private static void MontarMenuPrincipal()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("1) Cadastrar a localização de amigos. ");
            Console.WriteLine("2) Consultar amigos mais proximos por nome. ");
            Console.WriteLine("3) Listar amigos proximos da lista de amigos cadastrados. ");
            Console.WriteLine("4) Listar todos amigos já cadastrados. ");
            Console.WriteLine("5) Sair do programa. ");
            Console.WriteLine("----------------------------------------");
            Console.Write("Escolha uma das opções para continuar: ");

            string _Opcao = Console.ReadLine();

            switch (_Opcao)
            {
                case "1":
                    MontarMenuCadastroPessoa();
                    break;

                case "2":
                    MontarMenuConsultaPorNome();
                    break;

                case "3":
                    MontarMenuListarAmigosProximos();
                    break;

                case "4":
                    MontarMenuListarAmigosCadastrados();
                    break;

                case "5":
                    return;                    

                default:
                    Console.WriteLine("Valor digitado não corresponde a uma das opções, realize a seleção novamente.");
                    Console.ReadKey();
                    Console.Clear(); //Limpa a tela para a renderização do menu novamente
                    MontarMenuPrincipal();
                    break;
            }
        }

        private static void MontarMensagemVoltarMenuPrincipal()
        {
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
            MontarMenuPrincipal();
        }


        private static void MostrarTresPessoasProximasPorPessoa(Core.Entidades.Pessoa objPessoaEncontrada)
        {
            //Retornar 3 Amigos mais proximo dessa pessoa
            List<Core.Entidades.PessoaDistancia> lisPessoasProximas = _Pessoa.PesquisarTresProximosAmigos(objPessoaEncontrada);

            if (lisPessoasProximas.Count > 0)
            {
                Console.WriteLine("Amigos mais perto da pessoa pesquisada:");

                foreach (var objPessoaProxima in lisPessoasProximas)
                {
                    Console.WriteLine(string.Format("Nome: {{0}}; Lat.: {{1}}; Long.: {{2}}; Distancia: {{3}} metros "),
                        objPessoaProxima.Nome, objPessoaProxima.Latitude, objPessoaProxima.Longitude, objPessoaProxima.Distancia);
                }
            }
            else
            {
                Console.WriteLine("Não foi encontrado ninguem com o nome informado.");
                Console.WriteLine("Deseja continuar com as pesquisas (S / N)? ");
                if (Console.ReadLine().ToUpper().Equals("S"))
                {
                    MontarMenuConsultaPorNome();
                }
                else
                {
                    MontarMensagemVoltarMenuPrincipal();
                }
            }

        }

        private static void RegistrarPessoa(string Nome, string Latitude, string Longitude)
        {
            Core.Entidades.Pessoa pessoa = new Core.Entidades.Pessoa();

            try
            {
                pessoa.CarregarEntidade(Nome, Latitude, Longitude);
                _Pessoa.AdicionarEntidadeNaLista(pessoa);
                Console.WriteLine("Pessoa cadastrada com sucesso!!");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Evento Main

        static void Main(string[] args)
        {
            _Pessoa = new Core.Servicos.Pessoa();

            MontarMenuPrincipal();

            Console.WriteLine("Aperte qualquer tecla para finalizar o programa");
            Console.ReadKey();

            return;
        }

        #endregion

    }
}
