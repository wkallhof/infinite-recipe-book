using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace InfiniteRecipeBook.Common;

public static class Base64UrlEncoder
{
    public static string Encode(string value)
    {
        byte[] valueBytes = Encoding.UTF8.GetBytes(value);
        return WebEncoders.Base64UrlEncode(valueBytes);
    }

    public static string Decode(string value)
    {
        byte[] valueBytes = WebEncoders.Base64UrlDecode(value);
        return Encoding.UTF8.GetString(valueBytes);
    }
}