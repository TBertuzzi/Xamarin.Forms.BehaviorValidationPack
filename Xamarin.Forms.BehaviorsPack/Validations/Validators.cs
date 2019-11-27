using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Xamarin.Forms.BehaviorValidationPack
{
    public class Validators
    {
        public static bool CepValidator(string cep)
        {
            string cepRegex = @"^\d{5}-\d{3}$";

            if (string.IsNullOrEmpty(cep))
                return true;

            return (Regex.IsMatch(cep, cepRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }

        public static bool CpfValidator(string cpf)
        {
            if (string.IsNullOrEmpty(cpf)) {
                return false;
            }
            
            cpf = cpf.Replace(".", "").Replace("-", "");
            cpf = cpf.Trim();
            if (cpf.Length != 11)
                return false;
            
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        internal static bool CnpjValidator(string cnpj)
        {
            if (string.IsNullOrEmpty(Cnpj)) {
                return false;
            }

            Cnpj = Cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            Cnpj = Cnpj.Trim();
            if (Cnpj.Length != 14) {
                return false;
            }

            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            tempCnpj = Cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++) {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            }
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++) {
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            }
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return Cnpj.EndsWith(digito);
        }

        internal static bool CpfCnpjValidator(string cpfCnpj)
        {
            if (string.IsNullOrEmpty(cpfCnpj))
                return true;

            string cpfCnpjRegex = @"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})";
            return (Regex.IsMatch(cpfCnpj, cpfCnpjRegex));
        }

        public static bool EmailValidator(string email)
        {
            if (string.IsNullOrEmpty(email))
                return true;

            string emailRegex = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
         @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

            return (Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
        }

        public static bool DateValidator(DateTime date)
        {
            if(date == null)
                return true;

            DateTime value = date;
            int year = DateTime.Now.Year;
            int selyear = value.Year;
            int result = selyear - year;
            bool isValid = false;
            if (result <= 100 && result > 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool PasswordValidator(string password)
        {
            if (string.IsNullOrEmpty(password))
                return true;

            string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";
            return (Regex.IsMatch(password, passwordRegex));
        }

       
    }
}
