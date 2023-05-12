public static class AsyncExpansion
{
    public static int ToDelayMillisecond(this float number) =>
        (int)(number * 1000);
}