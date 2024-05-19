public class BabyFootRunner
{
    public BabyFootRunner(){
            List<Players> l1 = new List<Players> ();
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));
            l1.Add(new Players(15));

            List<Players> l2 = new List<Players> ();
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));
            l2.Add(new Players(15));

            Team t1 = new Team(l1 ,Color.Beige ,true);
            Team t2 = new Team(l2 ,Color.Coral ,false);

            var form = new Bbf_form("Baby-foot",815 ,400, true ,new Ball_(50,138,10,10),t1,t2);
            Application.Run(form);

    }
}