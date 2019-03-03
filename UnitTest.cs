using Xunit;

public class UnitTest {
    [Fact]
    public void TestBoardCreate() {
        Assert.NotNull(new PlayerBoard(12));
    }

    [Fact]
    public void TestBoardSize() {
        Assert.Equal(2, (new PlayerBoard(-565)).Size);
        Assert.Equal(2, (new PlayerBoard(1)).Size);
        Assert.Equal(12, (new PlayerBoard(12)).Size);
        Assert.Equal(99, (new PlayerBoard(1000)).Size);
    }

    [Fact]
    public void TestAddShip() {
        PlayerBoard board = new PlayerBoard(10);
        Assert.True(board.AddShip(2, 1, 6, 2)); 
        Assert.True(board.AddShip(5, 5, 5, 5)); 

        //Add ship the size of the board
        board = new PlayerBoard(10);
        Assert.True(board.AddShip(0, 0, 10, 10)); 
    }

    [Fact]
    public void TestAddShipOutsideBounds() {
        PlayerBoard board = new PlayerBoard(10);
        Assert.False(board.AddShip(2, 2, 10, 1)); 
        Assert.False(board.AddShip(3, 2, 8, 1)); 
    }

    [Fact]
    public void TestAttackShip() {
        PlayerBoard board = new PlayerBoard(10);

        Assert.False(board.Attack(5, 3));

        //Attack ship of length 1
        board.AddShipHorizontal(1, 0, 1);       
        Assert.True(board.Attack(1, 0));

        //Attack ship in its center
        Assert.True(board.AddShipVertical(0, 0, 10));       
        Assert.True(board.Attack(0, 5));

        //Attack ship in its end
        board.AddShipVertical(2, 0, 10);               
        Assert.True(board.Attack(2, 9));

        //Attack outside bounds
        Assert.False(board.Attack(2, 10));  

        //Add ship the size of the board
        board = new PlayerBoard(10);
        Assert.True(board.AddShip(0, 0, 10, 10)); 
        // and attack any cell
        Assert.True(board.Attack(2, 9));
    }
}