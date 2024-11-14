using BuberDinner.Application.Menus.Commands.CreateMenu;
using Constants = BuberDinner.Application.UnitTests.TestUtils.Constants.Constants;

namespace BuberDinner.Application.UnitTests.Menus.Commands.TestUtils;

public static class CreateMenuCommandUtils
{
    public static CreateMenuCommand CreateCommand(
        List<MenuSectionCommand>? sections = null) =>
        new(
            Constants.Host.Id.Value,
            Constants.Menu.c_Name,
            Constants.Menu.c_Description,
            sections ?? CreateSectionsCommand());

    public static List<MenuSectionCommand> CreateSectionsCommand(
        int sectionCount = 1,
        List<MenuItemCommand>? items = null) =>
        Enumerable.Range(0, sectionCount)
            .Select(index => new MenuSectionCommand(
                Constants.Menu.SectionNameFromIndex(index),
                Constants.Menu.SectionDescriptionFromIndex(index),
                items ?? CreateItemsCommand()))
            .ToList();

    public static List<MenuItemCommand> CreateItemsCommand(int itemCount = 1) =>
        Enumerable.Range(0, itemCount)
            .Select(index => new MenuItemCommand(
                Constants.Menu.ItemNameFromIndex(index),
                Constants.Menu.ItemDescriptionFromIndex(index)))
            .ToList();
}