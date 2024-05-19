using System;
using System.Collections.Generic;
using System.Data;
using BabyFoot.connections;
using MySql.Data.MySqlClient;

namespace foot.src.models
{
    public class PersonMoney
    {
        private int id;
        private string personId;
        private float money;
        private DateTime date;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string PersonId
        {
            get { return personId; }
            set { personId = value; }
        }

        public float Money
        {
            get { return money; }
            set { money = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public PersonMoney(int id, string personId, float money, DateTime date)
        {
            this.id = id;
            this.personId = personId;
            this.money = money;
            this.date = date;
        }

        public void InsertPersonMoney()
        {
            string[] query ={ $"INSERT INTO person_money (pm_person_id, pm_money, pm_date) VALUES ('{personId}', '{money}', '{date.ToString("yyyy-MM-dd")}')"};

            Connect connect = new Connect();
            connect.InsertQuery(query);
        }

         public static List<PersonMoney> GetAllPersonMoney()
        {
            List<PersonMoney> personMoneyList = new List<PersonMoney>();

            string query = "SELECT * FROM person_money";

            Connect connect = new Connect();
            List<DataTable> result = connect.ExecuteSelectQuery(new string[] { query });

            foreach (DataTable dataTable in result)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = Convert.ToInt32(row["person_money_id"]);
                        string personId = row["pm_person_id"].ToString();
                        float money = Convert.ToSingle(row["pm_money"]);
                        DateTime date = Convert.ToDateTime(row["pm_date"]);

                        PersonMoney personMoney = new PersonMoney(id, personId, money, date);
                        personMoneyList.Add(personMoney);
                    }
                }
            }

            return personMoneyList;
        }
    }
}
