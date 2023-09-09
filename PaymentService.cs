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
            int maxRange;
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
            double totalAmount = 0;
            if (installmentRange > maxRange)
            {
                // Если диапазон будет задаватся среди чисел 3,6,9,12,18,24 
                // то можно использовать ниже приведенный код:

                // var start = Array.IndexOf(ranges, maxRange);
                // var end = Array.IndexOf(ranges, installmentRange);
                // var percentage = (end - start) * percent;
                // totalAmount = productAmount + (productAmount * percentage);

                // ------------------------------------------------------------

                // Если диапозон может содержать такие числа как 10,15 или 21 то для правильной работы 
                // нужно использовать ниже приведенный код:

                var start = Array.IndexOf(ranges, maxRange);
                var end = Array.FindIndex(ranges, p => p >= installmentRange);
                if (installmentRange <= ranges[end])
                {
                    var percentage = (end - start) * percent;
                    totalAmount = productAmount + (productAmount * percentage);
                }
            }
            if (installmentRange <= maxRange)

            {
                totalAmount = productAmount;
            }


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