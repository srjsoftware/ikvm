package sun.nio.fs;

import java.nio.file.*;
import java.nio.file.spi.*;

public class DefaultFileTypeDetector {

    public static FileTypeDetector create() {
        if (cli.IKVM.Runtime.RuntimeUtil.get_IsWindows()) {
            return new RegistryFileTypeDetector();
        } else {
            FileSystemProvider provider = FileSystems.getDefault().provider();
            return ((UnixFileSystemProvider)provider).getFileTypeDetector();
        }
    }

}
