using HexKitHelper.Core;
using HexKitHelper.Entity;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace HexKitHelper.Performer
{
    class PackageConfigPerformer
    {
        static Package selectedPackage;
        static List<string> choices;
        static List<string> configs;

        public static void RUN()
        {
            selectedPackage = HexStorage.PACKAGES.Find(package => package.Name == HexStorage.USER_CHOICE);
            makeChoiceList();
            makeMenu();
            handleConfigs();
        }

        static void makeChoiceList()
        {
            choices = new List<string>();

            if (selectedPackage.CanInstall)
                choices.Add(selectedPackage.Install ? "Install? [greenyellow]Yes[/]" : "Install? [indianred1]No[/]");

            if (selectedPackage.CanPublish)
                choices.Add(selectedPackage.Publish ? "Publish? [greenyellow]Yes[/]" : "Publish? [indianred1]No[/]");

            if (selectedPackage.CanConfigure)
                choices.Add(selectedPackage.Configure ? "Configure? [greenyellow]Yes[/]" : "Configure? [indianred1]No[/]");
        }

        static void multiChoiceList(string Title, List<string> Choices, string Description = "", int PageSize = 10)
        {
            MultiSelectionPrompt<string> selectionPrompt = new MultiSelectionPrompt<string>()
                    .Title(Title)
                    .NotRequired()
                    .PageSize(PageSize)
                    .InstructionsText(Description)
                    .AddChoices(Choices);

             configs = AnsiConsole.Prompt(selectionPrompt);
        }

        static void makeMenu()
        {
            multiChoiceList(
                $"You are changing [skyblue1 underline]{selectedPackage.Name}[/] now",
                choices,
                "Selected configs will [gold1]invert[/]" +
                "\n" + "Press [skyblue1]SPACE[/] to [skyblue1]select[/] and [skyblue1]ENTER[/] to [skyblue1]apply[/]"
                );
        }

        static void handleConfigs()
        {
            foreach (var config in configs)
            {
                if (config.ToLower().StartsWith("install"))
                    selectedPackage.Install = !selectedPackage.Install;

                if (config.ToLower().StartsWith("publish"))
                    selectedPackage.Publish = !selectedPackage.Publish;

                if (config.ToLower().StartsWith("configure"))
                    selectedPackage.Configure = !selectedPackage.Configure;
            }
        }
    }
}
