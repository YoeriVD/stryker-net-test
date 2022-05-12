using System;
using app;
using Xunit;

namespace tests;

public class CalculatorTests
{
    private readonly int _seed;
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _seed = new Random().Next();
        _calculator = new Calculator(_seed);
    }
    [Fact]
    public void Add_5_should_return_seed_plus_5()
    {
        var sum = _calculator.Add(5);
        Assert.Equal(_seed + 5, sum);
    }
}