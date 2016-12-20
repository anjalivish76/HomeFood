using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFood.Models
{
    public static class Distance
    {
        public static double Calculate(double lat1,double long1,double lat2,double long2)
        {
            double R = 6371;
            double dLat = ToRad((lat2 - lat1));
            double dLon = ToRad((long2 - long1));
            lat1 = ToRad(lat1);
            lat2 = ToRad(lat2);
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double d = R * c;
            return d;
        }

        public static double ToRad(double value)
        {
            return value * Math.PI / 180;
        }
    }
}