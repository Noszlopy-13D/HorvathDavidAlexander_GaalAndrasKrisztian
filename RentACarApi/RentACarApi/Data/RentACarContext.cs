using Microsoft.EntityFrameworkCore;
using RentACarApi.Models;

namespace RentACarApi.Data;

public class RentACarContext(DbContextOptions<RentACarContext> options): DbContext(options)
{
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Model>Models => Set<Model>();
    public DbSet<Manufacturer> Manufacturers => Set<Manufacturer>();
    public DbSet<FuelType> FuelTypes => Set<FuelType>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<SupportMessage> SupportMessages => Set<SupportMessage>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Manufacturer>().HasData(
            new Manufacturer {Id = 1, Name = "Mercedes"},
            new Manufacturer {Id = 2,Name = "BMW"},
            new Manufacturer {Id = 3,Name = "Volkswagen"},
            new Manufacturer {Id = 4,Name = "Audi"},
            new Manufacturer {Id = 5,Name = "Ford"},
            new Manufacturer {Id = 6,Name = "Toyota"}
        );

        modelBuilder.Entity<FuelType>().HasData(
            new FuelType {Id = 1, Name = "Benzin"},
            new FuelType {Id = 2, Name = "Dízel"},
            new FuelType {Id = 3, Name = "Benzin-Hibrid"},
            new FuelType {Id = 4, Name = "Dízel-Hibrid"},
            new FuelType {Id = 5, Name = "Elektromos"}
        );

        modelBuilder.Entity<Category>().HasData(
            new Category {Id = 1, Name = "Hétköznapi"},
            new Category {Id = 2, Name = "Luxus"},
            new Category {Id = 3, Name = "Sport"}
        );

        modelBuilder.Entity<Model>().HasData(
            new Model{Id = 1, ManufacturerId = 1, Name = "C-Osztály"},
            new Model{Id = 2, ManufacturerId = 1, Name = "E-Osztály"},
            new Model{Id = 3, ManufacturerId = 3, Name = "Passat"},
            new Model{Id = 4, ManufacturerId = 5, Name = "Focus"},
            new Model{Id = 5, ManufacturerId = 6, Name = "Corolla"}
        );

        modelBuilder.Entity<Car>().HasData(
            new Car{Id = 1, CategoryId = 1, FuelTypeId = 1, ModelId = 3, HorsePower = 150, Km = 121_322, Year = 2016, PricePerKm = 50, Description = "A Volkswagen Passat egy tágas és kényelmes szedán, ideális hosszabb utakra és városi közlekedésre egyaránt. Gazdaságos fogyasztás, modern technológia és megbízható teljesítmény jellemzi. Automata váltóval, klímával és tágas csomagtérrel rendelkezik, tökéletes választás üzleti és családi utakhoz."},
            new Car{Id = 2, CategoryId = 1, FuelTypeId = 2, ModelId = 4, HorsePower = 120, Km = 98_500, Year = 2018, PricePerKm = 45, Description = "A Ford Focus egy dinamikus és megbízható kompakt autó, amely ideális választás városi közlekedéshez és hosszabb utakhoz egyaránt. Alacsony fogyasztás, kényelmes utastér és modern biztonsági felszereltség jellemzi."},
            new Car{Id = 3, CategoryId = 1, FuelTypeId = 1, ModelId = 5, HorsePower = 132, Km = 75_000, Year = 2020, PricePerKm = 48, Description = "A Toyota Corolla egy legendásan tartós és gazdaságos modell, amely kiváló vezetési élményt nyújt. Kényelmes beltér, megbízható motor és alacsony fenntartási költségek teszik népszerűvé."},
            new Car{Id = 4, CategoryId = 2, FuelTypeId = 2, ModelId = 2, HorsePower = 190, Km = 105_000, Year = 2017, PricePerKm = 80, Description = "A Mercedes E-Osztály egy elegáns és tágas prémium szedán, amely kimagasló komfortot és technológiai innovációt kínál. Automata váltó, bőr belső és fejlett vezetéstámogató rendszerek biztosítják a luxus élményt."},
            new Car{Id = 5, CategoryId = 3, FuelTypeId = 1, ModelId = 1, HorsePower = 204, Km = 60_200, Year = 2019, PricePerKm = 100, Description = "A Mercedes C-Osztály sportos megjelenése és erőteljes motorja garantálja a dinamikus vezetési élményt. Kiváló gyorsulás, prémium belső tér és modern technológia jellemzi."},
            new Car{Id = 6, CategoryId = 3, FuelTypeId = 3, ModelId = 5, HorsePower = 180, Km = 50_000, Year = 2021, PricePerKm = 90, Description = "A Toyota Corolla hibrid változata környezetbarát és takarékos megoldást kínál azok számára, akik modern és hatékony autót keresnek. Csendes üzemmód, alacsony fogyasztás és megbízható teljesítmény jellemzi."}
        );

        modelBuilder.Entity<Image>().HasData(
            new Image{Id = 1, CarId = 2, Path = "AF109A5C-041F-47E1-A103-ADD976BCD83B.jpg", UploadDate = new DateTime()},
            new Image{Id = 2, CarId = 2, Path = "631C96AF-2FD2-4198-86C5-5A9A011EDBBE.jpg", UploadDate = new DateTime()},
            new Image{Id = 3, CarId = 2, Path = "0BD9FD45-B1E9-4E47-BAA5-4A25C240907D.jpg", UploadDate = new DateTime()},
            new Image{Id = 4, CarId = 1, Path = "64BAACEA-7F1F-4F81-8498-4759FCCFEEAE.jpeg", UploadDate = new DateTime()},
            new Image{Id = 5, CarId = 1, Path = "34DE130B-8E3C-4007-95A5-DEB9E77F8CE6.jpg", UploadDate = new DateTime()}
        );
    }

    public bool CheckForeignKeys(Car car)
    {
        if (!Models.Any(x => x.Id == car.ModelId))
            return false;

        if (!FuelTypes.Any(x => x.Id == car.FuelTypeId))
            return false;

        if (!Categories.Any(x => x.Id == car.CategoryId))
            return false;
        
        return true;
    }

    public bool CheckForeignKeys(Model model)
    {
        return Manufacturers.Any(x => x.Id == model.ManufacturerId);
    }
}