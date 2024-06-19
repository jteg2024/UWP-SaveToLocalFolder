Universal Windows Platform (UWP) アプリで現在の時刻を `Now.txt` というファイル名でダウンロードフォルダに保存するには、以下の手順に従ってください。

1. **Capabilitiesの追加**:
   - UWPプロジェクトの`Package.appxmanifest`ファイルに必要なファイルアクセスの許可を追加します。具体的には、以下のように`broadFileSystemAccess`を追加します。

    ```xml
    <Package
      ...
      xmlns:rescap="http://schemas.microsoft.com/appx/manifest/foundation/windows10/restrictedcapabilities"
      IgnorableNamespaces="uap mp rescap">
      ...
      <Capabilities>
        <Capability Name="internetClient" />
        <rescap:Capability Name="broadFileSystemAccess" />
      </Capabilities>
    </Package>
    ```

2. **必要な名前空間のインポート**:
   - コードファイルで必要な名前空間をインポートします。

    ```csharp
    using System;
    using Windows.Storage;
    using Windows.Storage.Pickers;
    using Windows.Storage.AccessCache;
    ```

3. **時刻をテキストファイルに保存するコードの実装**:

    ```csharp
    public async void SaveCurrentTimeToFile()
    {
        // 現在の時刻を取得
        var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        // ダウンロードフォルダを取得
        StorageFolder downloadsFolder = KnownFolders.DownloadsLibrary;

        // ファイルを作成または取得
        StorageFile file = await downloadsFolder.CreateFileAsync("Now.txt", CreationCollisionOption.ReplaceExisting);

        // ファイルに書き込む
        await FileIO.WriteTextAsync(file, now);
    }
    ```

4. **UIから呼び出す**:
   - このメソッドをボタンのクリックイベントなどで呼び出すようにします。

    ```csharp
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SaveCurrentTimeToFile();
    }
    ```

これで、ボタンをクリックすると現在の時刻が`Now.txt`というファイルに保存され、ダウンロードフォルダに作成されるようになります。

---

アクセスが拒否される原因として、以下のポイントを確認してみてください。

broadFileSystemAccessの有効化:

Package.appxmanifestにbroadFileSystemAccessを追加するだけでは不十分で、実際にユーザーがこのアクセスを許可している必要があります。

<kbd>設定</kbd> > <kbd>プライバシーとセキュリティ</kbd> > <kbd>ファイルシステム</kbd> でアプリがファイルシステムにアクセスできるように設定します。
