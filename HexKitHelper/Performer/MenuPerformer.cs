using HexKitHelper.Core;
using HexKitHelper.Entity;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HexKitHelper.Performer
{
    class MenuPerformer
    {
        public static void RUN()
        {
            MenuPerformer.initPackagesChoices();
        }

        private static void initPackagesChoices()
        {
            List<string> choices = HexStorage.PACKAGES.ConvertAll(package => "[greenyellow]" + package.Name + "[/]");
            foreach (string action in HexStorage.ACTIONS_LIST)
            {
                choices.Add("[salmon1]" + action + "[/]");
            }
            HexStorage.PACKAGES_CHOICES = choices;
        }

        public static void MakeMenu()
        {
            string userChoice = promptSingleChoice("Select an [greenyellow]Item[/] or [salmon1]Action[/]?", HexStorage.PACKAGES_CHOICES);
            HexStorage.USER_CHOICE = new Regex("(?<=\\])(.*)(?=\\[)").Matches(userChoice)[0].ToString();
        }

        private static string promptSingleChoice(string Title, List<string> Choices, string Description = "[grey](Move up and down to reveal more items)[/]", int PageSize = 8)
        {
            return AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title(Title)
                    .PageSize(PageSize)
                    .MoreChoicesText(Description)
                    .AddChoices(Choices)
                )
                .ToString();
        }
    }
}
