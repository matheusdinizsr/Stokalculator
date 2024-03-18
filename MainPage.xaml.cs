using CommunityToolkit.Mvvm;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;

namespace Stokalculator
{

	public partial class MainPage : ContentPage, INotifyPropertyChanged
	{
		// Converters
		int _totalCapitalConverter = 0;
		public int TotalCapitalConverter
		{
			get => _totalCapitalConverter;
			set
			{
				_totalCapitalConverter = value;
				OnPropertyChanged(nameof(TotalCapitalConverter));
			}
		}


		int _buyingPriceConverter = 0;
		public int BuyingPriceConverter 
		{
			get => _buyingPriceConverter;
			set
			{
				_buyingPriceConverter = value;
				OnPropertyChanged(nameof(BuyingPriceConverter));
			} 
		
		}

		int _stopPriceConverter = 0;
		public int StopPriceConverter 
		{
			get => _stopPriceConverter;
			set
			{
				_stopPriceConverter = value;
				OnPropertyChanged(nameof(StopPriceConverter));
			} 
				
		}


		int _lossLimitConverter = 0;
		public int LossLimitConverter 
		{
			get => _lossLimitConverter;
			set
			{
				_lossLimitConverter = value;
				OnPropertyChanged(nameof(LossLimitConverter));
			} 
		}

		// Variables
        decimal totalCapital = 0;
		decimal buyingPrice = 0;
		decimal stopPrice = 0;
		decimal stopDecimal = 0;
		decimal lossLimit = 0;
		decimal buyingFactor = 0;
		decimal buyingCapital = 0;
		decimal stocks = 0;
		bool allIn = false;

		// Properties
		public InvalidInputMessages InvalidInputMessages = new InvalidInputMessages();


		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = this;
			InvalidMessagesInPage.ItemsSource = InvalidInputMessages.BindedMessages;
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

		public bool InputHandler()
		{
			decimal.TryParse(EntryTotalCapital.Text, out totalCapital);
			decimal.TryParse(EntryBuyingPrice.Text, out buyingPrice);
			decimal.TryParse(EntryStopPrice.Text, out stopPrice);
			decimal.TryParse(EntryLossLimit.Text, out lossLimit);

			List<decimal> inputs = new() { totalCapital, buyingPrice, stopPrice, lossLimit };
			List<Entry> userEntries = new() { EntryTotalCapital, EntryBuyingPrice, EntryStopPrice, EntryLossLimit };
			List<Entry> resultEntries = new() { EntryStopPercentage, EntryBuyingCapital, EntryStocks };

			var result = true;

			for (int i = 0; i < inputs.Count; i++)
			{
				if (inputs[i] <= 0)
				{
					result = false;
					userEntries[i].BackgroundColor = Colors.LightPink;
					InvalidInputMessages.MessageHandler(i, result);
				}
				else
				{
					InvalidInputMessages.MessageHandler(i, result);
					userEntries[i].BackgroundColor = Colors.White;
				}

			}

			if (stopPrice >= buyingPrice)
			{
				result = false;
				userEntries[1].BackgroundColor = Colors.LightPink;
				userEntries[2].BackgroundColor = Colors.LightPink;
				InvalidInputMessages.MessageHandler(4, result);
			}
			else
			{
				InvalidInputMessages.MessageHandler(4, true);
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




	}


}
