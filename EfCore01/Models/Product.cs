using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCore01.Models
{
    //Models-Entities-DomainModels-POCO Class
    //POCO:Plain old C# Object

    //Procucts
    internal class Product
    {
        //Search for intgeral property [int-short-long]
        //Not any integral property [Id,ProductId]
        //Mark Id is Pk [Identity(1,1)] in case Id is int-short-long
        //Search for string,GUID in case its name Id,ProductId
        public int Id { get; set; }


        //Nvarchar(Max)
        //string?=>Allow Null

        public string? Name { get; set; }

        //decimal(18,2)
        //not allow Null
        public decimal Price { get; set; }

        // int
        //not null
        public int Stock { get; set; }


    }
}
