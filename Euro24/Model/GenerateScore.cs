using Euro24.Model.interfaces;

namespace Euro24.Model;

public class GenerateScore:IGenerateScore
{
    public (int, int) generateScore(TeamCharacteristics team1, TeamCharacteristics team2)
    {
        var diff = team1.Rating - team2.Rating;
        int random = Random.Shared.Next(0, team2.Rating % 4);
        int team1Score, team2Score;
        if (diff > 0)
        {
            team1Score = random + Math.Abs(diff % 3);
            team2Score = random;
        }
        else
        {
            team1Score = random;
            team2Score = random + Math.Abs(diff % 3);
        }

        if (team1Score > team2Score)
        {
            team1.Win += 1;
            team2.Loss += 1;
            team1.Rating += 10;
            team2.Rating -= 10;
        }
        else
        {
            if (team1Score == team2Score)
            {
                // diffrent logic can be written here
                team1.Draw += 1;
                team2.Draw += 1;
                team1.Rating += (team1.Rating - team2.Rating) % 5;
                team2.Rating += (team1.Rating - team2.Rating) % 5;
            }
            else
            {
                team2.Win += 1;
                team1.Loss += 1;
                team2.Rating += 10;
                team1.Rating -= 10;
            }
        }

        team1.Round += 1;
        team2.Round += 1;

        return (team1Score, team2Score);

    }
}