using CommunityToolkit.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
		InvalidInputMessages _invalidInputMessages = new InvalidInputMessages();


		public MainPage()
		{
			InitializeComponent();
			collectionView.ItemsSource = _invalidInputMessages.BindedMessages;
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

			// Essas três listas abaixos estão sendo instanciadas a cada execução. Refatorar.
			List<decimal> inputs = new () { totalCapital, buyingPrice, stopPrice, lossLimit };
			List<Entry> userEntries = new () { EntryTotalCapital, EntryBuyingPrice, EntryStopPrice, EntryLossLimit };
			List<Entry> resultEntries = new () { EntryStopPercentage, EntryBuyingCapital, EntryStocks };

			var result = true;

			for (int i = 0; i < inputs.Count; i++)
			{
				if (inputs[i] <= 0)
				{
					userEntries[i].BackgroundColor = Colors.LightPink;
					_invalidInputMessages.MessageHandler(i, "add");
					result = false;
				}
				else
				{
					_invalidInputMessages.MessageHandler(i, "remove");
					userEntries[i].BackgroundColor = Colors.White;
				}

			}

			if (stopPrice >= buyingPrice)
			{
				userEntries[2].BackgroundColor = Colors.LightPink;
				userEntries[1].BackgroundColor = Colors.LightPink;
				_invalidInputMessages.MessageHandler(4, "add");
				result = false;
			}
			else
			{
				_invalidInputMessages.MessageHandler(4, "remove");
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
