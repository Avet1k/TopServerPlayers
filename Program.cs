namespace TopServerPlayers;
class Program
{
    static void Main(string[] args)
    {
        List<Player> players = new List<Player>
        {
            new ("Nagibator", 50, 478),
            new ("Razgibator", 23, 288),
            new ("killer666", 42, 743),
            new ("Sasha2013", 28, 274),
            new ("Kodzima genij", 19, 251),
            new ("Tractorist", 72, 852),
            new ("player346198433", 32, 563),
            new (".", 38, 433),
            new ("1=1'", 22, 291),
            new ("Cooller",34, 473)
        };

        Server server = new Server(players);
        
        server.ShowTopLevelPlayers();
        Console.WriteLine();
        server.ShowTopStrengthPlayers();
    }
}

class Player
{
    public Player(string name, int level, int strength)
    {
        Name = name;
        Level = level;
        Strength = strength;
    }
    
    public string Name { get; private set; }
    public int Level { get; private set; }
    public int Strength { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name}: {Level}lvl, {Strength}str.");
    }
}

class Server
{
    private List<Player> _players;
    private int _topCounter = 3;

    public Server(List<Player> players)
    {
        _players = players;
    }

    public void ShowTopLevelPlayers()
    {
        List<Player> sortedPlayers = _players.OrderByDescending(player => player.Level).Take(_topCounter).ToList();

        ShowPlayers(sortedPlayers);
    }

    public void ShowTopStrengthPlayers()
    {
        List<Player> sortedPlayers = _players.OrderByDescending(player => player.Strength).Take(_topCounter).ToList();
        
        ShowPlayers(sortedPlayers);
    }

    private void ShowPlayers(List<Player> players)
    {
        foreach (Player player in players)
            player.ShowInfo();
    }
}