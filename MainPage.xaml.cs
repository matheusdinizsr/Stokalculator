

namespace Stokalculator
{
	public partial class MainPage : ContentPage
	{
		decimal totalCapital = 0;
		decimal buyingPrice = 0;
		decimal stopPrice = 0;
		decimal stopDecimal = 0;
		decimal userLoss = 0;
		decimal buyingFactor = 0;
		decimal buyingCapital = 0;
		decimal stocks = 0;
		bool allIn = false;


		public MainPage()
		{
			InitializeComponent();
		}


		public void OnClickCalculate(object sender, EventArgs e)
		{
			totalCapital = decimal.Parse(EntryBank.Text);
			buyingPrice = decimal.Parse(EntryBuyingPrice.Text);
			stopPrice = decimal.Parse(EntryStopPrice.Text);
			userLoss = decimal.Parse(EntryLossLimit.Text) / 100;

			if (stopPrice > buyingPrice)
			{
;				FormatAndPrint(0, 0, "0", false);
				Error("Stop price has to be lower than buying price.");
				return;
			}

			stopDecimal = ((stopPrice / buyingPrice) - 1) * -1;
			buyingFactor = userLoss / stopDecimal;
			buyingCapital = buyingFactor * totalCapital;

			if (buyingCapital > totalCapital)
			{
				stocks = totalCapital / buyingPrice;
				buyingCapital = totalCapital;
				allIn = true;
			}
			else
			{
				stocks = buyingCapital / buyingPrice;
				allIn = false;

			}

			var stocksArray = stocks.ToString().Split(',');


			FormatAndPrint(stopDecimal, buyingCapital, stocksArray[0], allIn);



		}



		public void FormatAndPrint(decimal stop, decimal capital, string stocks, bool allIn)
		{
			EntryStopPercentage.Text = String.Format("{0:0.00}", stop * 100) + " %";
			EntryStocks.Text = stocks;

			if (allIn)
			{
				EntryBuyingCapital.Text = "$ " + String.Format("{0:0.00}", capital) + " - All In!";
			}
			else
			{
				EntryBuyingCapital.Text = "$ " + String.Format("{0:0.00}", capital);
			}
		}

		public void Error(string mensagem)
		{
			ErrorMessage.Text = mensagem;
			ErrorMessage.IsVisible = true;
			Device.StartTimer(TimeSpan.FromSeconds(3), () =>
			{
				ErrorMessage.IsVisible = false;
				return false;
			});
		}



	}


}
