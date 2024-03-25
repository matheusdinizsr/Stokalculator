# Stokalculator
Calculadora desktop de "tamanho de mão" para traders.
A aplicação foi feita para facilitar a vida dos traders, que muitas vezes devem tomar decisões rápidas quanto a compra de ações. Ela indica a quantidade de ações a ser comprada de acordo com informações que o usuário fornece, como capital disponível, preços de compra e stop, e limite de perda aceito pelo usuário. Com isso, realiza o **cálculo do tamanho do stop**, do **capital de compra** e da **quantidade de ações** que o usuário deve comprar para não ultrapassar o **limite de perda**, ou seja, o "tamanho da mão" que o trader deve utilizar naquela operação de compra.

## Stack Utilizada
- **Front-end**:  Xaml, Maui.
- **Back-end**: C#.

## Demonstração
https://imgur.com/tFwBUM8

## Funcionalidades
- Cálculo de "stop"
- Cálculo de "capital de compra"
- Cálculo de "quantidade de ações"

## Aprendizados
Neste projeto aprendi e utilizei:

- **Lógica de operações**: Criei toda a lógica matemática para permitir que a aplicação realizasse a operação da forma correta. Para isso, além de operações simples como a conversão de porcentagem para decimal, foi necessário encontrar o fator de compra que fizesse com que o resultado exibido fosse o correto.
- **Teste de inputs**: Adicionei um metodo que verifica se a informação fornecida pelo usuário está no formato correto. Caso alguma informação esteja em desacordo com o esperado pelo programa, os resultados são zerados, a sua respectiva caixa de texto tem sua cor alterada para vermelho e uma mensagem de entrada inválida é exibida, a fim de instruir o usuário a alimentar o sistema da forma correta. Aprendi a programar esse teste de inputs de forma dinâmica, em que os inputs do usuário e as caixas de texto de resultados são salvos em listas e iterados por meio de um _loop for_, fazendo com que apenas o input em desacordo seja destacado.
- **Converters**: Para forçar o usuário a digitar apenas números, optei por utilizar "converters". Assim, caso alguma letra seja digitada, o metodo automaticamente a remove, garantindo o funcionamento do sistema e eliminando as _exceptions_.
- **_Bind_ em propriedades, _ObservableCollection_**: Aprendi a utilizar o _binding_ em uma propriedade da classe que contém as mensagens de erros. Com isso, as mensagens de erros supracitadas são exibidas e removidas de forma automática e dinâmica.
- **Formtação da UI**: Aprendi a posicionar a janela da aplicação no centro da tela quando executada, com altura e largura pré-definidas. Também "travei" o tamanho da janela, desabilitando o botão "maximizar" e impossibilitando o seu redimensionamento. Aprendi a utilizar as funções de "style" do Maui, facilitando a padronização dos labels, entries e botões. O posicionamento dos componentes foi realizado utilizando o _Grid_, sendo necessário aprender sobre suas propriedades de colunas e linhas.

## Desafios
Considero que os dois maiores desafios foram o **exibir as mensagens de entrada inválida** e **não permitir a inserção de letras**. 

Quanto a **exibição das mensagens**, tive dificuldade porque minha ideia inicial era utilizar um método para alterar diretamente a propriedade "text" dos labels, o que não me dava o resultado esperado, já que a página não era atualizada quando essa propriedade era alterada. Após muita pesquisa, descobri que a solução seria utilizar **_binding_** nos campos da página e utilizar o evento **_OnPropertyChanged_** para exibi-las dinamicamente. Para simplificar a execução, optei por gerenciar as mensagens pela classe **_ObservableCollection_**, que possui esse evento intrinsicamente.

Para não permitir a **inserção de letras**, de início, havia utilizado o método **TryParse**. Com isso, conseguia eliminar as _exceptions_, mas ainda assim o usuário conseguia digitar os caracteres. Foi então que descobri a utilização dos **converters**, fazendo com que as letras fossem automaticamente removidas das entradas.

## E agora?
A ideia dessa aplicação era ser um projeto de estudo, mas no decorrer do desenvolvimento, percebi que ele tem potencial para ser um sistema muito maior. Por isso, decidi desenvolvê-lo novamente como **aplicação web**, utilizando **Blazor**.
Pretendo acrescentar as seguintes funções:

- Login com usuário e senha
- Banco de dados
- Histórico com operações de trading
- Gerenciamento de carteiras de capital
- Temas claro e escuro

