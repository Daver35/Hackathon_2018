public enum Direction{
    Up, Down, Left, Right, Center
}

public enum Orientation{
    Clock, Counterclock
}

public class DirectionF{
    
    public static Direction rotateDirection(Direction dir, Orientation o){
        if(o == Orientation.Clock){
            switch(dir){
			case Direction.Up:
				return Direction.Right;
			case Direction.Right:
				return Direction.Down;
			case Direction.Down:
				return Direction.Left;
			case Direction.Left:
				return Direction.Up;
			case Direction.Center:
				return Direction.Center;     
            }
        }else{
            switch(dir){
			case Direction.Up:
				return Direction.Left;
			case Direction.Right:
				return Direction.Up;
			case Direction.Down:
				return Direction.Right;
			case Direction.Left:
				return Direction.Down;
			case Direction.Center:
				return Direction.Center;     
            }
        }
		return Direction.Center;
    }
}
