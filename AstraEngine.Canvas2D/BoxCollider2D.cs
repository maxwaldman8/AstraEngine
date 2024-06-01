using System.Diagnostics;

using AstraEngine.Canvas2D;

public class BoxCollider2D{

    public Position2D TopLeft {get; set;}
    public Position2D BottomRight {get; set;}
    private bool IsOverlap(Position2D OtherTopLeft, Position2D OtherBottomRight){
        if(TopLeft.X == BottomRight.X || TopLeft.Y == BottomRight.Y || OtherTopLeft.X == OtherBottomRight.X || OtherTopLeft.Y == OtherBottomRight.Y){
            return false;
        }
        if(TopLeft.X > OtherBottomRight.X || OtherTopLeft.X > BottomRight.X){
            return false;
        }
        if(BottomRight.Y > OtherTopLeft.Y || OtherBottomRight.Y > TopLeft.Y){
            return false;
        }
        return true;
    }
    public bool IsColliding(BoxCollider2D other){
        return IsOverlap(other.TopLeft, other.BottomRight);
    }
}