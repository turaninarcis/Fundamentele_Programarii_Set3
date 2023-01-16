internal class Program
{
    private static void Main(string[] args)
    {
        int indexProblema = InputProblemIndex();
        while (indexProblema < 1||indexProblema>31)
        {
            Console.WriteLine("Indexul nu poate fi mai mic decat 1 si nici mai mare decat 31");
            indexProblema = InputProblemIndex();
        }    
        ExecutareProblema(indexProblema);
        int b = indexProblema;
    }
    private static int InputProblemIndex()
    {
        Console.WriteLine("Introdu indexul problemei dorite");
        int indexProblema=0;
        try
        {
            indexProblema = int.Parse(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Datele introduse sunt gresite, te rog introdu din nou datele.");
            indexProblema = InputProblemIndex();
        }
        return indexProblema;
    }
    private static void ExecutareProblema(int index)
    {
        switch(index)
        {
            case 1: break;//Problema1();
            case 2: break;//Problema2();
            case 3: break;//Problema3();
            case 4: break;//Problema4();
            case 5: break;//Problema5();
            case 6: break;//Problema6();
            case 7: break;//Problema7();
            case 8: break;//Problema8();
            case 9: break;//Problema9();
            case 10: break;//Problema10();
            case 11: break;//Problema11();
            case 12: break;//Problema12();
            case 13: break;//Problema13();
            case 14: break;//Problema14();
            case 15: break;//Problema15();
            case 16: break;//Problema16();
            case 17: break;//Problema17();
            case 18: break;//Problema18();
            case 19: break;//Problema19();
            case 20: break;//Problema20();
            case 21: break;//Problema21();
            case 22: break;//Problema22();
            case 23: break;//Problema23();
            case 24: break;//Problema24();
            case 25: break;//Problema25();
            case 26: break;//Problema26();
            case 27: break;//Problema27();
            case 28: break;//Problema28();
            case 29: break;//Problema29();
            case 30: break;//Problema30();
            case 31: break;//Problema31();
            default:throw new Exception(); break;
        }
    }
}