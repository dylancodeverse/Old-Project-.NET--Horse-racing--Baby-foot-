namespace babyfoot_winform{
    static class Run_app{
        [STAThread]
        static void Main(){
            ApplicationConfiguration.Initialize();
            new BabyFootRunner();

        }    
    }
}
