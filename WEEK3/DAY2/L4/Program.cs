using System;

// Base interface for vehicles
public interface IVehicle
{
    string Model { get; }

    void Drive();
}

// Interface for electric functionality
public interface IElectric
{
    int BatteryPercent { get; set; }

    void Charge();
}

// Combined interface
// It inherits members from both IVehicle and IElectric
public interface IElectricVehicle : IVehicle, IElectric
{
}

// ElectricCar implements the combined interface
// Therefore, it must implement members from both interfaces
public class ElectricCar : IElectricVehicle
{
    // Init-only property
    // It can be assigned while creating the object
    // but cannot be changed afterward
    public string Model { get; init; }

    private int batteryPercent;

    // BatteryPercent property
    // The setter ensures the value stays between 0 and 100
    public int BatteryPercent
    {
        get
        {
            return batteryPercent;
        }

        set
        {
            // Clamp value to the range 0-100
            if (value < 0)
                batteryPercent = 0;
            else if (value > 100)
                batteryPercent = 100;
            else
                batteryPercent = value;
        }
    }

    // Drive reduces battery by 10%
    // Battery cannot go below 0
    public void Drive()
    {
        BatteryPercent -= 10;

        Console.WriteLine($"{Model} is driving.");
    }

    // Charging sets battery to 100%
    public void Charge()
    {
        BatteryPercent = 100;

        Console.WriteLine($"{Model} is fully charged.");
    }
}

public class Program
{
    public static void Main()
    {
        // Create an ElectricCar object
        ElectricCar car = new ElectricCar
        {
            Model = "Tesla Model 3",
            BatteryPercent = 100
        };

        Console.WriteLine($"Vehicle Model: {car.Model}");
        Console.WriteLine($"Initial Battery: {car.BatteryPercent}%");

        // Drive three times
        car.Drive();
        Console.WriteLine($"Battery after first drive: {car.BatteryPercent}%");

        car.Drive();
        Console.WriteLine($"Battery after second drive: {car.BatteryPercent}%");

        car.Drive();
        Console.WriteLine($"Battery after third drive: {car.BatteryPercent}%");

        // Charge the car
        car.Charge();
        Console.WriteLine($"Battery after charging: {car.BatteryPercent}%");

        Console.WriteLine("\n--- Interface Demonstration ---");

        // Assign ElectricCar to IVehicle variable
        // Only IVehicle members are accessible through this reference
        IVehicle vehicle = car;

        Console.WriteLine($"Model through IVehicle: {vehicle.Model}");
        vehicle.Drive();

        // Assign ElectricCar to IElectric variable
        // Only IElectric members are accessible through this reference
        IElectric electric = car;

        Console.WriteLine($"Battery through IElectric: {electric.BatteryPercent}%");
        electric.Charge();

        Console.WriteLine(
            $"Battery after charging through IElectric: {electric.BatteryPercent}%"
        );
    }
}