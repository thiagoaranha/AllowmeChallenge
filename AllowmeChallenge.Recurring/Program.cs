using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace AllowmeChallenge.Recurring
{
    class Program
    {
        private static readonly int _scheduleIntervalInSeconds = 60;

        static void Main(string[] args)
        {
            Run().GetAwaiter().GetResult();
        }

        private static async Task Run()
        {
            try
            {
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };

                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                await scheduler.Start();

                IJobDetail job = JobBuilder.Create<AllowmeChallengeJob>()
                    .WithIdentity("AllowmeChallengeJob", "AllowmeChallengeGroup")
                    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(_scheduleIntervalInSeconds)
                        .RepeatForever())
                    .Build();

                await scheduler.ScheduleJob(job, trigger);

                await Task.Delay(-1);
                await scheduler.Shutdown();

            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }
                
    }

}
