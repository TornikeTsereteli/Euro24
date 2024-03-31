using Euro24.Model;
using Euro24.Model.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Euro24.Controllers;
[ApiController]
[Route("[controller]")]
public class PredictionController
{
    private IPredictionMap _predictionMap;
    private IClientSessionManager _sessionManager;
    private IGenerateScore _generateScore;
    
    public PredictionController(IPredictionMap predictionMap, IClientSessionManager sessionManager,IGenerateScore generateScore)
    {
        _generateScore = generateScore;
        _sessionManager = sessionManager;
        _predictionMap = predictionMap;
    }
    
    
    [HttpGet("/GetCountries")]
    
    public List<TeamCharacteristics> GetCountries(string sessionId)
    {
        return _sessionManager.GetClientSession(sessionId).TeamCharacteristics.Values.ToList();
    }
    [HttpPost("/RegisterSession")]
    public string RegisterSession()
    {
        string token = TokenGenerator.GenerateRandomToken(20);
        int i = 0;
        while (!_sessionManager.AddClient(token,new ClientSession(_generateScore)))
        {
            token = TokenGenerator.GenerateRandomToken(20+i++);
        }
        return token;
    }
    
    
    // [HttpPost("/UpdateRating")]
    // public void UpdateRating(string sessionId,string countryName, int rating)
    // {
    //     _sessionManager.GetClientSession(sessionId).TeamCharacteristics[countryName].Rating = rating;
    // }
    // [HttpGet("/GetGroups")]
    // public Dictionary<string, List<TeamCharacteristics>> GetGroups(string sessionId)
    // {
    //     return _sessionManager.GetClientSession(sessionId).GetTeamsByGroup();
    // }
    
    [HttpGet("/GetGroups")]
    public List<DecorateResult> GetGroupsUpdated(string sessionId)
    {
        Dictionary<string,List<TeamCharacteristics>> groups = _sessionManager.GetClientSession(sessionId).GetTeamsByGroup();
        return DecorateResult.GetDecoratedResult(groups);

    }

    
    [HttpGet("/GetDecoratedResultAndGamesResults")]
    public List<Tuple<DecorateResult,List<ClientSession.Game>>> GetDecoratedResultAndGamesResults(string sessionId)
    {
        return DecorateResult.GetDecoratedResultAndGamesResult(_sessionManager.GetClientSession(sessionId));
    } 
    
    
    [HttpGet("/GetRoundGamesOnConcreteGroup")]
    public Tuple<DecorateResult,List<ClientSession.Game>> GetRoundGamesOnConcreteGroup(string sessionId, string groupName, int round)
    {
        List<ClientSession.Game> games =  _sessionManager.GetClientSession(sessionId).GeneratesScores(groupName, round)[new Tuple<string, int>(groupName,round)];
        Dictionary<string,List<TeamCharacteristics>> groups = _sessionManager.GetClientSession(sessionId).GetTeamsByGroup();
        return DecorateResult.DecorateResultAndGames(groupName, round, groups,games);
    }
    
    
}

