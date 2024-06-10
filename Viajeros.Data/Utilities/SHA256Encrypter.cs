using System.Security.Cryptography;
using System.Text;

namespace Viajeros.Data.Utilities;

public static class SHA256Encrypter
{
    public static string Convert(string raw)
    {
        // HashData - returns byte array  
        byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(raw));

        // Convert byte array to a string   
        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
}
