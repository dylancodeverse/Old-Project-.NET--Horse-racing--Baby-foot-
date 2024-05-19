using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class Bbf_form : MyForm{

    public Ball_ bal { get; set; }

    public int[] Xpositiongauche_possible { get; } = new int[] { 51, 80, 169, 200, 337, 365, 532, 561 };

    public int[] Xpositiondroite_possible { get; } = new int[] { 243, 271, 441, 470, 673, 701, 740, 768 };

    public Team? team1 { get; set; }

    public Team? team2 { get; set; }

    public int x_direction { get; set; } = 2;

    public int y_direction { get; set; } = 0;
    
    // public int nb_bal =
    
    public Bbf_form(string title, int size_x, int size_y ,Boolean closing ,Ball_ bal ,Team t1 ,Team t2)
    : this(title,size_x ,size_y ,closing){
        this.bal =bal ;
        set_team(t1,t2);
    }
    public Bbf_form(string title, int size_x, int size_y ,Boolean closing) 
    : base(title, size_x, size_y, closing){
        new Bbf_form_listener(this);
        this.set_background_color(62,196,120);
        this.DoubleBuffered = true;
        new MyTimer(10, () => OnTimer(null, null)).Start();
    }

    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        drawing_goals_and_line(g) ;
        drawing_teams(g) ;
        bal.drawing_the_ball(g);
        bal.move_the_ball(x_direction ,y_direction);
        int position_x = checkBallonPosition_x(bal) ;
        checkBallonPosition_y(bal ,position_x) ;
        Font font = new Font("Arial", 12);
        Brush brush = Brushes.Black;
        g.DrawString("Equipe Gauche :"+ team1.Score, font, brush, 186, 19);
        g.DrawString("Equipe Droite :"+ team2.Score, font, brush, 689, 19);

    }
    private void OnTimer(object? sender, EventArgs? e){
        Invalidate();
    }
    private void drawing_goals_and_line(Graphics g){
        MyForm.fill_rect(g,0, 127, 20, 125 ,Color.Gray);
        MyForm.fill_rect(g,780, 127, 20, 125 ,Color.Gray);
        MyForm.drawLine(g,new Point(401,0) ,new Point(401,360),Color.White);
        MyForm.drawEllipse(g,387,174,30,30,Color.White);

    }
    private void drawing_teams (Graphics g){
        if(team1!= null){
            team1.drawing_all_players(g);
        }
        if(team2!=null){
            team2.drawing_all_players(g) ;
        }
    }
    public void set_team(Team t1 ,Team t2){
        if(t1 != null && t2 !=null){
            if (t1.Left){
                team1=t1;
                team2=t2;
            }
            else{
                team1=t2;
                team2 =t1;
            }
        }

    }
    public int checkBallonPosition_x(Ball_ ball){
        int position_ball = ball.Xposition ;
        for (int i = 0; i < Xpositiongauche_possible.Count() ; i+=2) {
            if(Xpositiongauche_possible[i]<= position_ball && position_ball <= Xpositiongauche_possible[i+1] ){
                return -1 ;// gauche
            }
        }
        for (int i = 0; i < Xpositiondroite_possible.Count() ; i+=2) {
            if(Xpositiondroite_possible[i]<= position_ball && position_ball <= Xpositiondroite_possible[i+1] ){
                return 1 ; // droite
            }
        }
        return 0 ; // sady tsy gauche no tsy droite
    }
    public void checkBallonPosition_y (Ball_ ballon , int position_x){
        if(position_x==0){
            checkIfBallonBord(ballon);
        }
        else if(position_x == -1) { // zany hoe team1
            List <Players>  list = team1.ListPlayer ;
            for (int i = 0; i < list.Count(); i++) {
                if(list[i].getYposition()<=ballon.Yposition && 
                    ballon.Yposition <= list[i].getYposition()+list[i].height && 
                    list[i].getXposition() <=ballon.Xposition &&
                    ballon.Xposition < list[i].getXposition() +10
                ){ // satria nataoko 15 ny height an'ny joueur rehetra
                    x_direction =0 ;
                    y_direction =0 ;
                    ballon.On_movement =false;
                    // x_direction*=-1;
                  break ;
                }
            }
            checkIfBallonBord(ballon);
        }else { // zany hoe equipe2
            List <Players> list = team2.ListPlayer ;
            for (int i = 0; i < list.Count(); i++) {
                if(list[i].getYposition()<=ballon.Yposition && 
                ballon.Yposition <= list[i].getYposition()+list[i].height && 
                list[i].getXposition() <=ballon.Xposition &&
                ballon.Xposition < list[i].getXposition() +10)  { // satria nataoko 15 ny height an'ny joueur rehetra
                    x_direction =0;
                    y_direction =0 ;
                    ballon.On_movement =false;
                    // x_direction*=-1;
                    break ;
                }
            }
            checkIfBallonBord(ballon);
        }
    }


    public void checkIfBallonBord (Ball_ ballon){
        if(ballon.Yposition <=12 ||  ballon.Yposition>359){
            y_direction*=-1 ;

        }
        else if (ballon.Xposition >=790){ 
            // akaiky ny but an'ny equipe 2
            // raha ohatra ka maty de maty
            if( 127< ballon.Yposition && ballon.Yposition<253) {
                x_direction=0;
                y_direction =0;
                ballon.On_movement = false ;
                ballon.Xposition = team2.ListPlayer[0].getXposition();
                ballon.Yposition = team2.ListPlayer[0].getYposition();
                team1.Score ++ ;
                if(team1.Score > 2){
                    MessageBox.Show("Nandresy e1");
                    // this.;
                }
            }
            // sinon
            else 
            x_direction *=-1 ;
        }        

        else if (ballon.Xposition <=0){
            // akaiky ny but an'ny equipe 1
            // raha ohatra ka maty de maty
            if( 127< ballon.Yposition && ballon.Yposition<253){
                x_direction=0;
                y_direction =0;
                ballon.On_movement=false;
                ballon.Xposition = team1.ListPlayer[0].getXposition();
                ballon.Yposition = team1.ListPlayer[0].getYposition();
                team2.Score ++ ;
                if(team2.Score > 2){
                    MessageBox.Show("Nandresy e2");
                }

            }
           // sinon
           else
            x_direction *=-1 ;
        }

    }

}


