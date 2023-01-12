using System.ComponentModel.DataAnnotations;
using static Common.Data;
using static Common.Models;

namespace Common;
public static class Code
{
    public static List<Person> GenPersons(int nRecs)
    {
        List<Person> L = new();
        Array FirstNamesM = Enum.GetValues(typeof(FirstNamesM));
        Array FirstNamesF = Enum.GetValues(typeof(FirstNamesF));
        Array LastNames = Enum.GetValues(typeof(LastNames));

        //  Is it possible to generate n different records with the supplied values ?
        if (nRecs > ((FirstNamesM.Length + FirstNamesF.Length) * LastNames.Length)) { return L; }

        int i = 0;
        Random random = new Random();

        do
        {
            Person pg = new();
            //  Record identifier
            pg.PersonId = i++;
            pg.MF = (Gender)random.Next(1, 3);
            pg.Country = (Countries)random.Next(1, 8);

            //Gender.(rnd.Next(0, 2));
            //  Generate a random person name; Keep on until it is new to the list
            do
            {
                //  Generates a male or female name according to assigned gender
                if (pg.MF == Gender.Male)
                    pg.Name = $"{FirstNamesM.GetValue(random.Next(FirstNamesM.Length))} {LastNames.GetValue(random.Next(LastNames.Length))}";
                if (pg.MF == Gender.Female)
                    pg.Name = $"{FirstNamesF.GetValue(random.Next(FirstNamesF.Length))} {LastNames.GetValue(random.Next(LastNames.Length))}";
                if (pg.MF == 0)
                    if (random.Next(0, 1) == 0)
                        pg.Name = $"{FirstNamesM.GetValue(random.Next(FirstNamesM.Length))} {LastNames.GetValue(random.Next(LastNames.Length))}";
                    else
                        pg.Name = $"{FirstNamesF.GetValue(random.Next(FirstNamesF.Length))} {LastNames.GetValue(random.Next(LastNames.Length))}";

            } while (L.Exists(m => m.Name == pg.Name)); ; //ex2 : ( L.Count(l => l.Name == p.Name) > 0); ex3 : (L.Any<Person>(l => l.Name == p.Name)); and many others

            //  Person Age
            pg.Age = random.Next(12, 32);
            //  Generate InitialDate                
            pg.InitialDate = new DateTime(2021, 1, 1).AddDays(random.Next(690));
            //  Person Hourly Wage
            pg.HourlyWage = random.Next(12, 22);

            //  Add valid generated person record to list
            if (IsValid(pg)) { L.Add(pg); }

        } while (L.Count() < nRecs);

        return L;
    }
    public static bool IsValid(Person pg)
    {
        // Instantiates Controls Model Validator
        var ctx = new ValidationContext(pg!);
        var validationResults = new List<ValidationResult>();
        return Validator.TryValidateObject(pg!, ctx, validationResults, true);
    }
    public static List<Product> GenProducts()
    {
        List<Product> P = new()
        {
            new Product(100400, "Compliments Whole Tomatoes",           3.50m),
            new Product(321085, "Nacho Cheese Flavour",                 4.10m),
            new Product(238410, "Tortilla Chips",                       2.50m),
            new Product(304808, "Hummus and Labneh Yogourt",            2.55m),
            new Product(203900, "Greet Yogurts Flavour peach",          1.99m),
            new Product(500124, "Lindt Lindor Assort Dark Chocolate",   3.22m),
            new Product(208408, "Sparkling waters flavour Mandrain",    5.99m),
            new Product(100409, "Nagano pork",                          10.99m),
            new Product(103840, "Sterling Silver premium beef",         13.98m),
            new Product(204808, "Fresh Market Herb and Garlic Roasted", 8.87m),

            new Product(503489, "Ferrero Collection",                   5.57m),
            new Product(608943, "Bounty Select-A-Size Paper Towel",     16.97m),
            new Product(709441, "Kid Connection Holiday Teddy",         15.00m),
            new Product(200409, "Cucumber Seedless",                    0.84m),
            new Product(308480, "Stove Top Turkey Stuffin",             0.74m),
            new Product(308490, "Stove Top Chicken",                    0.74m),
            new Product(200850, "Tropicana Orange Juice",               2.99m),
            new Product(100509, "Cracker Barrel Tex Mex",               22.97m),
            new Product(100510, "Cracker Barrel Old Cheddar",           4.97m),
            new Product(700511, "Oasis Orange Juice",                   16.99m),
        };

        //  Add valid generated person record to list
        foreach (Product p in P)
        {
            if (!IsValidProduct(p)) { P.Remove(p); }
        }
        return P;
    }
    public static bool IsValidProduct(Product p)
    {
        // Instantiates Controls Model Validator
        var ctx = new ValidationContext(p!);
        var validationResults = new List<ValidationResult>();
        return Validator.TryValidateObject(p!, ctx, validationResults, false);
    }
}