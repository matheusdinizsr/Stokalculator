# Stokalculator
Desktop "hand-size" calculator for traders.

The application was designed to ease the traders1 lives, who often need to make quick decisions regarding stock purchases. It indicates the **quantity of stocks** to be bought based on information provided by the user, such as available capital, buying and stop prices, and the loss limit accepted by the user. It then gives the user the **stop size**, **buying capital**, and **quantity of stocks** that should be bought to not exceed the loss limit. In other words, it calculates the "size of the hand" that the trader should use in that trade.

## Stack
- **Front-end**:  Xaml, Maui.
- **Back-end**: C#.

## Demon
https://imgur.com/tFwBUM8

## Features
- "Stop price" calculation
- "Buying capital" calculation
- "Stock amount" calculation

## Learnings
In this project, I learned and used:

- **Operation Logic**: I created the entire mathematical logic to allow the application to perform operations correctly. This involved not only simple operations like converting percentages to decimals but also finding the buying factor that would ensure the displayed result was accurate.
- **Input Testing**: I added a method to verify if the information provided by the user was in the correct format. If any information is not in line with what the program expected, the results are cleared, the respective text box it's collored in red, and an invalid input message is displayed to guide the user to write tine correct input. I learned to program this input testing dynamically, so user inputs and result text boxes are saved in lists and iterated through using a for loop, highlighting only the input that is not correct.
- **Converters**: To enforce the user to enter only numbers, I opted to use converters. Thus, if any letter was typed, the method automatically removed it, ensuring the system's operation and eliminating exceptions.
- **Binding on Properties, ObservableCollection**: I learned how to use binding on a property of the error message list class. With this, the above-mentioned error messages are displayed or removed automatically and dynamically.
- **UI Formatting**: I learned how to position the application window in the center of the screen when executed, with predefined height and width. I also "locked" the window size, disabling the "maximize" button and preventing resizing. I learned to use Maui's style functions, simplifying the standardization of labels, entries, and buttons. The positioning of components was done using the Grid, requiring research about its column and row properties.

## Challenges
I consider that the two main challenges were **displaying invalid input messages** and **preventing the input of letters**.

Regarding **displaying the messages**, I had a hard time because my initial idea was to directly modify the "text" property of the labels, which didn't give me the expected result since the page wasn't refreshed when this property was changed. After a lot of research, I found that the solution would be using **binding** on the page fields and using the **OnPropertyChanged** event to display them dynamically. To simplify execution, I chose to manage the messages through the **ObservableCollection** class, which inherently has this event.

To prevent input of letters, initially, I used the TryParse method. While this was correctly handling exceptions, users could still input characters. That's when I found about the use of converters, which automatically removed letters from the inputs.

## What's next?
A ideia dessa aplicação era ser um projeto de estudo, mas no decorrer do desenvolvimento, percebi que ele tem potencial para ser um sistema muito maior. Por isso, decidi desenvolvê-lo novamente como **aplicação web**, utilizando **Blazor**.
Pretendo acrescentar as seguintes funções:

- Login com usuário e senha
- Banco de dados
- Histórico com operações de trading
- Gerenciamento de carteiras de capital
- Temas claro e escuro

This project was initially made for study purposes, but as development progressed, I realized it had the potential to become a much more complete system. Therefore, I decided to rebuild it as a web application using **Blazor**.

I plan to add the following features:

- User login with username and password
- Database integration
- Trading operations history
- Capital portfolio management
- Light and dark themes

