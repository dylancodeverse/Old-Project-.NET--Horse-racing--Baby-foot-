using System.Data;
using BabyFoot.connections;
using PMU.src.models;

public class HorseInMatch : Horse
{
    public int MatchId { get; set; }
    public List<People> ListPeople { get; set; }
    public float SecondRecord { get; set; }

    public HorseInMatch(int horseId, int matchId, int horseNumber, float horseVitess, float[] horseEndurance, int indexOfHorseEndurance, List<People> listPeople, float secondRecord)
        : base(horseId, horseNumber, horseVitess, horseEndurance, indexOfHorseEndurance)
    {
        MatchId = matchId;
        ListPeople = listPeople;
        SecondRecord = secondRecord;
    }

    public void InsertHorseInMatch()
    {
        new Matchinfo(HorseId, MatchId, SecondRecord);
    }

    public static List<HorseInMatch> GetHorsesInMatch(int matchId)
    {
        Connect c = new Connect();
        List<HorseInMatch> horsesInMatch = new List<HorseInMatch>();

        string[] queries = new string[]
        {
            $"SELECT * FROM V_finalJoin WHERE matchId = {matchId}"
        };

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
                    float secondRecorded = float.Parse(row["secondRecorded"].ToString());

                    HorseInMatch horseInMatch = new HorseInMatch(horseId, matchId, horseNumber, horseVitess, null, 0, null, secondRecorded);
                    horsesInMatch.Add(horseInMatch);
                }
            }
        }

        return horsesInMatch;
    }
}
