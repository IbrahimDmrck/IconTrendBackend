using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Filehelper
{
    public static class RecognizedFileTypes
    {
        public static readonly Dictionary<string, string> Archives = new()
        {
            { "bz2", "application/x-bzip2" },
            { "gz", "application/x-gz" },
            { "rar", "application/x-compressed" },
            { "7z", "application/x-compressed" },
            { "tar", "application/x-tar" },
            { "zip", "application/x-compressed" }
        };

        public static readonly Dictionary<string, string> Audios = new()
        {
            { "flac", "audio/x-flac" },
            { "m4a", "audio/mp4" },
            { "midi", "audio/midi" },
            { "mid", "audio/midi" },
            { "mp3", "audio/mpeg3" },
            { "ogg", "application/ogg" },
            { "wav", "audio/wav" }
        };

        public static readonly Dictionary<string, string> Documents = new()
        {
            { "doc", "application/msword" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "dwg", "application/acad" },
            { "pdf", "application/pdf" },
            { "ppt", "application/mspowerpoint" },
            { "pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
            { "rtf", "application/rtf" },
            { "xls", "application/excel" },
            { "xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" }
        };

        public static readonly Dictionary<string, string> Executables = new()
        {
            { "dll", "application/octet-stream" },
            { "exe", "application/octet-stream" }
        };

        public static readonly Dictionary<string, string> Images = new()
        {
            //{ "bmp", "image/bmp" },
            //{ "gif", "image/gif" },
            //{ "ico", "image/x-icon" },
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/png" },
            //{ "psd", "application/octet-stream" },
            //{ "tiff", "image/tiff" }
        };

        public static readonly Dictionary<string, string> Texts = new()
        {
            { "txt", "text/plain" }
        };

        public static readonly Dictionary<string, string> Videos = new()
        {
            { "flv", "application/unknown" },
            { "mov", "video/quicktime" },
            { "mp4", "video/mp4" },
            { "3gp", "video/3gp" }
        };

        public static readonly Dictionary<string, string> Xmls = new()
        {
            { "xml", "application/xml" }
        };

    }
}
