
namespace OLSoftware.Infrastructure.Data.Seed
{
    using OLSoftware.Core.Entities;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    public class SeedDb
    {
        private readonly OlsoftwareContext context;
        private Random random;
        private DateTime fechaActual = DateTime.Now;

        public SeedDb(OlsoftwareContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.User.Any())
            {
                this.AddUser("John alexander jimenez", "Popayan, Cauca", "3128035624");
                this.AddUser("Juan Perez", "Cali, valle", "3128554454");
                this.AddUser("Cristian Fenando", "Pasto, Nariño", "987654");
                this.AddUser("Hernan Castro", "Medellin, Antioquia", "32145678");
                this.AddUser("cristian santader", "Popayan, Cauca", "3128035624");
                this.AddUser("Fernando burbano", "Cali, valle", "3128554454");
                this.AddUser("Andrea Lopez", "Pasto, Nariño", "987654");
                this.AddUser("Juan de Dios", "Medellin, Antioquia", "32145678");
                this.AddUser("gilbeira gonzales", "Pasto, Nariño", "987654");
                this.AddUser("Sebastian de Belalcazar", "Medellin, Antioquia", "32145678");

                await this.context.SaveChangesAsync();
            }

            if (!this.context.Project.Any())
            {
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(3), 52000000, 128);
                this.AddProject("Pagina Escritorio", fechaActual, fechaActual.AddDays(63), 52000000, 128);
                this.AddProject("Microservicio", fechaActual, fechaActual.AddDays(78), 52000000, 128);
                this.AddProject("Build Producto", fechaActual, fechaActual.AddDays(63), 52000000, 128);
                this.AddProject("Refactoring page", fechaActual, fechaActual.AddDays(3), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(9), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(30), 52000000, 128);
                this.AddProject("Pagina test", fechaActual, fechaActual.AddDays(98), 52000000, 128);
                this.AddProject("Pagina escritorio", fechaActual, fechaActual.AddDays(1), 52000000, 128);
                this.AddProject("Pagina prueba tecnica", fechaActual, fechaActual.AddDays(963), 52000000, 128);
                this.AddProject("Pagina web", fechaActual.AddDays(5), fechaActual.AddDays(78), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(93), 52000000, 128);
                this.AddProject("Pagina movil", fechaActual, fechaActual.AddDays(93), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(68), 52000000, 128);
                this.AddProject("Pagina web", fechaActual.AddDays(93), fechaActual.AddDays(15), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(93), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(987), 52000000, 128);
                this.AddProject("Pagina movil", fechaActual, fechaActual.AddDays(91), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(98), 52000000, 128);
                this.AddProject("Pagina web", fechaActual, fechaActual.AddDays(798), 52000000, 128);
            }

            if (!this.context.ProgrammingLanguage.Any())
            {
                this.AddLanguage("c#", "Alto");
                this.AddLanguage("python", "Alto");
                this.AddLanguage("C++", "Alto");
                this.AddLanguage("java", "Alto");
                this.AddLanguage("javascript", "Alto");
               

            }

            if (!this.context.ProjectLanguage.Any())
            {
                this.AddLanguageProject(1, 1);
                this.AddLanguageProject(2, 3);
                this.AddLanguageProject(3, 4);
                this.AddLanguageProject(4, 2);
                this.AddLanguageProject(5, 2);
                this.AddLanguageProject(6, 1);
                this.AddLanguageProject(7, 2);
                this.AddLanguageProject(8, 4);
                this.AddLanguageProject(9, 2);
                this.AddLanguageProject(10, 2);
                this.AddLanguageProject(11, 2);
                this.AddLanguageProject(12, 1);
                this.AddLanguageProject(13, 2);
                this.AddLanguageProject(14, 1);
                this.AddLanguageProject(15, 2);
                this.AddLanguageProject(16, 1);
                this.AddLanguageProject(17, 3);
                this.AddLanguageProject(18, 4);
                this.AddLanguageProject(19, 2);
                this.AddLanguageProject(20, 2);
            }

            if (!this.context.ProjectLanguage.Any())
            {
                this.AddUserProject("En Negociacion", 1, 2);
                this.AddUserProject("En Proceso", 2, 9);
                this.AddUserProject("En negociacion", 3, 5);
                this.AddUserProject("En negociacion", 4, 14);
                this.AddUserProject("En Proceso", 5, 9);
                this.AddUserProject("En negociacion", 6, 3);
                this.AddUserProject("En negociacion", 7, 10);
                this.AddUserProject("En Proceso", 8, 11);
                this.AddUserProject("Anulado", 9, 8);
                this.AddUserProject("En Negociacion", 10, 16);
                this.AddUserProject("Terminado", 1, 17);
                this.AddUserProject("En negociacion", 8, 17);
                this.AddUserProject("En Proceso", 2, 12);
                this.AddUserProject("En negociacion", 9, 13);
                this.AddUserProject("Anulado", 5, 7);
                this.AddUserProject("En negociacion", 2, 20);
                this.AddUserProject("En negociacion", 3, 19);
                this.AddUserProject("En Proceso", 4, 18);
            }


        }

        private void AddUser(string Name, string Address, string Phone)
        {
            this.context.User.Add(new User
            {
                Name = Name,
                Address = Address,
                Phone = Phone
                
            });

        }

        private void AddProject(string name,
                                DateTime startDate,
                                DateTime endDate,
                                float price,
                                float numberHours)
        {
            this.context.Project.Add(new Project
            {
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
                NumberHours = numberHours

            });

        }

        private void AddLanguage(string name,
                                 string level)
        {
            this.context.ProgrammingLanguage.Add(new ProgrammingLanguage
            {
                Name = name,
                Level = level

            });

        }

        private void AddUserProject(string status,
                                    int userId,
                                    int projectId)
        {
            this.context.UserProject.Add(new UserProject
            {
                Status = status,
                UserId = userId,
                ProjectId = projectId

            });

        }

        private void AddLanguageProject(int projectId,
                                        int programmingLanguageId
                                        )
        {
            this.context.ProjectLanguage.Add(new ProjectLanguage
            {
                ProjectId = projectId,
                ProgrammingLanguageId = programmingLanguageId

            });

        }





    }
}
