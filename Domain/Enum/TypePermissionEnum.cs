using System.ComponentModel;

namespace Domain.Enum
{
    public enum TypePermissionEnum
    {
        [Description("Gerenciamento de EPS")]
        WPS = 0,
        [Description("Gerenciamento de RQPS")]
        PQR = 1,
        [Description("Gerenciamento de Variáveis da Norma")]
        VARIABLE = 2,
        [Description("Gerenciamento de Normas")]
        WELDINGSTANDARD = 3,
        [Description("Auditoria")]
        AUDIT = 4,
        [Description("Gerenciamento de Unidades de Medida")]
        UNIT = 5,
        [Description("Gerenciamento de Consumíveis")]
        FILLERMETAL = 6,
        [Description("Gerenciamento de Materiais")]
        MATERIAL = 7,
        [Description("Gerenciamento de Template de EPS")]
        WPSTEMPLATE = 8,
        [Description("Gerenciamento de Template de RQPS")]
        PQRTEMPLATE = 9,
        [Description("Gerenciamento de Regras")]
        RULE = 10,
        [Description("Gerenciamento de Usuário")]
        USER = 11,
        [Description("Gerenciamento de Empresa")]
        COMPANY = 12,
        [Description("Gerenciamento de Controle de Acesso")]
        ACCESS = 13,
        [Description("Gerenciamento de Perfil de Acesso")]
        PROFILE = 14,
        [Description("Gerenciamento de Template de Consumíveis")]
        FILLERMETALTEMPLATE = 15,
        [Description("Gerenciamento de Template de Materiais")]
        MATERIALTEMPLATE = 16,
        [Description("Gerenciamento de Parágrafo da Norma")]
        PART = 17,
        [Description("Gerenciamento de Tipo da Norma")]
        WELDINGSTANDARDTYPE = 18,
        [Description("Gerenciamento de Processos de Soldagem")]
        WELDINGPROCESS = 19,

    }
}
