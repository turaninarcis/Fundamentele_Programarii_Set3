using System.IO.Pipes;
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
            case 10: Problema10();break;
            case 11: Problema11();break;
            case 12: Problema12();break;
            case 13: Problema13();break;
            case 14: Problema14();break;
            case 15: Problema15();break;
            case 16: Problema16();break;
            case 17: Problema17();break;
            case 18: Problema18(); break;
            case 19: Problema19(); break;
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

    #region Helpers
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

    private static int BinarySearch(int[] array, int x, int low, int high)
    {
        int mid;
        while (low < high)
        {
            mid = (low + high) / 2;
            if (array[mid] == x)
                return mid;
            else if (array[mid] < x)
            {
                low = mid + 1;
            }
            else if (array[mid] > x)
            {
                high = mid - 1;
            }
        }
        return -1;
    }

    private static int CMMDC(int a,int b)
    {
        int r;
        while(b!=0)
        {
            r = a%b; a = b; b = r;
        }
        return a;
    }
    private static char NumberToChar(int n)
    {
        switch(n)
        {
            case 0: return '0';
            case 1:return'1';
            case 2:return '2';
            case 3:return '3';
            case 4:return '4';
            case 5:return '5';
            case 6:return '6';
            case 7:return '7';
            case 8:return '8';
            case 9:return '9';
            case 10:return 'A';
            case 11:return 'B';
            case 12: return 'C';
            case 13: return 'D';
            case 14: return 'E';
            case 15: return 'F';
            default: throw new Exception();
        }
    }

    private static int InputProblemIndex()
    {
        Console.Write("Introdu indexul problemei dorite: ");
        int indexProblema = 0;
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
    #endregion

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
        Console.Write("Introduceti un numar k pe care doriti sa il gasiti in vector ");
        int k = GetInputInt();
        Array.Sort(numere);
        int index = BinarySearch(numere, k, 0, numere.Length);
        Console.WriteLine(index);
    }

    private static void Problema11()
    {
        Console.Write("Introduceti un numar n pentru care doriti sa aflati toate numerele prime mai mici sau egale cu acesta: ");
        int n = GetInputInt();

        int[] prime = new int[n+1];
        for(int i = 0;i<=n;i++)
        {
            prime[i] = 0;
        }
        prime[0] = 1;
        prime[1] = 1;

        for(int i = 2;i<Math.Sqrt(n);i++)
        {
            if (prime[i]==0)
            {
                for(int j = 2;j<=n/i;j++)
                {
                    prime[i * j] = 1;
                }
            }
        }
        Console.WriteLine("Numerele prime mai mici sau egale cu n sunt: ");
        for(int i =0;i<n;i++)
        {
            if (prime[i]==0)
            {
                Console.Write(i+" ");
            }
        }

    }

    private static void Problema12() 
    {
        int[] numere = GetInputVector();

        int min;
        for(int i = 0;i<numere.Length-1;i++)
        {
            min = i;
            for (int j = i+1;j<numere.Length;j++)
            {
                if (numere[min] > numere[j])
                {
                    
                    min = j;
                }

            }
            (numere[min], numere[i]) = (numere[i], numere[min]);
        }
        ShowTheArray(numere);
    }

    private static void Problema13() 
    {
        int[] numere = GetInputVector();

        for(int i = 1;i<numere.Length;i++)
        {
            int aux = numere[i];
            int position = i;
            while(position > 0 && numere[position-1]>aux)
            {
                numere[position] = numere[position- 1];
                position--;
            }
            numere[position] = aux;
        }
        ShowTheArray(numere);
    }

    private static void Problema14()
    {
        int[] numere = GetInputVector();
        int indexAux;
        for(int i = 0;i<numere.Length;i++)
        {
            if (numere[i]==0)
            {
                indexAux = i;
                while (i < numere.Length - 1 && numere[i] == 0)
                {
                    i++;
                } 
                numere[indexAux] = numere[i];
                numere[i] = 0;
                i = indexAux;
            }
        }
        ShowTheArray(numere);
    }

    private static void Problema15() 
    {
        int[] numere = GetInputVector();
        for (int i = 0; i < numere.Length; i++)
        {
            while (Array.FindIndex(numere, i + 1, val => val.Equals(numere[i]))>=0)
            {
                int index = Array.FindIndex(numere, i + 1, val => val.Equals(numere[i]));
                Array.ConstrainedCopy(numere,index+1, numere,index,numere.Length-index-1);
                Array.Resize(ref numere,numere.Length-1);
                
            }
            
        }
        ShowTheArray(numere);
    }

    private static void Problema16()
    {
        int[] numere = GetInputVector();

        int div = CMMDC(numere[0], numere[1]);

        for(int i = 2;i<numere.Length;i++)
        {
            div = CMMDC(div, numere[i]);
        }
        Console.WriteLine("Cel mai mare divizor al numerelor din sir este: "+ div);
    }
    private static void Problema17() 
    {
        Console.Write("Introduceti un numar: ");
        int n = GetInputInt();
        Console.Write("Introduceti baza in care doriti sa transformati numarul introdus: ");
        int b = GetInputInt();
        int c;
        Stack<char> numarInBazaB = new Stack<char>();
        while(n/b!=0)
        {
            c = n % b;
            numarInBazaB.Push(NumberToChar(c));
            n=n/b;

        }
        numarInBazaB.Push(NumberToChar(n % b));
        while(numarInBazaB.Count>0)
            Console.Write(numarInBazaB.Pop());
    }
    private static void Problema18() 
    {
        int[] polinom = GetInputVector();
        Console.Write("Introduceti un n pentru care doriti sa calculati valoarea polinomului in acel punct: ");
        int x = GetInputInt();
        double rezultat = 0;
        for(int i = 0;i<polinom.Length;i++)
        {
            rezultat += polinom[i] * Math.Pow(x, i);
        }

        Console.WriteLine($"Rezultatul polinomului in punctul {x} este: {rezultat}.");
    }

    private static void Problema19()
    {
        Console.WriteLine("Vectorul in care se cauta este: ");
        int[] s = GetInputVector();

        Console.WriteLine("Vectorul care se cauta este: ");
        int[] p = GetInputVector();

        int n = 0;
        
        for(int i = 0;i< s.Length;i++) 
        {
            bool ok = true;
            if (s[i] == p[0])
            {
                for(int j = 0;j<p.Length;j++)
                {
                    if (i + j >= s.Length || s[i+j] != p[j]) 
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok) { n++; }
            }
        }
        Console.WriteLine($"p apare in vectorul s de {n} ori.");
    }

    private static void Problema20() 
    {

    }
    #endregion
}