using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace app;
public class Calculator
{
    public Calculator(int initialValue)
    {
        Value = _operations
            .StartWith(new ResetOperation(initialValue))
            .Scan(
                0, 
                (acc, op) => op.Execute(acc)
            )
            .Replay(1)
            .AutoConnect();
    }
    private readonly Subject<IOperation> _operations = new();
    public IObservable<int> Value { get; }

    public void Add(int addend)
    {
        _operations.OnNext(new AddOperation(addend));
    }
    public void Subtract(int substractend)
    {
        _operations.OnNext(new SubstractOperation(substractend));
    }    
    public void Reset(int initialValue = 0)
    {
        _operations.OnNext(new ResetOperation(initialValue));
    }
}

internal interface IOperation
{
    int Execute(int value);
}

public class AddOperation : IOperation
{
    private readonly int _addend;

    public AddOperation(int addend)
    {
        this._addend = addend;
    }
    public int Execute(int value)
    {
        return value + _addend;
    }
}
public class SubstractOperation : IOperation
{
    private readonly int _substractend;

    public SubstractOperation(int substractend)
    {
        this._substractend = substractend;
    }
    public int Execute(int value)
    {
        return value - _substractend;
    }
}

public class ResetOperation : IOperation
{
    private readonly int _resetValue;

    public ResetOperation(int resetValue)
    {
        _resetValue = resetValue;
    }
    public int Execute(int value)
    {
        return _resetValue;
    }
}