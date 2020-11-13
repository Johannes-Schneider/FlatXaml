using System;
using System.Resources;

namespace FlatXaml.MarkupExtension
{
    public class EnumerationExtension : System.Windows.Markup.MarkupExtension
    {
        public Type Enumeration { get; set; }

        public ResourceManager Localization { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var memberNames = Enum.GetNames(Enumeration);
            var values = new string[memberNames.Length];

            for (var i = 0; i < memberNames.Length; ++i)
            {
                values[i] = Localization.GetString(memberNames[i]) ?? throw new Exception($"Unable to get the localized representation of {memberNames[i]} (type = {Enumeration.Name})!");
            }

            return values;
        }
    }
}