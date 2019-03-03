using System.Collections.Generic;

public class PlayerBoard
{
    private int[,] Cells;
    private Dictionary<int, bool> Ships;    //Store all ships and their 'sunken' state

    public int Size { get; private set; }

    public bool LostGame {get; private set;}

    public PlayerBoard(int size = 10)
    {
        this.Size = Util.ClampInt(size, 2, 99);   // size can range from 2 to 99
        this.Cells = new int[this.Size, this.Size];
        this.Ships = new Dictionary<int, bool>();

        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                this.Cells[i, j] = -1;
            }
        }
    }

    /*  Trying to reasonably generalise the definition of the region a ship can take - chose rectangle
    *   This way bigger 'mothership' class ships which are m x n size can be added.
    *   Returns bool to indicate successful addition of ship
    */
    public bool AddShip(int left, int top, int width, int height)
    {
        bool isValid = true;    //Assume true and find go through reasons why it isn't

        //Inputs are non-negative and bottom-right corner within board bounds
        if (left < 0 || width < 0 || left + width > this.Size) isValid = false;
        if (top < 0 || height < 0 || top + height > this.Size) isValid = false;

        if (!isValid) return false; //Early exit

        int right = left + width;
        int bottom = top + height;

        //Check if there is an existing ship in any cells
        for (int row = left; row < right; row++)
        {
            for (int col = top; col < bottom; col++)
            {
                if (Cells[col, row] != -1) { isValid = false; break; }
            }
            if (!isValid) break;
        }

        if (!isValid) return false; //Early exit
        
        //Place the ship
        for (int row = left; row < right; row++)
        {
            for (int col = top; col < bottom; col++)
            {
                Cells[col, row] = Ships.Count;
            }
        }
        Ships.Add(Ships.Count, true);
        return isValid;
    }

    // Chose a Horizontal and Vertical AddShip function as that was 
    public bool AddShipHorizontal(int left, int top, int length)
    {
        return AddShip(left, top, length, 1);
    }

    public bool AddShipVertical(int left, int top, int length)
    {
        return AddShip(left, top, 1, length);
    }

    public bool Attack(int left, int top)
    {
        if (left < 0 || left >= this.Size) return false;
        if (top < 0 || top >= this.Size) return false;

        bool hit = false;
        if (Cells[top, left] != -1) //Got ship
        {
            Ships[Cells[top, left]] = false;
            hit = true;
        }

        //Assume true, since LostGame is false if at least 1 ship is alive
        LostGame = true;
        foreach (KeyValuePair<int, bool> ship in Ships) {
            if (ship.Value) LostGame = false;
        }

        return hit;
    }
    
    /* Simple output of state of cells */
    public string Render()
    {
        string output = "";
        for (int i = 0; i < Cells.GetLength(0); i++)
        {
            for (int j = 0; j < Cells.GetLength(0); j++)
            {
                if (Cells[i, j] == -1)
                { output += "~"; }//Water cell

                else
                {  //Ship cell
                    if (Ships[Cells[i, j]]) output += "S";    //Alive
                    else output += "X";             //Sunken :(
                }

                output += " ";
            }
            output = output.Remove(output.Length - 1);  //Remove trailing comma
            output += '\n';
        }

        return output;
    }
}