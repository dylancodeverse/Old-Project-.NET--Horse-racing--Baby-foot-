using BabyFoot.connections;
using Npgsql;

namespace BabyFoot.postgres;

public class NbVictoire
{
    int vict;
    int def;

    public NbVictoire(int vict, int def) {
        this.vict = vict;
        this.def = def;
    }

    public void augmenterLeNombreVictoire() {
        Connect connect = new Connect();
        NpgsqlConnection conn = connect.getNpgsqlConnection();

        conn.Open();

        NpgsqlTransaction tran = conn.BeginTransaction();

        NpgsqlCommand command = new NpgsqlCommand("INSERT INTO nombre_victoire VALUES(@vict, @def)", conn);
        command.Parameters.AddWithValue("@vict", vict);
        command.Parameters.AddWithValue("@def", def);
        command.ExecuteNonQuery();

        tran.Commit();
        conn.Close();
    }

    public int getNbVictoire() {
        Connect connect = new Connect();
        NpgsqlConnection conn = connect.getNpgsqlConnection();

        conn.Open();

        NpgsqlCommand command = new NpgsqlCommand("SELECT count(victoire) FROM nombre_victoire WHERE victoire=@vict AND defaite=@def", conn);
        command.Parameters.AddWithValue("@vict", vict);
        command.Parameters.AddWithValue("@def", def);
        NpgsqlDataReader dr = command.ExecuteReader();
        int nb = 0;
        while (dr.Read()) {
            nb = (int)(Int64)dr[0];
        }

        conn.Close();
        return nb;
    }
}