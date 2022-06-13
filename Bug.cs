using System.Text;
public static class Bug
{
    public static Position Position { get; private set; } = new Position(0, 0);
    public static string Appearance { get; } = "\x1b[42m※\x1b[0m";
    public static string TrashAppearance { get; private set; } = "◎";
    public static int DroppingDustProbability { get; } = 30;
    public static void Spawn()
    {
        var random = new Random();
        SetPosition(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight));
        Write();
        // Console.Write($"c:{Position.Cols},l:{Position.Lines}");
    }


    public static void MoveUp()
    {
        if (Position.Lines - 1 < 0)
        {
            return;
        }
        Erase();
        SetPosition(Position.Cols, Position.Lines - 1);
        Write();
        DropTrash(Position.Cols, Position.Lines + 1);
    }

    public static void MoveDown()
    {
        if (Position.Lines + 1 >= Console.WindowHeight)
        {
            return;
        }
        Erase();
        SetPosition(Position.Cols, Position.Lines + 1);
        Write();
        DropTrash(Position.Cols, Position.Lines - 1);
    }

    public static void MoveLeft()
    {
        if (Position.Cols - 1 < 0)
        {
            return;
        }
        Erase();
        SetPosition(Position.Cols - 1, Position.Lines);
        Write();
        DropTrash(Position.Cols + 1, Position.Lines);
    }

    public static void MoveRight()
    {
        if (Position.Cols + 1 >= Console.WindowWidth)
        {
            return;
        }
        Erase();
        SetPosition(Position.Cols + 1, Position.Lines);
        Write();
        DropTrash(Position.Cols - 1, Position.Lines);
    }


    private static void DropTrash(int cols, int lines)
    {
        var random = new Random();
        if (random.Next(1, 101) <= DroppingDustProbability)
        {
            if (random.Next() % 2 == 0)
            {
                TrashAppearance = ((char)random.Next(65, 91)).ToString();
            }
            else
            {
                TrashAppearance = ((char)random.Next(97, 123)).ToString();
            }

            var currentCols = Console.CursorLeft;
            var currentLins = Console.CursorTop;
            Console.CursorLeft = cols;
            Console.CursorTop = lines;
            Console.Write(TrashAppearance);
            Console.CursorLeft = currentCols;
            Console.CursorTop = currentLins;
        }
    }

    private static void Write()
    {
        Console.Write(Appearance);
    }

    private static void Erase()
    {
        Console.Write('\b');
        Console.Write(' ');
    }
    private static void SetPosition(int cols, int lines)
    {
        var position = new Position(cols, lines);
        SetPosition(position);
    }

    private static void SetPosition(Position position)
    {
        Position = position;
        SetPosition();
    }
    private static void SetPosition()
    {
        Console.CursorLeft = Position.Cols;
        Console.CursorTop = Position.Lines;
    }
}
