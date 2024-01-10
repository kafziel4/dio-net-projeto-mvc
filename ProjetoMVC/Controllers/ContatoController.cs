using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers;

public class ContatoController(AgendaContext context) : Controller
{
    public IActionResult Index()
    {
        var contatos = context.Contatos.ToList();
        return View(contatos);
    }

    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(Contato contato)
    {
        if (!ModelState.IsValid)
        {
            return View(contato);
        }

        context.Contatos.Add(contato);
        context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Editar(int id)
    {
        var contato = context.Contatos.Find(id);

        if (contato is null)
        {
            return RedirectToAction(nameof(Index));
        }
        
        return View(contato);
    }

    [HttpPost]
    public IActionResult Editar(Contato contato)
    {
        var contatoBanco = context.Contatos.Find(contato.Id);

        if (contatoBanco is not null)
        {
            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;
        }

        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Detalhes(int id)
    {
        var contato = context.Contatos.Find(id);

        if (contato is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(contato);
    }

    public IActionResult Deletar(int id)
    {
        var contato = context.Contatos.Find(id);

        if (contato is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(contato);
    }

    [HttpPost]
    public IActionResult Deletar(Contato contato)
    {
        var contatoBanco = context.Contatos.Find(contato.Id);

        if (contatoBanco is null)
        {
            return RedirectToAction(nameof(Index));
        }

        context.Contatos.Remove(contatoBanco);
        context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}