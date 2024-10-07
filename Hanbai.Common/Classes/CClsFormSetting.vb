#Region "�Q��"

Imports System
Imports System.Windows.Forms
Imports System.io

#End Region

Namespace Classes

    ''' <summary>
    ''' ini �t�@�C�����g�p���ăt�H�[���̒l���Ǘ����邽�߂̃N���X�B
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CClsFormSetting

#Region "�萔"

        '�Z�N�V������
        Private Const SEC As String = "Form"

#End Region

        '-------------------------
        ' public �����o
        '-------------------------

#Region "�R���X�g���N�^"

        ''' <summary>
        ''' �N���X�̐V�����C���X�^���X�����������܂��B
        ''' </summary>
        ''' <param name="fileName">ini �t�@�C�����B</param>
        Public Sub New(ByVal fileName As String)
            _ini = New CClsIni(fileName)
        End Sub

#End Region

#Region "���\�b�h"

        ''' <summary>
        ''' �t�H�[���ʒu�𕜌����܂��B
        ''' </summary>
        ''' <param name="target">�Ώۃt�H�[���B</param>
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
        ''' �t�H�[���ʒu��ۑ����܂��B
        ''' </summary>
        ''' <param name="target">�Ώۃt�H�[���B</param>
        ''' <remarks>�Ώۃt�H�[�����A�ő剻�܂��͍ŏ������ꂽ�E�B���h�E�ł���ꍇ�͕ۑ�����܂���B</remarks>
        Public Sub SaveLocation(ByVal target As Windows.Forms.Form)
            If target.WindowState = FormWindowState.Normal Then
                _ini.WriteValue(SEC, "Left", target.Left.ToString())
                _ini.WriteValue(SEC, "Top", target.Top.ToString())
            End If
        End Sub

        ''' <summary>
        ''' �t�H�[���T�C�Y�𕜌����܂��B
        ''' </summary>
        ''' <param name="target">�Ώۃt�H�[���B</param>
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
        ''' �t�H�[���T�C�Y��ۑ����܂��B
        ''' </summary>
        ''' <param name="target">�Ώۃt�H�[���B</param>
        ''' <remarks>�Ώۃt�H�[�����A�ő剻�܂��͍ŏ������ꂽ�E�B���h�E�ł���ꍇ�͕ۑ�����܂���B</remarks>
        Public Sub SaveSize(ByVal target As Windows.Forms.Form)
            If target.WindowState = FormWindowState.Normal Then
                _ini.WriteValue(SEC, "Width", target.Width.ToString())
                _ini.WriteValue(SEC, "Height", target.Height.ToString())
            End If
        End Sub

#End Region

        '-------------------------
        ' private �����o
        '-------------------------

#Region "�t�B�[���h"

        Private _ini As CClsIni = New CClsIni(CClsSetting.GetInstance.pstrIniFileName)

#End Region

    End Class

End Namespace
