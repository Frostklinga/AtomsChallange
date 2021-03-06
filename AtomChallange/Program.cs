string[] atoms = new string[]
{
"1","H","Hydrogen","1,008",
"2","He","Helium","4,003",
"3","Li","Lithium","6,941",
"4","Be","Beryllium","9,012",
"5","B","Boron","10,811",
"6","C","Carbon","12,011",
"7","N","Nitrogen","14,007",
"8","O","Oxygen","15,999",
"9","F","Fluorine","18,998",
"10","Ne","Neon","20,180",
"11","Na","Sodium","22,990",
"12","Mg","Magnesium","24,305",
"13","Al","Aluminum","26,982",
"14","Si","Silicon","28,086",
"15","P","Phosphorus","30,974",
"16","S","Sulfur","32,065",
"17","Cl","Chlorine","35,453",
"18","Ar","Argon","39,948",
"19","K","Potassium","39,098",
"20","Ca","Calcium","40,078",
"21","Sc","Scandium","44,956",
"22","Ti","Titanium","47,867",
"23","V","Vanadium","50,942",
"24","Cr","Chromium","51,996",
"25","Mn","Manganese","54,938",
"26","Fe","Iron","55,845",
"27","Co","Cobalt","58,933",
"28","Ni","Nickel","58,693",
"29","Cu","Copper","63,546",
"30","Zn","Zinc","65,390",
"31","Ga","Gallium","69,723",
"32","Ge","Germanium","72,640",
"33","As","Arsenic","74,922",
"34","Se","Selenium","78,960",
"35","Br","Bromine","79,904",
"36","Kr","Krypton","83,800",
"37","Rb","Rubidium","85,468",
"38","Sr","Strontium","87,620",
"39","Y","Yttrium","88,906",
"40","Zr","Zirconium","91,224",
"41","Nb","Niobium","92,906",
"42","Mo","Molybdenum","95,940",
"43","Tc","Technetium","98,000",
"44","Ru","Ruthenium","101,070",
"45","Rh","Rhodium","102,906",
"46","Pd","Palladium","106,420",
"47","Ag","Silver","107,868",
"48","Cd","Cadmium","112,411",
"49","In","Indium","114,818",
"50","Sn","Tin","118,710",
"51","Sb","Antimony","121,760",
"52","Te","Tellurium","127,600",
"53","I","Iodine","126,905",
"54","Xe","Xenon","131,293",
"55","Cs","Cesium","132,906",
"56","Ba","Barium","137,327",
"57","La","Lanthanum","138,906",
"58","Ce","Cerium","140,116",
"59","Pr","Praseodymium","140,908",
"60","Nd","Neodymium","144,240",
"61","Pm","Promethium","145,000",
"62","Sm","Samarium","150,360",
"63","Eu","Europium","151,964",
"64","Gd","Gadolinium","157,250",
"65","Tb","Terbium","158,925",
"66","Dy","Dysprosium","162,500",
"67","Ho","Holmium","164,930",
"68","Er","Erbium","167,259",
"69","Tm","Thulium","168,934",
"70","Yb","Ytterbium","173,040",
"71","Lu","Lutetium","174,967",
"72","Hf","Hafnium","178,490",
"73","Ta","Tantalum","180,948",
"74","W","Tungsten","183,840",
"75","Re","Rhenium","186,207",
"76","Os","Osmium","190,230",
"77","Ir","Iridium","192,217",
"78","Pt","Platinum","195,078",
"79","Au","Gold","196,967",
"80","Hg","Mercury","200,590",
"81","Tl","Thallium","204,383",
"82","Pb","Lead","207,200",
"83","Bi","Bismuth","208,980",
"84","Po","Polonium","209,000",
"85","At","Astatine","210,000",
"86","Rn","Radon","222,000",
"87","Fr","Francium","223,000",
"88","Ra","Radium","226,000",
"89","Ac","Actinium","227,000",
"90","Th","Thorium","232,038",
"91","Pa","Protactinium","231,036",
"92","U","Uranium","238,029",
"93","Np","Neptunium","237,000",
"94","Pu","Plutonium","244,000",
"95","Am","Americium","243,000",
"96","Cm","Curium","247,000",
"97","Bk","Berkelium","247,000",
"98","Cf","Californium","251,000",
"99","Es","Einsteinium","252,000",
"100","Fm","Fermium","257,000",
"101","Md","Mendelevium","258,000",
"102","No","Nobelium","259,000",
"103","Lr","Lawrencium","262,000",
"104","Rf","Rutherfordium","261,000",
"105","Db","Dubnium","262,000",
"106","Sg","Seaborgium","266,000",
"107","Bh","Bohrium","264,000",
"108","Hs","Hassium","277,000",
"109","Mt","Meitnerium","268,000"
};

List<Atom> ListOfAtoms = new List<Atom>();
for (int i = 0; i < atoms.Length; i=i+4)
{
    var foo = Convert.ToDecimal(atoms[3]);
    ListOfAtoms.Add(new Atom
    {
        Number = Convert.ToInt32(atoms[i]),
        Symbol = atoms[i + 1],
        Name = atoms[i + 2],
        Weight = Convert.ToDecimal(atoms[i + 3])
    });
}
string input = "";
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
}

void GuessTheAtomSymbol()
{
    int atomNumber = GetRandomAtomNumber();
    Console.WriteLine("Which atombeteckning has atomnumber: "+atomNumber);
    var atomSymbol = ListOfAtoms.Find(x => x.Number == atomNumber).Symbol.ToLower();
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
    Console.WriteLine("Which atom has atomnumber " + atom.Number + ": ");
    var answer = Console.ReadLine().ToLower();
    if(answer == atom.Name.ToLower())
    {
        Console.WriteLine("Thats correct");
        return;
    }
    Console.WriteLine("Incorrect, the correct answer is: " + atom.Name);
}
void GuessAtomWeight()
{
    var atom = GetRandomAtom();
    Console.WriteLine("Guess the atom weight of "+atom.Name);
    var answer = Console.ReadLine();
    if(answer == atom.Weight.ToString())
    {
        Console.WriteLine("Thats correct");
        return;
    }
    Console.WriteLine("Incorrect. The correct answer is "+atom.Weight.ToString());
}
int GetRandomAtomNumber() =>
    new Random().Next() % 110;

Atom GetRandomAtom() =>
    ListOfAtoms.Find(x => x.Number == (new Random().Next() % 110));
public class Atom
{
    public int Number { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public decimal Weight { get; set; }
}
