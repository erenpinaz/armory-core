using System;
using System.IO;
using System.Net;

namespace Armory_CORE.Web.Blazor.Helpers
{
    public static class IOHelpers
    {
        /// <summary>
        /// Downloads and returns a stored copy of file.
        /// Returns remote file url if download is failed.
        /// </summary>
        /// <param name="remoteFileUrl"></param>
        /// <param name="fileDownloadPath"></param>
        /// <param name="returnRelativeUrl"></param>
        /// <returns>Stored copy of downloaded file</returns>
        public static string DownloadFile(string remoteFileUrl, string webRootPath, string fileDownloadPath, bool returnRelativeUrl = true)
        {
            if (string.IsNullOrEmpty(remoteFileUrl))
                return null;

            var downloadPath = Path.Combine(webRootPath, fileDownloadPath);
            if (!Directory.Exists(downloadPath))
            {
                Directory.CreateDirectory(downloadPath);
            }

            var fileName = Path.GetFileName(remoteFileUrl);
            var finalPath = Path.Combine(downloadPath, fileName);

            if (File.Exists(finalPath))
                return returnRelativeUrl ? $"{fileDownloadPath}{fileName}" : finalPath;

            try
            {
                using (var wc = new WebClient())
                {
                    wc.DownloadFile(remoteFileUrl, finalPath);
                }

                if (File.Exists(finalPath))
                    return returnRelativeUrl ? $"{fileDownloadPath}{fileName}" : finalPath;

                return remoteFileUrl;
            }
            catch
            {
                return remoteFileUrl;
            }
        }
    }
}
