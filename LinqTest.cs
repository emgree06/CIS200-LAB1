/*
 * Grade ID:Z9435
 * Due Date: 2/7/2018
 * Lab 1
 * CIS 200-01
 * */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    public class LinqTest
    {
        public static void Main(string[] args)
        {
            // initialize array of invoices
            Invoice[] invoices = {
                new Invoice( 83, "Electric sander", 7, 57.98M ),
                new Invoice( 24, "Power saw", 18, 99.99M ),
                new Invoice( 7, "Sledge hammer", 11, 21.5M ),
                new Invoice( 77, "Hammer", 76, 11.99M ),
                new Invoice( 39, "Lawn mower", 3, 79.5M ),
                new Invoice( 68, "Screwdriver", 106, 6.99M ),
                new Invoice( 56, "Jig saw", 21, 11M ),
                new Invoice( 3, "Wrench", 34, 7.5M ) };

            // Display original array
            Console.WriteLine("Original Invoice Data\n");
            Console.WriteLine("P.Num Part Description     Quant Price"); // Column Headers
            Console.WriteLine("----- -------------------- ----- ------");

            foreach (Invoice inv in invoices)
                Console.WriteLine(inv);

            //sorts the invoice by part description in ascending order
            var partDescriptionSort =
                from i in invoices
                orderby i.PartDescription ascending
                select i;

            Console.WriteLine();
            Console.WriteLine("The answer for Part A");
            Console.WriteLine();

            foreach (Invoice i in partDescriptionSort)//steps through each Invoice to sort them
            {
                
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine("The answer for Part B");
            Console.WriteLine();

            //Orders each invoice by price in descending order
            //most expensive item listed first and least expensive item listed last
            var price =
                from i in invoices
                orderby i.Price descending
                select i;

            foreach(Invoice i in price)//Steps through each invoice
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();
            Console.WriteLine("The answer for Part C");
            Console.WriteLine();

            //takes the partDescriptionSort and sorts them by quantity of the item.
            //The item with the largest quantity is listed first and the item with the least quantity
            //is listed last
            var quantitySort =
                from i in partDescriptionSort
                orderby i.Quantity descending
                select i;

            foreach(Invoice i in quantitySort)//steps through the invoices and displays part and qauntity
            {
                Console.WriteLine($"{i.PartDescription, 15} {i.Quantity, 15}");
            }

            Console.WriteLine();
            Console.WriteLine("The answer for Part D");
            Console.WriteLine();

            //creates a new variable that is used to diplay the total price of the invoice
            var valueOfInvoice =
                from i in invoices
                let TotalInvoice = i.Price * i.Quantity//finds the total invoice price
                where TotalInvoice > 0
                orderby TotalInvoice descending
                select new { InvoiceTotal = TotalInvoice , i.PartDescription};


            foreach(var item in valueOfInvoice)//steps through the invoice and displays part and 
                //                                  total price of the invoice
            {
                Console.WriteLine($" {item.PartDescription, 15} {item.InvoiceTotal, 15:C}");
            }

            Console.WriteLine();
            Console.WriteLine("The answer for Part E");
            Console.WriteLine();

            //orders the prices of the invoices in ascending order and only selects invoice totals
            // between a range of $200 to $500
            var totalsRange =
                from i in valueOfInvoice
                where i.InvoiceTotal > 200 && i.InvoiceTotal < 500
                select i.InvoiceTotal;

            foreach(var item in totalsRange)//steps through the totals range/InvoiceTotal to find
                //                          invoices in the acceptable range
            {
                Console.WriteLine($"{item:C}");
            }
        }
    }
}
