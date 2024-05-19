// using BabyFoot.connections;
// using Npgsql;

// namespace BabyFoot.postgres;

// public class Vs
// {
//     int joueurId;
//     int score;
//     double pari;
//     int nbBallWin;

//     public void setScore(int score) { this.score = score; }
//     public void setJoueurId(int joueurId) { this.joueurId = joueurId; }
//     public void setPari(double pari) { this.pari = pari; }
//     public void setNbBallWin() {
//         Baby baby = new Baby();
//         Baby baby1 = baby.getBaby();
//         this.nbBallWin = (baby1.getNombreBall() / 2) + 1;
//     }

//     public Vs(int joueurId) {
//         this.joueurId = joueurId;
//     }

//     public Vs (double pari) {
//         setPari(pari);
//         setNbBallWin();
//     }

//     public int getScoreInVs() {
//         Connect connect = new Connect();
//         NpgsqlConnection conn = connect.getNpgsqlConnection();

//         conn.Open();

//         NpgsqlCommand command = new NpgsqlCommand("SELECT score FROM vs WHERE player_id="+this.joueurId, conn);
//         NpgsqlDataReader dr = command.ExecuteReader();
        
//         int s = 0;
//         while (dr.Read()) {
//             s = (int)dr[0];
//         }

//         conn.Close();
//         return s;
//     }

//     public static int[] getIdJoueurs() {
//         int[] idJoueurs = new int[2];
//         idJoueurs[0] = BabyFoot.terrain.Vs.getIdJoueur1();
//         idJoueurs[1] = BabyFoot.terrain.Vs.getIdJoueur2();
//         return idJoueurs;
//     }

//     public void updateScore() {
//         Connect connect = new Connect();
//         NpgsqlConnection conn = connect.getNpgsqlConnection();

//         conn.Open();

//         NpgsqlTransaction tran = conn.BeginTransaction();

//         int newScore = getScoreInVs() + 1;
//         NpgsqlCommand command = new NpgsqlCommand("UPDATE vs SET score="+newScore+" WHERE player_id="+joueurId, conn);
//         command.ExecuteNonQuery();

//         tran.Commit();
//         conn.Close();
//     }

//     public void insertInVs(int joueur1Id, int joueur2Id) {
//         Connect connect = new Connect();
//         NpgsqlConnection conn = connect.getNpgsqlConnection();

//         conn.Open();

//         NpgsqlTransaction tran = conn.BeginTransaction();
//         try {
//             NpgsqlCommand delete = new NpgsqlCommand("DELETE FROM vs", conn);
//             NpgsqlCommand command = new NpgsqlCommand("INSERT INTO vs VALUES(@pari, @score, @nbBallWin, @joueurId)", conn);
//             NpgsqlCommand command1 = new NpgsqlCommand("INSERT INTO vs VALUES(@pari, @score, @nbBallWin, @joueurId)", conn);

//             command.Parameters.AddWithValue("@pari", pari);
//             command.Parameters.AddWithValue("@score", 0);
//             command.Parameters.AddWithValue("@nbBallWin", nbBallWin);
//             command.Parameters.AddWithValue("@joueurId", joueur2Id);

//             command1.Parameters.AddWithValue("@pari", pari);
//             command1.Parameters.AddWithValue("@score", 0);
//             command1.Parameters.AddWithValue("@nbBallWin", nbBallWin);
//             command1.Parameters.AddWithValue("@joueurId", joueur1Id);

//             delete.ExecuteNonQuery();
//             command.ExecuteNonQuery();
//             command1.ExecuteNonQuery();

//             tran.Commit();
//         }
//         catch(Exception e) {
//             tran.Rollback();
//             MessageBox.Show(e.StackTrace);
//         }
//         finally {
//             conn.Close();
//         }
//     }
    
// }