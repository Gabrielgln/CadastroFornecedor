using CadastroFornecedor1.Models;

namespace CadastroFornecedor1.Repositorio

{
    public interface IContatoRepositorio
    {
        FornecedorModel ListarPorId(int id);
        List<FornecedorModel> BuscarTodos();
        FornecedorModel Adicionar(FornecedorModel fornecedor);
        FornecedorModel Atualizar(FornecedorModel fornecedor);

        bool Apagar(int id);
    }
}
