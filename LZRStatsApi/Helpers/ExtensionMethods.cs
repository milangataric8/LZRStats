using LZRStatsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LZRStatsApi.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<User> WithoutPasswords(this IEnumerable<User> users)
        {
            return users.Select(x => x.WithoutPassword());
        }

        public static User WithoutPassword(this User user)
        {
            user.Password = null;
            return user;
        }

        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }

        public static string RemoveNonLetterCharactersAndEmptySpaces(this string source)
        {
            var result = new string(source.Where(c => Char.IsLetter(c) || c == '\'').ToArray());

            return result.Trim();
        }

        public static string ReplaceBadMinusCharacter(this string value)
        {
            return value.Replace('‐', '-');
        }
    }
}
