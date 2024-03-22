using GestoreEvento.Models;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
using System.Xml.Linq;

namespace GestoreEvento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime CURRENT_TIMESTAMP = default;

            #region Insert

            //using (var ctx = new GestoreEventoContext()) {
            //    Evento evUno = new Evento()
            //    {
            //        NomeEvento = "Concerto Uno",
            //        DescrizioneEvento = "Conterto Vasco Rossi",
            //        DataEvento = new DateTime (2024,05,05),
            //        LuogoEvento = "Roma",
            //        CapacitaMassima = 1000,
            //        Deleted = null

            //    };
            //    try
            //    {
            //        ctx.Eventos.Add(evUno);                
            //        ctx.SaveChanges();
            //        Console.WriteLine(evUno.ToString());
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }

            #endregion

            #region Find

            //ICollection<Partecipante> listaPartecipanti = new List<Partecipante>();

            // using (var context = new GestoreEventoContext())
            // {
            // try
            //{
            // Partecipante? partecipante = context.Partecipantes.Include(partecipante => partecipante.EventoRifs).Single(e => e.PartecipanteId == 3);
            // Console.WriteLine(partecipante.EventoRifs.Count);
            //        foreach (Partecipante eventi in Partecipante.
            //        {
            //            Console.WriteLine("   " + studente.Nominativo);
            //        }
            //    }
            //    catch (Exception ex) { Console.WriteLine(ex); }
            //}
            //  }

            #endregion

            #region Update

            //using (var context = new GestoreEventoContext())
            //{

            //    Evento evento = context.Eventos.FirstOrDefault(e => e.EventoId == 4);

            //    if (evento != null)
            //    {

            //        evento.NomeEvento = "Festa al mare ";
            //        evento.DescrizioneEvento = "Festa Privata";
            //        evento.DataEvento = DateTime.Now; 
            //        evento.LuogoEvento = "Fregene";
            //        evento.CapacitaMassima = 100;

            //        context.Eventos.Update(evento);

            //        context.SaveChanges();

            //        Console.WriteLine("Evento aggiornato con successo.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Evento non trovato.");
            //    }
            //}

            #endregion

            #region Esportazione CSV

            using (var context = new GestoreEventoContext())
            {
                
                var eventi = context.Eventos.ToList();

                
                string csvFilePath = "eventi.csv";

                
                using (var writer = new StreamWriter(csvFilePath))
                {
                    
                    writer.WriteLine("EventoId,NomeEvento,DescrizioneEvento,DataEvento,LuogoEvento,CapacitaMassima");

                    
                    foreach (var evento in eventi)
                    {
                        writer.WriteLine($"{evento.EventoId},{evento.NomeEvento},{evento.DescrizioneEvento},{evento.DataEvento},{evento.LuogoEvento},{evento.CapacitaMassima}");
                    }
                }

                Console.WriteLine($"Esportazione completata. Dati degli eventi sono stati scritti nel file '{csvFilePath}'.");
            }

            #endregion

        }
    }
}
