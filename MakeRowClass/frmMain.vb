Imports DataBase
Imports System.IO

Public Class frmMain

    Private Const STR_CNN_MyDB As String = "Data Source=SQLSERVER2008;Initial Catalog=KHDB;Integrated Security=False;uid=sa;pwd=KIYOHORI"

    Private mstrGateWay As String
    Dim mclm As DataColumnCollection

    Private Class MyTable : Inherits DataGateway

        Private mstrTableName As String

        Public Sub New(ByVal strCnn As String, ByVal strTableName As String)
            MyBase.New(strCnn, enmProvider.SQLServer)
            mstrTableName = strTableName
            mstrTrueTableName = strTableName
            TableName = strTableName
        End Sub

        Public Overrides Function GetTableName() As String
            Return mstrTableName
        End Function

    End Class

    Private Sub btnCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCreate.Click

        Dim strCnn As String = STR_CNN_MyDB
        mstrGateWay = "DataGateway"

        Try
            Dim tbl As New MyTable(strCnn, txtTblName.Text)
            tbl.Fill()
            mclm = tbl.Table.Columns
            mprcMake()
            MessageBox.Show("生成終了")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub mprcMake()

        Using sw As New StreamWriter(txtFileName.Text)

            sw.WriteLine("Imports ESystem.Common.Functions" & ControlChars.CrLf)

            sw.WriteLine("Namespace DataBase" & ControlChars.CrLf)
            sw.Write("''' <summary>" & ControlChars.CrLf)
            sw.Write(String.Format("''' {0} Table クラス{1}", txtTblName.Text, ControlChars.CrLf))
            sw.Write("''' </summary>" & ControlChars.CrLf & "''' <remarks></remarks>" & ControlChars.CrLf)
            sw.WriteLine(String.Format("Public Class {0} : Inherits {1}{2}", txtClsTbl.Text, mstrGateWay, ControlChars.CrLf))

            mprcTableConst(sw)
            mprcTableNew(sw)
            mprcTableOverRide(sw)
            mprcTableMethod(sw)

            sw.WriteLine("End Class" & ControlChars.CrLf)
            'sw.WriteLine("End Namespace")
            'sw.WriteLine(ControlChars.CrLf)

            'sw.WriteLine("'===================================================================================" & ControlChars.CrLf)

            'sw.WriteLine("Imports Smart.PDA.Common.Functions")
            'sw.WriteLine("Imports System.Data.SqlServerCe")
            'sw.WriteLine("Imports System.Data" & ControlChars.CrLf)

            'sw.WriteLine("Namespace Dream.Common.DataBase" & ControlChars.CrLf)
            sw.Write("''' <summary>" & ControlChars.CrLf)
            sw.Write(String.Format("''' {0} Row クラス{1}", txtTblName.Text, ControlChars.CrLf))
            sw.Write("''' </summary>" & ControlChars.CrLf & "''' <remarks></remarks>" & ControlChars.CrLf)
            sw.WriteLine(String.Format("Public Class {0} : Inherits CDataRowBase{1}", txtClsRow.Text, ControlChars.CrLf))

            mprcRowColumn(sw)
            mprcRowNew(sw)

            sw.Write("End Class" & ControlChars.CrLf)
            sw.WriteLine("End Namespace")

        End Using

    End Sub

#Region "Table"

    Private Sub mprcTableConst(ByVal sw As StreamWriter)

        sw.WriteLine("#Region ""定数""" & ControlChars.CrLf)

        Dim strText As String
        strText = "''' <summary>テーブル名</summary>" & ControlChars.CrLf
        strText &= String.Format("Public Const TABLE_NAME As String = ""{0}""", txtTblName.Text, ControlChars.CrLf)
        sw.WriteLine(strText)
        'strText = "''' <summary>プライマリーキー</summary>" & ControlChars.CrLf
        'strText &= "Public PRIMARY_KEY() As String = {""？""}" & ControlChars.CrLf
        'sw.WriteLine(strText)

        sw.Write(ControlChars.CrLf)
        sw.WriteLine("#End Region")
        'sw.Write(ControlChars.CrLf)

    End Sub

    Private Sub mprcTableNew(ByVal sw As StreamWriter)

        Dim strText As String

        'sw.WriteLine(ControlChars.CrLf)
        sw.WriteLine("#Region ""コンストラクタ""" & ControlChars.CrLf)
        strText = "''' <summary>コンストラクタ</summary>" & ControlChars.CrLf
        strText &= "Public Sub New()" & ControlChars.CrLf
        strText &= "MyBase.New()" & ControlChars.CrLf
        strText &= "End Sub" & ControlChars.CrLf
        sw.WriteLine(strText)

        strText = "''' <summary>コンストラクタ</summary>" & ControlChars.CrLf
        strText &= "''' <remarks>更新する場合はこのコンストラクタを使用する</remarks>" & ControlChars.CrLf
        strText &= String.Format("Public Sub New(ByVal dstGateway As {0}, Optional ByVal strTableName As String = """")", mstrGateWay) & ControlChars.CrLf
        strText &= "MyBase.New(dstGateway, strTableName)" & ControlChars.CrLf
        strText &= "End Sub" & ControlChars.CrLf
        sw.WriteLine(strText)

        sw.WriteLine("#End Region")
        sw.Write(ControlChars.CrLf)

    End Sub

    Private Sub mprcTableOverRide(ByVal sw As StreamWriter)

        sw.WriteLine("#Region ""オーバーライド　メソッド""" & ControlChars.CrLf)

        Dim strText As String
        strText = "''' <summary>テーブル名を取得する</summary>" & ControlChars.CrLf
        strText &= " Public Overrides Function GetTableName() As String" & ControlChars.CrLf
        strText &= "Return TABLE_NAME" & ControlChars.CrLf
        strText &= "End Function" & ControlChars.CrLf
        sw.WriteLine(strText)

        sw.WriteLine("#End Region")
        sw.Write(ControlChars.CrLf)

    End Sub

    Private Sub mprcTableMethod(ByVal sw As StreamWriter)

        sw.WriteLine("#Region ""メソッド""" & ControlChars.CrLf)

        sw.WriteLine("#End Region")
        sw.Write(ControlChars.CrLf)

    End Sub

#End Region

#Region "Row"

    Private Sub mprcRowColumn(ByVal sw As StreamWriter)

        sw.WriteLine("#Region ""カラム""" & ControlChars.CrLf)

        Dim strText As String

        '定数
        For Each clm As DataColumn In mclm
            strText = String.Format("Public Const CON_{0} As String = ""{0}""", clm.ColumnName)
            sw.WriteLine(strText)
        Next

        sw.Write(ControlChars.CrLf)

        For Each clm As DataColumn In mclm
            Debug.WriteLine(clm.DataType.Name)
            Select Case clm.DataType.Name
                Case "Guid"
                    mprcGuid(sw, clm)
                Case "Int32"
                    mprcInt32(sw, clm)
                Case "String"
                    mprcString(sw, clm)
                Case "DateTime"
                    mprcDateTime(sw, clm)
                Case "Decimal"
                    mprcDecimal(sw, clm)
                Case "Boolean"
                    mprcBoolean(sw, clm)
                Case "Double"
                    mprcDouble(sw, clm)
            End Select
        Next

        sw.Write(ControlChars.CrLf)
        sw.WriteLine("#End Region")

    End Sub

    Private Sub mprcGuid(ByVal sw As StreamWriter, ByVal clm As DataColumn)

        Dim strText As String

        strText = String.Format("Public Property clm{0}() As Guid{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "Get" & ControlChars.CrLf
        strText &= String.Format("Return Directcast(Me(CON_{0}), Guid){1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Get" & ControlChars.CrLf
        strText &= "Set(ByVal value As Guid)" & ControlChars.CrLf
        strText &= String.Format("Me(CON_{0}) = value{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Set" & ControlChars.CrLf
        strText &= "End Property" & ControlChars.CrLf
        sw.WriteLine(strText)

    End Sub

    Private Sub mprcInt32(ByVal sw As StreamWriter, ByVal clm As DataColumn)

        Dim strText As String

        strText = String.Format("Public Property clm{0}() As Integer{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "Get" & ControlChars.CrLf
        strText &= String.Format("Return CFncCommon.ObjToInt(Me(CON_{0})){1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Get" & ControlChars.CrLf
        strText &= "Set(ByVal value As Integer)" & ControlChars.CrLf
        strText &= String.Format("Me(CON_{0}) = value{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Set" & ControlChars.CrLf
        strText &= "End Property" & ControlChars.CrLf
        sw.WriteLine(strText)

    End Sub

    Private Sub mprcString(ByVal sw As StreamWriter, ByVal clm As DataColumn)

        Dim strText As String

        strText = String.Format("Public Property clm{0}() As String{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "Get" & ControlChars.CrLf
        strText &= String.Format("Return CFncCommon.ObjToStr(Me(CON_{0})){1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Get" & ControlChars.CrLf
        strText &= "Set(ByVal value As String)" & ControlChars.CrLf
        strText &= String.Format("Me(CON_{0}) = value{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Set" & ControlChars.CrLf
        strText &= "End Property" & ControlChars.CrLf
        sw.WriteLine(strText)

    End Sub

    Private Sub mprcDateTime(ByVal sw As StreamWriter, ByVal clm As DataColumn)

        Dim strText As String

        strText = String.Format("Public Property clm{0}() As Object{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "Get" & ControlChars.CrLf
        strText &= String.Format("Return Me(CON_{0}){1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Get" & ControlChars.CrLf
        strText &= "Set(ByVal value As Object)" & ControlChars.CrLf
        strText &= String.Format("Me(CON_{0}) = value{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Set" & ControlChars.CrLf
        strText &= "End Property" & ControlChars.CrLf
        sw.WriteLine(strText)

    End Sub

    Private Sub mprcDecimal(ByVal sw As StreamWriter, ByVal clm As DataColumn)

        Dim strText As String

        strText = String.Format("Public Property clm{0}() As Decimal{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "Get" & ControlChars.CrLf
        strText &= String.Format("Return CFncCommon.ObjToDec(Me(CON_{0})){1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Get" & ControlChars.CrLf
        strText &= "Set(ByVal value As Decimal)" & ControlChars.CrLf
        strText &= String.Format("Me(CON_{0}) = value{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Set" & ControlChars.CrLf
        strText &= "End Property" & ControlChars.CrLf
        sw.WriteLine(strText)

    End Sub

    Private Sub mprcDouble(ByVal sw As StreamWriter, ByVal clm As DataColumn)

        Dim strText As String

        strText = String.Format("Public Property clm{0}() As Double{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "Get" & ControlChars.CrLf
        strText &= String.Format("Return CFncCommon.ObjToDbl(Me(CON_{0})){1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Get" & ControlChars.CrLf
        strText &= "Set(ByVal value As Double)" & ControlChars.CrLf
        strText &= String.Format("Me(CON_{0}) = value{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Set" & ControlChars.CrLf
        strText &= "End Property" & ControlChars.CrLf
        sw.WriteLine(strText)

    End Sub

    Private Sub mprcBoolean(ByVal sw As StreamWriter, ByVal clm As DataColumn)

        Dim strText As String

        strText = String.Format("Public Property clm{0}() As Boolean{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "Get" & ControlChars.CrLf
        strText &= String.Format("Return CFncCommon.ObjToBool(Me(CON_{0})){1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Get" & ControlChars.CrLf
        strText &= "Set(ByVal value As Boolean)" & ControlChars.CrLf
        strText &= String.Format("Me(CON_{0}) = value{1}", clm.ColumnName, ControlChars.CrLf)
        strText &= "End Set" & ControlChars.CrLf
        strText &= "End Property" & ControlChars.CrLf
        sw.WriteLine(strText)

    End Sub

    Private Sub mprcRowNew(ByVal sw As StreamWriter)

        Dim strText As String

        sw.WriteLine(ControlChars.CrLf)
        sw.WriteLine("#Region ""コンストラクタ""" & ControlChars.CrLf)
        strText = "''' <summary>コンストラクタ</summary>" & ControlChars.CrLf
        strText &= "Public Sub New()" & ControlChars.CrLf
        strText &= "End Sub" & ControlChars.CrLf
        sw.WriteLine(strText)

        strText = "''' <summary>コンストラクタ</summary>" & ControlChars.CrLf
        strText &= "Public Sub New(ByVal row As DataRow)" & ControlChars.CrLf
        strText &= "Me.DataRow = row" & ControlChars.CrLf
        strText &= "End Sub" & ControlChars.CrLf
        sw.WriteLine(strText)

        strText = "''' <summary>コンストラクタ</summary>" & ControlChars.CrLf
        strText &= "Public Sub New(ByVal row As DataRowView)" & ControlChars.CrLf
        strText &= "Me.DataRowView = row" & ControlChars.CrLf
        strText &= "End Sub" & ControlChars.CrLf
        sw.WriteLine(strText)
        sw.WriteLine("#End Region")
        sw.WriteLine(ControlChars.CrLf)

    End Sub

#End Region

End Class
