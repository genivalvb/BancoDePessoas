using System;
using System.Collections.Generic;
using DIO.RegistroPessoas.Interfaces;

namespace DIO.RegistroPessoas
{
    public class PessoaRepositorio : IRepositorio<Pessoa>
    {
        private List<Pessoa> listaPessoa = new List<Pessoa>();
        public void Atualiza(int id, Pessoa entidade)
        {
            listaPessoa[id] = entidade;
        }

        public void exclui(int id)
        {
            listaPessoa[id].Excluir();
        }

        public void Insere(Pessoa entidade)
        {
            listaPessoa.Add(entidade);
        }

        public List<Pessoa> Lista()
        {
            return listaPessoa;
        }

        public int ProximoId()
        {
            return listaPessoa.Count;
        }

        public Pessoa RetornaPorId(int id)
        {
            return listaPessoa[id];
        }
    }
}