using System;
using System.Data;
using BabyFoot.connections;

namespace foot.src.models
{
    public class Rule
    {
        public string RuleId { get; set; }
        public int NumberOfBalls { get; set; }
        public float Money { get; set; }

        public Rule(string ruleId, int numberOfBalls, float money)
        {
            RuleId = ruleId;
            NumberOfBalls = numberOfBalls;
            Money = money;
        }

        public void InsertRule()
        {
            string[] queries = new string[]
            {
                $"INSERT INTO rule (rule_id, r_nb_of_ball, r_Money) VALUES ('{this.RuleId}', '{this.NumberOfBalls}', '{this.Money}')"
            };
            Connect connect = new Connect();
            connect.InsertQuery(queries);
        }

        public static List<Rule> GetAllRules()
        {
            Connect c = new Connect();
            List<Rule> rules = new List<Rule>();

            string[] queries = new string[] { "SELECT * FROM rule" };

            List<DataTable> result = c.ExecuteSelectQuery(queries);

            foreach (DataTable dataTable in result)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string RuleId = row["rule_id"].ToString();
                        int NumberOfBalls = int.Parse(row["r_nb_of_ball"].ToString());
                        float Money = float.Parse(row["r_Money"].ToString());

                        Rule rule = new Rule(RuleId, NumberOfBalls, Money);
                        rules.Add(rule);
                    }
                }
            }

            return rules;
        }
    }
}
