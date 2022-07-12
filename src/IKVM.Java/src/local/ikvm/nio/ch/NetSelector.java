package ikvm.nio.ch;

import java.nio.channels.spi.*;

/**
 * .NET implementation of Selector.
 */
final class NetSelector extends AbstractSelector
{

    NetSelector(SelectorProvider provider)
    {
        super(provider);
    }

}
