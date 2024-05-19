using System;
using System.Collections.Generic;
using System.Data;
using BabyFoot.connections;

namespace foot.src.models
{
    public class Match
    {
        public int MatchId { get; set; }
        public string RuleId { get; set; }
        public DateTime Date { get; set; }
        public float Pari { get; set; }

        public Match(int matchId, string ruleId, DateTime date , float pari)
        {
            MatchId = matchId;
            RuleId = ruleId;
            Date = date;
            Pari = pari ;
        }

        public void InsertMatch()
        {
            String  v =$"INSERT INTO matches (match_ruleid, pari,match_date ) VALUES ({this.RuleId},{this.Pari} ,'{this.Date.ToString("yyyy-MM-dd")}')";

            string[] queries = new string[]
            {
                $"INSERT INTO matches (match_ruleid, match_date) VALUES ({this.RuleId}, '{this.Date.ToString("yyyy-MM-dd")}')"
            };
            Connect connect = new Connect();
            connect.InsertQuery(queries);
        }

        public static List<Match> GetAllMatches()
        {
            Connect c = new Connect();
            List<Match> matches = new List<Match>();

            string[] queries = new string[] { "SELECT * FROM matches" };

            List<DataTable> result = c.ExecuteSelectQuery(queries);

            foreach (DataTable dataTable in result)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int matchId = Convert.ToInt32(row["match_id"]);
                        string ruleId = (row["match_ruleid"]).ToString();
                        DateTime date = Convert.ToDateTime(row["match_date"]);
                        float money = Convert.ToSingle(row["pari"]);
                        Match match = new Match(matchId, ruleId, date ,money);
                        matches.Add(match);
                    }
                }
            }

            return matches;
        }
    }
}
