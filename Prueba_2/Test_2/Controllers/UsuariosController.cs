// HomeController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test_2.Data;
using System.Linq;
using Test_2.Servicios;
using Test_2.Interfaces;

namespace Test_2.Controllers
{
    public class UsuariosController : Controller
    {

        private readonly IRepositorioUsuarios repositorioUsuarios;

        public UsuariosController(IRepositorioUsuarios repositorioUsuarios)
        {
            this.repositorioUsuarios = repositorioUsuarios;
        }

        public IActionResult Index()
        {
            var topUsuarios = repositorioUsuarios.Top10User();
            return View(topUsuarios);
        }
    }
}
