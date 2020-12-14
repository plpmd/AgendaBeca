using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaBeca
{
	class Agenda
	{
		static bool AgendaAberta = false;
		static List<Pessoa> agenda = new List<Pessoa> { };

		public void AbreAgenda()
		{
			AgendaAberta = true;
			Console.BackgroundColor = ConsoleColor.White;
			Console.ForegroundColor = ConsoleColor.Blue;
			while (AgendaAberta)
			{
				MenuDeOpcoes();
			}
		}

		private static void MenuDeOpcoes()
		{
			Console.Clear();

			Console.WriteLine("\r\nAgenda Pedro Solutions");
			Console.WriteLine("\r\nO que você deseja fazer?");
			Console.WriteLine("\r\nArmazenar pessoa na agenda    [1]");
			Console.WriteLine("\r\nRemover pessoa da agenda      [2]");
			Console.WriteLine("\r\nBuscar pessoa na agenda       [3]");
			Console.WriteLine("\r\nImprimir pessoa pelo índice  [4]");
			Console.WriteLine("\r\nImprimir toda a agenda        [5]");
			Console.WriteLine("\r\nSair                          [6]");
			try
			{
				int opcao = int.Parse(Console.ReadLine());

				RecebeDadosEChamaAFuncao(opcao);
			}
			catch (Exception)
			{
				Console.Clear();

				Console.WriteLine("Digite dados válidos!");
				Console.WriteLine("Digite qualquer tecla para continuar . . .");
				Console.ReadLine();
			}

			

		}

		private static void RecebeDadosEChamaAFuncao(int opcao)
		{
			Console.Clear();
			switch (opcao)
			{
				case 1:
					Console.WriteLine("\r\nArmazenar nova pessoa");
					Console.WriteLine("\r\nDigite o nome da pessoa: ");
					string nome = Console.ReadLine();

					Console.WriteLine($"\r\nDigite a idade de {nome}: ");
					int idade = int.Parse(Console.ReadLine());

					Console.WriteLine($"\r\nDigite a altura de {nome}: ");
					Console.WriteLine($"\r\nEx: 1.70");
					float altura = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

					ArmazenaPessoa(nome, idade, altura);
					Console.WriteLine("\r\nAperte qualquer tecla para voltar ao menu . . .");
					Console.ReadLine();
					break;

				case 2:
					Console.WriteLine("\r\nRemover pessoa");
					Console.WriteLine("\r\nDigite o nome da pessoa: ");
					string nomeRemover = Console.ReadLine();
					RemovePessoa(nomeRemover);
					Console.WriteLine("\r\nAperte qualquer tecla para voltar ao menu . . .");
					Console.ReadLine();
					break;

				case 3:
					Console.WriteLine("\r\nBuscar pessoa pelo nome");
					Console.WriteLine("\r\nDigite o nome da pessoa: ");
					string nomeBusca = Console.ReadLine();
					int indexBusca = BuscaPessoa(nomeBusca);
					Console.WriteLine($"Índice de {nomeBusca} na agenda: {indexBusca + 1}");
					Console.WriteLine("\r\nAperte qualquer tecla para voltar ao menu . . .");
					Console.ReadLine();
					break;

				case 4:
					Console.WriteLine("\r\nBuscar pessoa pelo índice");
					Console.WriteLine("\r\nDigite o índice da pessoa [1-10]: ");
					int index = int.Parse(Console.ReadLine());
					ImprimePessoa(index);
					Console.WriteLine("\r\nAperte qualquer tecla para voltar ao menu . . .");
					Console.ReadLine();
					break;

				case 5:
					Console.WriteLine("\r\nSua agenda:");
					ImprimeAgenda();
					Console.WriteLine("\r\nAperte qualquer tecla para voltar ao menu . . .");
					Console.ReadLine();

					break;

				case 6:
					Console.WriteLine("\r\nAperte qualquer tecla para fechar agenda . . .");
					Console.ReadLine();
					AgendaAberta = false;
					break;

			}
		}

		static void ArmazenaPessoa(string nome, int idade, float altura)
		{
			Console.Clear();
			if (agenda.Count < 10)
			{
				Pessoa pessoa = new Pessoa(nome, idade, altura);
				agenda.Add(pessoa);
				Console.WriteLine($"\r\n{nome} armazenado(a) na agenda!");
				AdicionaPessoaNoTxt(pessoa);
			}
			else
			{
				Console.WriteLine("\r\nA agenda está cheia!");
			}

		}

		static void RemovePessoa(string nome)
		{
			Console.Clear();
			var pessoaRemovida = agenda.Single(pessoa => pessoa.Nome == nome);
			agenda.Remove(pessoaRemovida);
			RemovePessoaNoTxt(pessoaRemovida);
			Console.WriteLine($"\r\n{nome} foi removido(a) da agenda.");

		}

		static int BuscaPessoa(string nome)
		{
			Console.Clear();
			return agenda.FindIndex(pessoa => pessoa.Nome == nome);
		}

		static void ImprimeAgenda()
		{
			Console.Clear();
			foreach (Pessoa pessoa in agenda)
			{
				Console.WriteLine("\r\n" + pessoa.ToString());
			}
			if(agenda.Count == 0)
			{
				Console.WriteLine("\r\n A agenda ainda está vazia . . . ");
			}
		}

		static void ImprimePessoa(int index)
		{
			Console.Clear();
			Pessoa pessoa = agenda[index - 1];
			Console.WriteLine(pessoa.ToString());

		}

		static void AdicionaPessoaNoTxt(Pessoa pessoa)
		{
			string fileName = @"C:\Temp\Agenda.txt";
			
			using (StreamWriter sw = File.AppendText(fileName))
			{
				sw.WriteLine(pessoa.ToString());
			}
			
		}

		static void RemovePessoaNoTxt(Pessoa pessoa)
		{
			string username = pessoa.Nome;
			string fileName = @"C:\temp\agenda.txt";
			Boolean encontrado = false;
			List<string> newLines = new List<string>();
			string[] allLines = File.ReadAllLines(fileName);
			foreach (string line in allLines)
			{
				string[] splitedLine = line.Split(',');
				if (splitedLine[0] == $"Nome: {username}")
				{
					string rightLine = line;
					Console.WriteLine($"\r\nUsuário encontrado:");
					Console.WriteLine(rightLine);

					Console.ReadLine();
					encontrado = true;
				}
				else
				{
					newLines.Add(line);
				}
			}

			if (encontrado)
			{
				File.WriteAllText(fileName, String.Empty);

				using (StreamWriter sw = File.AppendText(fileName))
				{
					foreach (string line in newLines)
					{
						sw.WriteLine(line);
					}
				}
				Console.WriteLine("Deleção efetuada com sucesso");
			}
			else
			{
				Console.WriteLine("Usuário não encontrado!");
				Console.ReadLine();
			}

		}

	}
}
