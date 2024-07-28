using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Entities.Address.Enum
{
    public enum GarAddressLevel
    {
        Region = 1,
        AdministrativeArea,
        MunicipalArea,
        RuralUrbanSettlement,
        City,
        Locality,
        ElementOfPlanningStructure,
        ElementOfRoadNetwork,
        Land,
        Building,
        Room,
        RoomInRooms,
        AutonomousRegionLevel,
        IntracityLevel,
        AdditionalTerritoriesLevel,
        LevelOfObjectsInAdditionalTerritories,
        CarPlace
    }
}
