// Consider using this approach only when performance is critical and a slight loss of precision is acceptable.

public static class FastMath
{
    public static float InverseSqrt(float x)
    {
        // 0.5 magic number for further refinement
        const float half = 0.5f;

        // Converting float to integer bits
        int i = BitConverter.SingleToInt32Bits(x);

        // Initial guess using a magic number: This magic number is derived from IEEE 754 single-precision format and sets the upper bits of the integer to an estimate.
        i = 0x5F3759DF - (i >> 1);

        // Convert integer bits back to float
        float y = BitConverter.Int32ToSingle(i);

        // Refine the approximation using Newton-Raphson method (one iteration)
        y = y * (half - (x * y * y));

        return y;
    }
}
