﻿int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

int SumSegment(int start, int end)
{
    int segmentSum = 0;
    for (int i = start; i < end; i++)
    {
        Thread.Sleep(50);
        segmentSum += array[i];
    }
    return segmentSum;
}

int sum1 = 0, sum2 = 0, sum3 = 0,sum4 = 0;

var startTime = DateTime.Now;

int numberOFThreads = 4;
int segmentLength = array.Length /numberOFThreads;

Thread[] threads = new Thread[segmentLength];
threads[0] = new Thread(() => { sum1 = SumSegment(0, segmentLength); });
threads[1] = new Thread(() => { sum2 = SumSegment(segmentLength, 2* segmentLength); });
threads[0] = new Thread(() => { sum3 = SumSegment(2 * segmentLength, 3 * segmentLength); });
threads[0] = new Thread(() => { sum4 = SumSegment(3 * segmentLength, 4 * segmentLength); });

foreach (var thread in threads) { thread.Start(); }
foreach (var thread in threads) { thread.Join(); }

var endTime = DateTime.Now;

var timespan = endTime - startTime;

Console.WriteLine($"The sum is {sum1 + sum2 +sum3 + sum4}");
Console.WriteLine($"Time taken was: {timespan.TotalMilliseconds}");

Console.ReadLine();
