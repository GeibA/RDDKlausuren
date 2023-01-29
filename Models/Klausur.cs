namespace Klausuren.Models
{
    public class Klausur
    {
        private static int _IdSeed = 1001;

        public Klausur()
        {
            Id = _IdSeed;
            _IdSeed++;
        }

        public int Id { get; }
        public int ECTS { get; set; }
        public string Modul { get; set; }
        public string? Beschreibung { get; set; }
        public string[] Studiengänge { get; set; }
        public string Standort { get; set; }
        public int Stockwerk { get; set; }
        public string Raum { get; set; }
        public DateOnly Datum => DateOnly.FromDateTime(Startzeit);
        public DateTime Startzeit { get; set; }
        public int Dauer { get; set; }
        public DateTime Endzeit => Startzeit.AddMinutes(Dauer);
    }
}
