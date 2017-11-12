using Rajaraman.PlayerProfile.Data;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace Rajaraman.PlayerProfile.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IPlayerProfileJsonService
    {
        [OperationContract]
        [WebGet(UriTemplate = "GetCountries", ResponseFormat=WebMessageFormat.Json)]
        List<Country> GetCountries();
    }
}
