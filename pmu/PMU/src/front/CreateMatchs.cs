using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.models;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class CreateMatchs : MyForm
    {
        TextBox inputName;

        public CreateMatchs(string title = "Create match", int taille_x = 400, int taille_y = 400, bool closing = false) : base(title, taille_x, taille_y, closing)
        {
            List<MyButton> buttons = new List<MyButton>();
            addLabel("Create match", 50, 40);
            addLabel("Name of the match:", 50, 80);
            inputName = GetTextBox(200, 75);
            addTextBox(inputName);
            buttons.Add(new MyButton("Create match", 200, 120, createMatchClick));
            buttons.Add(new MyButton("Create rule", 50, 160, createRuleClick));
            buttons.Add(new MyButton("Show rules", 200, 160, showRulesClick));
            buttons.Add(new MyButton("Show matches", 50, 200, showMatchesClick));
            buttons.Add(new MyButton("Create Horse", 200, 200, createHorseClick));
            buttons.Add(new MyButton("Show Horse", 50, 240, showHorseClick));
            buttons.Add(new MyButton("Create People", 200, 240, createPeopleClick));
            buttons.Add(new MyButton("Show People", 50, 280, showPeopleClick));
            addButton(buttons);
        }

        private void createMatchClick(object? sender, EventArgs e)
        {
            // mi creer objet match 
            Match match = new Match(0, inputName.Text, null, null);
            this.Hide();
            MessageBox.Show("Create!");
            // mi creer rules
            // CreateRules cr = new CreateRules();
            ShowRules sr = new ShowRules(true);
            sr.FormClosing += (s, args) =>
            { // miandry anle createRules ho tapitra
                if (sr.transaction)
                {
                    match.Rules = sr.rule;
                    if (match.Rules != null)
                    {
                        MessageBox.Show("Misafidy cheval");
                        ShowHorse sh = new ShowHorse(true) ;
                        sh.Show();

                        sh.FormClosing += (s,args) => {


                            if(sh.selectedHorses!=null){
                            
                                    // misafidy joueurs
                                ShowPeople sp = new ShowPeople(true) ;
                                sp.Show() ;
                                
                                sp.FormClosing += (s,args)=>{
                                    if(sp.selectedPeople !=null){
                                        MessageBox.Show(sp.selectedPeople.Count().ToString());
                                        ShowMatch va=  new ShowMatch(sh.selectedHorses ,sp.selectedPeople) ;
                                        va.Show();
                                        va.FormClosing += (s,args) => {
                                            if(va.horseInMatch!=null){
                                                match.ListHorse = va.horseInMatch ;
                                                Pist.Pist p = new Pist.Pist(match);
                                                p.Show();
                                            }
                                        };
                                    }
                                };

                            }
// 1;2;3
// 1,1;2,2;3,3
                        // alaina daholo ny cheval de mi choisir parieur

                        //  de zay vao mandeha ilay pmu

                        // rehefa vita ilay pmu de alaina ny resultat(liste ana horse in match)
                        };
                    }
                }
            };
            sr.Show();
            MessageBox.Show(sr.transaction.ToString());
        }

        private void createRuleClick(object? sender, EventArgs e)
        {
            this.Hide();
            new CreateRules().Show();
        }

        private void showMatchesClick(object? sender, EventArgs e)
        {
            MessageBox.Show("show matches!");
        }

        private void showRulesClick(object? sender, EventArgs e)
        {
            ShowRules sr = new ShowRules();
            sr.Show();
        }

        private void createHorseClick(object? sender, EventArgs e)
        {
            CreateHorse c= new CreateHorse();
            c.Show();
        }

        private void showHorseClick(object? sender, EventArgs e)
        {
            new ShowHorse().Show();
        }

        private void createPeopleClick(object? sender, EventArgs e)
        {
            new CreatePeople().Show();
        }

        private void showPeopleClick(object? sender, EventArgs e)
        {
            new ShowPeople().Show();
        }
    }
}
