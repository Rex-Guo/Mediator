## 简介

Huanent.Mediator与[jbogard/MediatR](https://github.com/jbogard/MediatR)同为中介者模式的.net实现，Huanent.Mediator具有以下优势：

* 更加精简的实现代码与api
* 更优的性能

下面表格是Huanent.Mediator与jbogard/MediatR同样的逻辑代码调用一百万次命令的耗时(测试详情可见samples/PerformanceComparisonWithMediatR)

|框架              |用时             |
|------------------|----------------|
| Huanent.Mediator| 00:00:02.8459768|
|jbogard/MediatR   |00:00:05.2528246|

## 独立使用
_安装nuget包 Huanent.Mediator_

新建测试类 TestCommand.cs TestHandler.cs

```
public class TestCommand : ICommand<string>
{
    public int Id { get; set; }
}
```
```
public class TestHandler : IHandler<TestCommand, string>
{
    public Task<string> HandleAsync(TestCommand command, CancellationToken token, IDispatcher dispatcher)
    {
        return Task.FromResult($"command payload: {command.Id}");
    }
}
```
Program.cs
```
internal class Program
{
    private static void Main(string[] args)
    {
        var dispatch = new DispatchBuilder().Build();
        var cmd = new TestCommand{Id=23};
        string result = dispatch.DispatchAsync(cmd).Result;
    }
}

```

## 与DependencyInjection配合在ASPNETCore下使用
_安装nuget包 Huanent.Mediator.DependencyInjection_

新建测试类 TestCommand.cs TestHandler.cs

```
public class TestCommand : ICommand<string>
{
    public int Id { get; set; }
}
```
```
public class TestHandler : IHandler<TestCommand, string>
{
    public Task<string> HandleAsync(TestCommand command, CancellationToken token, IDispatcher dispatcher)
    {
        return Task.FromResult($"command payload: {command.Id}");
    }
}
```
Startup.cs注册服务
```
public void ConfigureServices(IServiceCollection services)
{
    services.AddMediator(/*传入handler所在程序集，不传时只扫描当前程序集*/);
}

```
ValuesController.cs
```
[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public ValuesController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpGet]
    public async Task<IEnumerable<string>> GetAsync([FromQuery]TestCommand command)
    {
        return await _dispatcher.DispatchAsync(command, HttpContext.RequestAborted);
    }
}

```

## 完整API详见[WIKI]()
