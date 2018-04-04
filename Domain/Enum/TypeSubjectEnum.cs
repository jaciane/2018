using System.ComponentModel;

namespace Domain.Enum
{
    public enum TypeSubjectEnum
    {
        [Description("[Petrobras-SIS] Foi disponibilizada uma nova norma")]
        NEWWELDINGSTANDARD = 1,

        [Description("[Petrobras-SIS] Foi disponibilizada um novo processo de soldagem")]
        NEWWELDINGPROCESS = 2,

        [Description("[Petrobras-SIS] Foi disponibilizada uma nova unidade de medida")]
        NEWUNIT = 3,

        [Description("[Petrobras-SIS] Foi disponibilizado um novo RQPS")]
        NEWPQR = 4,

        [Description("[Petrobras-SIS] Foi disponibilizado uma nova EPS")]
        NEWWPS = 5,

        [Description("[Petrobras-SIS] Registro de novo usuário")]
        NEWUSER = 6,

        [Description("[Petrobras-SIS] Redefinir senha")]
        FORGOTPASSWORD = 7,

        [Description("[Petrobras-SIS] Foi criado um novo RQPS")]
        NEWPQRCOMPANY = 8,

        [Description("[Petrobras-SIS] Foi criado uma nova EPS")]
        NEWWPSCOMPANY = 9,
    }
}
