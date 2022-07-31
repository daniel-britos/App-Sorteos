using Microsoft.AspNetCore.Http;
using SorteoApp.Models;
using SorteoApp.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System;
using static SorteoApp.Models.Participante;
using System.Configuration;



namespace SorteoApp.Controllers
{
    public class ParticipantesController : Controller
    {
        private ApplicationDbContext _context;
        public ParticipantesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Formulario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(Participante participante, string nombre, 
                                      string apellido, string dni, string direccion, 
                                      string email, int codigopostal, string localidad, 
                                      string provincia, bool legal) //Participante participante, string nombre, string apellido, string dni, string direccion, string email, int codigopostal, string localidad, string provincia, bool confirmar
        {

            Participante oParticipante = new Participante()
            {

                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                Email = email,
                Direccion = direccion,
                CodigoPostal = codigopostal,
                Localidad = localidad,
                Provincia = provincia,
                Legal = legal
            };
            
            if (!ModelState.IsValid)
            {
                return View("Formulario", participante);
            };
            
            _context.Participantes.Add(oParticipante);        
            _context.SaveChanges();


            return View("Registro");  

        }


        public IActionResult Inscriptos()
        {
            ViewBag.Cantidad = _context.Participantes.Count();

            return View();
        }
    
        public IActionResult Selector()
        {
            return View();
        }

        public IActionResult Resultado()
        {
            //lista DNI en pantalla
            //ViewBag.SelectorGanador = _context.Participantes.OrderByDescending(x => x.Dni).ToList();

            //selecciona nombre y apellido y lo muestra en pantalla
            //Creo variable random
            Random rand = new Random();
            //selecciono un numero random desde el 0 hasta el numero maximo de inscriptos en la bdd
            var randoms = rand.Next(0, _context.Participantes.Count());
            //skip(saltea random) - Take(toma 1) - Select(selecciona x de x.nombre - FirstOrderDefault(devuelve la primera de una lista o null si no encuentra coincidencia)
            var nombre = _context.Participantes.Skip(randoms).Take(1).Select(p => p.Nombre).FirstOrDefault();
            var apellido = _context.Participantes.Skip(randoms).Take(1).Select(p => p.Apellido).FirstOrDefault();
            var dni = _context.Participantes.Skip(randoms).Take(1).Select(p => p.Dni).FirstOrDefault();
            var provincia = _context.Participantes.Skip(randoms).Take(1).Select(p => p.Provincia).FirstOrDefault();
            var localidad = _context.Participantes.Skip(randoms).Take(1).Select(p => p.Localidad).FirstOrDefault();
            ViewBag.RandomNombre = nombre;
            ViewBag.RandomApellido = apellido;
            ViewBag.RandomDni = dni;
            ViewBag.RandomProvincia = provincia;
            ViewBag.RandomLocalidad = localidad;
            return View();
        }

    }
}
