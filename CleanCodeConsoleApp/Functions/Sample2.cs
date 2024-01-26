using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeConsoleApp.Functions
{
    /// <summary>
    /// Don't repeat yourself (DRY) prensibi, aynı veya benzer kodun tekrar edilmemesini önerir, 
    /// Kodun yeniden kullanılabilir ve bakımı daha kolay hale getirecek şekilde düzenlenmesi gerekir.
    /// </summary>

    //BAD
    public class Car
    {
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string CarColor { get; set; }
    }

    public class CarService
    {
        public void PaintCar(Car car, string color)
        {
            car.CarColor = color;
        }
    }

    public class Motorcycle
    {
        public string MotorcycleBrand { get; set; }
        public string MotorcycleModel { get; set; }
        public string MotorcycleColor { get; set; }
    }

    public class MotorcycleService
    {
        public void PaintMotorcycle(Motorcycle motorcycle, string color)
        {
            motorcycle.MotorcycleColor = color;
        }
    }

    //GOOD

    //Araçlarla ilgili ortak özellikler Vehicle sınıfında toplabilir.
    //VehicleService sınıfındaki PaintVehicle metodunu kullanarak araçların rengini değiştirmek için tek bir yerden erişilebilir.
    //Vehicle ve VehicleService miras alınarak kullanılır.
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }

    public class VehicleService
    {
        public void PaintVehicle(Vehicle vehicle, string color)
        {
            vehicle.Color = color;
        }
    }

}
