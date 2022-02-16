Public Class frmMain

    Private rootNode = New TreeNode()               '' ルートノード
    Private nodeList = New List(Of TreeNode)        '' ノードリスト 


    ''' <summary>
    ''' フォームロード
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '' 無処理
    End Sub

    ''' <summary>
    ''' キャリアノードの作成
    ''' </summary>
    ''' <returns>キャリアノード</returns>
    Private Function createCarrierData() As TreeNode
        Dim retVal = New TreeNode  '' 返り値

        Dim srcText = txtInput.Text

        '' 1行ずつ分解
        For Each txt As String In txtInput.Lines
            Dim currentNode = retVal

            '' カンマで分解
            Dim names = txt.Split(",")

            For Each name As String In names
                'カレントノードが同名の場合、スキップ
                If currentNode.Text.Equals(name) Then
                    Continue For
                End If

                'サブノードを探索
                Dim findNode As TreeNode = Nothing
                For Each subNode As TreeNode In currentNode.Nodes
                    If subNode.Text.Equals(name) Then
                        findNode = subNode
                        Exit For
                    End If
                Next

                ' 同名のサブノードがない場合、追加する
                If (findNode Is Nothing) Then
                    Dim newNode = New TreeNode(name)
                    newNode.Name = Guid.NewGuid.ToString    'ユニークキーを生成

                    ' ノードリストに追加する
                    nodeList.Add(newNode)

                    ' カレントノードにサブノードを追加する
                    currentNode.Nodes.Add(newNode)

                    ' サブノードをカレントノードとする
                    currentNode = newNode
                Else
                    ' 同名のサブノードが見つかったので、サブノードをカレントノードとする
                    currentNode = findNode
                End If
            Next
        Next

        '' キャリアノードを返す
        Return retVal
    End Function

    ''' <summary>
    ''' ツリービューを構築
    ''' </summary>
    ''' <param name="carrierNode">キャリアノードデータ</param>
    Private Sub buildTreeView(carrierNode As TreeNode)
        ' ツリーの初期化
        treeView.Nodes.Clear()

        If Not carrierNode Is Nothing Then
            'ノードの追加
            For Each currentNode As TreeNode In carrierNode.Nodes
                treeView.Nodes.Add(currentNode)
            Next
        End If

        ' ツリーの全てを展開
        treeView.ExpandAll()
    End Sub

    ''' <summary>
    ''' ノードチェックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub treeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeView.AfterCheck

        'ノードデータから該当データを検索
        Dim target = rootNode.Nodes.Find(e.Node.Name, True)
        If (target IsNot Nothing) Then
            '' ツリービューに合わせて、ノードデータを更新する
            Console.WriteLine(e.Node.Name + ":" + e.Node.Checked.ToString)
        End If
    End Sub

    ''' <summary>
    ''' 変換ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        'キャリアノード作成
        rootNode = createCarrierData()

        'ノードデータからツリービューを構築
        buildTreeView(rootNode)
    End Sub
End Class
