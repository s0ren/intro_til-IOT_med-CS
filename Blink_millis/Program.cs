using System;
using System.Diagnostics;
using System.Threading;
using System.Device.Gpio;

namespace Blink_millis
{
    public class Program
    {
        // Vælg en GPIO pin til LED'en. Juster efter dit board.
        const int LED_PIN = 18;

        static void Main()
        {
            // Initialiser GPIO controller
            GpioController gpio = new GpioController();

            // Åbn pin og sæt til output
            gpio.OpenPin(LED_PIN, PinMode.Output);

            // Start med LED slukket
            PinValue ledState = PinValue.Low;
            gpio.Write(LED_PIN, ledState);

            // Holder styr på sidste toggle tidspunkt (ticks = 100 nanoseconds)
            long lastToggleTicks = DateTime.UtcNow.Ticks;
            // 10,000 ticks = 1 millisekund, så 10,000,000 ticks = 1 sekund
            const long oneSecondInTicks = 10000000;

            while (true)
            {
                // Læs nuværende tid i ticks
                long currentTicks = DateTime.UtcNow.Ticks;

                // Hvis mindst 1 sekund er gået siden sidste toggle, skift LED state
                if ((currentTicks - lastToggleTicks) >= oneSecondInTicks)
                {
                    // Toggle LED state
                    ledState = (ledState == PinValue.High) ? PinValue.Low : PinValue.High;

                    gpio.Write(LED_PIN, ledState);

                    // Opdater sidste toggle tidspunkt
                    lastToggleTicks = currentTicks;

                    // Debug output (valgfrit)
                    Debug.WriteLine($"LED toggled - State: {ledState}");
                }

                // Lille sleep for at give CPU en pause
                //Thread.Sleep(1);
            }
        }
    }
}
