public class Foot_form : MyForm{
    public Ball? bal { get; set; }
    public Team? team1 { get; set; }
    public Team? team2 { get; set; }
    public int x_direction { get; set; } = 2;
    public int y_direction { get; set; } = 0;
    public float pari {get ; set;} =0;
    public int stop {get; set;} =1;
    public Foot_form(string title, int size_x, int size_y ,Boolean closing ,Ball bal ,Team t1 ,Team t2 ,float p , int nb)
    : this(title,size_x ,size_y ,closing){
        this.bal =bal ;
        set_team(t1,t2);
        pari = p ;
        int a = nb/2 ;
        stop = a;
        MessageBox.Show(stop.ToString());
    }
    public Foot_form(string title, int size_x, int size_y ,Boolean closing) 
    : base(title, size_x, size_y, closing){
        new Foot_form_listener(this);
        this.set_background_color(62,196,120);
        this.DoubleBuffered = true;
        new MyTimer(10, () => OnTimer(null, null)).Start();
    }


    protected override void OnPaint(PaintEventArgs e) {
        base.OnPaint(e);
        Graphics g = e.Graphics;
        drawing_goals_and_line(g) ;
        drawing_teams(g) ;
        if (bal!=null){
            bal.drawing_the_ball(g);            
            style(g);
// ball
            bal.animate_the_ball(x_direction ,y_direction);
            checkCollision();
            checkIfBallonBord(bal) ;
        }        
    }

    private void drawing_goals_and_line(Graphics g){
        MyForm.fill_rect(g,0, 127, 20, 125 ,Color.Gray);
        MyForm.fill_rect(g,780, 127, 20, 125 ,Color.Gray);
        MyForm.drawLine(g,new Point(401,0) ,new Point(401,360),Color.White);
        MyForm.drawEllipse(g,387,174,30,30,Color.White);
    }
    private void style (Graphics g){
        if (team1!=null && team2 != null){
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;
            g.DrawString("Equipe Gauche :"+ team1.Score, font, brush, 186, 19);
            g.DrawString("Equipe Droite :"+ team2.Score, font, brush, 689, 19);
        }
    }

    private void OnTimer(object? sender, EventArgs? e){
        Invalidate();
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
    private void drawing_teams (Graphics g){
        if(team1!= null){
            team1.drawing_all_players(g);
        }
        if(team2!=null){
            team2.drawing_all_players(g) ;
        }
    }

    public void checkCollision(){
        team1.resetPlayersPossession();
        team2.resetPlayersPossession();
        int indice = team1.checkCollisionWithBall(bal) ;
        if ( indice== -1){
            indice = team2.checkCollisionWithBall(bal) ;
            if (indice == -1){
                return ;
            }else{
                team2.ListPlayer[indice].possession =true;
                team2.setPlayersPossession(indice);
            }
        }else{
            team1.ListPlayer[indice].possession =true;
            team1.setPlayersPossession(indice);
        } 
        x_direction =0;
        y_direction =0 ;
        bal.On_movement=false;
    }
    public void checkIfBallonBord (Ball ballon){
        if(ballon.Yposition <=12 ||  ballon.Yposition>359){
            y_direction*=-1 ;
        // amn sisiny ambony
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
                if(team1.Score > stop){
                    team1.winner(pari);
                    team2.loser(pari) ;
                    this.Dispose(true) ;
                }
            }
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
                if(team2.Score > stop){
                    team1.winner(pari);
                    team2.loser(pari);
                    this.Dispose(true);
                }
           }
           // sinon
           else
            x_direction *=-1 ;
        }
    }


}