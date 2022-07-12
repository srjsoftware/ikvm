package ikvm.nio.ch;

import java.nio.channels.*;
import java.nio.channels.spi.*;
import java.util.concurrent.*;

/**
 * .NET implementation of AsynchronousChannelGroup.
 */
final class NetAsynchronousChannelGroup extends AsynchronousChannelGroup
{

    NetExecutorServiceProxy proxy;

    NetAsynchronousChannelGroup(AsynchronousChannelProvider provider, NetExecutorServiceProxy proxy)
    {
        super(provider);

        this.proxy = proxy;
    }
    
    @Override
    public final native boolean isShutdown();
    
    @Override
    public final native boolean isTerminated();
    
    @Override
    public final native void shutdown();
    
    @Override
    public final native void shutdownNow();

    @Override
    public final native boolean awaitTermination(long timeout, TimeUnit unit);

}
