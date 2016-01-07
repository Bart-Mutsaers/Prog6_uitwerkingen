using LeagueManager.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LeagueManager.Service
{
    [ServiceContract]
    public interface ILMService
    {
        [OperationContract]
        int SendSetup(SetupContract setup);

        [OperationContract]
        GameContract GetGameResult(int gameId);
    }
}
