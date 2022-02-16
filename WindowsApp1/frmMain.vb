Public Class frmMain

    Private carrierRootNode As ClsCarrierNode = New ClsCarrierNode()   '' ルートキャリアノード


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
    ''' <param name="srcText">ソーステキスト</param>
    ''' <returns>キャリアノード</returns>
    Private Function createCarrierData(srcText As String) As ClsCarrierNode
        Dim retVal = New ClsCarrierNode '' 返り値

        '' 1行ずつ分解
        For Each txt As String In txtInput.Lines
            Dim currentNode = retVal

            '' カンマで分解
            Dim names = txt.Split(",")
            For Each name As String In names
                'カレントノードが同名の場合、スキップ
                If currentNode.Name.Equals(name) Then
                    Continue For
                End If

                'サブノードを探索
                Dim subNode = currentNode.Nodes.Find(Function(s) s.Name = name)
                If (subNode Is Nothing) Then
                    ' 同名のサブノードがない場合、追加する
                    Dim newNode = New ClsCarrierNode(name)
                    currentNode.Nodes.Add(newNode)

                    ' 新しいノードをカレントノードとする
                    currentNode = newNode
                Else
                    ' 同名のサブノードが見つかったので、サブノードをカレントノードとする
                    currentNode = subNode
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
    Private Sub buildTreeView(carrierNode As ClsCarrierNode)
        ' ツリーの初期化
        treeView.Nodes.Clear()

        If Not carrierNode Is Nothing Then
            '初期ノードの作成
            Dim treeNode = New TreeNode

            'キャリアノードからツリーノードへ変換
            convertNodeData(carrierNode, treeNode)

            'ノードの追加
            For Each currentNode As TreeNode In treeNode.Nodes
                treeView.Nodes.Add(currentNode)
            Next
        End If

        ' ツリーの全てを展開
        treeView.ExpandAll()
    End Sub

    ''' <summary>
    ''' キャリアノードからツリーノードへ変換
    ''' </summary>
    ''' <param name="srcCarrierNode">変換元キャリアノード</param>
    ''' <param name="destTreeNode">変換先ツリーノード</param>
    Private Sub convertNodeData(srcCarrierNode As ClsCarrierNode, destTreeNode As TreeNode)

        'キャリアノードをループ
        For Each currentNode As ClsCarrierNode In srcCarrierNode.Nodes

            '' ノードデータからツリーノードを作成
            Dim treeNode = destTreeNode.Nodes.Add(currentNode.Key, currentNode.Name)
            treeNode.Checked = currentNode.Checked

            '' 子ノードがある場合、再帰的に繰り返す
            If 0 < srcCarrierNode.Nodes.Count Then
                convertNodeData(currentNode, treeNode)
            End If
        Next
    End Sub

    ''' <summary>
    ''' ノードチェックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub treeView_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeView.AfterCheck

        'ノードデータから該当データを検索
        Dim target = carrierRootNode.ChildNodes.Find(Function(s) s.Key = e.Node.Name)
        If (target IsNot Nothing) Then
            '' ツリービューに合わせて、ノードデータを更新する
            target.Checked = e.Node.Checked
        End If
    End Sub

    ''' <summary>
    ''' 変換ボタン押下イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        'キャリアノード作成
        carrierRootNode = createCarrierData(txtInput.Text)

        'ノードデータからツリービューを構築
        buildTreeView(carrierRootNode)
    End Sub
End Class
