using CadastroPessoas.Models;
using CadastroPessoas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CadastroPessoas.Controllers
{
    public class PessoaController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarPost(PessoaViewModel dados)
        {  
            using (Conexao db = new Conexao())
            {
                dados.TratarDados();
                dados.Validar();

                Pessoa model = new Pessoa();
                model.Nome = dados.Nome;
                model.DataNascimento = dados.DataNascimento.Value;
                model.Sexo = dados.Sexo;
                model.EstadoCivil = dados.EstadoCivil;
                model.CPF = dados.CPF;
                model.CEP = dados.CEP;
                model.Endereco = dados.Endereco;
                model.Numero = dados.Numero;
                model.Complemento = dados.Complemento;
                model.Bairro = dados.Bairro;
                model.Cidade = dados.Cidade;
                model.UF = dados.UF;
                model.Email = dados.Email;

                db.Pessoa.Add(model);
                db.SaveChanges();
            }

            return RedirectToAction("Cadastrar");
        }
    }
}