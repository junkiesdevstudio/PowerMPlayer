using System;
using System.Collections.Generic;
using System.Text;
using System.IO;    

namespace Power_Mplayer
{
    class MPlaylistItem : System.Windows.Forms.ListViewItem
    {
        public string SourceString;

        public MPlaylistItem(string str) : base()
        {
            if (str.IndexOf("//") <= 0)
            {
                this.SourceString = "file://" + str;
            }
            else
            {
                this.SourceString = str;
            }

            if (SourceString.StartsWith("file://"))
            {
                str = System.IO.Path.GetFileName(str);
            }

            this.Text = str;
        }

        public override object Clone()
        {
            return new MPlaylistItem(this.SourceString);
        }
    }
}
