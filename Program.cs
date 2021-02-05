using System;

namespace NIP_validator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter NIP");
            NipValidator nipValidator = new NipValidator();
            string nip = Console.ReadLine();
            Console.WriteLine(nipValidator.ValidateNip(nip) ? "Nip number correct" : "Nip number incorect");
        }

        class NipValidator
        {
            int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7};

            public bool ValidateNip(string nip)
            {
                bool valid = false;
                try
                {
                    if (nip.Length == 10)
                    {
                        valid = CountSum(nip).Equals(nip[9].ToString());
                    }
                }
                catch (Exception)
                {
                    valid = false;
                }
                return valid;

            }

            public string CountSum(string nip)
            {
                int sum = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    sum += weights[i] * int.Parse(nip[i].ToString());
                }

                int modulo = sum % 11;
                return modulo.ToString();
            }
        }
    }
}
