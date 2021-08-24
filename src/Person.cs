using System.Collections.Generic;

namespace FamilyTree
{
    public class Person
    {
        private const int IdUnset = -1;
        private const int YearUnset = -1;
        private const string NameUnset = "";

        public int Id = IdUnset;
        public string FirstName = NameUnset;
        public string LastName = NameUnset;
        public int BirthYear = YearUnset;
        public int DeathYear = YearUnset;
        public Person Mother = null;
        public Person Father = null;

        public Person()
        {
            // Empty constructor.
            // Used when member values are set directly upon instantiation.
        }

        public string GetBriefDescription()
        {
            List<string> descriptionItems = new();

            // Construct short description
            if (FirstName != NameUnset) descriptionItems.Add(FirstName);
            if (Id != IdUnset)          descriptionItems.Add($"(Id={Id})");

            return string.Join(' ', descriptionItems);
        }

        public string GetDescription()
        {
            List<string> descriptionItems = new();

            // Construct description:
            // 1. Populate list of possible description items.
            if (FirstName != NameUnset) descriptionItems.Add(FirstName);
            if (LastName != NameUnset)  descriptionItems.Add(LastName);
            if (Id != IdUnset)          descriptionItems.Add($"(Id={Id})");
            if (BirthYear != YearUnset) descriptionItems.Add($"Født: {BirthYear}");
            if (DeathYear != YearUnset) descriptionItems.Add($"Død: {DeathYear}");
            if (Father != null)         descriptionItems.Add($"Far: {Father.GetBriefDescription()}");
            if (Mother != null)         descriptionItems.Add($"Mor: {Mother.GetBriefDescription()}");

            // 2. Construct and return description string based on available description items.
            return string.Join(' ', descriptionItems);
        }
    }
}
