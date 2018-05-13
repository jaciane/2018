using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum ValuePermissionEnum
    {
        [Description("Inserir")]
        INSERT = 0,
        [Description("Atualizar")]
        UPDATE = 1,
        [Description("Imprimir")]
        PRINT = 2,
        [Description("Consultar")]
        CONSULT = 3,
        [Description("Desativar")]
        DELETE = 4,
        [Description("Gerar")]
        GENERATE = 5,
        [Description("Validar")]
        VALIDATE = 6,
        [Description("Alterar")]
        CHANGE = 7,
        [Description("Configurar")]
        CONFIGURE = 8
    }
}
