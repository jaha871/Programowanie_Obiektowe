using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
/*public class Program
{

	public static void Main(string[] args)
	{





		Thread thread= new Thread(() =>
		   {
			   for (int i = 1; i <= 5; ++i)
			   {
				   Console.WriteLine("Iteration: " + i);
				   for (int j = 1; j <= 5; j++)
				   {
					   Console.WriteLine("Inside Iteration: " + j);
					   Thread.Sleep(1000);
                      
					}

				   Thread.Sleep(1000); 
			}
		   });
		thread.Start();
		thread.Join();
	}
	
		
}*/

	
	
		



// 1.3 Możemy przełączać się między wątkami i debugujemy tylko jeden na raz, oraz nazwy wątków są widoczne w debuggerze
// 2.3 Co robi metoda Thread.Sleep(1000)? Puszcza pętle co sekundę(ilość podana w nawiasie w jednosce ms), aż do jej zakończenia.
// 2.3b // Co robi metoda Thread Join()? Usypia wątek główny dopóki wątek nowo stworzony nie zostanie skończony
public class Program
{
	static HashSet<int> liczbyPierwsze = new HashSet<int>();
	public static void Main(string[] args)
	{
		Console.WriteLine("Zadanie 3:");

		Thread watek1 = new Thread(() => { Szukaj(0); });
		Thread watek2 = new Thread(() => { Szukaj(50000); });
		Thread watek3 = new Thread(() => { Szukaj(100000); });
		Thread watek4 = new Thread(() => { Szukaj(150000); });

		Stopwatch stop= Stopwatch.StartNew();

		watek1.Start();
		watek2.Start();
		watek3.Start();
		watek4.Start();
		
		watek1.Join();
		watek2.Join();
		watek3.Join();
		watek4.Join();

		stop.Stop();

		Console.WriteLine($"Czas wykonania operacji: {stop.Elapsed.TotalSeconds}");
		Console.WriteLine($"Wyliczono: {liczbyPierwsze.Count} liczb pierwszych");
	}

	static bool czyPierwsza(int liczba)
	{
		int dlugosc = 0;
		if (liczba % 2 == 0)
			return (liczba == 2);
		for (int i = 3; i <= liczba; i+= 2)  // Math.Sqrt(number) Czemu nie działa
		{
			if (liczba % i == 0)
			{
				dlugosc += 1;
			}
		}
		return dlugosc == 2;
	}

	static void Szukaj(int range)
	{
		Stopwatch stopWatch = Stopwatch.StartNew();
		for (int i = range; i <= range + 50000; ++i)
		{
			if (stopWatch.ElapsedMilliseconds > 10000)
			{
				stopWatch.Stop();
				break;
			}
			if (czyPierwsza(i))
			{
				lock (liczbyPierwsze)
				{
					liczbyPierwsze.Add(i);
				}
			}
			Thread.Yield();
		}
	}
}
