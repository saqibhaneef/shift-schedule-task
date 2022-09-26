using System.Text.Json;

namespace scheduling.Data
{
    public class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Shifts.Any())
                {
                    var shifts = new List<Shift>()
                    {
                        new Shift(){EmployeeId="1001",TimeIn="09/26/2022 09:00:00 AM",TimeOut="09/26/2022 06:00:00 PM",Type=1,Date=DateTime.Now.ToString()},
                        new Shift(){EmployeeId="1001",TimeIn="09/26/2022 01:00:00 PM",TimeOut="09/26/2022 03:00:00 PM",Type=2,Date=DateTime.Now.ToString()},
                        new Shift(){EmployeeId="1002",TimeIn="09/26/2022 09:00:00 AM",TimeOut="09/26/2022 06:00:00 PM",Type=1,Date=DateTime.Now.ToString()},
                        new Shift(){EmployeeId="1002",TimeIn="09/26/2022 11:00:00 AM",TimeOut="09/26/2022 02:00:00 PM",Type=2,Date=DateTime.Now.ToString()},
                        new Shift(){EmployeeId="1002",TimeIn="09/26/2022 04:00:00 PM",TimeOut="09/26/2022 05:00:00 PM",Type=2,Date=DateTime.Now.ToString()},
                        new Shift(){EmployeeId="1003",TimeIn="09/26/2022 09:00:00 AM",TimeOut="09/26/2022 03:00:00 PM",Type=1,Date=DateTime.Now.ToString()},
                        new Shift(){EmployeeId="1003",TimeIn="09/26/2022 03:00:00 PM",TimeOut="09/26/2022 06:00:00 PM",Type=3,Date=DateTime.Now.ToString()}
                    };
                    foreach (var item in shifts)
                    {
                        context.Shifts.Add(item);
                    }
                    context.SaveChanges();
                }                
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<AppDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
