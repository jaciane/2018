namespace Domain.Util
{
    public static class ResultMessages
    {
        public static string Success()
        {
            return "Operação concluída com sucesso.";
        }

        public static string Fail()
        {
            return "Um ou mais erros foram gerados. Verifique se os campos foram preenchidos corretamente.";
        }

        public static string Fail(string msg)
        {
            return msg;
        }

        public static string Unavailable()
        {
            return "Você não tem autorização para realizar este procedimento. Favor contactar o administrador do sistema.";
        }

        public static string Missing(string element)
        {
            return element + " não encontrado.";
        }

        public static string AplicationException()
        {
            return "Ocorreu um erro inesperado. Favor contactar o administrador do sistema.";
        }

        public static string MetalIdentifierException()
        {
            return "Não existem templates do tipo identificador cadastrados.";
        }
    }
}
