namespace app;
public class Calculator
{
    public Calculator(int initialValue)
    {
        this.Value = initialValue;
    }

    public int Value { get; private set; }

    public int Add(int addend)
    {
        this.Value += addend;
        return this.Value;
    }
}
