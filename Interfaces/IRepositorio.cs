using System.Collections.Generic;

namespace DIO.RegistroPessoas.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);

        void Insere(T entidade);

        void exclui(int id);

        void Atualiza(int id, T entidade);

        int ProximoId();

    }
}