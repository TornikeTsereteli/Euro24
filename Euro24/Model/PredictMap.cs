namespace Euro24.Model;

public class PredictMap: IPredictionMap
{
    private Dictionary<string, int> _map = new Dictionary<string, int>();

    public PredictMap()
    {
        _map.Add("brazil",12);
    }
    
    public void Update(string country, int rating)
    {
        _map["brazil"] = 23;
        
    }

    public IEnumerable<string> GetTeams()
    {
        Console.WriteLine(_map["brazil"]);
        return _map.Keys;

    }

    public TeamCharacteristics GetCharacteristics(string country)
    {
        throw new NotImplementedException();
    }
}