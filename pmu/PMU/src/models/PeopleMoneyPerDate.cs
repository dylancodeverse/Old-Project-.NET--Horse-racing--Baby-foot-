using System;
using System.Data;
using BabyFoot.connections;

public class PeopleMoneyPerDate
{
    public int Id { get; set; }
    public string PeopleId { get; set; }
    public float Money { get; set; }
    public DateTime Date { get; set; }

    public PeopleMoneyPerDate()
    {
    }

    public PeopleMoneyPerDate(int id, string peopleId, float money, DateTime date)
    {
        Id = id;
        PeopleId = peopleId;
        Money = money;
        Date = date;
    }

    public void InsertPeopleMoneyPerDate()
    {
        string[] queries = new string[]
        {
            $"INSERT INTO peopleMoneyPerDate (pMPD_peopleId, pMPD_money, pMPD_date) VALUES ('{this.PeopleId}', '{this.Money}', '{this.Date.ToString("yyyy-MM-dd")}')"
        };
        Connect connect = new Connect();
        connect.InsertQuery(queries);
    }

    public static List<PeopleMoneyPerDate> GetAllPeopleMoneyPerDate(string idPeople)
    {
        Connect c = new Connect();
        List<PeopleMoneyPerDate> peopleMoneyPerDates = new List<PeopleMoneyPerDate>();

        string[] queries = new string[] { $"SELECT * FROM peopleMoneyPerDate WHERE pMPD_peopleId = '{idPeople}'" };

        List<DataTable> result = c.ExecuteSelectQuery(queries);

        foreach (DataTable dataTable in result)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    int id = int.Parse(row["peopleMoneyPerDateId"].ToString());
                    string peopleId = row["pMPD_peopleId"].ToString();
                    float money = float.Parse(row["pMPD_money"].ToString());
                    DateTime date = DateTime.Parse(row["pMPD_date"].ToString());

                    PeopleMoneyPerDate peopleMoneyPerDate = new PeopleMoneyPerDate(id, peopleId, money, date);
                    peopleMoneyPerDates.Add(peopleMoneyPerDate);
                }
            }
        }

        return peopleMoneyPerDates;
    }
}
