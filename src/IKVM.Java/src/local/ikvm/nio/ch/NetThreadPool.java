package ikvm.nio.ch;

import java.util.concurrent.*;

final class NetThreadPool
{

    private static class DefaultHolder
    {

        final static NetThreadPool defaultInstance = createDefault();

    }

    static NetThreadPool createDefault()
    {
        return new NetThreadPool(new NetTaskSchedulerExecutor(cli.System.Threading.Tasks.TaskScheduler.Default), 0);
    }

    static NetThreadPool getDefault()
    {
        return DefaultHolder.defaultInstance;
    }

    static NetThreadPool create(int nThreads, ThreadFactory factory)
    {
        if (nThreads <= 0)
            throw new IllegalArgumentException("'nThreads' must be > 0");

        return new NetThreadPool(Executors.newFixedThreadPool(nThreads, factory), true, nThreads);
    }

    static NetThreadPool wrap(ExecutorService executor, int initialSize)
    {
        if (executor == null)
            throw new NullPointerException("'executor' is null");

        // attempt to check if cached thread pool
        if (executor instanceof ThreadPoolExecutor)
        {
            int max = ((ThreadPoolExecutor)executor).getMaximumPoolSize();
            if (max == Integer.MAX_VALUE)
            {
                if (initialSize < 0)
                    initialSize = Runtime.getRuntime().availableProcessors();
                else
                    // not a cached thread pool so ignore initial size
                    initialSize = 0;
            }
        }
        else
        {
            // some other type of thread pool
            if (initialSize < 0)
                initialSize = 0;
        }

        return new NetThreadPool(executor, initialSize);
    }

    private final ExecutorService executor;

    private NetThreadPool(ExecutorService executor, int initialThreads)
    {
        this.executor = executor;
    }

    public ExecutorService getExecutor()
    {
        return executor;
    }

}
