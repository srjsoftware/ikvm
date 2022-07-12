package ikvm.nio.ch;

import java.nio.channels.*;
import java.nio.channels.spi.*;

/**
 * .NET implementation of Pipe.
 */
final class NetPipe extends Pipe
{

    NetPipe(SelectorProvider provider)
    {
        super(provider);
    }

    @Override
    public final native SourceChannel source();

    @Override
    public final native SourceChannel sink();

}
