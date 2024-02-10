

namespace Stokalculator
{
	public partial class MainPage : ContentPage
	{
		decimal totalCapital = 0;
		decimal buyingPrice = 0;
		decimal stopPrice = 0;
		decimal stopDecimal = 0;
		decimal lossLimit = 0;
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
			var inputTester = InputHandler();

			if (inputTester == false)
			{
				return;
			}

			stopDecimal = ((stopPrice / buyingPrice) - 1) * -1;
			buyingFactor = (lossLimit / 100) / stopDecimal;
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

		public bool InputHandler()
		{
			decimal.TryParse(EntryTotalCapital.Text, out totalCapital);
			decimal.TryParse(EntryBuyingPrice.Text, out buyingPrice);
			decimal.TryParse(EntryStopPrice.Text, out stopPrice);
			decimal.TryParse(EntryLossLimit.Text, out lossLimit);

			List<decimal> inputs = new List<decimal>() { totalCapital, buyingPrice, stopPrice, lossLimit};
			List<Entry> userEntries = new List<Entry>() { EntryTotalCapital, EntryBuyingPrice, EntryStopPrice, EntryLossLimit};
			List<Entry> resultEntries = new List<Entry>() { EntryStopPercentage, EntryBuyingCapital, EntryStocks };

			var result = true;

			for (int i = 0; i < inputs.Count; i++)
			{
				if (inputs[i] <= 0)
				{
					userEntries[i].BackgroundColor = Colors.LightPink;
					result = false;
				}
				else
				{
					userEntries[i].BackgroundColor = Colors.White;
				}

			}

			if (stopPrice > buyingPrice)
			{
				EntryStopPrice.BackgroundColor = Colors.LightPink;
				EntryBuyingPrice.BackgroundColor = Colors.LightPink;
				result = false;
				//FALTA EXIBIR O ERRO
			}

			if (result == false)
			{
				for (int i = 0; i < resultEntries.Count; i++)
				{
					resultEntries[i].Text = "";
				}
			}

			return result;

		}



	}


}
