using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

namespace NanoFrameworkBlinkDemo
{
    public class Program
    {
        // Vælg en GPIO pin til LED'en
        const int LED_PIN = 18;
        const int LED_PIN2 = 19;

        static GpioController gpio;
        static GpioController gpio2;
        static PinValue ledState = PinValue.Low;
        static PinValue ledState2 = PinValue.Low;

        static void Main()
        {
            // Initialiser GPIO controller
            gpio = new GpioController();
            gpio2 = new GpioController();

            // Åbn pin og sæt til output
            gpio.OpenPin(LED_PIN, PinMode.Output);
            gpio2.OpenPin(LED_PIN2, PinMode.Output);

            // Start med LED slukket
            gpio.Write(LED_PIN, ledState);
            gpio2.Write(LED_PIN2, ledState);

            // Opret timer der kalder TimerCallback hver 1000 ms (1 sekund)
            // Timer(callback, state, dueTime, period)
            // dueTime: tid før første kald (1000 ms)
            // period: interval mellem kald (1000 ms)
            Timer blinkTimer = new Timer(TimerCallback, null, 1000, 500);
            Timer blinkTimer2 = new Timer(TimerCallback2, null, 500, 500);

            Debug.WriteLine("Timer started - LED will blink every second");

            // Hold programmet kørende
            Thread.Sleep(Timeout.Infinite);
        }

        // Callback metode der kaldes af timer'en
        static void TimerCallback(object state)
        {
            // Toggle LED state
            ledState = (ledState == PinValue.High) ? PinValue.Low : PinValue.High;

            gpio.Write(LED_PIN, ledState);

            // Debug output
            Debug.WriteLine($"LED toggled - State: {ledState}");
        }

        static void TimerCallback2(object state)
        {
            // Toggle LED state
            ledState2 = (ledState2 == PinValue.High) ? PinValue.Low : PinValue.High;

            gpio2.Write(LED_PIN2, ledState2);

            // Debug output
            Debug.WriteLine($"LED2 toggled - State: {ledState2}");
        }
    }
}
