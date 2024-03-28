namespace Euro24.Model;

public class TeamsFactoryMethod
{
    public static Dictionary<string, TeamCharacteristics> BuildTeams()
    {
        Dictionary<string, TeamCharacteristics> _teamCharacteristicsMap = new Dictionary<string, TeamCharacteristics>();
        _teamCharacteristicsMap.Add("Georgia",new TeamCharacteristics("Georgia",1312,"F"));
        _teamCharacteristicsMap.Add("Portugal",new TeamCharacteristics("Portugal",1745,"F"));
        _teamCharacteristicsMap.Add("Turkiye",new TeamCharacteristics("Turkiye",1505,"F"));
        _teamCharacteristicsMap.Add("Czechia",new TeamCharacteristics("Czechia",1494,"F"));
        _teamCharacteristicsMap.Add("Ukraine",new TeamCharacteristics("Ukraine",1553,"E"));
        _teamCharacteristicsMap.Add("Slovakia",new TeamCharacteristics("Slovakia",1465,"E"));
        _teamCharacteristicsMap.Add("Belgium",new TeamCharacteristics("Belgium",1798,"E"));
        _teamCharacteristicsMap.Add("Romania",new TeamCharacteristics("Romania",1472,"E"));
        _teamCharacteristicsMap.Add("Netherlands",new TeamCharacteristics("Netherlands",1745,"D"));
        _teamCharacteristicsMap.Add("France",new TeamCharacteristics("France",1845,"D"));
        _teamCharacteristicsMap.Add("Poland",new TeamCharacteristics("Poland",1520,"D"));
        _teamCharacteristicsMap.Add("Austria",new TeamCharacteristics("Austria",1546,"D"));
        _teamCharacteristicsMap.Add("Slovenia",new TeamCharacteristics("Slovenia",1427,"C"));
        _teamCharacteristicsMap.Add("Denmark",new TeamCharacteristics("Denmark",1601,"C"));
        _teamCharacteristicsMap.Add("Serbia",new TeamCharacteristics("Serbia",1517,"C"));
        _teamCharacteristicsMap.Add("England",new TeamCharacteristics("England",1800,"C"));
        _teamCharacteristicsMap.Add("Spain",new TeamCharacteristics("Spain",1732,"B"));
        _teamCharacteristicsMap.Add("Croatia",new TeamCharacteristics("Croatia",1717,"B"));
        _teamCharacteristicsMap.Add("Italy",new TeamCharacteristics("Italy",1718,"B"));
        _teamCharacteristicsMap.Add("Albania",new TeamCharacteristics("Albania",1382,"B"));
        _teamCharacteristicsMap.Add("Germany",new TeamCharacteristics("Germany",1631,"A"));
        _teamCharacteristicsMap.Add("Scotland",new TeamCharacteristics("Scotland",1506,"A"));
        _teamCharacteristicsMap.Add("Hungary",new TeamCharacteristics("Hungary",1525,"A"));
        _teamCharacteristicsMap.Add("Switzerland",new TeamCharacteristics("Switzerland",1613,"A"));

        return _teamCharacteristicsMap;
    }


}