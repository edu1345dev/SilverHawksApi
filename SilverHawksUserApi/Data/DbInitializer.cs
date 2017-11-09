using System;
using System.Linq;
using SilverHawksUserApi.Data;
using SilverHawksUserApi.Models;

namespace SilverHawksUserApi.Data
{
    public static class DbInitializer
    {
        public static void Initialize(SilverHawksContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            //if (context.Atletas.Any())
            //{
            //    return;   // DB has been seeded
            //}

            var atletas = new Atleta[]{
                new Atleta{Nome="Amanda", Diretoria=true, Numero="58"},
                new Atleta{Nome="Tue", Diretoria=false, Numero="44"}
            };

            foreach(Atleta a in atletas){
                context.Atletas.Add(a);
            }
            context.SaveChanges();

            var chamadas = new Chamada[]{
                new Chamada{ID=1, Data=DateTime.Parse("2017-10-12")},
                new Chamada{ID=2, Data=DateTime.Parse("2017-10-15")},
                new Chamada{ID=3, Data=DateTime.Parse("2017-11-15")}
            };

            foreach (Chamada c in chamadas)
            {
                context.Chamadas.Add(c);
            }
            context.SaveChanges();


            var presencas = new Presenca[]{
                new Presenca{ChamadaID= 1,AtletaID=atletas.Single(s => s.Nome == "Tue").ID, Tipo=TipoPresenca.F,Data=DateTime.Parse("2017-10-12")},
                new Presenca{ChamadaID= 2,AtletaID=atletas.Single(s => s.Nome == "Tue").ID, Tipo=TipoPresenca.P,Data=DateTime.Parse("2017-10-15")},
                new Presenca{ChamadaID= 3,AtletaID=atletas.Single(s => s.Nome == "Tue").ID, Tipo=TipoPresenca.P,Data=DateTime.Parse("2017-11-15")},
                new Presenca{ChamadaID= 1,AtletaID=atletas.Single(s => s.Nome == "Amanda").ID, Tipo=TipoPresenca.J,Data=DateTime.Parse("2017-10-12")},
                new Presenca{ChamadaID= 2,AtletaID=atletas.Single(s => s.Nome == "Amanda").ID, Tipo=TipoPresenca.F,Data=DateTime.Parse("2017-10-15")},
                new Presenca{ChamadaID= 3,AtletaID=atletas.Single(s => s.Nome == "Amanda").ID, Tipo=TipoPresenca.F,Data=DateTime.Parse("2017-11-15")}

            };

            foreach (Presenca p in presencas)
            {
                context.Presencas.Add(p);
            }
            context.SaveChanges();

            //var todoItems = new TodoItem[]
            //{
            //    new TodoItem{Name="Amanda", Id=1, IsComplete=true},
            //    new TodoItem { Name = "Jose", Id = 2, IsComplete = false},
            //    new TodoItem { Name = "Maria", Id = 3, IsComplete = true },
            //    new TodoItem { Name = "Eduardo", Id = 4, IsComplete = false }
            //};

            //foreach (TodoItem s in todoItems)
            //{
            //    context.TodoItems.Add(s);
            //}

            context.SaveChanges();
        }
    }
}
