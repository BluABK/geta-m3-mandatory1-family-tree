using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    public class FamilyApp
    {
        public string WelcomeMessage = $"Velkommen til slektstre-programmet!\n\n{GetHelp()}";
        public string CommandPrompt = ">: ";
        private Person[] people;

        public FamilyApp(params Person[] people)
        {
            this.people = people;
        }

        public static string GetHelp()
        {
            return "Gyldige kommandoer er:" + Environment.NewLine
                 + "  - hjelp    - Vis denne menyen." + Environment.NewLine
                 + "  - liste    - Vis liste over alle personer." + Environment.NewLine
                 + "  - vis <id> - Vis person med gitt ID (int)." + Environment.NewLine;
        }

        public string GetCommandError(string command)
        {
            return $"Ugyldig kommando (\"{command}\")! Gyldige kommandoer er: \"hjelp\", \"liste\" og \"vis\".";
        }

        public string HandleCommand(string command)
        {
            string[] arguments = command.Split(' ');

            // Check if the first argument is a valid command, and handle accordingly.
            if (arguments[0].ToLower() == "hjelp") return GetHelp();
            if (arguments[0].ToLower() == "liste") return GetPeopleDescriptions();
            if (arguments[0].ToLower() == "vis" && arguments.Length > 1) return GetDescriptionByPersonId(arguments[1]);

            return GetCommandError(command);
        }

        private string GetDescriptionByPersonId(string idString)
        {
            // Try to parse id string as int, if successful int id is initialized with its value, if not return error msg.
            if (!Int32.TryParse(idString, out int id)) return $"Ugyldig ID (\"{idString}\")!";

            foreach (Person person in people)
            {
                // If ID match is found, return its description.
                if (person.Id == id)
                {
                    // Person's description.
                    string description = person.GetDescription();

                    // Children, if any.
                    List<Person> children = GetChildrenByParentId(person.Id);

                    if (children.Count > 0)
                    {
                        description += $"\n  Barn:\n";

                        for (int i = 0; i < children.Count; i++) {
                            description += $"    {children[i].GetDescription(showParents: false)}\n";
                        }
                    }
                    
                    return description;
                }
            }

            // If we got here, the search failed. Return error msg.
            return $"Fant ingen person med ID {id}!";
        }

        public List<Person> GetChildrenByParentId(int parentId)
        {
            List<Person> children = new();

            foreach (Person p in people)
            {
                if (p.HasParentWithId(parentId)) children.Add(p);
            }

            return children;
        }

        private string GetPeopleDescriptions()
        {
            string personsDescriptions = string.Empty;

            foreach (Person p in people)
            {
                personsDescriptions += p.GetDescription() + Environment.NewLine;
            }

            return personsDescriptions;
        }
    }
}
