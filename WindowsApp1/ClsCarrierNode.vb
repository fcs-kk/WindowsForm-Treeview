Public Class ClsCarrierNode
    Public Property Name As String = ""

    Public Property Key As String = Guid.NewGuid.ToString

    Public Property Checked As String = False

    Public Property Nodes As List(Of ClsCarrierNode) = New List(Of ClsCarrierNode)

    Public Sub New()
        '無処理
    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="name"></param>
    Public Sub New(name As String)
        Me.Name = name
    End Sub

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="name"></param>
    ''' <param name="key"></param>
    Public Sub New(name As String, key As String)
        Me.Name = name
        Me.Key = key
    End Sub

    ''' <summary>
    ''' 全ての子ノードを返す
    ''' </summary>
    ''' <returns></returns>
    Public Function ChildNodes() As List(Of ClsCarrierNode)
        Dim retVal = New List(Of ClsCarrierNode)

        For Each node In Me.Nodes
            retVal.Add(node)
            For Each child In node.ChildNodes()
                retVal.Add(child)
            Next
        Next

        Return retVal
    End Function


End Class
