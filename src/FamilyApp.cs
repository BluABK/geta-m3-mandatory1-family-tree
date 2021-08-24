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
            string help = "Help!";
            
            return help;
        }

        public string GetCommandError(string command)
        {
            return $"Ugyldig kommando (\"{command}\")! Gyldige kommandoer er: \"hjelp\", \"liste\" og \"vis\".";
        }

        public string HandleCommand(string command)
        {
            string[] arguments = command.Split(' ');

            // Check if the first argument is a valid command, and handle accordingly.
            if (arguments[0] == "hjelp") return GetHelp();
            if (arguments[0] == "liste") return GetPersonsList();
            if (arguments[0] == "vis" && arguments.Length > 1) return GetPersonById(arguments[1]);

            return GetCommandError(command);
        }

        private string GetPersonById(string idString)
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

        private string GetPersonsList()
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
