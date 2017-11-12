using Rajaraman.PlayerProfile.Dao;
using Rajaraman.PlayerProfile.Data;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Rajaraman.PlayerProfile.Service
{
    public class PlayerProfileJsonService : IPlayerProfileJsonService
    {
        public List<Country> GetCountries()
        {
            try
            {
                List<Country> countryList = DbDao.GetCountries();

                if (countryList == null)
                {
                    throw new FaultException("Country list not found");
                }

                return countryList;
            }
            catch(Exception ex)
            {
                throw new FaultException(ex.Message + ex.StackTrace);
            }
        }
    }
}
