using System;
using System.Data;
using BabyFoot.connections;

public class People
{
    public string PeopleId { get; set; }
    public string PeopleName { get; set; }
    public float PeoplePocket { get; set; }
    public List<PeopleMoneyPerDate> ListVariance { get; set; }

    public int PointerForVariance{get ;set;} 

    public People(string peopleId, string peopleName, List<PeopleMoneyPerDate> listVariance)
    {
        if (peopleId == null || peopleName == null || listVariance == null)
        {
            throw new Exception("Values cannot be null");
        }
        PeopleId = peopleId;
        PeopleName = peopleName;
        ListVariance = listVariance;
        PeoplePocket = 0;
        for (int i = 0; i < listVariance.Count(); i++)
        {
            PeoplePocket += listVariance[i].Money;
        }
        PointerForVariance = listVariance.Count()-1;
    }

        public void InsertRecentListVarianceAdded()
        {
            PointerForVariance += 1;
            for (int i = PointerForVariance; i < ListVariance.Count; i++)
            {
                ListVariance[i].InsertPeopleMoneyPerDate();
            }
            for (int i = PointerForVariance; i < ListVariance.Count; i++)
            {
                PeoplePocket += ListVariance[i].Money;
            }
        }


    public void InsertPeople()
    {
        string[] queries = new string[]
        {
            $"INSERT INTO people (peopleId, peopleName) VALUES ('{this.PeopleId}', '{this.PeopleName}')"
        };
        Connect connect = new Connect();
        connect.InsertQuery(queries);
    }


    public static List<People> GetAllPeople()
    {
        Connect c = new Connect();
        List<People> peopleList = new List<People>();

        string[] queries = new string[] { "SELECT * FROM people" };

        List<DataTable> result = c.ExecuteSelectQuery(queries);

        foreach (DataTable dataTable in result)
        {
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    string peopleId = row["peopleId"].ToString();
                    string peopleName = row["peopleName"].ToString();

                    // Get the list of PeopleMoneyPerDate for the current People
                    List<PeopleMoneyPerDate> listVariance = PeopleMoneyPerDate.GetAllPeopleMoneyPerDate(peopleId);

                    People people = new People(peopleId, peopleName, listVariance);
                    peopleList.Add(people);
                }
            }
        }

        return peopleList;
    }
}
