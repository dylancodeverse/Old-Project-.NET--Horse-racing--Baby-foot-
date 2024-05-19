using BabyFoot.connections;
using Npgsql;

namespace BabyFoot.postgres;

public class Baby
{
    int id;
    double jeton;
    int nombreBall;
    double montant;

    public void setId(int id) { this.id = id; }
    public void setJeton(double jeton) { this.jeton = jeton; }
    public void setNombreBall(int nombreBall) { this.nombreBall = nombreBall; }
    public void setMontant(double jeton) { 
        this.montant = this.montant + jeton; 
    }

    public int getId() { return id; }
    public double getJeton() { return jeton; }
    public int getNombreBall() { return nombreBall; }
    public double getMontant() { return montant; }

    public Baby(int id, double jeton, int nombreBall, double montant) {
        this.setId(id);
        this.setJeton(jeton);
        this.setNombreBall(nombreBall);
        this.montant = montant;
    }

    public Baby() {

    }
    public Baby getBaby() {
        Connect connect = new Connect();
        NpgsqlConnection conn = connect.getNpgsqlConnection();

        conn.Open();

        NpgsqlCommand command = new NpgsqlCommand("SELECT *FROM baby", conn);
        NpgsqlDataReader dr = command.ExecuteReader();

        Baby baby = null;
        
        while (dr.Read()) {
            baby = new Baby((int)dr[0], (double)dr[1], (int)dr[2], (double)dr[3]);
        }

        conn.Close();
        return baby;
    }
}