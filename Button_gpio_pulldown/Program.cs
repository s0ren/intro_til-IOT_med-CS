// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Device.Gpio;
using System.Diagnostics;
using System.Threading;

Debug.WriteLine("Hello from nanoFramework, med GPIO knap!");

// Create a GpioController, then create a GpioPin for the led and the button
var gpio = new GpioController();

// Setup the GPIO pin to 2 as it is the embedded led in the ESP32, but I have one on pin 18
// Open the pin in output mode
// If your board has another pin, change here. If you are using an external led, change here as well.
GpioPin led = gpio.OpenPin(18, PinMode.Output);

// Create the button with input pull up mode
// Adjust the pin number if needed
GpioPin button = gpio.OpenPin(35, PinMode.InputPullDown);

// When the button has no physical pulldown, it often needs a debounce delay
button.DebounceTimeout = TimeSpan.FromMilliseconds(15);

// We want to set an event on the pin when the button is pressed or released
button.ValueChanged += (s, e) =>
{
    // When we press the button, the as we have the pin connected to a pull up, the initial value is high,
    // and when we press it, the value goes to the ground. So, the even is falling when we press.
    Debug.WriteLine($"Button is {(e.ChangeType == PinEventTypes.Rising ? "pressed" : "released")}");
    if (e.ChangeType == PinEventTypes.Rising)
    {
        // light the led
        led.Write(PinValue.High);
    }
    else
    {
        // switch off the led
        led.Write(PinValue.Low);
    }
};



Thread.Sleep(Timeout.Infinite);
