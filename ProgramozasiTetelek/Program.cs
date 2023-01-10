using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

namespace ProgramozasiTetelek
{
    internal class Program
    {

        /* Megjegyzés: 
         * Hogy könnyebb legyen a kódolás, minden példához generálunk egy tömböt egész számokkal 
         * Ehhez a tombGeneral függvényt fogjuk használni.
         *
         * Bemenet: 
         * elemekSzama: egész szám, hogy hány elemű legyen a tömb
         * legyenNegativSzm: a generált tömbben legyen negatív szám
         * 
         * Kimenet: 
         * a megadott elemű tömb
         */
        private static int[] tombGeneral(int elemekSzama, bool legyenNegativSzam)
        {
            Random randomGenerator = new Random();

            int[] generaltTomb = new int[elemekSzama];
            if (legyenNegativSzam)
                for (int i = 0; i < elemekSzama; i++)
                {
                    generaltTomb[i] = randomGenerator.Next(100);
                }
            else
            {
                for (int i = 0; i < elemekSzama; i++)
                {
                    generaltTomb[i] = randomGenerator.Next(100) - 50;
                }
            }

            return generaltTomb;
        }
        



        static void Main(string[] args)
        {
            /*
             * Programozási tételek
             * A programozási tételek olyan általános algoritmusok, melyekkel programozás során gyakran találkozunk.
             * Az algoritmusok általában tömbökkel foglalkoznak, legyen tehát T egy N elemű tömb(1..N)
             */
            int s;
            int[] tomb;

            /****************************************************************************************************
             * Összegzés
             * Egy tömb elemeinek összegzése
             * Könnyen átírható szorzatra vagy más műveletre
             
             * Algoritmus:
                s:= 0
                Ciklus i:= 1...N
                    s:= s + T[i]
                Ciklus vége
                Ki: s
            */

            s = 0;
            tomb = tombGeneral(10, false);

            for (int i = 0; i < tomb.Length; i++)
            {
                // aktuális elem értékének hozzáadása s-hez
                s = s + tomb[i];
            }
            Console.WriteLine("S értéke: " + s);

            /****************************************************************************************************
             * Meszámolás
             * Megszámolja, hogy a tömbben hány, adott tulajdonságú elem van
             * Például, negatív számok
             
             * Algoritmus
                s:= 0
                Ciklus i:= 1..N
                    Ha T[i]< 0 akkor s:= s + 1
                Ciklus vége
                Ki: s
             */
            s = 0;
            tomb = tombGeneral(10, true);

            for (int i = 0; i < tomb.Length; i++)
            {
                // aktuális elem vizsgálata
                if (tomb[i] < 0)
                {
                    //negatív
                    s = s + 1;
                }
            }
            Console.WriteLine("Negatív elemek száma: " + s);

            /****************************************************************************************************
             * Eldöntés
             * Az algoritmus eldönti, hogy van-e a tömbben adott tulajdonságú elem. Amint talál egyet, a ciklus leáll.­ 
             * Ha a ciklus azért állt le, mert túlléptünk a tömb utolsó, vizsgált elemén is, akkor nem volt benne keresett elem
             * Pl.: Van - e 50 az elemek között
            
             * Algoritmus
                i:= 1
                Ciklus amíg i <= N és T[i]<> 50
                    i:= i + 1
                Ciklus vége
                Ha i<= N akkor
                    ki: "volt 50"
             */
            s = 0;
            tomb = tombGeneral(20, false);
            int i = 1;
            while (i < tomb.Length && tomb[i] != 50)
            {
                i = i + 1;
            }
            if (i <= tomb.Length)
            {
                Console.WriteLine("Megtaláltam a keresett elemet!");
            }

            /****************************************************************************************************
             * Kiválasztás
             * Az algoritmus megadja, hogy a tömbben egy bizonyos elem hol(hányadik helyen) van.
             * >>> Csak akkor működik, ha biztosan van ilyen elem <<<
             
             * Algoritmus
                i:= 1
                Ciklus amíg T[i] <> 50
                    i:= i + 1
                Ciklus vége
                ki: i
             */



            /****************************************************************************************************
             * Keresés
             * Az előzőnél biztonságosabb algoritmus: megadja, hogy van-e olyan elem, és ha igen, hányadik. 
             * (többféle kereső algoritmus van)
            
             * Algoritmus
                i:= 1
                Ciklus amíg i <= N és T[i]<> 50
                    i:= i + 1
                Ciklus vége
                Ha i<= N akkor
                    ki: i
                különben
                    ki: -1 // bármilyen más érvénytelen index
             */


            /****************************************************************************************************
             * Kiválogatás
             * ­Ez az algoritmus egy tömb bizonyos tulajdonságú elemeit teszi egy másik tömbbe.
             * ­db változó számolja, hogy a másik tömbbe hány elem került
             * válogassuk ki a negatív számokat.­ 
             * Az eredmény a B tömbben lesz 
             * deklarációnál a B tömböt N eleműre kell választani, hacsak nem tudjuk előre, hány negatív szám van T - ben


             * Algoritmus
                db:= 0
                Ciklus i:= 1..N
                    Ha T[i]< 0 akkor
                        db:= db + 1
                        B[db]:= T[i]
                    Ha vége
                Ciklus vége
             */

            /****************************************************************************************************
             * Szétválogatás
             * Kiválogatáshoz hasonló, de a nem megfelelő elemeket is tömbbe tesszük
             */

            /****************************************************************************************************
             * Szétválogatás két tömbbe
             
             * Algoritmus
                dbb:= 0
                dbc:= 0
                Ciklus i:= 1..N
                    Ha T[i]< 0akkor
                        dbb:= dbb + 1, B[dbb]:= T[i]
                    különben
                        dbc:= dbc + 1, C[dbc]:= T[i]
                Ciklus vége
             */


            /****************************************************************************************************
             * Metszet
             * két tömb(A[1..N] és B[1..M]) azonos elemeinek kiválogatása C tömbbe
             * Az algoritmus lényege: menjünk végik A tömb elemein, és válogassuk ki azokat (kiválogatás), melyek szerepelnek B - ben(eldöntés). 
             * Visszavezethető a korábbi feladatokra
             * C maximális elemszáma N és M közül a kisebbik
             
             * Algoritmus
                db:= 0
                Ciklus i:= 1..N
                    j:= 1
                    Ciklus amíg j <= M és B[j]<> A[i]
                        j:= j + 1
                    Ciklus vége
                    Ha j<= M akkor db:= db + 1, C[db]:= A[i]
                Ciklus vége
             */





            /****************************************************************************************************
             * Unió
             * A és B tömb összes elemét C tömbbe tenni
             * Tegyük be C - be A összes elemét, majd B-ből azokat, melyek nem szerepelnek A-ban.
             * C elemszáma legfeljebb N+M.
              
             * Algoritmus 
                Ciklus i:= 1..N
                    C[i]:= A[i]
                Ciklus vége
                db:= N
                Ciklus j:= 1..M
                i:= 1
                    Ciklus amíg i <= N és B[j]<> A[i]
                    i:= i + 1
                    Ciklus vége
                    Ha i> N akkor db:= db + 1, C[db]:= B[j]
               Ciklus vége

             */



            /****************************************************************************************************
             * Maximum kiválasztás
             * T tömb maximális elemének megkeresése
            
             * Algoritmus:
                m:= 1
                Ciklus i:= 2..N
                    Ha T[i]> T[m] akkor m:= I
                Ciklus vége
                Ki: m, T[m]
                
                m: a pillanatnyilag talált legnagyobb elem helyét mutatja
            */


            /****************************************************************************************************
             * Rendezés
             * Sokféle van
             * –Különböző adatokra
             * –Különböző rendezettségre
             * –stb

            /****************************************************************************************************
             * Rendezés maximum kiválasztással
             * Az elv: kiválasztjuk a tömb legnagyobb elemét, és berakjuk a tömb végére(vagyis kicseréljük az utolsó elemmel)
             * Ezt az eljárást ismételjük a maradék tömbre
             * i változó adja meg, hogy hányadik elem fog a helyére kerülni 
             * A Csere(i, m) eljárás kicseréli a tömb i.és m. elemét
             
             * Algoritmus
                Ciklus i:= N..2
                    m:= 1
                    Ciklus j:= 2..I
                        Ha T[j]> T[m] akkor m:= j
                    Ciklus vége
                    Csere(i, m)
                Ciklus vége
             */



            /****************************************************************************************************
             * Buborékos rendezés 
             * Végigmegy a tömbön, és ha szomszédos elemeknél rossz a sorrend, megcseréli őket. 
             * Ez a csere, mint egy buborék, végighalad a tömbön, és a legnagyobb elemet biztosan a tömb végére teszi.
             * i változó ismét azt jelzi, hányadik elem kerül a helyére.
            
             * Algoritmus:
                Ciklus i:= N..2
                    Ciklus j:= 1..i - 1
                        Ha T[J]> T[J + 1] akkor Csere(j, j+1)
                    Ciklus vége
                Ciklus vége
             */

        }
    }
}