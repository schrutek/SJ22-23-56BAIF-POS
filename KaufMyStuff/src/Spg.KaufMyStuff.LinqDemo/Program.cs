using Microsoft.EntityFrameworkCore;
using Spg.KaufMyStuff.DomainModel.Models;
using Spg.KaufMyStuff.Infrastructure;
using System.Security.Cryptography.X509Certificates;

DbContextOptionsBuilder options = new DbContextOptionsBuilder();
options.UseSqlite("Data Source=KaufMyStuff.db");

KaufMyStuffContext db = new KaufMyStuffContext(options.Options);
db.Database.EnsureDeleted();
db.Database.EnsureCreated();
db.Seed();

// LinQ-Abfragen
// Gib den Shop mit der Id 3 und der Namen mit einem 'A' beginnt
var result01 = db.Products
    .Where(x => x.Name.StartsWith("A"))
    .Where(x => x.CategoryNavigation.Id == 7)
    .ToList();

// Beispiel QuerySyntax
var result01a = from p in db.Products where p.Name.StartsWith("A") && p.CategoryNavigation.Id == 7 select p;

// Gib alle Customers zurück, deren Vorname mit 'H' beginnt und die nach dem '01.01.2000' geboren wurden.
var result02 = db.Customers
    .Where(c => c.FirstName.ToUpper().StartsWith("H") && c.BirthDate < new DateTime(2000, 01, 01));

// Gib alle Kategorien vom Shop "Nieder" zurück
var result03 = db.Shops.Where(s => s.Name.StartsWith("Nieder"));
var result03a = db.Categories.Where(c => c.ShopNavigation.Name.StartsWith("Nieder"));

// Gib den Shop mit der Id 3 zurück
Shop? result04 = db.Shops.SingleOrDefault(s => s.Id == 3);

// All, Any

// Liste alle Products auf, mit dem PriceType ShortName='Aktion'
var result05 = db.Products.Where(p => p.Prices.Any(p => p.CatPriceTypeNavigation.ShortName == "Aktion"));


Console.ReadLine();

int? x = null;
Nullable<int> y = null;




// Liste aller Students mit dem Nachnamen like 'o' der Klasse 4711 absteigend sortiert
// LinQ
//var result = db.Students
//    .Where(s => s.LastName.ToLower().Contains("o") && s.SchoolClassNavigation.Id = 4711)
//    .OrderByDescending(s => s.LastName)
//    .Select(s => new { s.FirstName, s.LastName });

// SQL (wird aus LinQ erstellt)
// select t.FirstName, t.LastName
// from schoolclasses s, students t
// where s.id = t.schoolclassid and t.lastname like '%o%'
// order by desc