namespace AE.Application.Features.Ship.Queries.GetClosestPort;

public static class Helpers
{
    public static double ToRadians(double degree)
    {
        return degree * Math.PI / 180.0;
    }

    public static double GetDistance(double lat1, double lon1, double lat2, double lon2)
    {
        // Radius of the Earth in kilometers
        double R = 6371.0;

        // Convert latitude and longitude from degrees to radians
        double lat1Rad = ToRadians(lat1);
        double lon1Rad = ToRadians(lon1);
        double lat2Rad = ToRadians(lat2);
        double lon2Rad = ToRadians(lon2);

        // Differences in coordinates
        double dLat = lat2Rad - lat1Rad;
        double dLon = lon2Rad - lon1Rad;

        // Haversine formula
        double a = Math.Pow(Math.Sin(dLat / 2), 2) +
                   Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                   Math.Pow(Math.Sin(dLon / 2), 2);

        double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        // Distance in kilometers
        return R * c;
    }
}
