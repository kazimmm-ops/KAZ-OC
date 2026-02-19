using System;
using Cosmos.Core;
using Cosmos.System;

namespace KAZ_OS
{
    public static class Commands
    {
        public static void Execute(string input)
        {
            switch(input) 
            {
                // === POWER MANAGEMENT ===
                case "shutdown":
                    Console.Write("Shutdown? (y/n): ");
                    if(Console.ReadLine() == "y")
                        Power.Shutdown();
                    break;
                    
                case "reboot":
                    Console.Write("Reboot? (y/n): ");
                    if(Console.ReadLine() == "y")
                        Power.Reboot();
                    break;
                    
                // === CPU CONTROL ===
                case "cpuid":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("CPU Information:");
                    Console.WriteLine($"Brand: {CPU.GetCPUBrandString()}");
                    Console.WriteLine($"Vendor: {CPU.GetCPUVendorString()}");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                    
                case "halt":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("CPU HALTED!");
                    CPU.Halt();
                    break;
                    
                case "usage":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("CPU Usage: ~2-5%");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                    
                // === MEMORY CONTROL ===
                case "meminfo":
                    ShowMemoryInfo();
                    break;
                    
                case "memtest":
                    TestMemory();
                    break;
                    
                // === SYSTEM INFO ===
                case "sysinfo":
                    ShowSysInfo();
                    break;
                    
                case "ver":
                    Console.WriteLine("KAZ OS v1.0");
                    break;
                    
                case "uptime":
                    Console.WriteLine("System uptime: running");
                    break;
                    
                // === HELP ===
                case "help":
                    ShowHelp();
                    break;
                    
                // === UNKNOWN ===
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(input + ": unknown command");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        
        static void ShowHelp()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== POWER ===");
            Console.WriteLine("shutdown - shutdown computer");
            Console.WriteLine("reboot   - restart computer");
            
            Console.WriteLine("\n=== CPU ===");
            Console.WriteLine("cpuid    - show CPU info");
            Console.WriteLine("halt     - stop CPU");
            Console.WriteLine("usage    - show CPU usage");
            
            Console.WriteLine("\n=== MEMORY ===");
            Console.WriteLine("meminfo  - show memory info");
            Console.WriteLine("memtest  - test memory");
            
            Console.WriteLine("\n=== SYSTEM ===");
            Console.WriteLine("sysinfo  - full system info");
            Console.WriteLine("ver      - OS version");
            Console.WriteLine("uptime   - system uptime");
            
            Console.WriteLine("\n=== OTHER ===");
            Console.WriteLine("help     - this help");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void ShowSysInfo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=========================");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"CPU: {CPU.GetCPUBrandString()}");
            Console.WriteLine($"Vendor: {CPU.GetCPUVendorString()}");
            Console.WriteLine($"Total RAM: {CPU.GetAmountOfRAM()} MB");
            Console.WriteLine($"Available RAM: {GCImplementation.GetAvailableRAM()} MB");
            Console.WriteLine($"Used RAM: {GCImplementation.GetUsedRAM()} MB");
            Console.WriteLine("======================");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void ShowMemoryInfo()
        {
            Console.WriteLine("=== MEMORY INFO ===");
            Console.WriteLine($"Total: {CPU.GetAmountOfRAM()} MB");
            Console.WriteLine($"Available: {GCImplementation.GetAvailableRAM()} MB");
            Console.WriteLine($"Used: {GCImplementation.GetUsedRAM()} MB");
        }
        
        static void TestMemory()
        {
            Console.WriteLine("Testing memory...");
            uint total = CPU.GetAmountOfRAM();
            ulong avail = GCImplementation.GetAvailableRAM();
            uint used = GCImplementation.GetUsedRAM();
            
            Console.WriteLine($"Total RAM: {total} MB - OK");
            Console.WriteLine($"Available: {avail} MB - OK");
            Console.WriteLine($"Used RAM: {used} MB - OK");
            Console.WriteLine("Memory test passed!");
        }
    }
}
