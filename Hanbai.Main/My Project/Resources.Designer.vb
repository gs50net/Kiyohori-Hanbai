﻿'------------------------------------------------------------------------------
' <auto-generated>
'     このコードはツールによって生成されました。
'     ランタイム バージョン:4.0.30319.42000
'
'     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
'     コードが再生成されるときに損失したりします。
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'このクラスは StronglyTypedResourceBuilder クラスが ResGen
    'または Visual Studio のようなツールを使用して自動生成されました。
    'メンバーを追加または削除するには、.ResX ファイルを編集して、/str オプションと共に
    'ResGen を実行し直すか、または VS プロジェクトをビルドし直します。
    '''<summary>
    '''  ローカライズされた文字列などを検索するための、厳密に型指定されたリソース クラスです。
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  このクラスで使用されているキャッシュされた ResourceManager インスタンスを返します。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Hanbai.Main.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  厳密に型指定されたこのリソース クラスを使用して、すべての検索リソースに対し、
        '''  現在のスレッドの CurrentUICulture プロパティをオーバーライドします。
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  ＭＳ Ｐゴシック に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property APP_FONT_NAME() As String
            Get
                Return ResourceManager.GetString("APP_FONT_NAME", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  請求書発行システム に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property CAP_APPLICATION() As String
            Get
                Return ResourceManager.GetString("CAP_APPLICATION", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  エラー に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property CAP_ERROR() As String
            Get
                Return ResourceManager.GetString("CAP_ERROR", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  確認 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property CAP_KAKUNIN() As String
            Get
                Return ResourceManager.GetString("CAP_KAKUNIN", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property close_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("close_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property close_32x32() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("close_32x32", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Completed_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Completed_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property CustomizeLarge() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("CustomizeLarge", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property db() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("db", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property document_preview() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("document_preview", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Employee_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Employee_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  環境設定の読み込みで異常が発生しました。「環境設定」を確認して下さい。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property ERR_INI_FILE() As String
            Get
                Return ResourceManager.GetString("ERR_INI_FILE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  データーベースのオープンに失敗しました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property ERR_OPEN_DATABASE() As String
            Get
                Return ResourceManager.GetString("ERR_OPEN_DATABASE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  印刷対象は１件も選択されていません。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property ERR_印刷対象_未選択() As String
            Get
                Return ResourceManager.GetString("ERR_印刷対象_未選択", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Find_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Find_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property heChangeTableDialog() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("heChangeTableDialog", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property info_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("info_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property keys_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("keys_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Mail16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Mail16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  保存しますか？ に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_COMMIT() As String
            Get
                Return ResourceManager.GetString("MSG_COMMIT", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  保存は失敗しました に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_COMMIT_FAIL() As String
            Get
                Return ResourceManager.GetString("MSG_COMMIT_FAIL", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  保存は成功しました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_COMMIT_OK() As String
            Get
                Return ResourceManager.GetString("MSG_COMMIT_OK", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  環境設定値を初期値で生成しました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_CREATE_FILE() As String
            Get
                Return ResourceManager.GetString("MSG_CREATE_FILE", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  入力したデータを破棄します。よろしいですか？ に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_ROLLBACK() As String
            Get
                Return ResourceManager.GetString("MSG_ROLLBACK", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  取消しました に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_ROLLBACK_SUCCESS() As String
            Get
                Return ResourceManager.GetString("MSG_ROLLBACK_SUCCESS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  フォルダを指定してください。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_フォルダー指定() As String
            Get
                Return ResourceManager.GetString("MSG_フォルダー指定", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  レイアウトをリセットしますか？ に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_レイアウトリセット() As String
            Get
                Return ResourceManager.GetString("MSG_レイアウトリセット", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  このレコードを削除してもよろしいですか？ に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_削除OK() As String
            Get
                Return ResourceManager.GetString("MSG_削除OK", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  登録は成功しました。 に類似しているローカライズされた文字列を検索します。
        '''</summary>
        Friend ReadOnly Property MSG_登録_SUCCESS() As String
            Get
                Return ResourceManager.GetString("MSG_登録_SUCCESS", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property open_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("open_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property PenColor_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PenColor_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property print_32x32() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("print_32x32", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property PrintDirect() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("PrintDirect", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Save_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Save_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Undo_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Undo_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  型 System.Drawing.Bitmap のローカライズされたリソースを検索します。
        '''</summary>
        Friend ReadOnly Property Validate_16x16() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Validate_16x16", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
