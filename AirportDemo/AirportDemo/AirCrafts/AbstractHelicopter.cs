using AirportDemo.Interfaces;
using System;
using AirportDemo.Enums;

namespace AirportDemo.AirCrafts
{
    public abstract class AbstractHelicopter : AbstractAirCraft, IHelicopter
    {
        public RotorSystem RotorSystem
        {
            get; private set;
        }

        public override void Fly()
        {
            StartEngine();
            TakeOff();
        }

        private void StartEngine() => Console.WriteLine("Engine started"); 

        private void TakeOff() => Console.WriteLine("TakeOff"); 

        public AbstractHelicopter(string aircraftname, string id, int range, int fuelconsumption, RotorSystem rotorsystem) : base(aircraftname, id, range, fuelconsumption)
        {
            RotorSystem = rotorsystem;
        }        
    }
}
