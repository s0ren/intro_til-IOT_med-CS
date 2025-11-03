using System;
using System.Diagnostics;
using System.Threading;
using System.Device.Gpio;


namespace Blink1
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework!");

            int PinNumber = 2;
            GpioPin bultinLED = new GpioController().OpenPin(PinNumber, PinMode.Output);

            while (true)
            {
                // Turn on the LED (assuming an active high configuration)
                bultinLED.Write(PinValue.High);
                Thread.Sleep(500); // Keep the LED on for 500 milliseconds
                
                // Turn off the LED
                bultinLED.Write(PinValue.Low);
                Thread.Sleep(500); // Keep the LED off for 500 milliseconds
            }

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
