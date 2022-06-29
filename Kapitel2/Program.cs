// See https://aka.ms/new-console-template for more information

[ThreadStatic]
static int _local;
private static extern int _global;

Console.WriteLine("Hello, World!");
