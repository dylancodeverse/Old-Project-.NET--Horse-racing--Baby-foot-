using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.utils.MyForm;

namespace PMU.src.front
{
    public class CreateHorse : MyForm
    {
        TextBox horseNumber ;
        TextBox horseVitess ;
        TextBox horseEndurance ;
        public Horse horseCreated {get ;set;}
        public CreateHorse(string title="Create horse", int taille_x =400, int taille_y=400, bool closing = false) : base(title, taille_x, taille_y, closing)
        {
            addLabel("Create horse" ,50 ,40); 
            addLabel("Horse num:" ,50 ,80);
            horseNumber =GetTextBox(150 ,75);
            addLabel("Horse vitess:" ,50 ,120);
            horseVitess =GetTextBox(150 ,115);
            addLabel("Horse endurance:" ,50 ,160);
            horseEndurance =GetTextBox(150 ,155);
            MyButton n = (new MyButton("Create horse" , 90 ,200, createHorseOnClick)) ;
            MyButton m = (new MyButton("Create match" , 90 ,240, createMatch)) ;
            addButton(n);
            addButton(m) ;
            addTextBox(horseNumber);
            addTextBox(horseVitess);
            addTextBox(horseEndurance);
        }

        private void createHorseOnClick (object ? sender, EventArgs e){
            string [] endurances = horseEndurance.Text.Split(";") ;
            float [] f = new float[endurances.Count()] ;
            for (var i = 0; i < endurances.Count(); i++)
            {
                f[i]= float.Parse (endurances[i]) ;
            }

            Horse h = new Horse(0,int.Parse(horseNumber.Text),float.Parse(horseVitess.Text),f,0) ;
            h.InsertHorse();
            horseCreated =h ;
        }
        private void createMatch(object ? sender, EventArgs e){
            new CreateMatchs().Show();
            this.Close();
        }
    }
}