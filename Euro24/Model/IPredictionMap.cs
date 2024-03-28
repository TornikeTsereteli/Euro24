namespace Euro24.Model;

public interface IPredictionMap
{ 
    IEnumerable<string> GetTeams();
    TeamCharacteristics GetCharacteristics(string country);
    
}
