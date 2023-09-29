public class GameSettings
{
    public enum Diff
    {
        Easy,
        Medium,
        Hard
    }

    private Diff difficulty = Diff.Easy;
    private bool multiPlayer = true;
    
    private static GameSettings instance;

    public static Diff Difficulty
    {
        get => Instance.difficulty;
        set => Instance.difficulty = value;
    }
    
    public static bool MultiPlayer
    {
        get => Instance.multiPlayer;
        set => Instance.multiPlayer = value;
    }

    public static GameSettings Instance
    {
        get
        {
            if (instance == null)
                instance = new GameSettings();

            return instance;
        }
    }
}
