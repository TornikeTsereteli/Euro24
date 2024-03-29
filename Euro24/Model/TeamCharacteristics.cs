using System.Text.Json.Serialization;

namespace Euro24.Model;

public class TeamCharacteristics
{
    public string CountryName { get;}
    public int Rating { get; set; }

    public string Group { get; set;}
    
    public int Win { get;  set; }
    public int Loss { get; set; }
    public int Draw { get; set; }

    public int _scoredGoals;
    public int _conceadedGoals;
    public int Round { get; set;}
    
    public int GetPoints()
    {
        return Win* 3 + Draw;
    }

  

    public TeamCharacteristics(string countryName, int rating, string group)
    {
        CountryName = countryName;
        Rating = rating;
        Group = group;
        Win = 0;
        Loss = 0;
        Draw = 0;
    }
}