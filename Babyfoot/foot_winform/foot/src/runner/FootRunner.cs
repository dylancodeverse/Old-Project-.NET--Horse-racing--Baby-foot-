using foot.src.models;

public class FootRunner {
    public FootRunner(){
        Person p1 = new Person("Dylan","Dylan",1000);
        Person p2 = new Person("Alain","Alain",1000);
        Person p3 = new Person ("Lebron","Lebron",1000);
        Rule r = new Rule("5" ,5 ,100 ) ;
        MessageBox.Show(r.NumberOfBalls.ToString());
        float pari = 300;
        prepareGame(p1 ,p2 ,r, pari ,p3) ;
        game(p1,p2 ,r ,pari);
        p1.InsertInPocket();
        p2.InsertInPocket();
    }
    public void prepareGame(Person p1 ,Person p2 ,Rule r ,float pari ,Person owner){
        float de = 2 ;
        p1.Pocket= -1*r.Money/de ;
        p2.Pocket = -1*r.Money/de ;
        owner.Pocket = r.Money;
        owner.InsertInPocket();
        Match m = new Match(0,r.RuleId,DateTime.Now,pari) ;
        m.InsertMatch();
    }

    public void game(Person p1 ,Person p2 ,Rule r ,float pari){
        List<Players> l1 = new List<Players> ();
        l1.Add(new Players(15,15 ));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));
        l1.Add(new Players(15,15));

        List<Players> l2 = new List<Players> ();
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));
        l2.Add(new Players(15,15));

            Team t1 = new Team(l1 ,Color.Beige ,true ,p1);
            Team t2 = new Team(l2 ,Color.Coral ,false ,p2);
            var c= new Foot_form("Foot", 815,400,false ,new Ball(50,50,15,15) ,t1 ,t2,pari ,r.NumberOfBalls);
               Application.Run(c);
    }
}