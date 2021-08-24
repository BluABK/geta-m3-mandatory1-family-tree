using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyTree
{
    class FamilyApp
    {
        public string WelcomeMessage = "Velkommen til slektstre-programmet!";
        public string CommandPrompt = ">: ";
        private Person[] persons;

        public FamilyApp(params Person[] persons)
        {
            this.persons = persons;
        }

        public string GetHelp()
        {
            return "Gyldige kommandoer er:" + Environment.NewLine
                 + "\t- hjelp - Vis denne menyen." + Environment.NewLine
                 + "\t- liste - Vis liste over alle personer." + Environment.NewLine
                 + "\t- vis <id> - Vis person med gitt ID (int)." + Environment.NewLine;
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
            if (arguments[0].ToLower() == "liste") return GetPersonsDescription();
            if (arguments[0].ToLower() == "vis" && arguments.Length > 1) return GetPersonDescriptionById(arguments[1]);

            return GetCommandError(command);
        }

        private string GetPersonDescriptionById(string idString)
        {
            // Try to parse id string as int, if successful int id is initialized with its value, if not return error msg.
            if (!Int32.TryParse(idString, out int id)) return $"Ugyldig ID (\"{idString}\")!";

            foreach (Person p in persons)
            {
                // If ID match is found, return its description.
                if (p.Id == id) return p.GetDescription();
            }

            // If we got here, the search failed. Return error msg.
            return $"Fant ingen person med ID {id}!";
        }

        private string GetPersonsDescription()
        {
            string personsDescriptions = string.Empty;

            foreach (Person p in persons)
            {
                personsDescriptions += p.GetDescription() + Environment.NewLine;
            }

            return personsDescriptions;
        }
    }
}
