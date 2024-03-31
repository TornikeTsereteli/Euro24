using System.Text;

namespace Euro24.Model;

public class TokenGenerator
{
    
    
    public static string GenerateRandomToken(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var random = new Random();
        var token = new StringBuilder(length);
        for (int i = 0; i < length; i++)
        {
            token.Append(chars[random.Next(chars.Length)]);
        }
        return token.ToString();
    } 
}