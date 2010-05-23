使用說明 & 0.2 發佈
===================

安裝：
        基本上免安裝，但需要 .NET Framework 1.1 以上。
        如果你有安裝 Visual Studio .NET 2003/2005/2008 他們會自己幫你安裝。
        不然請到這個網址 http://tinyurl.com/2z9fzj 下載安裝:)

        0.2 下載處：
        http://downloads.sourceforge.net/powermplayer/PowerMplayer_0_2.zip

        解壓縮以後你會發現只有一個 exe 檔案。

        如果你平常就有在用 Mplayer ，請直接把他複製到 mplayer.exe 所在
        資料夾，點兩下就可以使用。

        如果你第一次用，請下載 0.1:
        http://downloads.sourceforge.net/powermplayer/PowerMplayer_0_1.7z
        裡面包含：
                * 官方編譯的 mplayer
                * http://oss.netfarm.it/mplayer-win32.php 編譯的 codec
                * CwTex 圓體 中文字型 (以後會改用 文泉驛正黑, 因為 GPL ..)

        解壓縮以後用 0.2 的檔案覆蓋過去。


更新:

        * 用繞路的方法讓 mplayer 支援 Unicode SRC/ASS 檔案。
          方法是用 C# 把該字幕先轉成 utf8 以後再讓 mplayer 吃。
          不過還是要選擇字幕語言，Power Mplayer 會根據該資訊轉換字幕檔。

          開啟這個功能，請在選項中將「自動轉換成 utf8」打勾(預設不會)。

        * 我看了以前的問題，有人需要調整 亮度/對比。
          在這版也把這些功能加進去了。

        * 拖放檔案來播放。因為播放清單還沒寫，所以目前只能拖一個檔案來播放。

        * 多了一些小設定。

TODOs:
        * 自訂快速鍵
        * 播放 DVD
        * 播放網址
        * 播放清單

如有任何問題請推文，或是到討論版
https://sourceforge.net/forum/forum.php?forum_id=862799

謝謝:)