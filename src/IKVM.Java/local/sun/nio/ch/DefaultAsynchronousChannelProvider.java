package sun.nio.ch;

import java.nio.channels.spi.*;
import java.security.*;

import sun.security.action.*;

public class DefaultAsynchronousChannelProvider {

    private DefaultAsynchronousChannelProvider() {
        
    }

    @SuppressWarnings("unchecked")
    private static AsynchronousChannelProvider createProvider(String cn) {
        Class<AsynchronousChannelProvider> c;
        try {
            c = (Class<AsynchronousChannelProvider>)Class.forName(cn);
        } catch (ClassNotFoundException x) {
            throw new AssertionError(x);
        }
        try {
            return c.newInstance();
        } catch (IllegalAccessException | InstantiationException x) {
            throw new AssertionError(x);
        }

    }

    public static AsynchronousChannelProvider create() {
        if (cli.IKVM.Runtime.RuntimeUtil.get_IsWindows()) {
            return createProvider("sun.nio.ch.WindowsAsynchronousChannelProvider");
        } else {
            String osname = AccessController.doPrivileged(new GetPropertyAction("os.name"));
            if (osname.equals("Linux"))
                return createProvider("sun.nio.ch.LinuxAsynchronousChannelProvider");
            if (osname.contains("OS X"))
                return createProvider("sun.nio.ch.BsdAsynchronousChannelProvider");
        }
        
        throw new AssertionError("Platform not recognized");
    }

}
