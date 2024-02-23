//using Javax.Xml.Transform;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Stokalculator
{
	public class InvalidInputMessages
	{
		public ObservableCollection<string> BindedMessages { get; } = new();
		private List<string> _messageList = new()
		{
			"Total capital can't be 0 or blank.", // [0]
			"Buying price can't be 0 or blank.", // [1]
			"Stop price can't be 0 or blank.", // [2]
			"Loss limit can't be 0 or blank.", // [3]
			"Buying price has to be higher than stop price." // [4]
		};
		public void MessageHandler(int index, string command) // Ao invés de string, posso fazer boolean e passar o "result"
		{
			if (command == "add")
			{
				if (BindedMessages.Contains(_messageList[index]))
				{
					return;
				}

				BindedMessages.Add(_messageList[index]);
			}

			if (command == "remove")
			{
				if (BindedMessages.Contains(_messageList[index]))
				{
					BindedMessages.Remove(_messageList[index]);
					return;
				}
			}
		}

	}


}
