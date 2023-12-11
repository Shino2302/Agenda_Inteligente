using Agenda_Inteligente.Data;
using Agenda_Inteligente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Agenda_Inteligente.Controllers
{
    public class HomeController : Controller
    {
        private readonly Agenda_InteligenteContext _context;

        public HomeController(Agenda_InteligenteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string nombreDeUsuario, string password)
        {
            var usuarioAutenticado = _context.Usuario.FirstOrDefault(u => u.NombreDeUsuario == nombreDeUsuario && u.Password == password);

            if (usuarioAutenticado != null)
            {
                // Autenticación exitosa
                // Puedes agregar la lógica de sesión aquí si es necesario
                return RedirectToAction("Index", "Usuarios"); // Redirige a la página principal después del inicio de sesión
            }
            else
            {
                // Autenticación fallida
                ViewBag.ErrorMensaje = "Nombre de usuario o contraseña incorrectos";
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}