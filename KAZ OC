public class Kernel : Sys.Kernel
{
    protected override void BeforeRun()
    {
        // перед запуском
        Console.WriteLine("Welcome to my KAZ");
    }
    
    protected override void Run()
    {
        // после запуска
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("KAZ >>");
        Console.ForegroundColor = ConsoleColor.White;
        
        var input = Console.ReadLine();
        
        switch(input) 
        {
            case "help":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("shutdown\nreboot\nsysinfo\nhelp");
                Console.ForegroundColor = ConsoleColor.White;
                break;
                
            case "shutdown":
                Cosmos.System.Power.Shutdown();
                break;
                
            case "reboot":
                Cosmos.System.Power.Reboot();
                break;
                
            case "sysinfo":
                string CPUbrand = Cosmos.Core.CPU.GetCPUBrandString();
                string CPUvendor = Cosmos.Core.CPU.GetCPUVendorString(); // ИСПРАВЛЕНО
                uint amount_of_ram = Cosmos.Core.CPU.GetAmountOfRAM(); // ИСПРАВЛЕНО
                ulong available_ram = Cosmos.Core.GCImplementation.GetAvailableRAM();
                uint UsedRAM = Cosmos.Core.GCImplementation.GetUsedRAM(); // ИСПРАВЛЕНО (;)
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================="); // ИСПРАВЛЕНО (;)
                Console.ForegroundColor = ConsoleColor.Magenta; // ИСПРАВЛЕНО
                Console.WriteLine(@"CPU:{0}
 CPU Vendor: {1}         
 Amount of RAM: {2} MB      
 Available RAM:  {3} MB     
 Used RAM: {4} MB", CPUbrand, CPUvendor, amount_of_ram, available_ram, UsedRAM); // ИСПРАВЛЕНО UseRam → UsedRAM
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("======================"); // ИСПРАВЛЕНО (;)
                break;
                
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(input + ": Unknown Command");
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
    }
}
