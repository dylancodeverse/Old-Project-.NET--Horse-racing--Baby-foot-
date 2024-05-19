using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class CreateRules : MyForm
    {
        TextBox bet ;
        TextBox secondRule ;
        TextBox  added ;
        public Rule ? ruleCreated {get;set;}

        public CreateRules( string title ="Create rules", int taille_x =400, int taille_y=400, bool closing = false) : base(title, taille_x, taille_y, closing)
        {

            List<MyButton> buttons = new List<MyButton>();
            addLabel("Create rules" ,50 ,40); 

            addLabel("The bet :" ,50, 120) ;
            bet =GetTextBox(200,115);
            addLabel("The second rule :" ,50, 160) ;
            secondRule = GetTextBox(200 ,155);
            addLabel("Added :" ,50, 200) ;
            added =GetTextBox(200 ,195) ;

            addTextBox(bet);
            addTextBox(secondRule);
            addTextBox(added);

            buttons.Add(new MyButton("Create rule" , 200 ,235, createRuleClick)) ;
            buttons.Add( new MyButton("Create match",50 ,275, createMatchClick)) ;
            buttons.Add(new MyButton("Show rules" ,50 ,315  , showRulesClick)) ;
            buttons.Add(new MyButton("Show matches" ,200,275, showMatchesClick)) ;
            addButton(buttons);
        }
        private void createMatchClick(object ? sender, EventArgs e)
        {
            MessageBox.Show("Create!");
            new CreateMatchs().Show();
            this.Close() ;

        }
        private void createRuleClick(object ? sender, EventArgs e)
        {
            ruleCreated= new Rule(0,float.Parse (bet.Text) ,float.Parse(secondRule.Text),float.Parse(added.Text));
            MessageBox.Show("Create rule!");
            ruleCreated.InsertRule() ;
            // this.Hide();
        }
        private void showMatchesClick(object ? sender, EventArgs e)
        {
            MessageBox.Show("show matches!");
            // show all matches
        }
        private void showRulesClick(object ? sender, EventArgs e)
        {
            MessageBox.Show("show rules!");
            new ShowRules().Show();
            this.Close() ;
        }
    }
}