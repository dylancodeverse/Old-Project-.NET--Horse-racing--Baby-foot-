using System.Data;
using BabyFoot.connections;

namespace foot.src.models
{
    public class MatchInfoPerson
    {
        public int MatchInfoPersonId { get; set; }
        public string PersonId { get; set; }
        public int Score { get; set; }

        public MatchInfoPerson(int matchInfoPersonId, string personId, int score)
        {
            MatchInfoPersonId = matchInfoPersonId;
            PersonId = personId;
            Score = score;
        }

        public void InsertMatchInfoPerson()
        {
            string[] queries = new string[]
            {
                $"INSERT INTO match_infoperson (person_id, score) VALUES ('{this.PersonId}', '{this.Score}')"
            };
            Connect connect = new Connect();
            connect.InsertQuery(queries);
        }

        public static List<MatchInfoPerson> GetAllMatchInfoPersons()
        {
            Connect c = new Connect();
            List<MatchInfoPerson> matchInfoPersons = new List<MatchInfoPerson>();

            string[] queries = new string[] { "SELECT * FROM match_infoperson" };

            List<DataTable> result = c.ExecuteSelectQuery(queries);

            foreach (DataTable dataTable in result)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int matchInfoPersonId = Convert.ToInt32(row["match_infoperson_id"]);
                        string personId = row["person_id"].ToString();
                        int score = Convert.ToInt32(row["score"]);

                        MatchInfoPerson matchInfoPerson = new MatchInfoPerson(matchInfoPersonId, personId, score);
                        matchInfoPersons.Add(matchInfoPerson);
                    }
                }
            }

            return matchInfoPersons;
        }
    }
}
