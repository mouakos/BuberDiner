namespace BuberDinner.Application.UnitTests.TestUtils.Constants;

public static partial class Constants
{
    public static class Menu
    {
        public const string c_Name = "Menu Name";
        public const string c_Description = "Menu Description";
        public const string c_SectionName = "Menu Section Name";
        public const string c_SectionDescription = "Menu Section Description";
        public const string c_ItemName = "Menu Item Name";
        public const string c_ItemDescription = "Menu Item Description";

        public static string SectionNameFromIndex(int index)
            => $"{c_SectionName} {index}";

        public static string SectionDescriptionFromIndex(int index)
            => $"{c_SectionDescription} {index}";

        public static string ItemNameFromIndex(int index)
            => $"{c_ItemName} {index}";

        public static string ItemDescriptionFromIndex(int index)
            => $"{c_ItemDescription} {index}";
    }
}