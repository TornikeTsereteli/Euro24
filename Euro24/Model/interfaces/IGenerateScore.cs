namespace Euro24.Model.interfaces;

public interface IGenerateScore
{
    (int, int) generateScore(TeamCharacteristics team1, TeamCharacteristics team2);

}