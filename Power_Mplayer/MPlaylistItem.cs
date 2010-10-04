using System;
using System.Collections.Generic;
using System.Text;
using System.IO;    

namespace Power_Mplayer
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
            else if (type == MediaType.VCD)
            {
                //
                // sourcePath format Volume (D:\) track (1) : D:\1 
                ///////////////

                DriveVolume = sourcePath.Substring(0, 3);

                try
                {
                    Track = int.Parse(sourcePath.Substring(3));
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
