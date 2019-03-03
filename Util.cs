/* Utility functions
 */
public class Util
{
    public static int ClampInt(int val, int min, int max)
    {
        return System.Math.Max(System.Math.Min(val, max), min);
    }
}
