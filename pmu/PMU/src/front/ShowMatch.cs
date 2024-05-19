using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class ShowMatch : MyForm
    {
        List<Horse> horses;
        List<People> people;
        TextBox input;
        public List<HorseInMatch> horseInMatch { get; set; }

        public ShowMatch(List<Horse> horses, List<People> people, string title = "Create Match", int taille_x = 600, int taille_y = 800, bool closing = false) : base(title, taille_x, taille_y, closing)
        {
            this.horses = horses;
            this.people = people;

            addLabel("Create Match", 300, 40);

            addLabel("Horses:", 50, 80);
            addLabel("People:", 600, 80);

            addLabel("Enter horse and people associations:", 50, 250);
            input = GetTextBox(300, 245);
            addTextBox(input);

            DataGridView horseTable = MyForm.createTable(50, 320);
            horseTable.Columns.Add("row", "row");
            horseTable.Columns.Add("HorseNumber", "Horse Number");
            horseTable.Columns.Add("HorseVitess", "Horse Vitess");

            DataGridView peopleTable = MyForm.createTable(600, 320);
            peopleTable.Columns.Add("row", "row");
            peopleTable.Columns.Add("People ID", "People ID");
            peopleTable.Columns.Add("People Name", "People Name");
            peopleTable.Columns.Add("People Pocket", "People Pocket");

            for (int i = 0; i < horses.Count; i++)
            {
                horseTable.Rows.Add(i + 1, horses[i].HorseNumber, horses[i].HorseVitess);
            }

            for (int i = 0; i < people.Count; i++)
            {
                peopleTable.Rows.Add(i + 1, people[i].PeopleId, people[i].PeopleName, people[i].PeoplePocket);
            }

            addTable(horseTable);
            addTable(peopleTable);

            MyButton createMatchButton = new MyButton("Create Match", 50, 290, createMatchButtonClick);
            addButton(createMatchButton);
        }

        private void createMatchButtonClick(object? sender, EventArgs e)
        {
            var associations = input.Text.Split(';');
            horseInMatch = new List<HorseInMatch>();

            foreach (var association in associations)
            {
                var associationParts = association.Trim().Split(',');

                if (associationParts.Length >= 2)
                {
                    var horseIndex = int.Parse(associationParts[0].Trim()) - 1;

                    if (horseIndex >= 0 && horseIndex < horses.Count)
                    {
                        var peopleIds = associationParts.Skip(1).ToList();
                        var peopleList = people.Where(person => peopleIds.Contains(person.PeopleId)).ToList();

                        var horse = horses[horseIndex];
                        var horseInMatchItem = new HorseInMatch(horse.HorseId, 0, horse.HorseNumber, horse.HorseVitess, horse.HorseEndurance, horse.IndexOfHorseEndurance, peopleList, 0);
                        horseInMatch.Add(horseInMatchItem);
                    }
                }
            }

            MessageBox.Show("Match created!");
            this.Close();
        }
    }
}
