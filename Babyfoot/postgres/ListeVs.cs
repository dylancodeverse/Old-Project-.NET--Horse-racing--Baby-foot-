using BabyFoot.connections;
using Npgsql;

namespace BabyFoot.postgres;

public class ListeVs
{
    int id;
    double pari;
    String score;
    int nombre_ball;
    double duree;
    int joueur1Id;
    int joueur2Id;

    public void setId(int id) { this.id = id; }
    public void setPari(double pari) { this.pari = pari; }
    public void setScore(String score) { this.score = score; }
    public void setDuree(double duree) { this.duree = duree; }
    public void setNombreBall(int nombre_ball) { this.nombre_ball = nombre_ball; }
    public void setJoueur1Id(int joueur1Id) { this.joueur1Id = joueur1Id; }
    public void setJoueur2Id(int joueur2Id) { this.joueur2Id = joueur2Id; }

    public ListeVs(double pari, String score, double duree, int nombre_ball, int joueur1Id, int joueur2Id) {
        setPari(pari);
        setScore(score);
        setDuree(duree);
        setNombreBall(nombre_ball);
        setJoueur1Id(joueur1Id);
        setJoueur2Id(joueur2Id);
    }

    public void insertListeVs() {
        Connect connect = new Connect();
        NpgsqlConnection conn = connect.getNpgsqlConnection();

        conn.Open();

        NpgsqlTransaction tran = conn.BeginTransaction();

        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO liste_vs VALUES(default, @pari, @score, @nombre_ball, @duree, @player1_id, @player2_id)", conn);
        command.Parameters.AddWithValue("@pari", pari);
        command.Parameters.AddWithValue("@score", score);
        command.Parameters.AddWithValue("@nombre_ball", nombre_ball);
        command.Parameters.AddWithValue("@duree", duree);
        command.Parameters.AddWithValue("@player1_id", joueur1Id);
        command.Parameters.AddWithValue("@player2_id", joueur2Id);
        command.ExecuteNonQuery();

        tran.Commit();
        conn.Close();
    }
}