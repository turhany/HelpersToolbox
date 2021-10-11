using System;
using System.Collections.Generic;
using System.Json;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Ganss.XSS;
using Newtonsoft.Json;
using Slugify;

namespace HelpersToolbox.Extensions
{
    public static class StringExtensions
    {
        private static readonly HtmlSanitizer HtmlSanitizer = new HtmlSanitizer();
        private static readonly SlugHelper SlugHelper = new SlugHelper();
        private static readonly Dictionary<string, string> TurkishEnglishCharMappingForSlugify = new Dictionary<string, string>
        {
            {"ı", "i"},
            {"İ", "I"},
            {"ö", "o"},
            {"Ö", "O"},
            {"ç", "c"},
            {"Ç", "C"},
            {"ü", "u"},
            {"Ü", "U"},
            {"ğ", "g"},
            {"Ğ", "G"},
            {"ş", "s"},
            {"Ş", "S"}
        };

        //Pattern get from there https://emailregex.com/
        private const string EmailValidateRegexPattern =
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9][\-a-zA-Z0-9]{0,22}[a-zA-Z0-9]))$";

        private static readonly TimeSpan MatchTimeout = TimeSpan.FromMilliseconds(2000);

        public static string Truncate(this string text, int maxLength) =>
            text.Length > maxLength ? $"{text.Substring(0, maxLength - 3)}..." : text;

        public static bool EqualsWithIgnoreCase(this string str, string other) =>
            str.Equals(other, StringComparison.InvariantCultureIgnoreCase);

        public static string ComputeHashSha(this string text, string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);
            using var hmac = new HMACSHA1(keyBytes);
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(text));
            var builder = new StringBuilder();
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var i = 0; i < hash.Length; i++)
            {
                builder.Append(hash[i].ToString("x2"));
            }

            return builder.ToString();
        }

        public static bool IsValidUrl(this string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public static bool IsValidJson(this string text)
        {
            try
            {
                JsonValue.Parse(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsValidEmail(this string text)
        {
            var trimEmail = text?.Trim();
            if (text != null && !string.IsNullOrWhiteSpace(text))
            {
                var emailRegexValidator = new Regex(EmailValidateRegexPattern, RegexOptions.None, MatchTimeout);

                try
                {
                    if (emailRegexValidator.IsMatch(trimEmail))
                    {
                        return true;
                    }
                }
                catch
                {
                    // ignored
                }
            }

            return false;
        }

        public static string SanitizeHtml(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            return HtmlSanitizer.Sanitize(text);
        }

        public static string Slugify(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            foreach (var charMapping in TurkishEnglishCharMappingForSlugify.Where(charMapping => text.Contains(charMapping.Key)))
            {
                text = text.Replace(charMapping.Key, charMapping.Value);
            }
            
            return SlugHelper.GenerateSlug(text);
        }
        
        public static T FromJson<T>(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return default;
            }
            
            return JsonConvert.DeserializeObject<T>(text, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All,
                ObjectCreationHandling = ObjectCreationHandling.Replace
            });
        }
    }
}