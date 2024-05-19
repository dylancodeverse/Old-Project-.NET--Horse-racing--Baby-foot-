public class Players {
    private int xposition;
    private int yposition;
    private int yposition_limit;

    public bool possession =false ;
    private int xposition_limit ;
    public int height ;
    public int width ;
    public Players (int h , int w){
        height = h;
        width = w ;
    }

    public void setXposition(int xposition) {
        this.xposition = xposition;
        this.xposition_limit =xposition+ width ;
    }

    public int getXposition() {
        return xposition;
    }

    public void setYposition(int yposition) {
        this.yposition = yposition;
        this.yposition_limit =yposition+this.height;
    }
    public int getXposition_limit(){
        return xposition_limit ;
    }

    public int getYposition() {
        return yposition;
    }

    public void setYposition_limit(int yposition_limit) {
        this.yposition_limit = yposition_limit;
    }

    public int getYposition_limit() {
        return yposition_limit;
    }
}
