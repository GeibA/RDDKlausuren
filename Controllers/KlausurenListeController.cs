using Klausuren.Models;
using Microsoft.AspNetCore.Mvc;

namespace Klausuren.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlausurenListeController : ControllerBase
    {
        private static readonly string[] Studiengänge = new[]
        {
        "IT-Management M.Sc.", "Wirtschaftsinformatik B.Sc.", "Digitale Medien B.Sc.", "Management M.Sc.", "Angewandte Informatik B.Sc."
        };

        private static readonly string[] Modulnamen = new[]
        {
            "Integration Management", "IT Service Management", "Human Resource Management & Leadership", "Enterprise Architecture Management", "Forschung & Praxis", "Methoden der Wirtschafsinformatik", "Innovation & IT"
        };

        private static readonly string[] Beschreibungen = new[]
        {
            "Gesamter Inhalt des Semesters", "Themenliste (Siehe OLAT)", "Ergebnisse der Gruppenarbeiten", "Inhalte der RDDs", "Vorlesungsunterlagen und Einführungskurs auf YouTube"
        };

        private static readonly string[] Standorte = new[]
        {
            "Campus", "Holzstraße", "Wallstraße"
        };

        private static readonly string[] Räume = new[]
        {
            "D 1.09", "Aula", "Hybrid", "Mensa", "A 3.10"
        };

        private static readonly int[] Dauer = new[]
        {
            45,60,90,120
        };

        private readonly ILogger<KlausurenListeController> _logger;

        public KlausurenListeController(ILogger<KlausurenListeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetKlausuren")]
        public IEnumerable<Klausur> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Klausur
            {
                ECTS = Random.Shared.Next(3, 7),
                Modul = Modulnamen[index],
                Beschreibung = Beschreibungen[Random.Shared.Next(Beschreibungen.Length)],
                Studiengänge = new[] { Studiengänge[Random.Shared.Next(Studiengänge.Length)], Studiengänge[Random.Shared.Next(Studiengänge.Length)] },
                Standort = Standorte[Random.Shared.Next(Standorte.Length)],
                Stockwerk = Random.Shared.Next(-1, 3),
                Raum = Räume[Random.Shared.Next(Räume.Length)],
                Startzeit = DateTime.Now.AddDays(Random.Shared.Next(14, 70)),
                Dauer = Dauer[Random.Shared.Next(Dauer.Length)]
            })
            .ToArray();
        }
    }
}
