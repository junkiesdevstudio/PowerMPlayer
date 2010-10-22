using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace MplayerWrapper
{
    public class MPlaylistItem : System.Windows.Forms.ListViewItem
    {
        public MediaType ItemType { get; private set; }
        public TimeSpan Time { get; set; }
        public string SourcePath { get; private set; }
        public int Track { get; set; }
        public string DriveVolume { get; set; }

        public MPlaylistItem(MediaType type, string sourcePath) : base()
        {
            ItemType = type;
            SourcePath = sourcePath;

            if (type == MediaType.File)
            {
                this.Text = System.IO.Path.GetFileName(SourcePath);
            }
            else if (type == MediaType.VCD || type == MediaType.DVD)
            {
                //
                // sourcePath format Volume (D:\) track (1) : "1 D:\" 
                ///////////////

                int spaceIndex = sourcePath.IndexOf(' ');

                DriveVolume = sourcePath.Substring(spaceIndex + 1);

                try
                {
                    Track = int.Parse(sourcePath.Substring(0, spaceIndex));
                }
                catch
                {
                    Track = 0;
                }

                this.Text = sourcePath;
            }
        }

        public string GetMplayerCommand()
        {
            switch (ItemType)
            {
                case MediaType.VCD:
                    return string.Format("vcd://{0}/{1}", Track, DriveVolume);
                case MediaType.DVD:
                    return string.Format("dvd://{0}/{1}", Track, DriveVolume);
                case MediaType.File:
                default:
                    return SourcePath;
            }
        }

        public override object Clone()
        {
            return new MPlaylistItem(ItemType, this.SourcePath);
        }
    }
}
