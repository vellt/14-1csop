```c#
// éves átlaghőmérséklet
int honap = 1;
int osszhomerseklet = 0;
while (honap!=13)
{
	Console.Write($"{honap}. honap hőmérséklete: ");
	int homerseklet = Convert.ToInt32(Console.ReadLine());
	osszhomerseklet += homerseklet;
	//osszhomerseklet =osszhomerseklet+ homerseklet;
	honap++;
}
double atlagHom = osszhomerseklet / 12.0;
Console.WriteLine($"Az éves átlaghőmérséklet: {atlagHom:0.00}");

Random random = new Random();
int i = 1;
int amennyiPozitivvan = 0;
int amennyiParos = 0;
int amennyiParatlan = 0;
while (i!=41)
{
	int szam = random.Next(201)-100;
	Console.Write($"{szam} ");
	if (i % 8 == 0)
	{
		Console.WriteLine();
	}
	if (i > 0) amennyiPozitivvan++;
	if (i % 2 == 0) amennyiParos++;
	else amennyiParatlan++;
	i++;
}

// bekért szám faktoriálisa
int bekertSzam = Convert.ToInt32(Console.ReadLine());
int faktorialis = 1;
while (bekertSzam!=1)
{
	faktorialis *= bekertSzam;
	bekertSzam--;
}
Console.WriteLine($"faktoriálisa: {faktorialis}");


Random r = new Random();
int gep = r.Next(51)+50;
int felh = 0;
int lepesek = 0;
while (gep!=felh)
{
	felh = Convert.ToInt32(Console.ReadLine());
	lepesek++;
	if (gep > felh)
	{
		Console.WriteLine("nagyobbra gondoltam");
	}else if (gep < felh)
	{
		Console.WriteLine("kisebbre gondoltam");
	}
}
Console.WriteLine($"eltaláltad. {lepesek}db lépéssel");
Console.ReadKey();
```