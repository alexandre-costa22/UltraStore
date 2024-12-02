using System.ComponentModel;

namespace LvlUp.Enums
{
    public enum Rating
    {
        [Description("Everyone: For all ages")]
        E = 1,      // Everyone: Para todos os públicos

        [Description("Teen: For ages 13-17")]
        T = 2,      // Teen: Para adolescentes (13-17 anos)

        [Description("Mature: For ages 17 and older")]
        M = 3,      // Mature: Para maiores de 17 anos

        [Description("Adults Only: For 18 and older")]
        AO = 4      // Adults Only: Para maiores de 18 anos
    }
}
