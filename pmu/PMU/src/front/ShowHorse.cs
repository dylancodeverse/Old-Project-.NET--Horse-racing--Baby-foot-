using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class ShowHorse : MyForm
    {
        public List<Horse> selectedHorses { get; set; }
        List<Horse> horses { get; set; }
        TextBox input { get; set; }
        public bool transaction { get; set; }

        public ShowHorse(bool matchTransaction = false, string title = "Show horses", int taille_x = 600, int taille_y = 400, bool closing = false) : base(title, taille_x, taille_y, closing)
        {
            transaction = matchTransaction;
            addLabel("All horses", 300, 40);
            MyButton btn = new MyButton("Create horse", 350, 35, createHorseClick);
            dotransaction(matchTransaction);
            DataGridView table = MyForm.createTable(50, 160);

            table.Columns.Add("row", "row");
            table.Columns.Add("HorseNumber", "Horse Number");
            table.Columns.Add("HorseVitess", "Horse Vitess");

            // Données à récupérer
            horses = Horse.GetAllHorses();
            for (int i = 0; i < horses.Count; i++)
            {
                table.Rows.Add(i + 1, horses[i].HorseNumber, horses[i].HorseVitess);
            }

            addTable(table);
            addButton(btn);
        }

        private void dotransaction(bool transaction)
        {
            if (transaction)
            {
                addLabel("Choose row number:", 300, 80);
                input = GetTextBox(450, 75);
                addTextBox(input);
                MyButton btntrans = new MyButton("Continue", 300, 120, continueClick);
                addButton(btntrans);
            }
        }

        private void createHorseClick(object sender, EventArgs e)
        {
            CreateHorse ch = new CreateHorse();
            ch.Show();

            if (transaction)
            {
                ch.FormClosing += (s, args) =>
                {
                    // horse = ch.horseCreated;
                };
            }
            else
            {
                ch.FormClosing += (s, args) =>
                {
                    // horse = ch.horseCreated;
                    new ShowHorse().Show();
                };
            }

            this.Hide();
        }

        private void continueClick(object sender, EventArgs e)
        {
            var selectedRows = input.Text.Split(';');
            selectedHorses = new List<Horse>();

            foreach (var row in selectedRows)
            {
                var rowIndex = int.Parse(row.Trim()) - 1;
                if (rowIndex >= 0 && rowIndex < horses.Count)
                {
                    selectedHorses.Add(horses[rowIndex]);
                }
            }

            MessageBox.Show("Continue transaction!");
            this.Close();
        }
    }
}
