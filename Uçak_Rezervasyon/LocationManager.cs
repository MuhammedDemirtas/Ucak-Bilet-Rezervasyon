using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uçak_Rezervasyon
{
    internal class LocationManager
    {
        public static Location[] GetLocations()
        {
            return new Location[] {
            new Location("Türkiye", "Istanbul", "Atatürk Havalimanı"),
            new Location("France", "Paris", "Charles de Gaulle Airport"),
            new Location("Türkiye", "Antalya", "Antalya Havalimanı"),
            new Location("Germany", "Berlin", "Tegel Airport"),
            new Location("Türkiye", "Ankara", "Esenboğa Havalimanı"),
            new Location("Italy", "Roma", "Fiumicino Airport"),
            new Location("Holland", "Amsterdam", "Schiphol Airport"),
            new Location("Poland", "Varşova", "Chopin Airport"),
            new Location("Azerbaycan", "Baku", "Haydar Aliyev Airport"),
            new Location("Türkiye", "Adana", "Şakirpaşa Havalimanı")           
            };
        }
    }
}
