


using AtomChallange;

//var ListOfAtoms = new AtomsModel().Atoms;



string input = "";
var manager = new DataStorageManager();
var ListOfAtoms = manager.Load();
//LoadData.ParseLoadedData(ref ListOfAtoms, loadedData);
while(input != "9")
{
    Console.WriteLine("############################");
    Console.WriteLine("# Menu - The guessing game");
    Console.WriteLine("# 1. Guess the atom symbol");
    Console.WriteLine("# 2. Guess the atom number");
    Console.WriteLine("# 3. Guess the atom weight");
    Console.WriteLine("# 4. List all of the atoms");
    Console.WriteLine("# 9. Exit this program");
    Console.WriteLine("############################");
    input = Console.ReadLine();
    switch(input)
    {
        case "1":
            GuessTheAtomSymbol();
            break;
        case "2":
            GuessAtomNumber();
            break;
        case "3":
            GuessAtomWeight();
            break;
        case "4":
            //Console.WriteLine(atoms.Aggregate((a, b) => a + "\n" + b));
            Console.WriteLine("Temp");
            break;
    }
}

void GuessTheAtomSymbol()
{
    int atomNumber = GetRandomAtomNumber();
    Console.WriteLine("Which atombeteckning has atomnumber: "+atomNumber);
    var atomSymbol = ListOfAtoms.Find(x => x.number == atomNumber).symbol.ToLower();
    var answer = Console.ReadLine().ToLower();
    if (answer == atomSymbol)
    {
        Console.WriteLine("Thats correct!");
        return;
    }
    Console.WriteLine("Incorrect, the correct answer is: "+atomSymbol);
}
void GuessAtomNumber()
{
    var atom = GetRandomAtom();
    Console.WriteLine("Which atom has atomnumber " + atom.number + ": ");
    var answer = Console.ReadLine().ToLower();
    if(answer == atom.name.ToLower())
    {
        Console.WriteLine("Thats correct");
        return;
    }
    Console.WriteLine("Incorrect, the correct answer is: " + atom.name);
}
void GuessAtomWeight()
{
    var atom = GetRandomAtom();
    Console.WriteLine("Guess the atom weight of "+atom.name);
    var answer = Console.ReadLine();
    if(answer == atom.weight.ToString())
    {
        Console.WriteLine("Thats correct");
        return;
    }
    Console.WriteLine("Incorrect. The correct answer is "+atom.weight.ToString());
}
int GetRandomAtomNumber() =>
    new Random().Next() % 110;

Atom GetRandomAtom() =>
    ListOfAtoms.Find(x => x.number == (new Random().Next() % 110));

