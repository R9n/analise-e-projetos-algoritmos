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
      2) Para selecionar e comparar 2 algoritmos especcíficos.";


    public static string invalidOption = @"Opção inválida";

}


