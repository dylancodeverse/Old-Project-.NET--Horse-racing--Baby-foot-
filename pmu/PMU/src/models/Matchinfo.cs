using System;
using System.Collections.Generic;
using System.Data;
using BabyFoot.connections;

namespace PMU.src.models
{
    public class Matchinfo
    {
        public int HorseId { get; set; }
        public int MatchId { get; set; }
        public float SecondRecorded { get; set; }
        
        public Matchinfo(int horseId, int matchId, float secondRecord)
        {
            HorseId = horseId;
            MatchId = matchId;
            SecondRecorded = secondRecord;
        }

        public void InsertMatchInfo()
        {
            string[] queries = new string[]
            {
                $"INSERT INTO match_info (horseId, secondRecorded) VALUES ('{HorseId}', '{SecondRecorded}')"
            };
            Connect connect = new Connect();
            connect.InsertQuery(queries);
        }

        public static List<Matchinfo> GetAllMatchInfo()
        {
            Connect c = new Connect();
            List<Matchinfo> matchInfoList = new List<Matchinfo>();

            string[] queries = new string[] { "SELECT * FROM match_info" };

            List<DataTable> result = c.ExecuteSelectQuery(queries);

            foreach (DataTable dataTable in result)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int horseId = int.Parse(row["horseId"].ToString());
                        int matchId = int.Parse(row["match_infoID"].ToString());
                        float secondRecord = float.Parse(row["secondRecorded"].ToString());

                        Matchinfo matchInfo = new Matchinfo(horseId, matchId, secondRecord);
                        matchInfoList.Add(matchInfo);
                    }
                }
            }

            return matchInfoList;
        }
    }
}
