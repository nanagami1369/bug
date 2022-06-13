public record Position
{
    public Position(int cols, int lines)
    {
        Cols = cols;
        Lines = lines;
    }

    public int Cols { get; init; }
    public int Lines { get; init; }
}
