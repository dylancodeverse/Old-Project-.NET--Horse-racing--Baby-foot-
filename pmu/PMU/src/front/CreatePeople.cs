using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class CreatePeople : MyForm
    {
        TextBox peopleId;
        TextBox peopleName;
        TextBox peopleVariance;
        public People peopleCreated { get; set; }

        public CreatePeople(string title = "Create people", int taille_x = 400, int taille_y = 400, bool closing = false) : base(title, taille_x, taille_y, closing)
        {
            addLabel("Create people", 50, 40);
            addLabel("People ID:", 50, 80);
            peopleId = GetTextBox(150, 75);
            addLabel("People Name:", 50, 120);
            peopleName = GetTextBox(150, 115);
            addLabel("People Variance (separated by ';'):", 50, 160);
            peopleVariance = GetTextBox(250, 155);
            MyButton createBtn = new MyButton("Create people", 90, 200, createPeopleOnClick);
            addButton(createBtn);
            addTextBox(peopleId);
            addTextBox(peopleName);
            addTextBox(peopleVariance);
        }

        private void createPeopleOnClick(object sender, EventArgs e)
        {
            string id = peopleId.Text;
            string name = peopleName.Text;
            string varianceInput = peopleVariance.Text;

            List<PeopleMoneyPerDate> listVariance = new List<PeopleMoneyPerDate>();

            string[] varianceArray = varianceInput.Split(';');

            foreach (string varianceItem in varianceArray)
            {
                if (!string.IsNullOrWhiteSpace(varianceItem))
                {
                    string[] varianceValues = varianceItem.Split(',');
                    if (varianceValues.Length == 2 && float.TryParse(varianceValues[1], out float varianceAmount))
                    {
                        DateTime varianceDate;
                        if (DateTime.TryParse(varianceValues[0], out varianceDate))
                        {
                            PeopleMoneyPerDate variance = new PeopleMoneyPerDate
                            {
                                PeopleId = id,
                                Money = varianceAmount,
                                Date = varianceDate
                            };
                            variance.InsertPeopleMoneyPerDate();

                            listVariance.Add(variance);
                        }
                    }
                }
            }

            People people = new People(id, name, listVariance);

            // Insertion de l'objet People dans la base de données ou toute autre opération nécessaire
            people.InsertPeople();
            

            peopleCreated = people;
        }
    }
}
