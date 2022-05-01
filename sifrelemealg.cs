using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DövizAlSat
{
    class sifrelemealg
    {
        public  static string sezar(string text, int key)
        {
            char[] x = text.ToCharArray();
            string sezartext = null;

            foreach (char item in x)
            {
                sezartext += Convert.ToChar(item + key);
            }
            return sezartext;
        }

        public static string desezar (string text, int key)
        {
            char[] x = text.ToCharArray();
            string desezartext = null;
            foreach (char item in x)
            {
                desezartext += Convert.ToChar(item - key);
            }
            return desezartext;
        }
    }
}
