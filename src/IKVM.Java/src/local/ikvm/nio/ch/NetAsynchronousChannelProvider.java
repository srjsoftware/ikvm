package ikvm.nio.ch;

import java.io.*;
import java.nio.channels.spi.*;
import java.nio.channels.*;
import java.util.concurrent.*;

import sun.nio.ch.*;

/**
 * .NET implementation of AsynchronousChannelProvider.
 */
final class NetAsynchronousChannelProvider extends AsynchronousChannelProvider
{

    final NetAsynchronousChannelGroup defaultInstance = createDefault();
    
    @Override
    public final AsynchronousChannelGroup openAsynchronousChannelGroup(int nThreads, ThreadFactory factory) throws IOException
    {
        return new NetAsynchronousChannelGroup(this, NetExecutorServiceProxy.create(nThreads, factory)).start();
    }

    @Override
    public final AsynchronousChannelGroup openAsynchronousChannelGroup(ExecutorService executor, int initialSize) throws IOException
    {
        return new NetAsynchronousChannelGroup(this, NetExecutorServiceProxy.wrap(executor, initialSize)).start();
    }

    NetAsynchronousChannelGroup getDefault()
    {
        if (defaultGroup == null)
            synchronized(NetAsynchronousChannelProvider.class) {
                if (defaultGroup == null)
                    defaultGroup = new NetAsynchronousChannelGroup(this, NetExecutorServiceProxy.getDefault()).start();
            }
    }

    private NetAsynchronousChannelGroup toNetChannelGroup(AsynchronousChannelGroup group) throws IOException
    {
        if (group == null)
        {
            return getDefault();
        }
        else
        {
            if (!(group instanceof NetAsynchronousChannelGroup))
                throw new IllegalChannelGroupException();

            return (NetAsynchronousChannelGroup)group;
        }
    }
    
    @Override
    public final AsynchronousServerSocketChannel openAsynchronousServerSocketChannel(AsynchronousChannelGroup group) throws IOException
    {
        return new NetAsynchronousServerSocketChannel(toNetChannelGroup(group));
    }

    @Override
    public final AsynchronousSocketChannel openAsynchronousSocketChannel(AsynchronousChannelGroup group) throws IOException
    {
        return new NetAsynchronousSocketChannel(toNetChannelGroup(group));
    }

}
