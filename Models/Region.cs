using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTUWebApi.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }
    }
}
