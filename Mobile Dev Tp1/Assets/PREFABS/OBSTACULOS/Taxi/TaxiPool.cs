public class TaxiPool : Pool
{
    protected override void Awake()
    {
        base.Awake();
        
        if (GameSettings.Difficulty != GameSettings.Diff.Hard)
            Destroy(gameObject);
    }
}
