using MIDAMS.Models;
using System.Collections.Generic;

namespace MIDAMS.Areas.Admin.ViewModels
{
    public class MapClientsViewModel
    {
        public IEnumerable<MapClientsToPartner> MapClientsToPartners { get; set; }
        public string PartnerName { get; set; }
    }
}