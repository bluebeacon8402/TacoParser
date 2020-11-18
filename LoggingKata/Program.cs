using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Windows;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            


                logger.LogInfo($"Lines: {lines[0]}");

                // Create a new instance of your TacoParser class
                var parser = new TacoParser();

                // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
                var locations = lines.Select(parser.Parse).ToArray();

                // DON'T FORGET TO LOG YOUR STEPS
           
            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the farthest from each other.
            // Create a `double` variable to store the distance
            ITrackable location1 = null;
            ITrackable location2 = null;
            
            var x = new TacoBell();
                 
            var y = new TacoBell();

           
            double z = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            for(int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var coorda = new GeoCoordinate();
                coorda.Latitude = locA.Location.Latitude;
                coorda.Longitude = locA.Location.Longitude;

                
                for(int e = 0; e < locations.Length; e++) //var distance = coordinateA.GetDistanceTo(coordinateB); - HINT
                {
                    var locB = locations[e];
                    var coordb = new GeoCoordinate();
                    coordb.Latitude = locB.Location.Latitude;
                    coordb.Longitude = locB.Location.Longitude;
           
                    if (coorda.GetDistanceTo(coordb) > z)
                    {
                        z = coorda.GetDistanceTo(coordb);
                        location1 = locA;
                        location2 = locB;
                    }
                }
            }

            Console.WriteLine($"The distance between {location1.Name} and {location2.Name} is {z}");
            // Create a new corA Coordinate with your locA's lat and long

            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.


            
        }
    }
}
