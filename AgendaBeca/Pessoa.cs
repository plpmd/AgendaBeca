using System;
using System.Globalization;

namespace AgendaBeca
{
	class Pessoa
	{

		private int id = 0;
		public string Nome { get ; private set ; }

		public float Altura { get; private set ; }

		public int Idade { get; private set; }




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
