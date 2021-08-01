class Messages
{
    public static string mainMenu = @"""
      ========================== Trabalho de APA (Análise e projeto de algoritmos)==========================
      Alunos: 
      Ronaldo Modesto Ponciano 

      Algoritmos disponíves para comparação: 

       - BubbleSort
       - InsertionSort
       - SelectionSort
       - QuickSort
       - HeapSorte
       - MergeSort
       - Bogosort
      `";


    public static string loadingConfig = @"
    ========================== Trabalho de APA (Análise e projeto de algoritmos)==========================
  
    Alunos:
    Ronaldo Modesto Ponciano
  
    Por favor, aguarde, estamos carregando as configurações do projeto e gerando os arrays de valores.
    
    ";


    public static string erroLoadingConfig =
        @"Erro ao carregar as configurações do projeto.
        Por favor verifique o arquivo de configurações localizado em ${configPath} e reinicie o programa";

    public static string selectAnOption = @"Digite:
      1) Para comparar executar e comparar todos os algoritmos.
      2) Para selecionar e comparar 2 algoritmos específicos.";


    public static string invalidOption = @"Opção inválida";

    public static string selectFirstAlgorithm = @"
    Selecione o primeiro algoritmo que será utilizado para comparação:
    Digite:
      1) Para selecionar o quicksort.
      2) Para selecionar o heapsort
      3) Para selecionar o bogosort
      4) Para selecionar o mergesort
      5) Para selecionar o bubblesort
      6) Para selecionar o inserctionsort
      7) Para selecionar o selectionsort";

    public static string selectSecondAlgorithm = @"
        Agora selecione o segundo algoritmo:
        Digite:
      1) Para selecionar o quicksort.
      2) Para selecionar o heapsort
      3) Para selecionar o bogosort
      4) Para selecionar o mergesort
      5) Para selecionar o bubblesort
      6) Para selecionar o inserctionsort
      7) Para selecionar o selectionsort";


    public static string selectCompareType = @"
        Por favor informe o tipo de comparação. Digite :
        1) Para comparar os tempos de execução
        2) Para comparar o número de comarações realizadas
        ";

    public static string selecNumberType = @"
        Por favor informe o tipo de dado que será comparado. Digite :
        1) Para comparar os valores double
        2) Para comparar os valores inteiros
        3) Para comparar os valores bytes
        ";

    public static string selectDataState = @"
        Por favor informe o estado dos dados que serão comparados. Digite :
        1) Para comparar os valores ordenados
        2) Para comparar os valores não ordenados
        3) Para comparar os valores inversamente ordenados
        4) Para comparar valores não repetidos
        ";

}


