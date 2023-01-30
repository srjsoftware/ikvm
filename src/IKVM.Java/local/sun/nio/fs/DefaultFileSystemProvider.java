package sun.nio.fs;

import java.nio.file.spi.*;
import java.security.*;

import sun.security.action.*;

public class DefaultFileSystemProvider {

    @SuppressWarnings("unchecked")
    private static FileSystemProvider createProvider(String cn) {
        Class<FileSystemProvider> c;
        try {
            c = (Class<FileSystemProvider>)Class.forName(cn);
        } catch (ClassNotFoundException x) {
            throw new AssertionError(x);
        }
        try {
            return c.newInstance();
        } catch (IllegalAccessException | InstantiationException x) {
            throw new AssertionError(x);
        }
    }

    public static FileSystemProvider create() {
        if (cli.IKVM.Runtime.RuntimeUtil.get_IsWindows()) {
                return createProvider("sun.nio.fs.WindowsFileSystemProvider");
        } else {
            String osname = AccessController.doPrivileged(new GetPropertyAction("os.name"));
            if (osname.equals("Linux"))
                return createProvider("sun.nio.fs.LinuxFileSystemProvider");
            if (osname.contains("OS X"))
                return createProvider("sun.nio.fs.MacOSXFileSystemProvider");
        }
        
        throw new AssertionError("Platform not recognized");
    }

}
