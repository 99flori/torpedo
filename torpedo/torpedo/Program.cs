using System;
class MainClass
{
	//H,T,S, ,V
	//tabla meret legalabb 8, max 26
	static void kiirtabla(string[,] tabla, int meret)
	{
		for (int i = 0; i < meret; i++) {
			Console.Write("{0,2} ", i + 1);
			for (int j = 0; j < meret; j++) {
				if (tabla[i, j] == null)
					Console.Write(" ");
				Console.Write(tabla[i, j] + " ");
			}
			Console.WriteLine();
		}
		Console.Write("  ");
		for (int i = 0; i < meret; i++)
			Console.Write(" " + (char)(65 + i));
		Console.WriteLine();
	}

	static string[,] gep;
	public static void Main(string[] args)
	{
		string[,] sajat;
		int meret;
		while (true) {
			try {
				Console.WriteLine("Kérem írja be a tábla meretét [8,26] tartományban");
				meret = int.Parse(Console.ReadLine());
				if (meret < 8 || meret > 26)
					Console.WriteLine("Hibás méret");
				else
					break;
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
		sajat = new string[meret, meret];
		for (int i = 1; i < meret; i++) {
			kiirtabla(sajat, meret);
			while (true) {
				try {
					Console.WriteLine("Írja be hogy hol kezdődik a(z) {0} méretű hajó milyen irányú (X vízszintes, Y függőleges)", i);
					Console.WriteLine("Példa: A 1 X");
					Console.WriteLine("Hajók nem lehetnek egymás mellett és felett");
					string[] input = Console.ReadLine().Split(' ');
					int x = int.Parse(input[1]) - 1,
						y = Convert.ToChar(input[0]) - 65;

					if (y < 0 || y >= meret)
						throw new Exception("Hibás bemenet");
					if (x != 0)
						if (sajat[x - 1, y] == "H")
							throw new Exception("Hibás elhelyezés");
					if (y != 0)
						if (sajat[x, y - 1] == "H")
							throw new Exception("Hibás elhelyezés");
					sajat[x, y] = "H";
					if (input[2] == "X" || input[2] == "x") {
						for (int j = 1; j < i; j++) {
							if (y != 0 && sajat[x + j, y - 1] != null)
								throw new Exception("Hibás elhelyezés");
							if (y != meret - 1 && sajat[x + j, y + 1] != null)
								throw new Exception("Hibás elhelyezés");
							if (sajat[x, y + j] == null)
								sajat[x, y + j] = "H";
							else
								throw new Exception("Hibás elhelyezés");
						}
						break;
					} else if (input[2] == "Y" || input[2] == "y") {
						for (int j = 1; j < i; j++) {
							if (x != 0 && sajat[x - 1, y + j] != null)
								throw new Exception("Hibás elhelyezés");
							if (y != meret - 1 && sajat[x - 1, y + j] != null)
								throw new Exception("Hibás elhelyezés");
							if (sajat[x, y + j] == null)
								sajat[x, y + j] = "H";
							else
								throw new Exception("Hibás elhelyezés");
						}
					} else
						throw new Exception("Hibás bemenet");
					break;
				} catch (Exception ex) {
					Console.WriteLine(ex.Message);
				}
			}
		}
		Console.Read();
	}
}
