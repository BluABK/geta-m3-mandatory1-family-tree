using System.Collections.Generic;

namespace FamilyTree
{
    public class Person
    {
        public const int IdUnset = -1;
        public const int YearUnset = -1;
        public const string NameUnset = "";

        public int Id = IdUnset;
        public string FirstName = NameUnset;
        public string LastName = NameUnset;
        public int BirthYear = YearUnset;
        public int DeathYear = YearUnset;
        public Person Mother = null;
        public Person Father = null;

        public bool HasMother()
        {
            return Mother != null;
        }

        public bool HasFather()
        {
            return Father != null;
        }

        public bool HasParentWithId(int id)
        {
            // Determine IDs pre-emptively, in case a parent is missing and would thus be null.
            int fatherId = HasFather() ? Father.Id : IdUnset;
            int motherId = HasMother() ? Mother.Id : IdUnset;

            return (fatherId == id || motherId == id);
        }

        public string GetDescription(bool showFirstName = true, bool showLastName = true, bool showId = true, bool showBirthYear = true, bool showDeathYear = true, bool showParents = true)
        {
            List<string> descriptionItems = new();

            // Construct description:
            // 1. Populate list of possible description items.
            if (showFirstName   && FirstName != NameUnset) descriptionItems.Add(FirstName);
            if (showLastName    && LastName != NameUnset)  descriptionItems.Add(LastName);
            if (showId          && Id != IdUnset)          descriptionItems.Add($"(Id={Id})");
            if (showBirthYear   && BirthYear != YearUnset) descriptionItems.Add($"Født: {BirthYear}");
            if (showDeathYear   && DeathYear != YearUnset) descriptionItems.Add($"Død: {DeathYear}");
            if (showParents)
            {
                if (Father != null) descriptionItems.Add($"Far: {Father.GetDescription(showLastName: false, showBirthYear: false, showDeathYear: false, showParents: false)}");
                if (Mother != null) descriptionItems.Add($"Mor: {Mother.GetDescription(showLastName: false, showBirthYear: false, showDeathYear: false, showParents: false)}");
            }

            // 2. Construct and return description string based on available description items.
            return string.Join(' ', descriptionItems);
        }
    }
}
