using System;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;

namespace Workflow {
    public class TimerJob : IJob {
        public async Task Execute(IJobExecutionContext context) {
            var dataMap = context.MergedJobDataMap;
            var action = dataMap["action"] as Func<Task>;
            if (action != null) {
                await action.Invoke();
            }
        }
    }

    public static class Timer {
        public static async Task AddHandler(Func<Task> action) {
            var dataMap = new JobDataMap();
            dataMap.Add("action", action);
            var job = JobBuilder.Create<TimerJob>()
                .SetJobData(dataMap)
                .Build();
            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(2)
                    .RepeatForever())
                .Build();
            await _scheduler.ScheduleJob(job, trigger);
        }
        public static async Task Stop() {
            await _scheduler.Shutdown();
        }

        private static readonly IScheduler _scheduler;
        static Timer() {
            var factory = new StdSchedulerFactory();
            _scheduler = factory.GetScheduler().Result;
            _scheduler.Start().Wait();
        }
    }
}