``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.2130/21H2/November2021Update)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=6.0.402
  [Host]     : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2  [AttachedDebugger]
  DefaultJob : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2


```
|          Method |       Mean |     Error |     StdDev |     Median | Ratio | RatioSD |
|---------------- |-----------:|----------:|-----------:|-----------:|------:|--------:|
|  TestExpression |   9.674 ms | 0.2195 ms |  0.6472 ms |   9.599 ms |  1.20 |    0.08 |
|  TestReflection | 399.960 ms | 8.5930 ms | 25.3368 ms | 397.555 ms | 49.67 |    4.20 |
| TestReflection2 | 408.599 ms | 9.3370 ms | 27.2364 ms | 404.183 ms | 50.67 |    4.30 |
| TestExpression2 |   6.132 ms | 0.1274 ms |  0.3552 ms |   6.032 ms |  0.76 |    0.06 |
| TestExpression3 |   5.954 ms | 0.1177 ms |  0.1445 ms |   5.990 ms |  0.74 |    0.05 |
|      TestDirect |   8.069 ms | 0.1609 ms |  0.4511 ms |   7.939 ms |  1.00 |    0.00 |
