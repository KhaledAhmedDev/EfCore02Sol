using EfCore01.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EfCore01
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using CompanyDbContext dbContext = new CompanyDbContext();

          await dbContext.Database.MigrateAsync(); // Apply pending migrations In App
            //using CompanyDbContext dbContext = new CompanyDbContext()
            //{



            //};


            //try
            //{

            //}
            //catch (Exception ex)
            //{

            //}

            //finally
            //{
            //    dbContext.Dispose(); //Deallocate object dbcontext from heap
            //                         // connection is clodes


            }
        }
        }

