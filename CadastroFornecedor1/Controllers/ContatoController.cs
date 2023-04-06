using CadastroFornecedor1.Models;
using CadastroFornecedor1.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace CadastroFornecedor1.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio) 
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<FornecedorModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {   
            FornecedorModel fornecedor = _contatoRepositorio.ListarPorId(id);
            return View(fornecedor);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            FornecedorModel fornecedor = _contatoRepositorio.ListarPorId(id);
                        
            return View(fornecedor);
        }

        public IActionResult Apagar(int id)
        {
            _contatoRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(FornecedorModel fornecedorModel)
        {
            _contatoRepositorio.Adicionar(fornecedorModel);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(FornecedorModel fornecedorModel)
        {
            _contatoRepositorio.Atualizar(fornecedorModel);
            return RedirectToAction("Index");
        }
    }
}
