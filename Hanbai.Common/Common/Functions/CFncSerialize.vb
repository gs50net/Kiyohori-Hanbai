Namespace Functions

    ''' <summary>
    ''' シリアライズ関係のクラス
    ''' </summary>
    ''' <remarks>このクラスはインスタンス化できません。</remarks>
    Public Class CFncSerialize

#Region "コンストラクタ"

        ''' <summary>
        ''' コンストラクタ
        ''' </summary>
        ''' <remarks>このコンストラクタはこのクラスをインスタンス化をできないようにします。</remarks>
        Private Sub New()
        End Sub

#End Region

#Region "メソッド"

        ''' <summary>
        ''' クラスをシリアライズ化する
        ''' </summary>
        ''' <param name="strFileName">ファイル名</param>
        ''' <param name="typClass">クラスのタイプ</param>
        ''' <param name="objClass">シリアライズするクラス</param>
        ''' <remarks></remarks>
        ''' <example>
        ''' SerializeClassToXML(strFileName, GetType(ClsCareCard), clsCard)
        ''' </example>
        Public Shared Sub SerializeClassToXML(ByVal strFileName As String, ByVal typClass As Type, ByVal objClass As Object)

            Try
                'XmlSerializerオブジェクトを作成
                '書き込むオブジェクトの型を指定する
                Dim serializer As New System.Xml.Serialization.XmlSerializer(typClass)
                'ファイルを開く
                Dim fs As New System.IO.FileStream(strFileName, System.IO.FileMode.Create)
                'シリアル化し、XMLファイルに保存する
                serializer.Serialize(fs, objClass)
                '閉じる
                fs.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CFncSerialize.SerializeClassToXML")
            End Try

        End Sub

        ''' <summary>
        ''' XMLからクラスを逆シリアライズ化する
        ''' </summary>
        ''' <param name="strFileName">ファイル名</param>
        ''' <param name="typClass">クラスのタイプ</param>
        ''' <returns>クラスのオブジェクト</returns>
        ''' <remarks></remarks>
        Public Shared Function DeSerializeXMLToClass(ByVal strFileName As String, ByVal typClass As Type) As Object

            Dim obj As Object = Nothing

            Try
                'XmlSerializerオブジェクトの作成
                Dim serializer As New System.Xml.Serialization.XmlSerializer(typClass)
                'ファイルを開く
                Dim fs As New System.IO.FileStream(strFileName, System.IO.FileMode.Open)
                'XMLファイルから読み込み、逆シリアル化する
                obj = serializer.Deserialize(fs)
                '閉じる
                fs.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message, "CFncSerialize.DeSerializeXMLToClass")
            End Try

            Return obj

        End Function

#End Region

    End Class

End Namespace
