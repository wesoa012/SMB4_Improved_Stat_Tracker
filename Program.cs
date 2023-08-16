// See https://aka.ms/new-console-template for more information
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.IO.Compression;
using SMB4_Improved_Stat_Tracker.DataReading;
using SMB4_Improved_Stat_Tracker;

////ZLibStream compressedFile = new ZLibStream(new MemoryStream());
//using (var input = File.OpenRead(@"C:\Users\wesoa\AppData\Local\Metalhead\Super Mega Baseball 4\76561198197840490\season-546EE2F0-2878-41D1-8BA1-C8FAA34FDE80.sav"))
//using (var output = File.Create(@"DataCopyLocation/uncompressed-season.sav"))
//{
//    // if there are additional headers before the zlib header, you can skip them:
//    // input.Seek(xxx, SeekOrigin.Current);

//   // if (input.ReadByte() != 0x78)//|| input.ReadByte() != 0x9C)//zlib header
//     //   throw new Exception("Incorrect zlib header");
//     while(true)
//    {
//        for (int i = 0; i < input.Length; i++)
//        {
//            try
//            {
//                using (var input1 = File.OpenRead(@"C:\Users\wesoa\AppData\Local\Metalhead\Super Mega Baseball 4\76561198197840490\season-546EE2F0-2878-41D1-8BA1-C8FAA34FDE80.sav"))

//                    for (int j = 0; j < i; j++)
//                    {
//                        input1.ReadByte();
//                    }
//                using (var deflateStream = new DeflateStream(input, CompressionMode.Decompress, true))
//                {
//                    deflateStream.CopyTo(output);
//                }
//                break;
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.ToString());
//            }

//        }
//        break;
//    }


//}

//This actually works for reading the leagues in
//List<string> leagues = new List<string>();

//leagues.Add("league-0A757E58-25AA-44FF-8D13-A4754B94C247");
//leagues.Add("league-1EE40D82-453A-4740-82E5-0827731C22E0");
//leagues.Add("league-5AD3D4C3-1F41-462F-87A8-123EE583118D");
//leagues.Add("league-6DA019BD-CF70-49B8-934D-6B7F5A655E3D");
//leagues.Add("league-7CBC32B9-BD7F-48D7-AE01-44C6595CD5A6");
//leagues.Add("league-9FCE29ED-0472-4CB0-870D-02020A021DCC");
//leagues.Add("league-61C55AD4-C86B-412B-B8B1-04A6B57465AB");
//leagues.Add("league-99F30082-775B-4547-ADD8-8C7D2C94FCE5");
//leagues.Add("league-234F7051-2A1C-4683-913E-93B80CC6A907");
//leagues.Add("league-2155F3C0-0AC7-48B4-9E36-2610201BC142");
//leagues.Add("league-CB74B36F-A40D-4D3F-A452-234F61A434C3");

//SMB4_Improved_Stat_Tracker.DataReading.MasterAndLeagueFileReader masterandleaguedatareader = new SMB4_Improved_Stat_Tracker.DataReading.MasterAndLeagueFileReader();
//masterandleaguedatareader.DecompressMasterAndLeagueSavFiles(@"C:\Users\wesoa\AppData\Local\Metalhead\Super Mega Baseball 4\76561198197840490\", "master.sav");
//foreach(string league in leagues)
//{
//masterandleaguedatareader.DecompressMasterAndLeagueSavFiles(@"C:\Users\wesoa\AppData\Local\Metalhead\Super Mega Baseball 4\76561198197840490\", league + ".sav");
//}

//Definitely broken right now since idk how to read the seasondata
//SMB4_Improved_Stat_Tracker.DataReading.SeasonFileReader seasondatareader = new SMB4_Improved_Stat_Tracker.DataReading.SeasonFileReader();
//seasondatareader.DecompressSeasonSavFiles(@"C:\Users\wesoa\AppData\Local\Metalhead\Super Mega Baseball 4\76561198197840490\", "season-546EE2F0-2878-41D1-8BA1-C8FAA34FDE80.sav");


Text2CSV text2CSV = new Text2CSV();
string[] convertEs = Directory.GetFiles(@".\DataCopyLocation\Entire Game\Text2CSV");

foreach (string s in convertEs)
{
    text2CSV.ReadTXTProduceCSV(s);
}


Console.WriteLine("");


//// »"Å2
//long fileChangeNum = 1;
//while(true)
//{
//    var watch = System.Diagnostics.Stopwatch.StartNew();


//    //File 1
//    byte[] hash;
//    StringBuilder formatted;
//    string franchiseFile = "league-5AD3D4C3-1F41-462F-87A8-123EE583118D.sav";
//    string dir1 = @"C:\Users\wesoa\AppData\Local\Metalhead\Super Mega Baseball 4\76561198197840490\";
//    string dir2 = @".\DataCopyLocation\";
//    using (FileStream fs = new FileStream(dir1 + franchiseFile, FileMode.Open, FileAccess.Read))
//    using (BufferedStream bs = new BufferedStream(fs))
//    {
//        using (SHA1Managed sha1 = new SHA1Managed())
//        {
//            hash = sha1.ComputeHash(bs);
//            formatted = new StringBuilder(2 * hash.Length);
//            foreach (byte b in hash)
//            {
//                formatted.AppendFormat("{0:X2}", b);
//            }
//        }
//    }

//    //copy file location
//    byte[] hash2;
//    StringBuilder formatted2;

//    using (FileStream fs2 = new FileStream(dir2 + (fileChangeNum-1) + "-" + franchiseFile, FileMode.OpenOrCreate, FileAccess.Read))
//    using (BufferedStream bs2 = new BufferedStream(fs2))
//    {
//        using (SHA1Managed sha1 = new SHA1Managed())
//        {
//            hash2 = sha1.ComputeHash(bs2);
//            formatted2 = new StringBuilder(2 * hash2.Length);
//            foreach (byte b in hash2)
//            {
//                formatted2.AppendFormat("{0:X2}", b);
//            }
//        }
//    }

//    watch.Stop();
//    if (!formatted.Equals(formatted2))
//    {
//        var elapsedMs = watch.ElapsedMilliseconds;
//        Console.WriteLine("Time elapsed = " + elapsedMs.ToString());
//        Console.WriteLine("\n== File1 hashes == ");
//        Console.WriteLine("File1 = " + formatted.ToString());
//        Console.WriteLine("File2 = " + formatted2.ToString());
//        Console.WriteLine("\n\nChange detected, copying file - change num = " + fileChangeNum);
//        File.Delete(dir2 + fileChangeNum + "-" + franchiseFile);
//        File.Copy(dir1 + franchiseFile, dir2 + fileChangeNum + "-" + franchiseFile);
//        fileChangeNum++;
//    }

//}
