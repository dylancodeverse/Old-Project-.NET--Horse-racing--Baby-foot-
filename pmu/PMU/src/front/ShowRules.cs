using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class ShowRules : MyForm
    {
        public Rule? rule {get; set;}
        List<Rule> rules {get;set;}
        TextBox input {get;set;}
        public bool transaction {get;set;}
        public ShowRules(bool matchTransaction = false, string title ="Show rules", int taille_x=600, int taille_y=400, bool closing = false ) : base(title, taille_x, taille_y, closing)
        {
                transaction = matchTransaction ;
                addLabel("All rules" ,300 ,40); 
                MyButton btn  = (new MyButton("Create rule" ,350 ,35 , createRuleClick)) ;
                dotransaction(matchTransaction) ;
                DataGridView table = MyForm.createTable(50 ,160) ;

                table.Columns.Add("row" ,"row");
                table.Columns.Add("Id" ,"Id");
                table.Columns.Add("Bet" ,"Bet") ;
                table.Columns.Add("Second rule" ,"Second rule");
                table.Columns.Add("Added rule" ,"Added rule");

            // donnees mbola alaina 
                rules = Rule.GetAllRules();
                for (var i = 0; i < rules.Count(); i++)
                {
                    table.Rows.Add( i+1,rules[i].RuleId, rules[i].Bet,rules[i].SecondRule,rules[i].Added);
                }
                addTable(table);
                addButton(btn) ;
        }
        
        private void dotransaction(bool transaction){
            if(transaction){
                addLabel("Choose row number:" ,300, 80) ;
                input= GetTextBox(450 ,75) ;
                addTextBox(input);
                MyButton btntrans = new MyButton("Continue", 300 ,120 ,continueClick) ;
                addButton(btntrans) ;
            }

        }
        private void createRuleClick(object ? sender, EventArgs e)
        {
                CreateRules cr = new CreateRules() ;
                cr.Show();

            if(transaction){
                MessageBox.Show("In!");

                cr.FormClosing +=(s,e) =>{
                    rule =cr.ruleCreated ;
                };
            }else{
                cr.FormClosing +=(s,e) =>{
                    rule =cr.ruleCreated ;
                    new ShowRules().Show() ;
                };
            }
            this.Close() ;
        }
private void continueClick(object ? sender, EventArgs e)
{
    // Définir la règle sélectionnée
    rule = rules[int.Parse(input.Text) - 1];
    MessageBox.Show("Continue transaction!");

    // Appeler explicitement l'événement FormClosing
    this.Close(); 
}

    }
}