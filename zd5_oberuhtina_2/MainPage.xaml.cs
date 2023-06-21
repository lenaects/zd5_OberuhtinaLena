using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace zd5_oberuhtina_2
{
    public partial class MainPage :ContentPage
    {
        private Entry loanAmountEntry;
        private Entry loanTermEntry;
        private Picker paymentTypePicker;
        private Slider interestRateSlider;
        private Label interestRateLabel;
        private Label monthlyPaymentLabel;
        private Label totalAmountLabel;
        private Label overpaymentLabel;
        public MainPage (string username)
        {
            InitializeComponent();
            
            var usernameLabel = new Label
            {
                Text = $"Добро пожаловать, {username}!",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            loanAmountEntry = new Entry
            {
                Placeholder = "Сумма кредита",
                FontSize = 20
            };

            loanTermEntry = new Entry
            {
                Placeholder = "Срок (месяцев)",
                FontSize = 20
            };

            paymentTypePicker = new Picker
            {
                Title = "Вид платежа",
                FontSize = 20
            };
            paymentTypePicker.Items.Add("Аннуитетный");
            paymentTypePicker.Items.Add("Дифференцированный");

            interestRateSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 5,
                ThumbColor = Color.Blue
            };

            interestRateLabel = new Label
            {
                Text = $"Процентная ставка: {interestRateSlider.Value}%",
                FontSize = 20
            };

            monthlyPaymentLabel = new Label
            {
                Text = "Ежемесячный платеж: ",
                FontSize = 20
            };

            totalAmountLabel = new Label
            {
                Text = "Общая сумма: ",
                FontSize = 20
            };

            overpaymentLabel = new Label
            {
                Text = "Переплата: ",
                FontSize = 20
            };

            loanAmountEntry.TextChanged += UpdateCalculation;
            loanTermEntry.TextChanged += UpdateCalculation;
            paymentTypePicker.SelectedIndexChanged += UpdateCalculation;
            interestRateSlider.ValueChanged += UpdateCalculation;

            Content = new StackLayout
            {
                Children =
                {
                    usernameLabel,
                    loanAmountEntry,
                    loanTermEntry,
                    paymentTypePicker,
                    interestRateLabel,
                    interestRateSlider,
                    monthlyPaymentLabel,
                    totalAmountLabel,
                    overpaymentLabel
                }
            };
        }

        private void UpdateCalculation (object sender, EventArgs e)
        {
            double loanAmount;
            double.TryParse(loanAmountEntry.Text, out loanAmount);

            int loanTerm;
            int.TryParse(loanTermEntry.Text, out loanTerm);



            double interestRate = interestRateSlider.Value;
            interestRateLabel.Text = $"Процентная ставка: {interestRate}%";

            double monthlyPayment = 0;
            double totalAmount = 0;
            double overpayment = 0;

            if (paymentTypePicker.SelectedIndex == 0)
            {
                double monthlyInterestRate = interestRate / 100 / 12;
                double factor = Math.Pow(1 + monthlyInterestRate, loanTerm);
                monthlyPayment = loanAmount * monthlyInterestRate * factor / (factor - 1);
                totalAmount = monthlyPayment * loanTerm;
                overpayment = totalAmount - loanAmount;
            } else if (paymentTypePicker.SelectedIndex == 1)
            {
                monthlyPayment = loanAmount / loanTerm;
                double monthlyInterest = loanAmount * (interestRate / 100) / 12;
                totalAmount = loanAmount + (monthlyInterest * loanTerm);
                overpayment = totalAmount - loanAmount;
            }
            monthlyPaymentLabel.Text = $"Ежемесячный платеж: {monthlyPayment:C}";
            totalAmountLabel.Text = $"Общая сумма: {totalAmount:C}";
            overpaymentLabel.Text = $"Переплата: {overpayment:C}";
        }
    }
}

