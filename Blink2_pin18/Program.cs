using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace Blink2_pin18
{
    public class Program
    {
        public static void Main()
        {
            Debug.WriteLine("Hello from nanoFramework! With police blink blink");

            int PinNumber = 18;
            int PinNumber2 = 19;
            GpioPin bultinLED = new GpioController().OpenPin(PinNumber, PinMode.Output);
            GpioPin bultinLED2 = new GpioController().OpenPin(PinNumber2, PinMode.Output);

            while (true)
            {
                
                // Turn on the LED (assuming an active high configuration)
                bultinLED.Write(PinValue.High);
                bultinLED2.Write(PinValue.Low);
                Thread.Sleep(500); // Keep the LED on for 500 milliseconds

                // Turn off the LED
                bultinLED.Write(PinValue.Low);
                bultinLED2.Write(PinValue.High);
                Thread.Sleep(500); // Keep the LED off for 500 milliseconds
            }

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
