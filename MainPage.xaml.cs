﻿using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Storage;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x411 を参照してください

namespace SaveToLocalFolder
{
    /// <summary>
    /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void hoge_Click(object sender, RoutedEventArgs e)
        {
            SaveCurrentTimeToFile();
        }

        public async void SaveCurrentTimeToFile()
        {
            // 現在の時刻を取得
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // ダウンロードフォルダを取得
            StorageFolder DocumentsLibraryFolder = KnownFolders.DocumentsLibrary;

            // ファイルを作成または取得
            StorageFile file = await DocumentsLibraryFolder.CreateFileAsync("Now.txt", CreationCollisionOption.ReplaceExisting);

            // ファイルに書き込む
            await FileIO.WriteTextAsync(file, now);
        }
    }
}
