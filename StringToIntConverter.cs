using System.Globalization;

namespace Stokalculator
{
	public class StringToIntConverter : IValueConverter
	{
		public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			return value?.ToString();
		}

		public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
		{
			var str = value?.ToString();

			if (int.TryParse(str, out int result))
			{
				return result;
			}
			else
			{
				return 0;
			}
		}
	}


}
