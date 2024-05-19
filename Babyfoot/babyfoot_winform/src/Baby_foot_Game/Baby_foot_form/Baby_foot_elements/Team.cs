using System.Drawing;
using System.Collections.Generic;

public class Team {
    List<Players>? list_player ;
    Color team_color ;
    bool left ;
    int [] post ;
    int score =0;
    int [] xpositiongauche = new int[] { 51, 169, 169, 169, 169, 337, 337, 337, 532, 532, 532 };
    int[] ypositiongauche = new int[] { 208, 64, 150, 230, 316, 107, 180, 260, 107, 180, 260 };
    int[] xpositiondroite = new int[] { 740, 673, 673, 673, 673, 441, 441, 441, 243, 243, 243 };
    int[] ypositiondroite = new int[] { 208, 316, 230, 150, 64, 260, 180, 107, 279, 185, 100 };

    public Team(List<Players> list ,Color color ,bool isleft){
        team_color=color ;
        left = isleft ;
        List<int> c = new List <int> () ;
        setListPlayer(list) ;
    }
    public List<Players> ListPlayer {
        get { return list_player; }
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

    public void drawing_all_players (Graphics g){
        if (list_player!=null){
            for (int i = 0; i < list_player.Count; i++){
                Players temp = list_player[i] ;
                MyForm.fill_rect(g,temp.getXposition(),temp.getYposition(),20,temp.height,team_color);
            }
        }
    }

    public void ajoutGoal() {
        list_player[0].height+=list_player[0].height ;
    }

    // deplacements:
    public void deplacer_en_haut_gardien(int add){
        Players temporaire= list_player[0] ; // maka anle joueur amn io indice io (avy amn vecteur)
        temporaire.setYposition(temporaire.getYposition()- add);
    }

    public void deplacer_en_bas_gardien(int add){
            Players temporaire= list_player[0] ; // maka anle Players amn io indice io (avy amn vecteur)
            temporaire.setYposition(temporaire.getYposition()+add);
    }
    public void deplacer_en_haut_defenses(int add){
        for (int i = 1; i < 5; i++) {
            Players temporaire= list_player[i] ; // maka anle Players amn io indice io (avy amn vecteur)
            temporaire.setYposition(temporaire.getYposition()-add);
        }
    }
    public void deplacer_en_bas_defenses(int add){
        for (int i = 1; i < 5; i++) {
            Players temporaire= list_player[i] ; // maka anle Players amn io indice io (avy amn vecteur)
            temporaire.setYposition(temporaire.getYposition()+add);
        }
    }
    public void deplacer_en_haut_milieu(int add){
        for (int i = 5; i < 8; i++) {
            Players temporaire= list_player[i] ; // maka anle Players amn io indice io (avy amn vecteur)
            temporaire.setYposition(temporaire.getYposition()-add);
        }
    }
    public void deplacer_en_bas_milieu(int add){
        for (int i = 5; i < 8; i++) {
            Players temporaire= list_player[i] ; // maka anle Players amn io indice io (avy amn vecteur)
            temporaire.setYposition(temporaire.getYposition()+add);
        }
    }
    public void deplacer_en_haut_attaque(int add){
        for (int i = 8; i < 11; i++) {
            Players temporaire= list_player[i] ; // maka anle Players amn io indice io (avy amn vecteur)
            temporaire.setYposition(temporaire.getYposition()-add);
        }
    }
    public void deplacer_en_bas_attaque(int add){
        for (int i = 8; i < 11; i++) {
            Players temporaire= list_player[i] ; // maka anle Players amn io indice io (avy amn vecteur)
            temporaire.setYposition(temporaire.getYposition()+add);
        }
    }



}