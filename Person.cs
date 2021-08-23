namespace FamilyTree
{
    public class Person
    {
        private const int YearUnset = -1;
        private const string NameUnset = "";

        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Mother;
        public Person Father;

        public Person()
        {
            // Empty constructor.
            // Used when member values are set directly upon instantiation.
        }

        public Person(int id, string firstName = NameUnset, string lastName = NameUnset, int birthYear = YearUnset, int deathYear = YearUnset, Person father = null, Person mother = null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthYear = birthYear;
            DeathYear = deathYear;
            Mother = mother;
            Father = father;

        }

        public string GetDescription()
        {
            string description = "";

            return description;
        }
    }
}
