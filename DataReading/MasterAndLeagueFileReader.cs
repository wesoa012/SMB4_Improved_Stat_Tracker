using System;
using System.Collections.Generic;
using System.IO;
using System.IO;
using Ionic.Zlib;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace SMB4_Improved_Stat_Tracker.DataReading
{
    internal class MasterAndLeagueFileReader
    {
        public async Task<int> DecompressMasterAndLeagueSavFiles(string fileDir, string filename)
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
                Console.WriteLine("Error in " +  filename + "\n\n" + ex + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
            }
            decompressedStream.Position = 0;

            //Log.Debug("Writing decompressed data to memory stream");
            filename = filename.Substring(0, filename.IndexOf(".sav"));
            if(File.Exists(@".\DataCopyLocation\" + filename + ".sqlite"))
            {
                File.Delete(@".\DataCopyLocation\" + filename + ".sqlite");
            }
            var copyherestream = File.Create(@".\DataCopyLocation\" + filename + ".sqlite");
            await decompressedStream.CopyToAsync(copyherestream);
            return 0;
        }
    }
}
