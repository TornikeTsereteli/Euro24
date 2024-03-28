using Euro24.Model.interfaces;

namespace Euro24.Model;

public class ClientSessionManager:IClientSessionManager
{
    private readonly Dictionary<string, ClientSession> map;

    public ClientSessionManager()
    {
        map = new Dictionary<string, ClientSession>();
    }

    public bool AddClient(string sessionId, ClientSession clientSession)
    { 
        map.Add(sessionId,clientSession);
        return true;
    }

    public ClientSession GetClientSession(string sessionId)
    {
        return map[sessionId];
    }
}