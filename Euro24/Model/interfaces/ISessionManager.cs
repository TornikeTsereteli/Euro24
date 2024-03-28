namespace Euro24.Model.interfaces;

public interface ISessionManager
{
    ClientSession GetSession(string sessionId);
}