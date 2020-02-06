namespace CarRental.Domain.Entities
{
    public class Invoice
    {
        public Invoice(double basicPayment, double tax)
        {
            BasicPayment = basicPayment;
            Tax = tax;
        }

        public double BasicPayment { get; private set; }
        public double Tax { get; private set; }

        public double TotalPayment
        {
            get { return BasicPayment + Tax; }
        }
    }
}
