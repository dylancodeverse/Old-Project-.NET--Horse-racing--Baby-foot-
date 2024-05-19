using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class ShowPeople : MyForm
    {
        public List<People> selectedPeople { get; set; }
        List<People> peopleList;
        DataGridView table;
        TextBox input;
        public bool transaction { get; set; }

        public ShowPeople(bool matchTransaction = false, string title = "Show people", int taille_x = 600, int taille_y = 400, bool closing = false) : base(title, taille_x, taille_y, closing)
        {
            transaction = matchTransaction;

            addLabel("All people", 300, 40);

            table = MyForm.createTable(50, 160);
            table.Columns.Add("row", "row");
            table.Columns.Add("People ID", "People ID");
            table.Columns.Add("People Name", "People Name");
            table.Columns.Add("People Pocket", "People Pocket");

            peopleList = People.GetAllPeople();

            for (int i = 0; i < peopleList.Count; i++)
            {
                table.Rows.Add(i + 1, peopleList[i].PeopleId, peopleList[i].PeopleName, peopleList[i].PeoplePocket);
            }

            addTable(table);

            MyButton createMatchButton = new MyButton("Create Match", 50, 300, createMatchButtonClick);
            addButton(createMatchButton);

            dotransaction(matchTransaction);
        }

        private void createMatchButtonClick(object? sender, EventArgs e)
        {
            new CreateMatchs().Show();
            this.Hide();
        }

        private void dotransaction(bool transaction)
        {
            if (transaction)
            {
                addLabel("Choose row number(s):", 300, 80);
                input = GetTextBox(450, 75);
                addTextBox(input);
                MyButton btntrans = new MyButton("Continue", 300, 120, continueClick);
                addButton(btntrans);
            }
        }

        private void continueClick(object? sender, EventArgs e)
        {
            var selectedRows = input.Text.Split(';');
            selectedPeople = new List<People>();

            foreach (var row in selectedRows)
            {
                var rowIndex = int.Parse(row.Trim()) - 1;
                if (rowIndex >= 0 && rowIndex < peopleList.Count)
                {
                    selectedPeople.Add(peopleList[rowIndex]);
                }
            }

            MessageBox.Show("Continue transaction!");
            this.Close();
        }
    }
}
