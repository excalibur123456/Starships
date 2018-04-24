using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarShips
{
    public enum TimeUnit
    {
        day = 24,
        week = 168,
        month = 730,
        year = 8760
    }

    public class Calculation
    {
        /// <summary>
        /// Get Time Unit by consumables
        /// </summary>
        /// <param name="consumables">How long the supply will last</param>
        /// <returns>Time unit</returns>
        public static TimeUnit GetByConsumables(string consumables)
        {
            foreach (var s in Enum.GetNames(typeof(TimeUnit)))
            {
                if (consumables.IndexOf(s, StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    return (TimeUnit)Enum.Parse(typeof(TimeUnit), s);
                }
            }
            return TimeUnit.day;
        }

        /// <summary>
        /// Get Time Unit by consumables
        /// </summary>
        /// <param name="consumables">How long the supply will last</param>
        /// <param name="planetDistance">Distance supplied by user in mega lights</param>
        /// <param name="mglt">The Maximum number of Megalights the starship can travel in a standard hour</param>
        /// <returns>Starship Number of Stops</returns>
        public static int GetNumberofStops(string consumables, int planetDistance , int mglt)
        {
            var hours = planetDistance / mglt;
            var timeUnitused = GetByConsumables(consumables);
            var number = int.Parse(consumables.Split(' ')[0]);
            var numStops = hours / (int)timeUnitused / number;
            return numStops;
        }
    }
}
