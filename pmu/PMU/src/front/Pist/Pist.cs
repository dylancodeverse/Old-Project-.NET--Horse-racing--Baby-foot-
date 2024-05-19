using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMU.src.models;

namespace PMU.src.front.Pist
{
    public class Pist : MyForm
    {
        public  Match match {get;set;}
        public Pist( Match m  ,string title="Piste", int taille_x=800, int taille_y=800, bool closing = false) : base(title, taille_x, taille_y, closing)
        {
            match =m ;
            new MyTimer(10, () => OnTimer(null, null)).Start();
        }
        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            drawPiste(g) ;      
        }


        public void drawPiste(Graphics g){
            drawPiste2(g, match.ListHorse.Count, 400, 400, 250, 150, 20);
        }

        public void drawPiste2(Graphics g, int numRectangles, int startX, int startY, int width, int height, int spacing)
        {
            int x = startX;
            int y = startY;
            int rectWidth = width;
            int rectHeight = height;

            for (int i = 0; i < numRectangles; i++)
            {
                DrawRoundedRectangle(g, x, y, rectWidth, rectHeight);
                // Mettez à jour les dimensions pour le prochain rectangle
                x -= spacing; // Ajustez la position horizontale pour créer un espacement égal
                y -= spacing; // Ajustez la position verticale pour créer un espacement égal
                rectWidth += 2 * spacing; // Augmentez la largeur pour créer un rectangle plus grand
                rectHeight += 2 * spacing; // Augmentez la hauteur pour créer un rectangle plus grand
            }
        }

        public void DrawRoundedRectangle(Graphics g, int x, int y, int width, int height)
        {
            int radius = height / 2; // Rayon pour former un demi-cercle
            // Dessine les côtés du rectangle
            g.DrawLine(Pens.Black, x + radius, y, x + width - radius, y);
            g.DrawLine(Pens.Black, x + radius, y + height, x + width - radius, y + height);
            // Dessine les demi-cercles sur les côtés
            g.DrawArc(Pens.Black, x, y, radius * 2, height, 90, 180);
            g.DrawArc(Pens.Black, x + width - radius * 2, y, radius * 2, height, 270, 180);
        }

        private void OnTimer(object? sender, EventArgs? e){
            Invalidate();
        }

    }
}