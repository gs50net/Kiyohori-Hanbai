#Region "参照"

Imports System
Imports System.Windows.Forms
Imports System.io

#End Region

Namespace Classes

    ''' <summary>
    ''' ini ファイルを使用してフォームの値を管理するためのクラス。
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CClsFormSetting

#Region "定数"

        'セクション名
        Private Const SEC As String = "Form"

#End Region

        '-------------------------
        ' public メンバ
        '-------------------------

#Region "コンストラクタ"

        ''' <summary>
        ''' クラスの新しいインスタンスを初期化します。
        ''' </summary>
        ''' <param name="fileName">ini ファイル名。</param>
        Public Sub New(ByVal fileName As String)
            _ini = New CClsIni(fileName)
        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' フォーム位置を復元します。
        ''' </summary>
        ''' <param name="target">対象フォーム。</param>
        Public Overloads Sub RestoreLocation(ByVal target As Windows.Forms.Form)
            Dim left As String = _ini.GetValue(SEC, "Left", target.Left.ToString())
            Dim top As String = _ini.GetValue(SEC, "Top", target.Top.ToString())
            '-------------------------
            Try
                target.Left = Integer.Parse(left)
                target.Top = Integer.Parse(top)
            Catch
            End Try
        End Sub

        ''' <summary>
        ''' フォーム位置を保存します。
        ''' </summary>
        ''' <param name="target">対象フォーム。</param>
        ''' <remarks>対象フォームが、最大化または最小化されたウィンドウである場合は保存されません。</remarks>
        Public Sub SaveLocation(ByVal target As Windows.Forms.Form)
            If target.WindowState = FormWindowState.Normal Then
                _ini.WriteValue(SEC, "Left", target.Left.ToString())
                _ini.WriteValue(SEC, "Top", target.Top.ToString())
            End If
        End Sub

        ''' <summary>
        ''' フォームサイズを復元します。
        ''' </summary>
        ''' <param name="target">対象フォーム。</param>
        Public Sub RestoreSize(ByVal target As Windows.Forms.Form)
            Dim width As String = _ini.GetValue(SEC, "Width", target.Width.ToString())
            Dim height As String = _ini.GetValue(SEC, "Height", target.Height.ToString())
            '-------------------------
            Try
                target.Width = Integer.Parse(width)
                target.Height = Integer.Parse(height)
            Catch
            End Try
        End Sub

        ''' <summary>
        ''' フォームサイズを保存します。
        ''' </summary>
        ''' <param name="target">対象フォーム。</param>
        ''' <remarks>対象フォームが、最大化または最小化されたウィンドウである場合は保存されません。</remarks>
        Public Sub SaveSize(ByVal target As Windows.Forms.Form)
            If target.WindowState = FormWindowState.Normal Then
                _ini.WriteValue(SEC, "Width", target.Width.ToString())
                _ini.WriteValue(SEC, "Height", target.Height.ToString())
            End If
        End Sub

#End Region

        '-------------------------
        ' private メンバ
        '-------------------------

#Region "フィールド"

        Private _ini As CClsIni = New CClsIni(CClsSetting.GetInstance.pstrIniFileName)

#End Region

    End Class

End Namespace
