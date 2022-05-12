using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
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
    public async Task Value_should_return_initial_value()
    {
        var single = await _calculator.Value.FirstAsync();
        Assert.Equal(_seed, single);
    }
    [Fact]
    public async Task Add_5_should_return_seed_plus_5()
    {
        _calculator.Add(5);
        var result = await _calculator.Value.FirstAsync();
        Assert.Equal(_seed + 5, result);
    }
}