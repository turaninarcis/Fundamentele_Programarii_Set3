using System.ComponentModel;
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
            case 20: Problema20(); break;
            case 21: Problema21(); break;
            case 22: Problema22(); break;
            case 23: Problema23(); break;
            case 24: Problema24(); break;
            case 25: Problema25(); break;
            case 26: Problema26(); break;
            case 27: Problema27(); break;
            case 28: Problema28(); break;
            case 29: Problema29(); break;
            case 30: Problema30(); break;
            case 31: Problema31(); break;
            default:throw new Exception(); break;
        }
    }

    #region Helpers

    #region InputsOutputs
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
    private static int[] GetInputVector()
    {
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

    #endregion
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
    #region Transformari
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

    private static int CharToNumber(char c)
    {
        switch (c)
        {
            case '0': return 0;
            case '1': return 1;
            case '2': return 2;
            case '3': return 3;
            case '4': return 4;
            case '5': return 5;
            case '6': return 6;
            case '7': return 7;
            case '8': return 8;
            case '9': return 9;
            default: throw new Exception();
        }
        
    }
    #endregion
    

    private static int[] RemoveRepeatingElements(int[] numere)
    {
        for (int i = 0; i < numere.Length; i++)
        {
            while (Array.FindIndex(numere, i + 1, val => val.Equals(numere[i])) >= 0)
            {
                int index = Array.FindIndex(numere, i + 1, val => val.Equals(numere[i]));
                Array.ConstrainedCopy(numere, index + 1, numere, index, numere.Length - index - 1);
                Array.Resize(ref numere, numere.Length - 1);

            }

        }
        return numere;
    }
    #region Sortari
    private static int[] SelectionSort(int[] numere) 
    {
        int min;
        for (int i = 0; i < numere.Length - 1; i++)
        {
            min = i;
            for (int j = i + 1; j < numere.Length; j++)
            {
                if (numere[min] > numere[j])
                {

                    min = j;
                }

            }
            (numere[min], numere[i]) = (numere[i], numere[min]);
        }
        return numere;
    }

    private static void QuickSort(int[] numere, int beg,int end) 
    {
        if(beg<end)
        {
            int pivotIndex = Partition(numere,beg,end);
            QuickSort(numere, beg, pivotIndex-1);
            QuickSort(numere, pivotIndex+1, end);
        }
    }
    private static int Partition(int[]numere,int beg,int end)
    {
        int pivot = numere[end];
        int pIndex = beg - 1;
        for(int i = beg;i<end;i++)
        {
            if (numere[i]<pivot)
            {
                pIndex++;
                (numere[i], numere[pIndex]) = (numere[pIndex], numere[i]);
            }
        }
        (numere[pIndex + 1], numere[end]) = (numere[end], numere[pIndex+1]);
        return pIndex+1;
    }

    private static void MergeSortAux(int[]numere, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        int[] L = new int[n1];
        int[] R = new int[n2];
        int i, j;

        for (i = 0; i < n1; ++i)
            L[i] = numere[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = numere[m + 1 + j];
        i = 0;
        j = 0;

        int k = l;
        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                numere[k] = L[i];
                i++;
            }
            else
            {
                numere[k] = R[j];
                j++;
            }
            k++;
        }
        while (i < n1)
        {
            numere[k] = L[i];
            i++;
            k++;
        }
        while (j < n2)
        {
            numere[k] = R[j];
            j++;
            k++;
        }
    }
    private static void MergeSort(int[] numere,int l, int r)
    {
        if (l < r)
        {
            int m = l + (r - l) / 2;
            MergeSort(numere, l, m);
            MergeSort(numere, m + 1, r);
            MergeSortAux(numere, l, m, r);
        }
    }
    #endregion

    #region ProcesareNumereMari
    private static string AdunareDouaNumereMari(string numar1,string numar2)
    {
        char[] adunare;
        string longerNumber;
        string shorterNumber;
        if (numar1.Length > numar2.Length)
        {
            longerNumber = numar1;
            shorterNumber = numar2;
        }
        else
        {
            longerNumber = numar2;
            shorterNumber = numar1;
        }
        adunare = ("0" + longerNumber).ToCharArray();
        int aux;
        int carry = 0;

        int i = 0;
        while (i < shorterNumber.Length)
        {
            aux = CharToNumber(adunare[adunare.Length - i - 1]) + CharToNumber(shorterNumber[shorterNumber.Length - i - 1]);
            aux += carry;
            if (aux >= 10)
            {
                carry = 1;
                aux = aux % 10;
            }
            else
            {
                carry = 0;
            }
            adunare[adunare.Length - i - 1] = NumberToChar(aux);
            i++;
        }
        while (i < adunare.Length)
        {
            aux = CharToNumber(adunare[adunare.Length - i - 1]);
            aux += carry;
            if (aux >= 10)
            {
                carry = 1;
                aux = aux % 10;
            }
            else
            {
                carry = 0;
            }
            adunare[adunare.Length - i - 1] = NumberToChar(aux);
            i++;
        }
        if (adunare[0] == '0')
        { Array.Copy(adunare, 1, adunare, 0, adunare.Length - 1); Array.Resize(ref adunare,adunare.Length - 1); }
        string rezultat="";
        foreach(char c in adunare)
        {
            rezultat += c;
        }
        return rezultat;
    }
    private static string ScadereDouaNumereMari(string numar1,string numar2)
    {
        Stack<char> stackScadere = new Stack<char>();

        bool isNegative =false;
        if(numar1.Length <numar2.Length) 
        {
            isNegative = true;
        }
        else if(numar1.Length>numar2.Length)
        {
            isNegative = false;
        }
        else
        {
            for (int i = 0; i < Math.Min(numar1.Length, numar2.Length); i++)
            {
                if (CharToNumber(numar1[i]) > CharToNumber(numar2[i]))
                {
                    isNegative = false;
                    break;
                }
                else if (CharToNumber(numar1[i]) < CharToNumber(numar2[i]))
                {
                    isNegative = true;
                    break;
                }
            }
        
        }
       if(isNegative)
        {
            stackScadere = ScadereDouaNumereMariAux(numar2, numar1);
        }
       else
        {
            stackScadere = ScadereDouaNumereMariAux(numar1, numar2);
        }




        if (isNegative) 
        {
            stackScadere.Push('-');
        }
        string stringNumar = "";

        while (stackScadere.Peek()=='0')
        {
            stackScadere.Pop();
        }

        foreach(char c in stackScadere) 
        {
            stringNumar += c;
        }
        
        return stringNumar;
    }
    private static Stack<char> ScadereDouaNumereMariAux(string numar1, string numar2)
    {
        Stack<char> stackScadere = new Stack<char>();

        int i = numar1.Length - 1;
        int j = numar2.Length - 1;
        int carry = 0;
        int aux;
        while (i >= 0 && j >= 0)
        {
            aux = CharToNumber(numar1[i]) - CharToNumber(numar2[j]) - carry;
            carry = 0;
            if (aux < 0)
            {
                carry = 1;
                aux += 10;
                stackScadere.Push(NumberToChar(aux));
            }
            else
            {
                stackScadere.Push(NumberToChar(aux));
            }
            i--;
            j--;
        }
        if (i >= 0)
        {
            for (int k = i; k >= 0; k--)
            {
                aux = CharToNumber(numar1[k]) - carry;
                if (aux < 0)
                {
                    carry = 1;
                    stackScadere.Push(NumberToChar(aux + 10));

                }
                else
                {
                    stackScadere.Push(NumberToChar(aux));
                    carry = 0;
                }
            }
        }
        return stackScadere;
    }
    
    private static string InmultireDouaNumereMari(string numar1,string numar2)
    {
        int[,] matriceInmultire = new int[numar1.Length,numar2.Length+1];
        int carry;
        int aux;
        for (int i = 0; i < numar1.Length; i++)
        {
            carry = 0;
            for (int j = 0; j < numar2.Length; j++)
            {
                aux = CharToNumber(numar1[numar1.Length-i-1]) * CharToNumber(numar2[numar2.Length-j-1])+carry;
                carry = 0;
                if(aux>=10)
                {
                    carry = aux / 10;
                    aux = aux % 10;
                }
                matriceInmultire[i, numar2.Length - j] = aux;
            }
            matriceInmultire[i, 0] = carry;
        }
        string[] sirNumereAuxiliare = new string[matriceInmultire.GetLength(0)];
        for(int i = 0;i<matriceInmultire.GetLength(0);i++)
        {
            for (int j = 0;j<matriceInmultire.GetLength(1);j++)
            {
                if (j == 0 && matriceInmultire[i, j] == 0)
                    continue;
                sirNumereAuxiliare[i] += NumberToChar(matriceInmultire[i, j]);
            }
            
            for(int k = 0;k<i;k++)
            {
                sirNumereAuxiliare[i] += "0";
            }
        }
        string rezultat = "0";
        foreach (string sir in sirNumereAuxiliare)
        {
            rezultat = AdunareDouaNumereMari(rezultat, sir);
        }
        return rezultat;
    }

    #endregion

    #endregion

    #region Probleme
    #region PrimaJumatate
    private static void Problema1()
    {
        Console.WriteLine("Introduceti vectorul pentru care doriti suma elementelor: ");
        int[] numere = GetInputVector();
        int sum = 0;
        foreach(int numar in numere)
        { sum += numar; }
        Console.WriteLine(sum.ToString());
    }
    private static void Problema2()
    {
        Console.WriteLine("Introduceti vectorul pe care doriti sa fie cautat numarul k: ");
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
        Console.WriteLine("Introduceti vectorul pentru care doriti sa aflati cel mai mic element si cel mai mare element care se afla in acesta: ");
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
        Console.WriteLine("Introduceti vectorul pentru care doriti sa aflati cel mai mic element si cel mai mare element care se afla in acesta: ");

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
        Console.WriteLine("Introduceti vectorul in care doriti sa inserati o valoare e pe pozitia k: ");
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
        Console.WriteLine("Introduceti vectorul din care doriti sa stergeti o valoare de pe pozitia k: ");

        int[]? numere = GetInputVector();

        Console.WriteLine("Introduceti o pozitie al unui element din vector pe care doriti sa il stergeti");
        bool ok;
        int k = GetInputInt();
        
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
        Console.WriteLine("Introduceti vectorul pe care doriti sa il inserati: ");
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
        Console.WriteLine("Introduceti vectorul pe care doriti sa il rotiti cu o pozitie spre stanga: ");
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
        Console.WriteLine("Introduceti vectorul pe care doriti sa il rotiti cu k pozitii spre stanga: ");

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
        Console.Write("Introduceti vectorul pe care se va face cautarea binara: ");
        int[] numere = GetInputVector();
        Console.Write("Introduceti un numar k pe care doriti sa il gasiti in vector ");
        int k = GetInputInt();
        Array.Sort(numere);
        int index = BinarySearch(numere, k, 0, numere.Length);
        Console.WriteLine(index);
    }

    private static void Problema11()
    {
        Console.WriteLine("Introduceti un numar n pentru care doriti sa aflati toate numerele prime mai mici sau egale cu acesta: ");
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
        Console.WriteLine("Introduceti vectorul pe care doriti sa se faca SelectionSort: ");
        int[] numere = GetInputVector();

        SelectionSort(numere);
        ShowTheArray(numere);
    }

    private static void Problema13() 
    {
        Console.WriteLine("Introduceti vectorul pe care doriti sa se faca InsertionSort: ");

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
        Console.WriteLine("Introduceti vectorul pentru care doriti ca toate valorile egale cu zero sa ajunga la final: ");
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
        Console.WriteLine("Introduceti vectorul din care se vor elimina elementele care se repeta: ");
        int[] numere = GetInputVector();
        numere = RemoveRepeatingElements(numere);
        ShowTheArray(numere);
    }
    #endregion
    #region ADouaJumatate
    private static void Problema16()
    {
        Console.WriteLine("Introduceti vectorul din care doriti sa extrageti cel mai mare divizor comun pentru toate numerele din vector: ");
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
        Console.WriteLine("Introduceti polinomul de grad n cu cel mai putin semnificativ coeficient fiind pe prima pozitie in vector: ");
        int[] polinom = GetInputVector();
        Console.Write("Introduceti un n pentru care doriti sa calculati valoarea polinomului in acel punct: ");
        int x = GetInputInt();
        long rezultat = 0;
        for(int i = 0;i<polinom.Length;i++)
        {
            rezultat += polinom[i] * (long)Math.Pow(x, i);
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
        Console.WriteLine("Introduceti primul sireag de margele");
        int[] s1 = GetInputVector();
        Console.WriteLine("Introduceti al doilea sireag de margele");
        int[] s2 = GetInputVector();
        int n = 0;
        int aux = 0;
        for(int i = 0;i< s1.Length;i++) 
        {
            for(int j = 0;j<s1.Length;j++)
            {
                if (s1[j] == s2[j]) n++;
            }
            aux = s1[0];
            for(int j = 0; j < s1.Length-1; j++) 
            {
                s1[j] = s1[j+1];
            }
            s1[s1.Length-1] = aux;

        }
        Console.WriteLine("Numarul de margele suprapuse este: " + n);
    }
    private static void Problema21()
    {
        Console.WriteLine("Introduceti primul cuvant: ");
        string cuvant1 = Console.ReadLine();
        Console.WriteLine("Introduceti al doilea cuvant: ");
        string cuvant2 = Console.ReadLine();

        string cuvant1aux = cuvant1.ToUpper();
        string cuvant2aux = cuvant2.ToUpper();
        if(cuvant1aux.Equals(cuvant2aux)) { Console.WriteLine("Cuvintele sunt egale."); return; }
        int aux = Math.Min(cuvant1.Length, cuvant2.Length);
        int i = 0;
        while (cuvant2aux[i] == cuvant1aux[i]&&i<aux)
        { i++; }
        if (cuvant1aux[i] < cuvant2aux[i]) { Console.WriteLine($"{cuvant1} ar aparea primul in dictionar iar {cuvant2} ar aparea al doilea."); }
        else { Console.WriteLine($"{cuvant2} ar aparea primul in dictionar iar {cuvant1} ar aparea al doilea."); }
    }

    private static void Problema22()
    {
        Console.WriteLine("Introduceti primul vector");
        int[] v1 = GetInputVector();
        Console.WriteLine("Introduceti al doilea vector");
        int[] v2 = GetInputVector();

        v1 = RemoveRepeatingElements(v1);
        v2 = RemoveRepeatingElements(v2);

        List<int> listaIntersectieVectori = new List<int>();
        List<int> listaReuniuneVectori= new List<int>();
        List<int> v1minusv2 = new List<int>();
        List<int> v2minusv1 = new List<int>();

        for(int i = 0;i<v1.Length;i++) 
        {
            for(int j = 0;j<v2.Length;j++) 
            {
                if (v1[i] == v2[j]) 
                {
                    listaIntersectieVectori.Add(v1[i]);
                }
            }
        }
        for (int i = 0; i < v1.Length; i++)
        {
            listaReuniuneVectori.Add(v1[i]);
        }
        for(int j = 0; j < v2.Length; j++) 
        {
            if (!listaReuniuneVectori.Contains(v2[j]))
                listaReuniuneVectori.Add(v2[j]);
        }
        bool ok;
        for (int i = 0; i < v1.Length; i++)
        {
            ok = true;   
            for (int j = 0; j < v2.Length; j++)
            {
                if (v1[i] == v2[j])
                {
                    ok= false;
                }
            }
            if(ok==true) { v1minusv2.Add(v1[i]); }
        }
        for (int i = 0; i < v2.Length; i++)
        {
            ok = true;
            for (int j = 0; j < v1.Length; j++)
            {
                if (v2[i] == v1[j])
                {
                    ok = false;
                }
            }
            if (ok == true) { v2minusv1.Add(v2[i]); }
        }

        Console.Write("Reuniunea vectorilor: ");
        for(int i = 0; i < listaReuniuneVectori.Count; i++) { Console.Write(listaReuniuneVectori[i]+" "); }
        Console.WriteLine();

        Console.Write("Intersectia vectorilor: ");
        for (int i = 0; i < listaIntersectieVectori.Count; i++) { Console.Write(listaIntersectieVectori[i] + " "); }
        Console.WriteLine();

        Console.Write("v1-v2: ");
        for (int i = 0; i < v1minusv2.Count; i++) { Console.Write(v1minusv2[i] + " "); }
        Console.WriteLine();

        Console.Write("v2-v1: ");
        for (int i = 0; i < v2minusv1.Count; i++) { Console.Write(v2minusv1[i] + " "); }
        Console.WriteLine();

    }

    private static void Problema23()
    {
        Console.WriteLine("Introduceti primul vector");
        int[] v1 = GetInputVector();
        Console.WriteLine("Introduceti al doilea vector");
        int[] v2 = GetInputVector();

        v1 = RemoveRepeatingElements(v1);
        v2 = RemoveRepeatingElements(v2);
        v1 = SelectionSort(v1);//singura diferenta intre cealalta rezolvare si aceasta rezolvare este aparitia acestor apeluri a functiei de sortare
        v2 = SelectionSort(v2);
        List<int> listaIntersectieVectori = new List<int>();
        List<int> listaReuniuneVectori = new List<int>();
        List<int> v1minusv2 = new List<int>();
        List<int> v2minusv1 = new List<int>();

        for (int i = 0; i < v1.Length; i++)
        {
            for (int j = 0; j < v2.Length; j++)
            {
                if (v1[i] == v2[j])
                {
                    listaIntersectieVectori.Add(v1[i]);
                }
            }
        }
        for (int i = 0; i < v1.Length; i++)
        {
            listaReuniuneVectori.Add(v1[i]);
        }
        for (int j = 0; j < v2.Length; j++)
        {
            if (!listaReuniuneVectori.Contains(v2[j]))
                listaReuniuneVectori.Add(v2[j]);
        }
        bool ok;
        for (int i = 0; i < v1.Length; i++)
        {
            ok = true;
            for (int j = 0; j < v2.Length; j++)
            {
                if (v1[i] == v2[j])
                {
                    ok = false;
                }
            }
            if (ok == true) { v1minusv2.Add(v1[i]); }
        }
        for (int i = 0; i < v2.Length; i++)
        {
            ok = true;
            for (int j = 0; j < v1.Length; j++)
            {
                if (v2[i] == v1[j])
                {
                    ok = false;
                }
            }
            if (ok == true) { v2minusv1.Add(v2[i]); }
        }

        Console.Write("Reuniunea vectorilor: ");
        for (int i = 0; i < listaReuniuneVectori.Count; i++) { Console.Write(listaReuniuneVectori[i] + " "); }
        Console.WriteLine();

        Console.Write("Intersectia vectorilor: ");
        for (int i = 0; i < listaIntersectieVectori.Count; i++) { Console.Write(listaIntersectieVectori[i] + " "); }
        Console.WriteLine();

        Console.Write("v1-v2: ");
        for (int i = 0; i < v1minusv2.Count; i++) { Console.Write(v1minusv2[i] + " "); }
        Console.WriteLine();

        Console.Write("v2-v1: ");
        for (int i = 0; i < v2minusv1.Count; i++) { Console.Write(v2minusv1[i] + " "); }
        Console.WriteLine();
    }

    private static void Problema24()
    {
        Console.WriteLine("Introduceti primul vector");
        int[] v1 = GetInputVector();
        Console.WriteLine("Introduceti al doilea vector");
        int[] v2 = GetInputVector();
        int maximul = int.MinValue;
        for(int i = 0;i<v1.Length;i++)
        {
            if (v1[i]>maximul) maximul = v1[i];
        }
        int[] v1Bool = new int[maximul+1];

        int max = int.MinValue;
        for (int i = 0; i < v2.Length; i++)
        {
            if (v2[i] > maximul) maximul = v2[i];
        }
        int[] v2Bool = new int[maximul+1];
        
        for(int i = 0;i< v1.Length;i++) 
        {
            v1Bool[v1[i]] = 1;
        }
        for (int i = 0; i < v2.Length; i++)
        {
            v2Bool[v2[i]] = 1;
        }

        Console.Write("Intersectia celor doi vectori este: ");
        for(int i = 0;i<v1Bool.Length;i++)
        {
            if (v1Bool[i] == 1 && v2Bool[i]==1)
                Console.Write(i+" ");
        }
        Console.WriteLine();

        Console.Write("Reuniunea celor doi vectori este: ");
        for (int i = 0; i < Math.Max(v1Bool.Length,v2Bool.Length); i++)
        {
            if (i<v1Bool.Length&&v1Bool[i] == 1)
                Console.Write(i + " ");
            else if (i < v2Bool.Length && v2Bool[i]==1) 
            {
                Console.Write(i + " ");
            }
        }

        Console.WriteLine() ;
        Console.Write("v1-v2 este: ");
        for (int i = 0; i < v1Bool.Length; i++)
        {
            if (i<v2Bool.Length&&v1Bool[i] == 1 && v2Bool[i] == 0)
                Console.Write(i + " ");
            else if (i>=v2Bool.Length&&v1Bool[i] == 1)
                Console.Write(i + " ");
        }
        Console.WriteLine();

        Console.Write("v2-v1 este: ");
        for (int i = 0; i < v2Bool.Length; i++)
        {
            if (i< v1Bool.Length && v1Bool[i] == 0 && v2Bool[i] == 1)
                Console.Write(i + " ");
            else if (i>=v1Bool.Length&&v2Bool[i]==1)
                Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    private static void Problema25()
    {
        Console.Write("Introduceti primul vector: ");
        int[] v1 = GetInputVector();
        Console.Write("Introduceti al doilea vector: ");
        int[] v2 = GetInputVector();
        int[] v3 = new int[v1.Length + v2.Length];
        int i = 0; int j = 0;int k = 0;
        while (i < v1.Length && j < v2.Length) 
        {
            if (v1[i] > v2[j]) 
            {
                v3[k] = v2[j];
                j++;k++;
            }
            else 
            {
                v3[k] = v1[i];
                i++;
                k++;
            }
        }
        
        if(i<v1.Length)
        {
            while (i < v1.Length)
            {
                v3[k] = v1[i];
                i++;
                k++;
            }
        }
        else if(j<v2.Length) 
        {
            while (j < v2.Length)
            {
                v3[k] = v2[j];
                j++; k++;
            }
        }
        Console.Write("Vectorul interclasat este: ");
        ShowTheArray(v3);
    }

    private static void Problema26()
    {
        Console.WriteLine("Introduceti primul numar natural mare fara alte simboluri in afara de cifre.");
        string numar1 = Console.ReadLine();
        Console.WriteLine("Introduceti al doilea numar natural mare fara alte simboluri in afara de cifre.");
        string numar2 = Console.ReadLine();
        
        string adunare = AdunareDouaNumereMari(numar1,numar2);
        string scadere = ScadereDouaNumereMari(numar1, numar2);
        string inmultire = InmultireDouaNumereMari(numar1, numar2);

        Console.WriteLine("Adunarea numerelor: " + adunare);
        Console.WriteLine("Scaderea numerelor: " + scadere);
        Console.WriteLine("Inmultirea numerelor: "+ inmultire);
        
        
    }
    private static void Problema27()
    {
        Console.WriteLine("Introduceti un vector de numere: ");
        int[] v = GetInputVector();
        Console.Write("Introduceti indexul dorit: ");
        int k = GetInputInt();
        int max = int.MinValue;
        for(int i = 0;i< v.Length;i++) { if (v[i]> max) max = v[i]; }
        int[] vFrecventa = new int[max+1];
        for(int i = 0; i < v.Length; i++) { vFrecventa[v[i]]++; }
        int aux = -1;
        int l = 0;
        while(l< vFrecventa.Length&&aux<k)
        {
            for(int j = 0; j < vFrecventa[l];j++)
            {
                aux++;
                if (aux == k) { Console.Write($"{l}"); break; }
            }
            l++;
        }

    }

    private static void Problema28() 
    {
        Console.WriteLine("Introduceti un vector de numere pe care sa se aplice QuickSort: ");

        int[] v = GetInputVector();
        QuickSort(v,0,v.Length-1);
        ShowTheArray(v);
    }

    private static void Problema29() 
    {
        Console.WriteLine("Introduceti un vector de numere pe care sa se aplice MergeSort: ");

        int[] v = GetInputVector();
        MergeSort(v,0,v.Length-1);
        ShowTheArray(v);
    }

    private static void Problema30() 
    {
        Console.Write("Introduceti vectorul de numere: ");
        int[] E = GetInputVector();
        Console.WriteLine();
        Console.Write("Introduceti vectorul de pondere: ");
        int[] W = GetInputVector();

        bool sorted;
        do
        {
            sorted = true;
            for (int i = 0; i < E.Length - 1; i++)
            {
                if (E[i] > E[i + 1])
                {
                    (E[i], E[i + 1]) = (E[i + 1], E[i]);
                    (W[i], W[i + 1]) = (W[i + 1], W[i]);
                    sorted = false;
                }
                else if (E[i] == E[i + 1]&& W[i] < W[i + 1])
                {
                    (E[i], E[i + 1]) = (E[i + 1], E[i]);
                    (W[i], W[i + 1]) = (W[i + 1], W[i]);
                    sorted = false;
                }
            }
        }
        while(sorted==false);
        ShowTheArray(E);
        Console.WriteLine();
        ShowTheArray(W);
    }
    private static void Problema31()
    {
        Console.Write("Introdu vectorul pe care se cauta elementul majoritate: ");
        int[] v = GetInputVector();
        int majoritate = 0;
        int elementMajoritate=-1;
        int aux = 1;
        MergeSort(v,0,v.Length-1);
        for(int i = 0;i<v.Length-1;i++) 
        {
            if (v[i] == v[i+1])
            {
                aux++;
            }
            else if (aux > majoritate)
            {
                majoritate = aux;
                elementMajoritate= v[i];
                aux = 1;
            }
        }
        if(majoritate>v.Length/2)
        {
            Console.WriteLine(elementMajoritate);
        }
        else Console.WriteLine("<nu exista>");
    }
    #endregion
    #endregion
}