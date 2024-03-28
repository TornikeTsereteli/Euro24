using System.Security.Cryptography.Xml;
using Euro24.Model.interfaces;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Euro24.Model;

public class ClientSession
{

    private int _round;
    private readonly IGenerateScore _generateScore; 
    public Dictionary<string, TeamCharacteristics> TeamCharacteristics { get; }
    public Dictionary<Tuple<string,int>, List<Game>> GroupGames = new Dictionary<Tuple<string,int>, List<Game>>(); 
    public ClientSession(IGenerateScore generateScore)
    {
        _generateScore = generateScore;
        TeamCharacteristics = TeamsFactoryMethod.BuildTeams();
    }

    public Dictionary<string, List<TeamCharacteristics>> GetTeamsByGroup()
    {
        var groupedByGroup = TeamCharacteristics.Values.GroupBy(x => x.Group);
        return groupedByGroup.ToDictionary(
            group => group.Key,
            group => group.ToList());
    }

    public Dictionary<Tuple<string,int>, List<Game>> GeneratesScores(string groupName, int round)
    {
        List<TeamCharacteristics> ConcreteGruopGames = GetTeamsByGroup()[groupName];
        List<Game> games = new List<Game>();
        GroupGames.Add(new Tuple<string, int>(groupName,round),games);

        switch (round)
        {
            case 1:
            {
                games.Add(new Game(ConcreteGruopGames[0],ConcreteGruopGames[3],_generateScore));
                games.Add(new Game(ConcreteGruopGames[1],ConcreteGruopGames[2],_generateScore));
                break;
            }
            case 2:
            {
                games.Add(new Game(ConcreteGruopGames[0],ConcreteGruopGames[2],_generateScore));
                games.Add(new Game(ConcreteGruopGames[1],ConcreteGruopGames[3],_generateScore));
                break;
            }
            case 3:
            {
                games.Add(new Game(ConcreteGruopGames[0],ConcreteGruopGames[1],_generateScore));
                games.Add(new Game(ConcreteGruopGames[2],ConcreteGruopGames[3],_generateScore));
                break;
            }
        }
        return GroupGames;
    }
   public class Game
    {

        public TeamCharacteristics Team1 { get; set; }
        public TeamCharacteristics Team2 { get; set; }
        public int Team1Score { get; }
        public int Team2Score { get; }
        public Game(TeamCharacteristics team1, TeamCharacteristics team2, IGenerateScore generateScore)
        {
            Team1 = team1;
            Team2 = team2;
            (int,int) score = generateScore.generateScore(team1, team2); // 
            Team1Score = score.Item1;
            Team2Score = score.Item2;
        }
    }
}