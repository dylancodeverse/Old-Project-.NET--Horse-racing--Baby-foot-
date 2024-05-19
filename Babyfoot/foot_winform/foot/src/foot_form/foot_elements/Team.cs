using System.Drawing;
using System.Collections.Generic;
using foot.src.models;

public class Team {
    List<Players> list_player ;
    Color team_color ;
    bool left ;
    int playersActive =-1 ;

     int playersPossession =-1 ;
    int score =0;
    int [] xpositiongauche = new int[] { 51, 169, 169, 169, 169, 337, 337, 337, 532, 532, 532 };
    int[] ypositiongauche = new int[] { 208, 64, 150, 230, 316, 107, 180, 260, 107, 180, 260 };
    int[] xpositiondroite = new int[] { 740, 673, 673, 673, 673, 441, 441, 441, 243, 243, 243 };
    int[] ypositiondroite = new int[] { 208, 316, 230, 150, 64, 260, 180, 107, 279, 185, 100 };

    public Person p1 ;
    
    public Team(List<Players> list ,Color color ,bool isleft ,Person p){
        team_color=color ;
        left = isleft ;
        list_player = list ;
        setListPlayer(list_player);
        p1=p ;
    }
    public void winner (float pari){
        p1.Pocket+= pari ;

    }
    public void loser(float pari ){
        p1.Pocket-= pari ;
    }
    public void resetPlayersPossession(){
        if (playersPossession==-1){
            return ;
        }else{
            list_player[playersPossession].possession = false ;
            playersPossession=-1 ;
        }
    }
    public void setPlayersPossession(int a){
        playersPossession =a;
    }
    public int getPlayerActive (){
        return playersActive ;
    }
    public void setPlayerActive ( int p){
        playersActive = p ;
    }
    public void setListPlayer (List<Players> players){
        if (left){
            // tous les Playerss sont à gauche
            for (int i = 0; i < players.Count; i++){
                players[i].setXposition(xpositiongauche[i]);
                players[i].setYposition(ypositiongauche[i]);
            }
        }
        else{
            // tous les Playerss sont à droite
            for (int i = 0; i < players.Count; i++){
                players[i].setXposition(xpositiondroite[i]);
                players[i].setYposition(ypositiondroite[i]);
            }
        }
        this.list_player = players;
    }

    public List<Players> ListPlayer {
        get { return list_player; }
        set {list_player =value;}
    }

    public int Score {
        get { return score ;}
        set { score=value ;}
    }

    public Color TeamColor {
        get { return team_color; }
        set { team_color = value; }
    }

    public bool Left {
        get { return left; }
        set { left = value; }
    }
    public void drawing_all_players (Graphics g){
        if (list_player!=null){
            for (int i = 0; i < list_player.Count; i++){
                Players temp = list_player[i] ;
                MyForm.fill_rect(g,temp.getXposition(),temp.getYposition(),20,temp.height,team_color);
            }
        }
    }
    public int checkCollisionWithCursor(int x , int y ,int x_limit ,int y_limit) {
        for (int i = 0; i < list_player.Count; i++){
            if ( list_player[i].getXposition() <= x && x<=list_player[i].getXposition_limit () ||
            list_player[i].getXposition() <= x_limit && x_limit<=list_player[i].getXposition_limit () ){
                if (list_player[i].getYposition() <= y && y<=list_player[i].getYposition_limit ()||
            list_player[i].getYposition() <= y_limit && y_limit<=list_player[i].getYposition_limit () ){
                    return i ;                   
                }
            }
        }
        return -1 ;
    }

    public  int checkCollisionWithBall(Ball? bal)
    {
        return checkCollisionWithCursor(bal.Xposition ,bal.Yposition ,bal.Xposition +bal.Width ,bal.Yposition+bal.Height) ;
    }
    public bool changeCursor(int x ,int y){
         int rep = checkCollisionWithCursor(x,y,x,y);
        playersActive =rep ;
        if (rep ==-1)
        {
            return false ;            
        }
        return true ;
    }

}