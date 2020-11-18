using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.IO;



/*
 * -------------------------------------
 * GEMEINSAM MIT PATRICK HUEMER GEMACHT
 * -------------------------------------
 */

namespace OrderImportQuiz
{
    class Program
    {
        static async void Main(string[] args)
        {
            //IMPORT
            if (args[0].ToLower() == "import")
            {
                String[] customers = await File.ReadAllLinesAsync(args[1]);
                String[] orders = await File.ReadAllLinesAsync(args[2]);

            }
        }

    }
    //    | Customer                                     |
    //|----------------------------------------------|
    //| Id(int, PK)                                 |
    //| Name(string, max. 100 chars)                |
    //| CreditLimit(decimal, length 8, precision 2) |

    class Customer
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Name {get; set;}

        [Column(TypeName = "decimal(8,2)")]
        public decimal CreditLimit { get; set; }

        public List<Order> Orders { get; set; } = new();
    }

//    ---------------------------------------------+
//| Order                                        |
//|----------------------------------------------|
//| Id(int, PK)                                 |
//| CustomerId(int, FK to Customer)             |
//| OrderDate(date + time)                      |
//| OrderValue(decimal, length 8, precision 2)  |
//+----------------------------------------------+

    class Order
    {
        public int Id { get; set; }

        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        
        public DateTime OrderDate { get; set; }
        
        [Column(TypeName = "decimal(8,2)")]
        public decimal OrderValue { get; set; }
    }
}
