namespace GPUPerfAPI.CodeGen;

internal class Program
{
    static async Task Main(string[] args)
    {
        var generatorApp = new GeneratorApp();

        await generatorApp.Initialize();

        generatorApp.Run();
    }
}