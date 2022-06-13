using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace FikirEdin.Localization
{
    public static class FikirEdinLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(FikirEdinConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FikirEdinLocalizationConfigurer).GetAssembly(),
                        "FikirEdin.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
