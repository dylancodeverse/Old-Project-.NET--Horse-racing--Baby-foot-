using System;
    public interface MyIListener{
        public void MouseEntered(object sender, EventArgs e);
        public void MouseExited(object sender, EventArgs e);
        public void MousePressed(object sender, MouseEventArgs e);
        public void MouseReleased(object sender, MouseEventArgs e);
        public void MouseClicked(object sender, MouseEventArgs e);
        public void MouseMoved(object sender, MouseEventArgs e);
        public void MouseDragged(object sender, MouseEventArgs e);
        public void KeyPressed(object sender, KeyPressEventArgs e);
        public void KeyDown(object sender, KeyEventArgs e);
        public void KeyUp(object sender, KeyEventArgs e);        
    }
