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

    public static DecorateResult GetInstance(string groupName, int round,  Dictionary<string,List<TeamCharacteristics>> groups )
    {
        return new DecorateResult(groupName, round, groups);
    }

    public static Tuple<DecorateResult, List<ClientSession.Game>> DecorateResultAndGames(string groupName,int round,Dictionary<string,List<TeamCharacteristics>> groups,List<ClientSession.Game> games)
    {
        return new Tuple<DecorateResult,List<ClientSession.Game>>(new DecorateResult(groupName, round, groups), games);
    }

    public static List<Tuple<DecorateResult, List<ClientSession.Game>>> GetDecoratedResultAndGamesResult(ClientSession clientSession)
    {
        List<Tuple<DecorateResult, List<ClientSession.Game>>> result = new List<Tuple<DecorateResult, List<ClientSession.Game>>>();
        
        string[] groupNames = { "A", "B", "C", "D", "E", "F"};
        int[] rounds = { 1, 2, 3 };
        Dictionary<string,List<TeamCharacteristics>> groups = clientSession.GetTeamsByGroup();

        foreach (var groupName in groupNames)
        {
            List<ClientSession.Game> games = new List<ClientSession.Game>();
            int cnt = 0;
            foreach (var round in rounds)
            {
                List<ClientSession.Game> games1 = clientSession.GroupGames.GetValueOrDefault(new Tuple<string, int>(groupName, round),new List<ClientSession.Game>());
                if (games1.Count != 0)
                    cnt++;
                games.AddRange(games1);
                
    
            }

            Console.WriteLine(cnt);
            DecorateResult decorateResult = DecorateResult.GetInstance(groupName, cnt, groups);
            result.Add(new Tuple<DecorateResult, List<ClientSession.Game>>(decorateResult, games));
            
        }

        return result;

    }
    
}

