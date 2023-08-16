using System;
using System.Collections.Generic;
using System.IO;
using System.IO;
using Ionic.Zlib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SMB4_Improved_Stat_Tracker.DataReading
{
    internal class SeasonFileReader
    {
        public async Task<int> DecompressSeasonSavFiles(string fileDir, string filename)
        {
            await using var compressedStream = File.OpenRead(fileDir + filename); //systemIoWrapper.FileOpenRead(filePath);
            if (compressedStream is null)
            {
                //Log.Error("Failed to open file, the file stream was null");
                //return new Error<string>("Could not open file.");
            }
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();
            //compressedStream.ReadByte();

            await using var zlibStream = new ZlibStream(compressedStream, CompressionMode.Decompress); //systemIoWrapper.GetZlibDecompressionStream(compressedStream);
            using var decompressedStream = new MemoryStream();

            var buffer = new byte[4096];
            int count;
            
            try
            {
                while ((count = zlibStream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    decompressedStream.Write(buffer, 0, count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in " + filename + "\n\n" + ex + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
            }
            //Log.Debug("Writing decompressed data to memory stream");


            decompressedStream.Position = 0;
            return 0;
        }
    }
}
