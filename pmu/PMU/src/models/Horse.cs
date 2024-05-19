using System.Data;
using BabyFoot.connections;

public class Horse
{
    public int HorseId { get; set; }
    public int HorseNumber { get; set; }
    public float HorseVitess { get; set; }
    public float[] HorseEndurance { get; set; }
    public int IndexOfHorseEndurance { get; set; }

    public Horse(int horseId, int horseNumber, float horseVitess, float[] horseEndurance, int indexOfHorseEndurance)
    {
        HorseId = horseId;
        HorseNumber = horseNumber;
        HorseVitess = horseVitess;
        HorseEndurance = horseEndurance;
        IndexOfHorseEndurance = 0;
    }

    public void InsertHorse()
    {
        string[] queries = new string[]
        {
            $"INSERT INTO horse (horseId,horseNumber, horseVitess) VALUES ('{this.HorseNumber}','{this.HorseNumber}', '{this.HorseVitess}')"
        };
        InsertPercentageLimit() ;
        Connect connect = new Connect();
        connect.InsertQuery(queries);
    }
    public void InsertPercentageLimit(){
        for (var i = 0; i < HorseEndurance.Count(); i++)
        {
        string []queries= new string []{
          $"INSERT INTO horse_endurance (horseId, percentageLimit) VALUES ('{this.HorseNumber}','{this.HorseEndurance[i]}')"
        };
        Connect connect = new Connect();
        connect.InsertQuery(queries);
            
        }

    }

    public static List<Horse> GetAllHorses()
    {
        Connect c = new Connect();
        List<Horse> horses = new List<Horse>();

        string[] queries = new string[] { "SELECT * FROM horse" };

        List<DataTable> result = c.ExecuteSelectQuery(queries);

        foreach (DataTable dataTable in result)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    int horseId = int.Parse(row["horseId"].ToString());
                    int horseNumber = int.Parse(row["horseNumber"].ToString());
                    float horseVitess = float.Parse(row["horseVitess"].ToString());

                    // Perform the additional select query to fetch the percentage limits
                    string[] selectQueries = new string[] { "SELECT * FROM V_FHorseInf WHERE horseId = " + horseId + " ORDER BY horseId, percentageLimit" };
                    List<DataTable> selectResult = c.ExecuteSelectQuery(selectQueries);

                    // Extract the percentage limits into a float array
                    List<float> percentageLimits = new List<float>();
                    foreach (DataTable selectTable in selectResult)
                    {
                        foreach (DataRow selectRow in selectTable.Rows)
                        {
                            float percentageLimit = float.Parse(selectRow["percentageLimit"].ToString());
                            percentageLimits.Add(percentageLimit);
                        }
                    }
                    float[] listpercentage = percentageLimits.ToArray();

                    // Create the Horse object with the fetched data
                    Horse horse = new Horse(horseId, horseNumber, horseVitess, listpercentage, 0);
                    horses.Add(horse);
                }
            }
        }

        return horses;
    }
}
