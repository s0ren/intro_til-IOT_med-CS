using System;
using System.Diagnostics;
using System.Threading;
using System.Device.Adc;

Debug.WriteLine("ADC med nanoFramework!");

AdcController adc1 = new AdcController();

int max1 = adc1.MaxValue;
int min1 = adc1.MinValue;

Debug.WriteLine("min1=" + min1.ToString() + " max1=" + max1.ToString());

AdcChannel ac0 = adc1.OpenChannel(0);

// VP 
//AdcChannel ac3 = adc1.OpenChannel(3);
// VN 
while (true)
{
    int value = ac0.ReadValue();
    double percent = ac0.ReadRatio();

    Debug.WriteLine("value0=" + value.ToString() + " ratio=" + percent.ToString());

    Thread.Sleep(1000);
}
