namespace Liso.Tangent
{
    public static class DataTypeHelper
    {
        /// <summary>
        /// Converts the string to integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return 0;

            return int.TryParse(value, out var intValue) ? intValue : 0;
        }
    }
}
