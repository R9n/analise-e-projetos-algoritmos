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

    public static string selectAlgorithm = @"Digite:
      1) Para selecionar o quicksort.
      2) Para selecionar o heapsort
      3) Para selecionar o bogosort
      4) Para selecionar o mergesort
      5) Para selecionar o bubblesort
      6) Para selecionar o inserctionsort
      7) Para selecionar o selectionsort";

}


