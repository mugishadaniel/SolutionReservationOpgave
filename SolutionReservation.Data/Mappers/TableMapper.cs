using SolutionReservation.Data.Model;
using SolutionReservation.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionReservation.Data.Mappers
{
    public class TableMapper
    {
        public static Table Map(TableEF tableEF)
        {
            return new Table(tableEF.TableID, tableEF.Seats,tableEF.RestaurantId);
        }

        public static TableEF Map(Table table)
        {
            return new TableEF()
            {
                TableID = table.TableID,
                Seats = table.Seats,
                RestaurantId = table.RestaurantId
            };
        }
    }
}
