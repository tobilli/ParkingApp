
using Microsoft.CodeAnalysis.Options;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace ParkingApp.Models
{
    public class AreaSpace
    {
        public static List<Space> GetAll()
        {
            return new List<Space>
            {
                new Space(){Local_Govt="Ajeromi-Ifelodun"},
                new Space(){Local_Govt="Amuwo-Odofin"},
                new Space(){Local_Govt="Ojo"},
                new Space(){Local_Govt="Epe"},
                new Space(){Local_Govt="Ibeju-Lekki"},
                new Space(){Local_Govt="Agege"},
                new Space(){Local_Govt="Alimosho"},
                new Space(){Local_Govt="Amuwo-Odofin"},
                new Space(){Local_Govt="Ifako-Ijaiye"},
                new Space(){Local_Govt="Ikeja"},
                new Space(){Local_Govt="Kosofe"},
                new Space(){Local_Govt="Mushin"},
                new Space(){Local_Govt="Somolu"},
                new Space(){Local_Govt="Ikorodu"},
                new Space(){Local_Govt="Apapa"},
                new Space(){Local_Govt="Eti-Osa"},
                new Space(){Local_Govt="Lagos-Island"},
                new Space(){Local_Govt="Surulere"}
            };
        }
    }
}

                              