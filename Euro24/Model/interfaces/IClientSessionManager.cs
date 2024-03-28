namespace Euro24.Model.interfaces;

public interface IClientSessionManager
{
    bool AddClient(string sessionId, ClientSession clientSession);
    ClientSession GetClientSession(string sessionId);
}