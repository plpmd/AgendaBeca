using System.Globalization;

namespace AgendaBeca
{
	class Pessoa
	{
		private string nome;
		private int idade;
		private float altura;
		public string Nome { get => nome; private set => nome = value; }

		public float Altura { get => altura; private set => altura = value; }

		public int Idade { get => idade; private set => idade = value; }

		//private DateTime DataDeNascimento { get; set ; }	


		//public int AchaIdade()
		//{
		//	DateTime dataAtual = DateTime.Today;
		//	return dataAtual.Year - DataDeNascimento.Year;
		//}

		public Pessoa(string nome, int idade, float altura)
		{
			Nome = nome;
			Altura = altura;
			Idade = idade;
		}
		public override string ToString()
		{
			return $"Nome: {Nome}, Idade: {Idade} anos, Altura: {Altura.ToString("F2", CultureInfo.InvariantCulture)}";
		}
	}
}
