using System.Data;
using BabyFoot.connections;
namespace foot.src.models{
    public class Person{
        private string id;
        private string name;
        private float pocket = 0;


        public Person(string id ,string name ,float pocket){
            this.id = id ;
            this.name =name; 
            this.pocket =pocket ;
        }

        public void InsertPerson(){
            string[] queries = new string[] {
                $"INSERT INTO person (person_id, person_name) VALUES ('{this.id}', '{this.name}')" ,
                $"INSERT INTO person_money (pm_person_id, pm_money) VALUES ('{this.id}', '{this.pocket}')" 
                };
                Connect connect = new Connect();
                connect.InsertQuery(queries);
        }
        public void InsertInPocket(){
            string[] queries = new string[] {
                $"INSERT INTO person_money (pm_person_id, pm_money) VALUES ('{this.id}', '{this.pocket}')" 
                };
                Connect connect = new Connect();
                connect.InsertQuery(queries);
        }

        public static List<Person> GetPersonsTotalMoney()
        {
            Connect c = new Connect();
            List<Person> persons = new List<Person>();

            string[] queries = new string[] { "SELECT * FROM view_person_with_total_money" };

            List<DataTable> result = c.ExecuteSelectQuery(queries);

            foreach (DataTable dataTable in result)
            {
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        string id = row["person_id"].ToString();
                        string name = row["person_name"].ToString();
                        float totalMoney = float.Parse(row["total_money"].ToString());

                        Person person = new Person(id, name, totalMoney);
                        persons.Add(person);
                    }
                }
            }

            return persons;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public float Pocket
        {
            get { return pocket; }
            set { pocket = value; }
        }
    }
}