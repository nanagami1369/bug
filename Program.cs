// See https://aka.ms/new-console-template for more information
if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
{
    Console.WriteLine(args[0]);
}
Console.WriteLine($"cols:{Console.WindowWidth}:lines:{Console.WindowHeight}");
Console.WriteLine($"cursor:cols{Console.CursorLeft}:lines:{Console.CursorTop}");
Bug.Spawn();
var random = new Random();
while (true)
{
    // var key = Console.ReadKey();
    var dice = random.Next(int.MaxValue) % 4;
    Debug($"position{{c:{Bug.Position.Cols},l{Bug.Position.Lines},dice:{dice}}}");
    // switch (key.Key)
    // {
    //     case ConsoleKey.UpArrow:
    //         Bug.MoveUp();
    //         break;
    //     case ConsoleKey.DownArrow:
    //         Bug.MoveDown();
    //         break;
    //     case ConsoleKey.LeftArrow:
    //         Bug.MoveLeft();
    //         break;
    //     case ConsoleKey.RightArrow:
    //         Bug.MoveRight();
    //         break;
    //     default:
    //         break;
    // }
    switch (dice)
    {
        case 0:
            Bug.MoveUp();
            break;
        case 1:
            Bug.MoveDown();
            break;
        case 2:
            Bug.MoveLeft();
            break;
        default:
            Bug.MoveRight();
            break;
    }
}


static void Debug(string message)
{
    var cols = Console.CursorLeft;
    var lines = Console.CursorTop;
    Console.CursorLeft = 0;
    Console.CursorTop = 0;
    Console.WriteLine(message);
    Console.CursorLeft = cols;
    Console.CursorTop = lines;
}
