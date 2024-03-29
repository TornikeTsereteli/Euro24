namespace Euro24.Model;

public class DecorateResult
{
    public int Round { get; set; }
    
    public string GroupName { get; set; }
    
    public List<TeamCharacteristics> Counties { get; set; }


    private DecorateResult(string groupName, int round, Dictionary<string,List<TeamCharacteristics>> groups)
    {
        GroupName = groupName;
        Round = round;
        Counties = groups[groupName];
    }

    public static List<DecorateResult> GetDecoratedResult(Dictionary<string,List<TeamCharacteristics>> groups)
    {
        List<DecorateResult> decoratedList = new List<DecorateResult>();
        foreach (var groupName in groups.Keys)
        {
            List<TeamCharacteristics> teamCharacteristicsList = groups[groupName];
            int round = teamCharacteristicsList[0].Round;
            DecorateResult decorateResult = new DecorateResult(groupName, round, groups);
            decoratedList.Add(decorateResult);
        }

        return decoratedList;
    }

    public static Tuple<DecorateResult, List<ClientSession.Game>> DecorateResultAndGames(string groupName,int round,Dictionary<string,List<TeamCharacteristics>> groups,List<ClientSession.Game> games)
    {
        return new Tuple<DecorateResult,List<ClientSession.Game>>(new DecorateResult(groupName, round, groups), games);
    }
    
}