﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Deccagram.Utils
{
    public class MD5Utils
    {
        public static string GerarHashMD5(string texto)
        {
            MD5 md5Hash = MD5.Create();
            var bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                stringBuilder.Append(bytes[i]);
            }
            return stringBuilder.ToString();
        }
    }
}
