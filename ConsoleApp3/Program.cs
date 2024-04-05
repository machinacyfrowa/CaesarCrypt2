//funkcja realizująca przesunięcie znaku (szyfr Cezara)
//funkcja zwraca char, przyjmuje jako argument char i int
char AsciiCaesar(char c, int offset)
{
    if((int)c < 65 || (int)c > 90)
    {
        //znak spoza dopuszczalnego zakresu - zwróć pusty literał znakowy (null)
        return '\0';
    }
    //popraw polskie znaki driaktryczne
    if (c == 'Ś')
        c = 'S';
    if (c == 'Ć')
        c = 'C';
    if (c == 'Ą')
        c = 'A';
    if (c == 'Ż')
        c = 'Z';
    //todo: popraw pozostałe...


    //pobierz wartość liczbową znaku
    int charAsciiCode = (int)c;
    //dodaj do niej przesunięcie
    charAsciiCode += offset;
    //jesli wyjdziemy poza zakres wielkich liter (>90)
    if (charAsciiCode > 90)
        //odejmij długość alfabetu
        charAsciiCode -= 26;
    //w druga strone
    if (charAsciiCode < 65)
        //dodaj długośc alfabetu
        charAsciiCode += 26;
    //zwróć zmodyfikowany znak
    return (char)charAsciiCode;
}

Console.WriteLine("Podaj tekst do zakodowania:");
string input = Console.ReadLine() ?? "";
string clearText = input.ToUpper();
Console.WriteLine("Podaj wartość przesunięcia:");
input = Console.ReadLine() ?? "";
int offset = int.Parse(input);
Console.WriteLine("Koduje...");
string encodedText = "";
foreach (char c in clearText)
{
    encodedText += AsciiCaesar(c, offset);
}
Console.WriteLine("Zakodowany tekst:");
Console.WriteLine(encodedText);
    
