using CadastroFornecedor.Data;
using CadastroFornecedor1.Models;


namespace CadastroFornecedor1.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext) 
        {
            this._bancoContext = bancoContext;
        }

        public FornecedorModel Atualizar(FornecedorModel fornecedor)
        {
            FornecedorModel fornecedorModel = ListarPorId(fornecedor.Id);

            if (fornecedorModel == null) throw new System.Exception("Houve um erro na atualização do fornecedor!");

            fornecedorModel.Nome = fornecedor.Nome;
            fornecedorModel.Cnpj = fornecedor.Cnpj;
            fornecedorModel.Especialidade = fornecedor.Especialidade;

            _bancoContext.Update(fornecedorModel);
            _bancoContext.SaveChanges();

            return fornecedorModel;
        }

        public FornecedorModel ListarPorId(int id)
        {
            return _bancoContext.Fornecedores.FirstOrDefault(x => x.Id == id);
        }

        public List<FornecedorModel> BuscarTodos()
        {
            return _bancoContext.Fornecedores.ToList();
        }
        public FornecedorModel Adicionar(FornecedorModel fornecedor)
        {
            _bancoContext.Fornecedores.Add(fornecedor);
            _bancoContext.SaveChanges();
            return fornecedor;
        }

        public bool Apagar(int id)
        {
            FornecedorModel fornecedorModel = ListarPorId(id);

            if (fornecedorModel == null) throw new System.Exception("Houve um erro na deleção do fornecedor!");

            _bancoContext.Fornecedores.Remove(fornecedorModel);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
