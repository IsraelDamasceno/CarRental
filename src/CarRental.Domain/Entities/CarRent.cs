using System;

namespace CarRental.Domain.Entities
{
    public class CarRent 
    {
        public CarRent()
        {

        }
        public CarRent(DateTime start, DateTime finish, Vehicle vehicle)
        {
            _start = start;
            _finish = finish;
            Vehicle = vehicle;
        }
        private DateTime _start;

        public DateTime Start
        {
            get { return _start; }
            set { _start = value; }
        }
        private DateTime _finish;

        public DateTime Finish
        {
            get { return _finish; }
            set { _finish = value; }
        }

        public Vehicle Vehicle { get; private set; }
        public Invoice Invoice { get; set; }

    }
}
