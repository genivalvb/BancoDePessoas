using System;

namespace DIO.RegistroPessoas
{
    public class Pessoa : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Nome { get; set; }
        private string Obras { get; set; }
        private string DataNascimento { get; set; }
        private string Descricao { get; set; }
        private bool Excluido { get; set; }

        public Pessoa(int id, Genero genero, string nome, string obras, string dataNascimento,
                        string descricao )
                        {
                            this.Id = id;
                            this.Genero = genero;
                            this.Nome = nome;
                            this.Obras = obras;
                            this.DataNascimento = dataNascimento;
                            this.Descricao = descricao;
                            this.Excluido = false;
                        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Obras: " + this.Obras + Environment.NewLine;
            retorno += "Data de Nascimento: " + this.DataNascimento + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }

        internal int retornaId()
        {
            return this.Id;
        }

        public void Excluir(){
            this.Excluido = true;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    }
}