// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Iot.Device.Ssd13xx;
using Iot.Device.Ssd13xx.Samples;
using nanoFramework.Hardware.Esp32;
using System.Device.I2c;
using System.Diagnostics;
using System.Threading;

Debug.WriteLine("Hello Ssd1306 Sample!");

//////////////////////////////////////////////////////////////////////
// when connecting to an ESP32 device, need to configure the I2C GPIOs
// used for the bus, for example
Configuration.SetPinFunction(21, DeviceFunction.I2C1_DATA);
Configuration.SetPinFunction(22, DeviceFunction.I2C1_CLOCK);
//////////////////////////////////////////////////////////////////////

using Ssd1306 device = new Ssd1306(
    I2cDevice.Create(new I2cConnectionSettings(1, Ssd1306.DefaultI2cAddress)), 
    Ssd13xx.DisplayResolution.OLED128x32);

device.ClearScreen();
device.Font = new BasicFont();
device.DrawString(2, 2, "nF IOT!", 2);//large size 2 font
device.DrawString(2, 32, "nanoFramework", 1, true);//centered text
device.Display();
Thread.Sleep(200);

device.ClearScreen();
device.Font = new BasicFont();
for (int i = 0; i < 50; i++)
{
    int line = 1;
    Debug.WriteLine($"1, line++, $\"i: {i}\", 1");
    device.Write(1, line++, $"i: {i}", 1);
    device.Write(1, line++, "Hest!", 1, true);
    device.Display();
    Thread.Sleep(500);
}

Debug.WriteLine("End of Ssd1306 Sample!");
Thread.Sleep(Timeout.Infinite);