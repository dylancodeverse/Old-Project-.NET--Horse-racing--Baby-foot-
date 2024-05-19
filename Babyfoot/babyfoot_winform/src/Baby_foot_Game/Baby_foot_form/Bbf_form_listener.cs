using System;

    public class Bbf_form_listener : MyIListener{
        private Bbf_form form;

        public Bbf_form_listener(Bbf_form j){
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
            MessageBox.Show("Position du clic: X = " + e.X + ", Y = " + e.Y);
        }
        public void KeyPressed(object sender, KeyPressEventArgs e){
            // MessageBox.Show("Touche pressée: " + );
            // juste hanamorako ny deplacement
            int add =0;
            if(form.bal.On_movement == true){
                add =10 ;
            }else {
                add =20 ;
            }

            char pressed =e.KeyChar ;
            if(pressed=='a'){
                form.team1.deplacer_en_bas_gardien(add);
            }
            else if(pressed=='s'){
                form.team1.deplacer_en_bas_defenses(add);
            }
            else if(pressed=='d'){
                form.team1.deplacer_en_bas_milieu(add);
            }
            else if(pressed=='f'){
                form.team1.deplacer_en_bas_attaque(add);
            }
            else if(pressed=='q'){
                form.team1.deplacer_en_haut_gardien(add);
            }
            else if(pressed=='w'){
                form.team1.deplacer_en_haut_defenses(add);
            }
            else if(pressed=='e'){
                form.team1.deplacer_en_haut_milieu(add);
            }
            else if(pressed=='r'){
                form.team1.deplacer_en_haut_attaque(add);
            }
            else if(pressed=='j'){
                form.team2.deplacer_en_bas_attaque(add);
            }
            else if(pressed=='k'){
                form.team2.deplacer_en_bas_milieu(add);
            }
            else if(pressed=='l'){
                form.team2.deplacer_en_bas_defenses(add);
            }
            else if(pressed==';'){
                form.team2.deplacer_en_bas_gardien(add);
            }
            else if(pressed=='u'){
                form.team2.deplacer_en_haut_attaque(add);
            }
            else if(pressed=='i'){
                form.team2.deplacer_en_haut_milieu(add);
            }
            else if(pressed=='o'){
                form.team2.deplacer_en_haut_defenses(add);
            }
            else if(pressed=='p'){
                form.team2.deplacer_en_haut_gardien(add);
            }
            else if(pressed=='1'){
                if(form.bal.On_movement== false){
                    form.x_direction =-2;
                    form.bal.On_movement =(true);
                }
            }
            else if(pressed=='2'){
                if(form.bal.On_movement== false){
                    form.x_direction =2;
                    form.bal.On_movement =(true);

                }
            }
            else if(pressed=='3'){
                if(form.bal.On_movement== false){
                    form.y_direction =-2;
                    form.bal.On_movement =(true);
                }
            }
            else if(pressed=='4'){
                if(form.bal.On_movement== false){
                    form.y_direction =2;
                    form.bal.On_movement =(true);
                }
            }
            else if (pressed=='b'){
                form.team1.ajoutGoal();
            }
            else if (pressed=='n'){
                form.team2.ajoutGoal();
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
