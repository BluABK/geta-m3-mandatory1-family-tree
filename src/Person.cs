namespace FamilyTree
{
    public class Person
    {
        private const int IdUnset = -1;
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

        public string GetDescription()
        {
            // Get required properties of mother and father (if null, use unset signifiers).
            int motherId = Mother != null ? Mother.Id : IdUnset;
            string motherName = Mother != null ? Mother.FirstName : NameUnset;
            int fatherId = Father != null ? Father.Id : IdUnset;
            string fatherName = Father != null ? Father.FirstName : NameUnset;

            return $"{FirstName} {LastName} (Id={Id}) Født: {BirthYear} Død: {DeathYear} Far: {fatherName} (Id={fatherId}) Mor: {motherName} (Id={motherId})";
        }
    }
}
