using System.ComponentModel;

namespace LvlUp.Enums
{
    public enum DeveloperType
    {
        [Description("Estúdios independentes")]
        Indie,   // Estúdios independentes

        [Description("Grandes estúdios com grandes orçamentos")]
        AAA,     // Grandes estúdios com grandes orçamentos

        [Description("Estúdios de médio porte")]
        AA,      // Estúdios de médio porte

        [Description("Estúdios independentes que também publicam seus próprios jogos")]
        IndiePublisher // Estúdios independentes que também publicam seus próprios jogos
    }
}
