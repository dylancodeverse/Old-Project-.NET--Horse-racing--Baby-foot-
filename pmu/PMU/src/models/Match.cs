using System;
using System.Collections.Generic;
using System.Data;
using BabyFoot.connections;

namespace PMU.src.models
{
    public class Match
    {
        public int MatchId { get; set; }
        public string MatchName { get; set; }
        public List<HorseInMatch> ListHorse { get; set; }
        public Rule Rules { get; set; }

        public Match(int matchId, string matchName, List<HorseInMatch> listHorse, Rule rules)
        {
            MatchId = matchId;
            MatchName = matchName;
            ListHorse = listHorse;
            Rules = rules;
        }

        public void InsertMatch()
        {
            string[] queries = new string[]
            {
                $"INSERT INTO match_table (matchId, matchName, ruleId) VALUES ('{MatchId}', '{MatchName}', '{Rules.RuleId}')"
            };
            Connect connect = new Connect();
            connect.InsertQuery(queries);
        }

        public static List<Match> GetAllMatches()
        {
            Connect c = new Connect();
            List<Match> matchList = new List<Match>();

            string[] queries = new string[] { "SELECT * FROM match_table" };

            List<DataTable> result = c.ExecuteSelectQuery(queries);

            foreach (DataTable dataTable in result)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int matchId = int.Parse(row["matchId"].ToString());
                        string matchName = row["matchName"].ToString();

                        // Get the associated Rule for the current Match
                        int ruleId = int.Parse(row["ruleId"].ToString());
                        Rule rule = Rule.GetRuleById(ruleId);

                        // Get the list of HorseInMatch for the current Match
                        List<HorseInMatch> listHorse = HorseInMatch.GetHorsesInMatch(matchId);

                        Match match = new Match(matchId, matchName, listHorse, rule);
                        matchList.Add(match);
                    }
                }
            }

            return matchList;
        }
    }
}
