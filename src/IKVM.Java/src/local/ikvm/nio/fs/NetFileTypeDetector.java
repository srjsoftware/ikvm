package ikvm.nio.fs;

import java.io.*;
import java.nio.file.*;
import java.nio.file.spi.*;

final class NetFileTypeDetector extends FileTypeDetector
{

    @Override
    public final native String probeContentType(Path path) throws IOException;

}
