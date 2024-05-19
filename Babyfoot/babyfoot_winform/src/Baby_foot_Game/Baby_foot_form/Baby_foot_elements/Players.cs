public class Players {
    private int xposition;
    private int yposition;
    private int yposition_limit;
    public int height ;

    public Players (int h){
        height = h;
    }

    public void setXposition(int xposition) {
        this.xposition = xposition;
    }

    public int getXposition() {
        return xposition;
    }

    public void setYposition(int yposition) {
        this.yposition = yposition;
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
