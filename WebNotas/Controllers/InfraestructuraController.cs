using Microsoft.AspNetCore.Mvc;

namespace WebNotas.Controllers
{
    public class InfraestructuraController : Controller
    {
        public IActionResult Index()
        {
            return View("Folleto");
        }
        public IActionResult Folleto()
        {
            return View();
        }
        public IActionResult Primero() 
        {
            ViewData["Año"] = "Primer año";
            ViewData["Materias"] = new string[] { "Comunicación (1° cuat.)", "Unidad de definición Institucional (2° cuat.)", "Matemática", "Física Aplicada a las Tecnologías de la Información", "Administración ", "Inglés Técnico ", "Arquitectura de las Computadoras", "Lógica y Programación  ", "Infraestructura de Redes I" };
            return View("Materias");
        }
        public IActionResult Segundo()
        {
            ViewData["Año"] = "Segundo año";
            ViewData["Materias"] = new string[] { "Problemáticas Socio Contemporáneas (1° cuat.)Unidad de definición Institucional (2° cuat.)","Innovación y Desarrollo Emprendedor","Estadística","Sistemas Operativos","Algoritmos y Estructuras de Datos ","Base de Datos ","Infraestructura de Datos II ","Práctica Profesionalizante I" };
            return View("Materias");
        }
        public IActionResult Tercero()
        {
            ViewData["Año"] = "Tercer año";
            ViewData["Materias"] = new string[] { "Ética y Responsabilidad Social","Derecho y Legislación Laboral ","Administración de Base de Datos ","Integridad y Migración de Datos ","Seguridad de los Sistemas ","Administración de Sistemas ","Operativos y Redes ","Práctica Profesionalizante II " };
            return View("Materias");
        }
    }
}
