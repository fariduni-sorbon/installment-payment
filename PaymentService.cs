namespace InstallmentPayment
{
    public class PaymentService
    {
        int[] ranges = { 3, 6, 9, 12, 18, 24 };
        public delegate void SmsHandler(string phoneNumber);
        public event SmsHandler? SmsSentNotify;

        public double TotalPayment(string productName, double productAmount,
         string phoneNumber, int installmentRange)
        {
            int  maxRange;
            double percent;
            switch (productName)
            {
                case "Смартфон":
                    maxRange = 9;
                    percent = 0.03;
                    break;

                case "Компютер":
                    maxRange = 12;
                    percent = 0.04;
                    break;

                case "Телевизор":
                    maxRange = 18;
                    percent = 0.05;
                    break;

                default:
                    Console.WriteLine("Продукт не найден");
                    return 0;
            }

            var start = Array.IndexOf(ranges, maxRange);
            var end = Array.IndexOf(ranges, installmentRange);
            var percentage = (end - start) * percent;
            double totalAmount = productAmount + (productAmount * percentage);

            string msg = $"вы купили {productName} на сумму {productAmount}см в рассрочку на {installmentRange} месяцев.\nОбщая сумма платежа: {totalAmount}см";

            bool isSend = SendSms(phoneNumber, msg);
            if (isSend)
            {
                SmsSentNotify?.Invoke(phoneNumber);
            }
            return totalAmount;
        }

        private bool SendSms(string number, string sms)
        {
            //TODO Логика отправки смс
            return true;
        }
    }
}