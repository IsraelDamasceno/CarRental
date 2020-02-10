namespace CarRental.Domain.Entities
{
    public class Invoice
    {
        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }
        private double _basicPayment;

        public double BasicPayment
        {
            get { return _basicPayment; }
            set { _basicPayment = value; }
        }

        private double   _tax;

        public double  Tax
        {
            get { return _tax; }
            set { _tax = value; }
        }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }
    }
}
