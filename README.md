# .Net Data Access Tools Benchmarking Result

![performans](https://github.com/mackali1453/BenchmarkDataAccessTools/assets/87720632/e9820c93-f2ef-4bd9-b652-971fa1a61a7f)

- The conclusion to be drawn from the image is that the fastest tools are ado net, dapper and EF respectively. When we look at the memory allocation, we see the same order.
- EF is a high level data access tool thus we write less code with the help of linq queries but performance is more than others.
- Ado Net is low level data access tool. Performance is high but code is more complicated than others and there is no mapping.
- Dappers performance is very close to Ado Net and there is mapping but we still write sql script as in Ado Net.
