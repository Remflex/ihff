using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ihff.Models
{
    public class CodeGenerator
    {
            private static string Pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijlkmnopqrstuvwxyz0123456789";
            private static Random r = new Random();


            public static string GenerateCode()
            {
                string code = "";

                for (int i = 0; i < 8; i++)
                {
                    int c = r.Next(0, Pool.Length - 1);
                    code += Pool[c];
                    Console.WriteLine("{0,5},{1,5}", Pool[c], code);
                }

                return code;
            }
        }
    }
