using System.Numerics;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            case 1: Problema1();break;
            case 2: Problema2();break;
            case 3: Problema3();break;
            case 4: Problema4();break;
            case 5: Problema5();break;
            case 6: Problema6();break;
            case 7: Problema7();break;
            case 8: Problema8();break;
            case 9: Problema9();break;
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

    private static int[] GetInputVector()
    {
        Console.WriteLine("Introduceti sirul de numere necesar problemei");
        int[] vectorNumere;
        string[] stringuriNumere;
        char[] despartitoare = { ' ', ',', ';' };
        stringuriNumere = Console.ReadLine().Split(despartitoare);
        Stack<int> stackNumere = new Stack<int>();
        int aux = 0;
        foreach(string numar in stringuriNumere)
        {
            if(int.TryParse(numar,out aux))
            { stackNumere.Push(aux);}
        }
        vectorNumere = stackNumere.ToArray();
        Array.Reverse(vectorNumere);
        return vectorNumere;
        
    }
    private static int GetInputInt()
    {
        bool ok;
        int k = 0;
        do
        {
            ok = false;
            try
            {
                if(int.TryParse(Console.ReadLine(), out k))
                    ok = true;
                else throw new Exception();
            }
            catch { Console.WriteLine("Input gresit, incercati sa introduceti din nou datele."); }
        } while (ok == false);
        return k;
    }
    private static void ShowTheArray(int[] array)
    {
        Console.Write("Noul vector: ");
        foreach(int i in array) Console.Write(i+" ");
    }

    #region Probleme
    private static void Problema1()
    {
        int[] numere = GetInputVector();
        int sum = 0;
        foreach(int numar in numere)
        { sum += numar; }
        Console.WriteLine(sum.ToString());
    }
    private static void Problema2()
    {
        int[] numere = GetInputVector();
        int k;
        Console.WriteLine("Introduceti un numar intreg k pe care doriti sa il cautati in sir.");
        while(!int.TryParse(Console.ReadLine(),out k))
        { Console.WriteLine("Valoarea introdusa nu este valida. Introduceti un numar intreg k pe care doriti sa il cautati in sir."); }
        for(int i = 0;i<numere.Length;i++)
        {
            if (numere[i] == k)
            {
                Console.WriteLine(i);
                return;
            }
        }
        Console.WriteLine("-1");
    }

    private static void Problema3() 
    {
        int[] numere = GetInputVector();
        int[] numere2 = new int[numere.Length];
        Array.Copy(numere, numere2,numere.Length);
        Array.Sort(numere2);
        int max = numere2[numere2.Length-1];
        int min = numere2[0];
        Console.WriteLine("Cel mai mic element din vector e pe pozitia " + Array.IndexOf(numere, min) + 
                            " iar cel mai mare element se afla pe pozitia "+ Array.LastIndexOf(numere,max));
        //0 comparatii
    }

    private static void Problema4()
    {
        int[] numere = GetInputVector();
        int max = int.MinValue; 
        int min = int.MaxValue;
        int maxAppearances=0;
        int minAppearances=0;

        for(int i = 0;i< numere.Length;i++)
        {
            if (numere[i]>max)
            {
                max = numere[i];
                maxAppearances=1;
            }
            else if (numere[i]==max)
                maxAppearances++;
            if (numere[i] < min)
            {
                min = numere[i];
                minAppearances=1;
            }
            else if (numere[i]==min)
            {
                minAppearances++;
            }
        }
        Console.WriteLine($"Cel mai mic element din vector este {min} care a aparut de {minAppearances} ori, " +
                            $"iar cel mai mare element este {max} care a aparut de {maxAppearances} ori.");

    }
    private static void Problema5() 
    {
        int[] numere = GetInputVector();
        int[] numereExtended = new int[numere.Length+1];
        Array.Copy(numere, numereExtended,numere.Length);
        Console.WriteLine("Introduceti o valoare e si o pozitie din vector k");
        string[] numberStrings = new string[2];
        bool ok;
        int e=0;int k = 0;
        do
        {
            ok = false;
            try
            { numberStrings = Console.ReadLine().Split(" ");
                int.TryParse(numberStrings[0], out e);
                int.TryParse(numberStrings[1], out k);
             ok = true; }
            catch { Console.WriteLine("Input gresit, incercati sa introduceti din nou datele."); }
        }while(ok==false);
        
        for(int i = numereExtended.Length-1; i>k; i--)
        {
            numereExtended[i] = numereExtended[i - 1];
        }
        numereExtended[k] = e;
        
        Console.WriteLine("Noul vector este: ");
        foreach(int i in numereExtended)
        {
            Console.Write(i+" ");
        }
        
    }

    private static void Problema6()
    {
        int[]? numere = GetInputVector();

        Console.WriteLine("Introduceti o pozitie al unui element din vector pe care doriti sa il stergeti");
        bool ok;
        int k = 0;
        do
        {
            ok = false;
            try
            {
                int.TryParse(Console.ReadLine(), out k);
                ok = true;
            }
            catch { Console.WriteLine("Input gresit, incercati sa introduceti din nou datele."); }
        } while (ok == false);

        for(int i = k; i < numere.Length-1;i++)
        {
            numere[i] = numere[i + 1];
        }
        Array.Resize(ref numere, numere.Length - 1);

        Console.WriteLine("Noul vector este: ");
        foreach (int i in numere)
        {
            Console.Write(i + " ");
        }
    }

    private static void Problema7()
    {
        int[] numere = GetInputVector();
        int aux = 0;
        for(int i = 0;i<numere.Length/2;i++)
        {
            aux = numere[i];
            numere[i] = numere[numere.Length-i-1];
            numere[numere.Length-i-1] = aux;
        }

        Console.WriteLine("Noul vector este: ");

        foreach(int i in numere)
        {
            Console.Write(i + " ");
        }
    }

    private static void Problema8()
    {
        int[] numere = GetInputVector();
        int aux = numere[0];
        for (int i = 0; i < numere.Length - 1; i++)
        {
            numere[i] = numere[i + 1];
        }
        numere[numere.Length - 1] = aux;
        ShowTheArray(numere);
    }
    private static void Problema9()
    {
        int[] numere = GetInputVector();
        Console.WriteLine("Introduceti un numar k care semnifica numarul de rotiri pe care doriti sa-l efectuati asupra vectorului.");
        int k = GetInputInt();

        while(k>0)
        {
            int aux = numere[0];
            for(int i = 0;i<numere.Length-1;i++)
            {
                numere[i] = numere[i + 1];
            }
            numere[numere.Length - 1] = aux;
            k--;
        }
        ShowTheArray(numere);
    }

    private static void Problema10() 
    {
        int[] numere = GetInputVector();
        int k = GetInputInt();
        Array.Sort(numere);
    }

    private static int BinarySearch(int[] array,int x ,int low, int high)
    {
        int mid;
        while(low < high)
        {
            mid = (low+high)/2;
            if (array[mid]==x) return mid;
            else if (array[mid]<x)
            {

            }
        }
    }
    #endregion
}