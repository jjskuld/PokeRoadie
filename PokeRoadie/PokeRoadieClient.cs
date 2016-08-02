﻿#region " Imports "

using System;
using System.Linq;
using System.IO;
using System.Reflection;

using PokemonGo.RocketAPI;

#endregion

namespace PokeRoadie
{
    public class PokeRoadieClient : Client
    {

        private static PokeRoadieClient _current;
        public static PokeRoadieClient Current { get { _current = _current ?? new PokeRoadieClient(); return _current; } }

        public DateTime? RefreshEndDate { get; set; }

        private PokeRoadieClient() : base(PokeRoadieSettings.Current)
        {
        }

        public void SetLocation(double lat, double lng, double alt)
        {
            var type = typeof(Client);
            var latProp = type.GetProperties(BindingFlags.Public & BindingFlags.Instance).Where(x => x.Name == "CurrentLatitude").FirstOrDefault();
            if (latProp != null)
            {
                latProp.SetValue(this, lat);
            }
            var lngProp = type.GetProperties(BindingFlags.Public & BindingFlags.Instance).Where(x => x.Name == "CurrentLongitude").FirstOrDefault();
            if (lngProp != null)
            {
                lngProp.SetValue(this, lng);
            }
            var altProp = type.GetProperties(BindingFlags.Public & BindingFlags.Instance).Where(x => x.Name == "CurrentAltitude").FirstOrDefault();
            if (altProp != null)
            {
                altProp.SetValue(this, alt);
            }
        }


    }
}