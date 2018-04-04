using System;

namespace Domain.Util
{
    public class Formatter
    {
        public static string RemoveFormattingOfCnpjOrCpf(string cpfOrCnpj)
        {
            return cpfOrCnpj.Replace(".", "").Replace("-", "").Replace("_", "").Replace("/", "");
        }

        public static string AddCommaAndDotInValueByVariableType(string value, int variableValueType)
        {
            if ((variableValueType == (int)Enum.VariableValueTypeEnum.NUMERICASEMDECIMAIS ||
                variableValueType == (int)Enum.VariableValueTypeEnum.NUMERICACOMDECIMAIS) && value != null && !String.IsNullOrEmpty(value.Trim()))
            {
                var valueSplited = value.Split(',');
                int valueParsed;
                if (Int32.TryParse(valueSplited[0], out valueParsed))
                {
                    string decimalPart = valueSplited.Length > 1 ? "," + valueSplited[1] : "";
                    value = String.Format("{0:n0}", valueParsed);
                    return value + decimalPart;
                }
            }
            return value;
        }

        public static string RemoveLastZeros(string value)
        {
            string number = value;
            if (number.Contains("."))
            {
                number = number.TrimEnd('0').TrimEnd('.');
            }

            return number;
        }
    }
}
