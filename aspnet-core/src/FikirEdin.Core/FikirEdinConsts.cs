using FikirEdin.Debugging;

namespace FikirEdin
{
    public class FikirEdinConsts
    {
        public const string LocalizationSourceName = "FikirEdin";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "49a48d6242f640d58731d8e6e5685c27";
    }
}
