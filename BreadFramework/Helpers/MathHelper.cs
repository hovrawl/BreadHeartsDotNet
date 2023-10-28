namespace BreadFramework.Helpers;

public class MathHelper
{
    public static object CastToUnsigned<T>(T number) where T : struct
    {
        unchecked
        {
            switch (number)
            {
                case long xlong: return (ulong) xlong;
                case int xint: return (uint)xint;
                case short xshort: return (ushort) xshort;
                case sbyte xsbyte: return (byte) xsbyte;
            }
        }
        return number;
    }
}