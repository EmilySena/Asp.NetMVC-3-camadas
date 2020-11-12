using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Supermercado3.Negocios;

namespace Supermercado3.Web.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome deve ser preenchido")]
        public string Nome { get; set; }
        [Range(18, 50, ErrorMessage = "Idade entre 18 e 50 anos")]
        [Required(ErrorMessage = "A idade deve ser preenchido")]
        public int Idade { get; set; }
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [RegularExpression(@"[a-zA-Z]{5,15}", ErrorMessage = "Somente letras, 5 a 15 caracteres")]
        [Required(ErrorMessage = "Login deve ser preenchido")]
        [Remote("LoginUnico", "Pessoa", ErrorMessage = "Esse nome de login já existe")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A senha deve ser informada")]
        public string Senha { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não conferem")]
        public string ConfirmarSenha { get; set; }
        public PessoaViewModel()
        {

        }

        public PessoaViewModel(Pessoa pessoa)
        {
            Id = pessoa.Id;
            Nome = pessoa.Nome;
            Idade = pessoa.Idade;
            Email = pessoa.Email;
            Login = pessoa.Login;
        }
    }
}