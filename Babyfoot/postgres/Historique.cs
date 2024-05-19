using System.Collections.Generic;
using BabyFoot.connections;
using Npgsql;

namespace BabyFoot.postgres;

public class Historique
{
    String joueur1;
    String joueur2;
    double pari;
    String score;
    int nombreBall;
    double duree;

    public String getJoueur1() { return joueur1; }
    public String getJoueur2() { return joueur2; }
    public double getPari() { return pari; }
    public String getScore() { return score; }
    public int getNombreBall() { return nombreBall; }
    public double getDuree() { return duree; }

    public Historique(String joueur1, String joueur2, double pari, String score, int nombreBall, double duree) {
        this.joueur1 = joueur1;
        this.joueur2 = joueur2;
        this.pari = pari;
        this.score = score;
        this.nombreBall = nombreBall;
        this.duree = duree;
    }
    public Historique() {

    }

    public List<Historique> getHistoriques() {
        List<Historique> historiques = new List<Historique>();
        Connect connect = new Connect();
        NpgsqlConnection conn = connect.getNpgsqlConnection();

        conn.Open();

        NpgsqlCommand command = new NpgsqlCommand("SELECT *FROM historique", conn);
        NpgsqlDataReader dr = command.ExecuteReader();

        Historique historique = null;
        
        while (dr.Read()) {
            historique = new Historique((String)dr[0], (String)dr[1], (double)dr[2], (String)dr[3], (int)dr[4], (double)dr[5]);
            historiques.Add(historique);
        }

        conn.Close();
        return historiques;
    }
}