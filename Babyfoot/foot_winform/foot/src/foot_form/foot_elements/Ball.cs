using System.Drawing;
public class Ball {
    int xposition;
    int yposition;
    int width;
    int height ;
    bool on_movement =true;
    Color c;

    public Ball (int x ,int y , int w , int h , bool is_on_movement=true ){
        xposition =x ;
        yposition = y;
        width =w;
        height = h; 
        on_movement =is_on_movement ;
    }
    public void drawing_the_ball(Graphics g){
        MyForm.fill_oval(g,xposition,yposition,width,Color.Blue ) ;
    }
    public void move_the_ball(int x_add ,int y_add){
        xposition+=x_add;
        yposition += y_add;
    }

    public void animate_the_ball(int x_d ,int y_d){
        if (on_movement)
        {
            xposition+= x_d ;
            yposition+= y_d ;
            
        }
    }
    public int Xposition { get => xposition; set => xposition = value; }
    public int Yposition { get => yposition; set => yposition = value; }
    public int Width { get => width; set => width = value; }
    public int Height { get => height; set => height = value; }
    public bool On_movement { get => on_movement; set => on_movement = value; }
}