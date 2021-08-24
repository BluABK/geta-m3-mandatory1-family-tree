# GET Academy Module 3 Mandatory Assignment 1: Family Tree

## Task description

Du skal lage et enkelt slektstre-program. Det skal v�re en konsollapplikasjon, og programmet skal kunne gj�re disse kommandoene: 

`hjelp`    => viser en hjelpetekst som forklarer alle kommandoene
`liste`    => lister alle personer med id, fornavn, f�dsels�r, d�ds�r og navn og id p� mor og far om det finnes registrert. 
`vis <id>` => viser en bestemt person med mor, far og barn (og id for disse, slik at man lett kan vise en av dem)

Videre i denne teksten beskrives hva du skal gj�re skritt for skritt, og du f�r ferdige unit tester til � sjekke at du har gjort det riktig. 

Lag klassen Person. En person skal ha fornavn, etternavn, f�dsels�r og d�ds�r. Alle feltene er frivillige. For eksempel skal du kunne legge inn en person selv om du ikke vet f�dsels�r.

Klassen skal ha en metode GetDescription(). Testen under viser hva den metoden skal returnere om alle feltene er fylt ut. Lag et unit test prosjekt og legg til en klasse PersonTest, hvor du legger testene fra oppgaveteksten, men bare testene som tester klassen Person. 
```cs
public void TestAllFields()
{
    var p = new Person
    {
        Id = 17,
        FirstName = "Ola",
        LastName = "Nordmann",
        BirthYear = 2000,
        DeathYear = 3000,
        Father = new Person() { Id = 23, FirstName = "Per" },
        Mother = new Person() { Id = 29, FirstName = "Lise" },
    };

    var actualDescription = p.GetDescription();
    var expectedDescription = "Ola Nordmann (Id=17) F�dt: 2000 D�d: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

    Assert.AreEqual(expectedDescription, actualDescription);
}
```
Hvis ingen av feltene er fylt ut, skal den samme metoden returnere dette:
```cs
public void TestNoFields()
{
    var p = new Person
    {
        Id = 1,
    };

    var actualDescription = p.GetDescription();
    var expectedDescription = "(Id=1)";

    Assert.AreEqual(expectedDescription, actualDescription);
}
```
Lag selv en test til hvor noen felt (i tillegg til Id) er satt men ikke alle. 

Lag s� klassen FamilyApp. N�r du er ferdig med denne klassen, skal du kunne legge koden under inn i Program - og applikasjonen skal v�re ferdig:
```cs
class Program
{
    static void Main(string[] args)
    {
        var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
        var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
        var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
        var metteMarit = new Person { Id = 4, FirstName = "Mette-Marit", BirthYear = 1973 };
        var marius = new Person { Id = 5, FirstName = "Marius", LastName = "Borg H�iby", BirthYear = 1997 };
        var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
        var sonja = new Person { Id = 7, FirstName = "Sonja", BirthYear = 1937 };
        var olav = new Person { Id = 8, FirstName = "Olav", BirthYear = 1903 };

        sverreMagnus.Father = haakon;
        sverreMagnus.Mother = metteMarit;
        ingridAlexandra.Father = haakon;
        ingridAlexandra.Mother = metteMarit;
        marius.Mother = metteMarit;
        haakon.Father = harald;
        haakon.Mother = sonja;
        harald.Father = olav;

        var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon,
            metteMarit, marius, harald, sonja, olav);
        Console.WriteLine(app.WelcomeMessage);
        while (true)
        {
            Console.Write(app.CommandPrompt);
            var command = Console.ReadLine();
            var response = app.HandleCommand(command);
            Console.WriteLine(response);
        }
    }
```
Implementer klassen FamilyApp slik at testen under lykkes. Lag en ny testklasse FamilyAppTest og legg testen der. Gitt kommandoen vis 3, skal metoden HandleCommand finne frem personen med id=3 og printe ut resultatet av et kall p� metoden GetDescription() p� denne personen. I tillegg skal metoden s�ke gjennom listen over alle personer og sjekke om det er noen som har denne personen som far eller mor. I s� fall skal disse listes ut under overskriften "Barn". 
```cs
public void Test()
{
    var sverreMagnus = new Person { Id = 1, FirstName = "Sverre Magnus", BirthYear = 2005 };
    var ingridAlexandra = new Person { Id = 2, FirstName = "Ingrid Alexandra", BirthYear = 2004 };
    var haakon = new Person { Id = 3, FirstName = "Haakon Magnus", BirthYear = 1973 };
    var harald = new Person { Id = 6, FirstName = "Harald", BirthYear = 1937 };
    sverreMagnus.Father = haakon;
    ingridAlexandra.Father = haakon;
    haakon.Father = harald;

    var app = new FamilyApp(sverreMagnus, ingridAlexandra, haakon);
    var actualResponse = app.HandleCommand("vis 3");
    var expectedResponse = "Haakon Magnus (Id=3) F�dt: 1973 Far: Harald (Id=6)\n"
           + "  Barn:\n"
           + "    Sverre Magnus (Id=1) F�dt: 2005\n"
           + "    Ingrid Alexandra (Id=2) F�dt: 2004\n";
    Assert.AreEqual(expectedResponse, actualResponse);
}
```
For � kunne sende med ingen, �n eller flere personer i constructoren, kan du gj�re slik:
```cs
public FamilyApp(params Person[] people)
{
    _people = new List<Person>(people);
}
```
Lag en test som sjekker at om en person ikke har noen barn, s� listes det ikke opp noen personer som barn - og overskriften "Barn" vises heller ikke. S�rg s� for at testen lykkes.