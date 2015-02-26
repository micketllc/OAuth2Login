﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Oauth2Login.Core
{
    public class QueryStringBuilder
    {
        public static string Build(params object[] keyValueEntries)
        {
            if (keyValueEntries.Length%2 != 0)
            {
                throw new Exception(
                    "KeyAndValue collection needs to be dividable by two... key, value, key, value... get it?");
            }

            var sb = new StringBuilder();
            for (int i = 0; i < keyValueEntries.Length; i+=2)
            {
                var key = keyValueEntries[i];
                var val = keyValueEntries[i + 1];

                var valEncoded = HttpUtility.UrlEncode(val.ToString());

                sb.AppendFormat("{0}={1}&", key, valEncoded);
            }

            return sb.ToString().TrimEnd('&');
        }
    }
}
