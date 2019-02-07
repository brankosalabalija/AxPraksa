using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VehicleSetup3.Models
{
    public class AdditionalFieldsLists
    {
        public int ID { get; set; }
        public string FleetNo { get; set; }
        public List<string> Name { get; set; }
        public List<string> Value { get; set; }

        public virtual FleetAsset FleetAsset { get; set; }

    }
}