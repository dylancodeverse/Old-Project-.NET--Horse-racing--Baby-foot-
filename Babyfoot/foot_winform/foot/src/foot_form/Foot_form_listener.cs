using System ;

    public class Foot_form_listener :MyIListener{
        private Foot_form form ;

        public Foot_form_listener(Foot_form j){
            form = j;
            form.MouseEnter += MouseEntered;
            form.MouseLeave += MouseExited;
            form.MouseDown += MousePressed;
            form.MouseUp += MouseReleased;
            form.MouseClick += MouseClicked;
            form.MouseMove += MouseMoved;
            form.KeyDown += KeyDown;
            form.KeyUp += KeyUp;
            form.KeyPress += KeyPressed;
        }
        public void MouseClicked(object sender, MouseEventArgs e){
            // MessageBox.Show("Position du clic: X = " + e.X + ", Y = " + e.Y);
            int p = form.team1.checkCollisionWithCursor(e.X ,e.Y ,e.X ,e.Y);
            if (p ==-1){
                p = form.team2.checkCollisionWithCursor(e.X ,e.Y ,e.X ,e.Y) ;
                if (p!=-1){
                    form.team2.setPlayerActive(p);
                }
            }else{
                form.team1.setPlayerActive(p) ;
            }
            
        }
        public void KeyPressed(object sender, KeyPressEventArgs e){
            char pressed =e.KeyChar ;
            if(pressed=='w'){
                    int indice = form.team1.getPlayerActive();
                    if (indice!=-1)
                    {
                        form.team1.ListPlayer[indice].setYposition(form.team1.ListPlayer[indice].getYposition()-5);
                        if(form.team1.ListPlayer[indice].possession ) form.bal.move_the_ball(0,-5) ;
                    }
            }else if(pressed == 's') {

                    int indice = form.team1.getPlayerActive();
                    if (indice!=-1)
                    {
                        form.team1.ListPlayer[indice].setYposition(form.team1.ListPlayer[indice].getYposition()+5);
                        if(form.team1.ListPlayer[indice].possession ) form.bal.move_the_ball(0,+5) ;
                    }

            }else if (pressed== 'a'){

                int indice = form.team1.getPlayerActive();
                    if (indice!=-1)
                    {
                        form.team1.ListPlayer[indice].setXposition(form.team1.ListPlayer[indice].getXposition()-5);
                        if(form.team1.ListPlayer[indice].possession ) form.bal.move_the_ball(-5,0) ;
                    }

            }else if (pressed =='d'){

                int indice = form.team1.getPlayerActive();
                    if (indice!=-1)
                    {
                        form.team1.ListPlayer[indice].setXposition(form.team1.ListPlayer[indice].getXposition()+5);
                         if(form.team1.ListPlayer[indice].possession ) form.bal.move_the_ball(5,0) ;
                    }

            }else if(pressed == 'o') {

                int indice = form.team2.getPlayerActive();
                    if (indice!=-1)
                    {
                        form.team2.ListPlayer[indice].setYposition(form.team2.ListPlayer[indice].getYposition()-5);
                        if(form.team2.ListPlayer[indice].possession ) form.bal.move_the_ball(0,-5) ;                    }

            }else if (pressed== 'k'){
                int indice = form.team2.getPlayerActive();
                    if (indice!=-1)
                    {
                        form.team2.ListPlayer[indice].setXposition(form.team2.ListPlayer[indice].getXposition()-5);
                        if(form.team2.ListPlayer[indice].possession ) form.bal.move_the_ball(-5,0) ;                    }

            }else if (pressed ==';'){

                int indice = form.team2.getPlayerActive();
                    if (indice!=-1){
                        form.team2.ListPlayer[indice].setXposition(form.team2.ListPlayer[indice].getXposition()+5);
                        if(form.team2.ListPlayer[indice].possession ) form.bal.move_the_ball(5,0) ;                   
                    }

            }else if (pressed=='l'){
                int indice = form.team2.getPlayerActive();
                    if (indice!=-1)
                    {
                        form.team2.ListPlayer[indice].setYposition(form.team2.ListPlayer[indice].getYposition()+5);
                        if(form.team2.ListPlayer[indice].possession ) form.bal.move_the_ball(0,+5) ;
                    }
            }
            else if (pressed =='1'){
                if(form.bal.On_movement== false){
                    form.x_direction =-2;
                    form.bal.On_movement =(true);
                }

            }else if(pressed == '2') {
                if(form.bal.On_movement== false){
                    form.x_direction =2;
                    form.bal.On_movement =(true);

                }

            }else if (pressed== '3'){
                if(form.bal.On_movement== false){
                    form.y_direction =-2;
                    form.bal.On_movement =(true);
                }

            }else if (pressed =='4'){
                if(form.bal.On_movement== false){
                    form.y_direction =2;
                    form.bal.On_movement =(true);
                }
            }else if (pressed=='c'){
                if(!form.bal.On_movement){
                    int indice  = form.team1.getPlayerActive(); 
                    int indice2 = form.team2.getPlayerActive();
                    if (indice!=-1 && form.team1.ListPlayer[indice].possession && indice2 !=-1)
                    {
                            form.bal.Xposition =form.team2.ListPlayer[indice2].getXposition() ;
                            form.bal.Yposition = form.team2.ListPlayer[indice2].getYposition() ;
                            form.team2.ListPlayer[indice2].possession = true ;
                            form.team1.ListPlayer[indice].possession = false;
                    }else if(indice2!=-1 && form.team2.ListPlayer[indice2].possession&& indice!=-1) {
                            form.bal.Xposition =form.team1.ListPlayer[indice].getXposition() ;
                            form.bal.Yposition = form.team1.ListPlayer[indice].getYposition() ;
                            form.team1.ListPlayer[indice].possession = true ;
                            form.team2.ListPlayer[indice2].possession = false;
                    } 
                    
                }
            }

        }

        public void MouseEntered(object sender, EventArgs e){

        }

        public void MouseExited(object sender, EventArgs e){

        }

        public void MousePressed(object sender, MouseEventArgs e){
        }

        public void MouseReleased(object sender, MouseEventArgs e){
        }


        public void MouseMoved(object sender, MouseEventArgs e){
        }

        public void MouseDragged(object sender, MouseEventArgs e){

        }
        public void KeyDown(object sender, KeyEventArgs e){
            
        }
        public void KeyUp(object sender, KeyEventArgs e){

        } 

    }