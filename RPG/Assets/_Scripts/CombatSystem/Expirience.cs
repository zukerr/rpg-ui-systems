using System;

public class Expirience
{

    public int Level {get; private set;} = 1;
    public int Exp {get; private set;}=0;
    public int NextLevelThreshold {get; private set;}
    public event Action<int> OnLevelUp;


    private const int LINEAR_LVL_RISE=100;
    private int CalculateLevelThreshold(int previousThreshold)
    {
        return Level*LINEAR_LVL_RISE+previousThreshold;
    }
    public void LevelUp()
    {
        Level++;
        Exp-=NextLevelThreshold;// ???
        NextLevelThreshold=CalculateLevelThreshold(NextLevelThreshold);

        OnLevelUp?.Invoke(Level);
    }
    public void AddExp(int amount)
    {
        Exp+= amount;
        if(Exp >= NextLevelThreshold)
        {
            LevelUp();
        }
    }
}
