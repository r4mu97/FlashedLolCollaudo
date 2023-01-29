using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace FlahedLOLUpdater
{
	/// <summary>
	/// Logica di interazione per MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

      Task.Run(() => this.downloadAndInstall());
    }

    public async Task downloadAndInstall()
		{
      try
      {
        String url = "http://erp.kiwitron.it/FlashedLOL/flashedlol.zip";

        await this.GetFileAsync(url, "", new CancellationTokenSource().Token);
      } catch(Exception ex) {
				MessageBox.Show(ex.Message);
			}
    }

    public async Task GetFileAsync(string path, string filename, CancellationToken cancellationToken)
    {
      using (HttpClient client = new HttpClient()) {
        using (HttpResponseMessage response = await client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead)) {
          var total = response.Content.Headers.ContentLength.HasValue ?
             response.Content.Headers.ContentLength.Value : -1L;

          var canReportProgress = total != -1;

          using (var outStream = File.Create("update.zip"))
          {
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
              var totalRead = 0L;
              var buffer = new byte[4096];
              var moreToRead = true;

              do
              {
                cancellationToken.ThrowIfCancellationRequested();

                var read = await stream.ReadAsync(buffer, 0, buffer.Length, cancellationToken);

                if (read == 0)
                {
                  moreToRead = false;
                }
                else
                {
                  var data = new byte[read];
                  buffer.ToList().CopyTo(0, data, 0, read);

                  // TODO: write the actual file to disk
                  outStream.Write(buffer, 0, read);

                  // Update the percentage of file downloaded
                  totalRead += read;

                  if (canReportProgress)
                  {
                    var downloadPercentage = ((totalRead * 1d) / (total * 1d)) * 100;
                    var value = Convert.ToInt32(downloadPercentage);

                    //PercentageChanged.Raise(this, (value.ToString()));
                    this.Dispatcher.Invoke(() =>
                    {
                      progressBar.Value = downloadPercentage;
                    });
                  }
                }
              }
              while (moreToRead);

              outStream.Close();

              //ZipFile.ExtractToDirectory("update.zip", "C:\\Temp");
              //System.Diagnostics.Debug.WriteLine(System.AppDomain.CurrentDomain.BaseDirectory);

              /*
              using (ZipFile zip1 = ZipFile.OpenRead("update.zip"))
              {
                foreach (ZipEntry e in zip1)
                {
                  e.Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
              }
              */  

              using (ZipArchive archive = ZipFile.OpenRead("update.zip"))
              {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                  if (Directory.Exists(entry.FullName)) {
                    Directory.Delete(entry.FullName, true);

                  } else if (File.Exists(entry.FullName))
                    File.Delete(entry.FullName);
                }
              }

              ZipFile.ExtractToDirectory("update.zip", ".");

              using (System.Diagnostics.Process pProcess = new System.Diagnostics.Process())
              {
                pProcess.StartInfo.FileName = @"FlashedLOL.exe";
                pProcess.Start();
              }

              System.Environment.Exit(0);
            }
          }
        }
      }
    }
  }
}
