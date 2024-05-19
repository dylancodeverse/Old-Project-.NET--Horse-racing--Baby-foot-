using System.Data;
using BabyFoot.connections;

public class Rule
{
    public int RuleId { get; set; }
    public float Bet { get; set; }
    public float SecondRule { get; set; }
    public float Added { get; set; }

    public Rule(int ruleId, float bet, float secondRule, float added)
    {
        RuleId = ruleId;
        Bet = bet;
        SecondRule = secondRule;
        Added = added;
    }

    public void InsertRule()
    {
        string[] queries = new string[]
        {
            $"INSERT INTO rule (bet, secondRule, added) VALUES ('{this.Bet}', '{this.SecondRule}', '{this.Added}')"
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
                    int ruleId = int.Parse(row["ruleId"].ToString());
                    float bet = float.Parse(row["bet"].ToString());
                    float secondRule = float.Parse(row["secondRule"].ToString());
                    float added = float.Parse(row["added"].ToString());

                    Rule rule = new Rule(ruleId, bet, secondRule, added);
                    rules.Add(rule);
                }
            }
        }

        return rules;
    }
    public static Rule GetRuleById(int ruleId){
        Connect c = new Connect();
        Rule rule = null;

        string[] queries = new string[] { $"SELECT * FROM rule WHERE ruleId = {ruleId}" };

        List<DataTable> result = c.ExecuteSelectQuery(queries);

        foreach (DataTable dataTable in result)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    int id = int.Parse(row["ruleId"].ToString());
                    float bet = float.Parse(row["bet"].ToString());
                    float secondRule = float.Parse(row["secondRule"].ToString());
                    float added = float.Parse(row["added"].ToString());

                    rule = new Rule(id, bet, secondRule, added);
                }
            }
        }

        return rule;
    }

}
