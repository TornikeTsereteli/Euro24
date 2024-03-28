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
    
    public Dictionary<string,TeamCharacteristics> GetCountries(string sessionId)
    {
        return _sessionManager.GetClientSession(sessionId).TeamCharacteristics;
    }
    [HttpPost("/AddSession")]
    public void AddSession(string sessionId)
    {
        _sessionManager.AddClient(sessionId, new ClientSession(_generateScore));
    }
    
    [HttpPost("/UpdateRating")]
    public void UpdateRating(string sessionId,string countryName, int rating)
    {
        _sessionManager.GetClientSession(sessionId).TeamCharacteristics[countryName].Rating = rating;
    }
    [HttpGet("/GetGroups")]
    public Dictionary<string, List<TeamCharacteristics>> GetGroups(string sessionId)
    {
        return _sessionManager.GetClientSession(sessionId).GetTeamsByGroup();
    }
    [HttpGet("/GetRoundGamesOnConcreteGroup")]
    public List<ClientSession.Game> GetRoundGamesOnConcreteGroup(string sessionId, string groupName, int round)
    {
        return _sessionManager.GetClientSession(sessionId).GeneratesScores(groupName, round)[new Tuple<string, int>(groupName,round)];
    }
    
}