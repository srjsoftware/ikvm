package ikvm.nio.ch;

import java.io.*;
import java.nio.channels.spi.*;
import java.nio.channels.*;
import java.util.concurrent.*;

import sun.nio.ch.*;

/**
 * Implementation of ExecutorService which executes work on the configured .NET TaskScheduler.
 */
final class NetTaskSchedulerExecutor extends AbstractExecutorService
{

    private cli.System.Threading.Tasks.TaskScheduler scheduler;

    NetTaskSchedulerExecutor(cli.System.Threading.Tasks.TaskScheduler scheduler)
    {
        this.scheduler = scheduler;
    }

}
