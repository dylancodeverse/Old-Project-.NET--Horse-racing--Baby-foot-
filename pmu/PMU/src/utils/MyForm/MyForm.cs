using System.Reflection.Emit;
using System;
using System.Text;
using System.Security.AccessControl;
using System.Windows.Forms;
using PMU.src.utils.MyForm;

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

    protected void closeMyForm(){
        this.Dispose(true);
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
        label.AutoSize = true;
        label.Text = text;
        label.Location = new Point(x, y);
        // label.Font = new Font("Arial", 12);
        return label ;
    }
    protected void addButton(MyButton btn){
        Controls.Add(btn) ;
    }
    protected void addLabel(String text , int x , int y){
        Controls.Add(MyForm.drawLabel(text , x , y)) ;
    }
    protected void addButton(List<MyButton> ls ){
        for (var i = 0; i < ls.Count(); i++)
        {
            Controls.Add(ls[i]);
        }
    }

    public static TextBox GetTextBox(int x ,int y){
        TextBox t = new TextBox() ;
        t.Location = new System.Drawing.Point(x, y);
        return t;
    }

    // protected void addTextBox( int x, int y){
    //     Controls.Add(GetTextBox(x,y)) ;
    // }
    protected void addTextBox(TextBox t){
        Controls.Add(t);
    }

    public static DataGridView createTable(int x , int y){
        DataGridView dataGridView = new DataGridView();
        dataGridView.Location = new System.Drawing.Point(x, y);
        dataGridView.AutoSize = true ;
        dataGridView.BackgroundColor = System.Drawing.Color.White;
        return dataGridView ;
    }
    protected void addTable(DataGridView table){
        Controls.Add(table);
    }
    
}
