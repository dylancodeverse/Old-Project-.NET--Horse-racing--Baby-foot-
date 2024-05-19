
using System.Runtime.CompilerServices;
using BabyFoot.connections;
using foot.src.models;
using MySql.Data.MySqlClient;
using Npgsql;

static class Run_app{
        [STAThread]
        static void Main(){
            ApplicationConfiguration.Initialize();
            try{
            new FootRunner();

            }catch (Exception e){
                MessageBox.Show(e.StackTrace);
            }


        }    
    }
