using InstallmentPayment;

PaymentService service = new PaymentService();
service.SmsSentNotify += (string number) =>
Console.WriteLine($"смс успешно отправлен на номер {number}");



var total = service.TotalPayment("Смартфон", 1000, "555-5555", 18);
//var total = service.TotalPayment("Компютер", 1000, "555-5555", 24);
//var total = service.TotalPayment("Телевизор", 1000, "555-5555", 24);

Console.WriteLine($"Общая сумма платежа: {total}см");