``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19044.1889/21H2/November2021Update)
Intel Core i7-8750H CPU 2.20GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
  [Host]     : .NET Framework 4.8 (4.8.4510.0), X64 RyuJIT VectorSize=256  [AttachedDebugger]
  DefaultJob : .NET Framework 4.8 (4.8.4510.0), X64 RyuJIT VectorSize=256


```
|          Method |       Mean |      Error |     StdDev |     Median | Ratio | RatioSD |
|---------------- |-----------:|-----------:|-----------:|-----------:|------:|--------:|
|  TestExpression |  11.567 ms |  0.2645 ms |  0.7418 ms |  11.361 ms |  1.41 |    0.11 |
|  TestReflection | 575.589 ms | 25.5196 ms | 68.9936 ms | 557.600 ms | 70.25 |    8.94 |
| TestReflection2 | 486.852 ms |  9.5935 ms | 20.6510 ms | 480.669 ms | 58.97 |    3.96 |
| TestExpression2 |  10.645 ms |  0.2101 ms |  0.4478 ms |  10.618 ms |  1.29 |    0.09 |
| TestExpression3 |  10.608 ms |  0.2099 ms |  0.4094 ms |  10.534 ms |  1.27 |    0.09 |
|      TestDirect |   8.209 ms |  0.1638 ms |  0.4456 ms |   8.160 ms |  1.00 |    0.00 |
