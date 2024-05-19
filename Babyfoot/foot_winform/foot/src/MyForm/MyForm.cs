using System.Reflection.Emit;
using System;
using System.Text;
using System.Security.AccessControl;
using System.Windows.Forms;

public class MyForm : Form{
    public MyForm(string title, int taille_x, int taille_y ,Boolean closing  = false) {
        Text = title;
        Size = new System.Drawing.Size(taille_x, taille_y);
        if (closing){
            FormClosing += MyForm_FormClosing;
        }
    }   
    public MyForm(string title) : this(title, 500, 500) {
    }
    public MyForm() : this("Ma fenêtre") {
    }
    private void MyForm_FormClosing(object ? sender, FormClosingEventArgs ? e) {
        Application.Exit();
    }
    protected void set_background_color(int r ,int g ,int b){
        this.BackColor = Color.FromArgb(r,g,b);
    }
    public static void fill_rect(Graphics g , int x ,int y ,int width , int height ,Color c) {
        SolidBrush color = new SolidBrush(c);
        g.FillRectangle(color, x, y, width, height);
    }
    public static void fill_oval(Graphics g , int x ,int y, int diameter , Color c){
        Brush brush = new SolidBrush(c); 
        g.FillEllipse(brush, x, y, diameter, diameter);
    }
    public static void drawLine(Graphics graphics, Point startPoint, Point endPoint ,Color c){
        Pen pen = new Pen(c, 1);
        graphics.DrawLine(pen, startPoint, endPoint);
        pen.Dispose();
    }
    public static void drawEllipse(Graphics graphics , int x ,int y ,int w , int h ,Color c){
        Pen pen = new Pen(c, 2);
        graphics.DrawEllipse(pen, x, y, w, h);
    }
    public static System.Windows.Forms.Label drawLabel (String text , int x , int y ){
        System.Windows.Forms.Label label = new System.Windows.Forms.Label();
        label.Text = text;
        label.Location = new Point(x, y);
        // label.Font = new Font("Arial", 12);
        return label ;
    }
}
