using AirportDemo.Interfaces;
using System;
using AirportDemo.Enums;

namespace AirportDemo.AirCrafts
{
    public abstract class AbstractAirPlane : AbstractAirCraft, IAirPlane
    {
        public WingType WingType { get; private set; }

        public override void Fly()
        {
            StartEngine();
            RunUp();
            TakeOff();
        }

        private void StartEngine() => Console.WriteLine("Engine started");
        private void TakeOff() => Console.WriteLine("TakeOff");
        private void RunUp() => Console.WriteLine("Run-Up");

        public AbstractAirPlane(string aircraftname, string id, int range, int fuelconsumption, WingType wingtype) : base(aircraftname, id, range, fuelconsumption)
        {
            WingType = wingtype;
        }
    }
}
